﻿using System;
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


        private async Task<Station> ClosestAvailable(JCDPosition pos)
        {
            var stations = (await GetStationsAsync()).OrderBy(s => s.position.Distance(pos)).ToArray();
            var couples = (await Task.WhenAll(stations.Take(5)
                .Select(async station => (station, 
                    (await GetRouteWalking(pos, station.position))["features"][0]["properties"]["summary"]["distance"]))))
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

        private async Task<JObject> GetRouteFull(string type, JCDPosition start, JCDPosition end)
        {
            return JsonConvert.DeserializeObject<JObject>(await OpenRouteAPI.GetAsyncString($"v2/directions/{type}", new()
            {
                ["start"] = $"{start.longitude},{start.latitude}",
                ["end"] = $"{end.longitude},{end.latitude}"
            }));
        }

        private async Task<JObject> GetRouteWalking(JCDPosition start, JCDPosition end)
        {
            return await GetRouteFull("foot-walking", start, end);
        }

        public async Task<Stream> GetRoute(RouteParameters points)
        {
            var closestStart = await ClosestAvailable(points.start);

            if (closestStart == null)
            {
                // no available stations
                return new[] { await GetRouteWalking(points.start, points.end) }.AsStream();
            }

            var closestEnd = await ClosestAvailable(points.end);

            if (closestEnd == closestStart)
            {
                // only one available station
                return new[] { await GetRouteWalking(points.start, points.end) }.AsStream();
            }

            var routes = new[]
            {
                GetRouteWalking(points.start, closestStart.position),
                GetRouteFull("cycling-regular", closestStart.position, closestEnd.position),
                GetRouteWalking(closestEnd.position, points.end)
            };
            return (await Task.WhenAll(routes)).AsStream();
        }

        public async Task<Stream> Geocode(GeocodeParameters geo)
        {
            return await OpenRouteAPI.GetAsync("geocode/autocomplete", new()
            {
                ["text"] = geo.query,
                ["focus.point.lon"] = geo.focus.longitude,
                ["focus.point.lat"] = geo.focus.latitude,
                ["sources"] = "openstreetmap"
            });
        }
    }
}