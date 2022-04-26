using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LetsGoBiking_tc.RoutingWCF.Models;
using LetsGoBiking_tc.RoutingWCF.ProxyService;
using LetsGoBiking_tc.RoutingWCF.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.RoutingWCF.Services
{
    public class BikeRoutingService : IBikeRoutingService
    {
        private static readonly ProxyServiceClient _proxyService = new();

        private static readonly int THRESHOLD_AVAILABLE_BIKES = 2; //Nombre de vélos minimum pour que la station soit considérée comme disponible
        private static readonly int THRESHOLD_AVAILABLE_BIKES_STANDS = 2; //Nombre de stands minimum pour que la station soit considérée comme disponible
        private static readonly int MIN_DISTANCE_TO_STATION = 50; //Distance minimum d'arrêt de recherche : si station trouvée à moins de 50m, pas de recherche sup.



        private static List<Station> _stations;

        public BikeRoutingService()
        {
            _stations = JsonConvert.DeserializeObject<List<Station>>(_proxyService.GetStationsAsync().Result);
        }

        public async Task<List<Station>> GetStationsAsync()
        {
            return _stations ??= JsonConvert.DeserializeObject<List<Station>>(await _proxyService.GetStationsAsync());
        }

        public async Task<List<Station>> GetStationsCityAsync(string city)
        {
            return JsonConvert.DeserializeObject<List<Station>>(await _proxyService.GetStationsCityAsync(city));            
        }

        public async Task<Station> GetStationAsync(string city, string id)
        {
            return JsonConvert.DeserializeObject<Station>(await _proxyService.GetStationAsync(city, id));
        }

        public async Task<Station> FindNearestStation(string latitude, string longitude)
        {
            //convert latitude and longitude to double or return error
            if (!double.TryParse(latitude, NumberStyles.Any, CultureInfo.InvariantCulture, out var lat) ||
                !double.TryParse(longitude, NumberStyles.Any, CultureInfo.InvariantCulture, out var lon))
            {
                return null;
            }

            GeoCoordinate location = new GeoCoordinate(lat, lon);
            Station stationFound = null;
            double dist = double.MaxValue;
            foreach (Station station in _stations)
            {
                if (location.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude)) <
                    dist)
                {
                    string response = await _proxyService.GetStationAsync(station.contractName, station.number.ToString());
                    var tmp = JsonConvert.DeserializeObject<Station>(response);
                    if (tmp.totalStands.availabilities.bikes >= THRESHOLD_AVAILABLE_BIKES &&
                        tmp.status.Equals("OPEN", StringComparison.InvariantCultureIgnoreCase))
                    {
                        stationFound = tmp;
                        dist = location.GetDistanceTo(new GeoCoordinate(stationFound.position.latitude,
                            stationFound.position.longitude));
                        if (dist < MIN_DISTANCE_TO_STATION)
                            break;
                    }
                }
            }

            if (stationFound != null)
                Log($"Station trouvée : {stationFound.contractName}, {stationFound.number} : {stationFound.name}");

            return stationFound;
        }

        public async Task<List<Station>> FindStationsAround(string latitude, string longitude, string radius)
        {
            if (!double.TryParse(latitude, NumberStyles.Any, CultureInfo.InvariantCulture, out var lat) ||
                !double.TryParse(longitude, NumberStyles.Any, CultureInfo.InvariantCulture, out var lon) ||
                !int.TryParse(radius, out var rad))
            {
                return null;
            }            
            
            List<Station> stationsAround = new();
            GeoCoordinate userPosition = new GeoCoordinate(lat, lon);
            
            //get city of userPosition
            string city = await OpenStreetMapAPI.GetCity(lat, lon);

            foreach (Station station in _stations.Where(station => station.contractName.Equals(city, StringComparison.InvariantCultureIgnoreCase)))
                if (userPosition.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude)) < rad)
                    stationsAround.Add(station);

            return stationsAround;
        }

        public async Task<JCDPosition> GetPosition(string address)
        {
            //get position from address with OpenStreetMapAPI
            address = address.Trim();
            if (address.Equals("null") || address.Equals(string.Empty))
            {
                return null;
            }

            List<OSMPlace> places = await OpenStreetMapAPI.GetPlacesFromAddress(address);
            OSMPlace bestPlace = null;
            double importance = double.MinValue;

            foreach (OSMPlace place in places)
            {
                if (place.Importance > importance)
                {
                    bestPlace = place;
                    importance = place.Importance;
                }
            }

            return (bestPlace == null) ? null : new JCDPosition
            {
                latitude = bestPlace.Latitude,
                longitude = bestPlace.Longitude
            };
        }


        private async Task<Station> ClosestAvailable(JCDPosition pos)
        {
            var stations = (await GetStationsAsync()).OrderBy(s => s.position.Distance(pos)).ToArray();
            var couples = (await Task.WhenAll(stations.Take(5)
                .Select(async station => (station, 
                    (await GetRouteWalking(new JCDPosition[]{pos, station.position}))["features"][0]["properties"]["summary"]["distance"]))))
                .OrderBy(s => s.Item2.Value<double>())
                .Select(x => x.station);
            foreach (var s1 in couples.Concat(stations.Skip(5)))
            {
                if ((await GetStationAsync(s1.contractName, s1.number.ToString())).totalStands.availabilities.bikes > 0) 
                    return s1;
                Log($"Station {s1.number} unavailable, trying next one");
            }
            Log("No stations found");
            return null;
        }

        private async Task<JObject> GetRouteFull(string type, JCDPosition[] positions)
        {
            return JsonConvert.DeserializeObject<JObject>(await OpenRouteAPI.PostDirections(positions, type));
        }

        private async Task<JObject> GetRouteWalking(JCDPosition[] positions)
        {
            return await GetRouteFull("foot-walking", positions);
        }

        public async Task<Stream> GetRoute(JCDPosition[] positions)
        {
            if (positions.Length < 2)
                return null;

            var closestStart = await ClosestAvailable(positions[0]);

            if (closestStart == null)
            {
                // no available stations
                return new[] { await GetRouteWalking(positions) }.AsStream();
            }

            var closestEnd = await ClosestAvailable(positions[positions.Length - 1]);

            if (closestEnd == closestStart)
            {
                // only one available station
                return new[] { await GetRouteWalking(positions) }.AsStream();
            }

            var routes = new[]
            {
                GetRouteWalking(new JCDPosition[] { positions[0], closestStart.position }),
                GetRouteFull("cycling-regular", new JCDPosition[] { closestStart.position, closestEnd.position }),
                GetRouteWalking(new JCDPosition[] {closestEnd.position, positions[positions.Length - 1]})
            };
            var myStream = await Task.WhenAll(routes);

            //compute total duration of all routes
            var totalDuration = myStream.Sum(x => x["features"][0]["properties"]["summary"]["duration"].Value<double>());

            //get duration with full walk
            var fullDurationWalkRoute = await GetRouteWalking(new JCDPosition[] { positions[0], positions[positions.Length - 1] });
            var fullDurationWalk = fullDurationWalkRoute["features"][0]["properties"]["summary"]["duration"].Value<double>();

            if (fullDurationWalk < totalDuration)
            {
                fullDurationWalkRoute["type"] = "foot-walking";
                return new[] { fullDurationWalkRoute}.AsStream();
            }

            //set type of route to walking-cycling
            return myStream.AsStream(); //TODO return chelou ?
        }

        //public async Task<Stream> Geocode(GeocodeParameters geo)
        //{
        //    return await OpenRouteAPI.GetAsync("geocode/autocomplete", new()
        //    {
        //        ["text"] = geo.query,
        //        ["focus.point.lon"] = geo.focus.longitude,
        //        ["focus.point.lat"] = geo.focus.latitude,
        //        ["sources"] = "openstreetmap"
        //    });
        //}
    }
}
