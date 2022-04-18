﻿using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks.Dataflow;
using GeoCoordinatePortable;
using LetsGoBiking_tc.Lib;
using LetsGoBiking_tc.Lib.Models;
using LetsGoBiking_tc.Proxy.Models;
using LetsGoBiking_tc.Proxy.Services;
using LetsGoBiking_tc.Routing.Externals;
using LetsGoBiking_tc.Routing.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsGoBiking_tc.Routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LGBikingController : ControllerBase
    {
        private static readonly EJCDecauxProxy Proxy = new();

        private readonly OSMapNomatim osMapNomatim = new();
        private readonly ORService openRouteService = new();

        private static List<Station> _stations = EJCDecaux.GetStations().Result; //TODO: Update stations when specific ones are queried
        private static readonly Dictionary<(DateTime, int), (string, int)> logs = new();

        private static readonly int THRESHOLD_AVAILABLE_BIKES = 2; //Nombre de vélos minimum pour que la station soit considérée comme disponible
        private static readonly int THRESHOLD_AVAILABLE_BIKES_STANDS = 2; //Nombre de stands minimum pour que la station soit considérée comme disponible
        private static readonly int MIN_DISTANCE_TO_STATION = 50; //Distance minimum d'arrêt de recherche : si station trouvée à moins de 50m, pas de recherche sup.



        // GET: api/<LGBikingController>
        [HttpGet]
        public async Task<IEnumerable<Station>> GetAllStations()
        {
            _stations = await EJCDecaux.GetStations();
            return _stations;
        }

        [HttpGet("Stations/{city}/{stationNumber}")]
        public async Task<Station> GetStationInfos(string city, string stationNumber)
        {
            JCDecauxObject obj = await Proxy.GetJCDecauxItem(city, stationNumber);
            return obj.Station;
        }

        [HttpGet("Stations/Nearest/{latitude}/{longitude}")]
        public async Task<Station> FindNearestStation(double latitude, double longitude)
        {
            GeoCoordinate location = new GeoCoordinate(latitude, longitude);
            Station stationFound = null;
            double dist = double.MaxValue;
            foreach (Station station in _stations)
            {
                if (location.GetDistanceTo(new GeoCoordinate(station.Position.Latitude, station.Position.Longitude)) <
                    dist)
                {
                    JCDecauxObject tmp = await Proxy.GetJCDecauxItem(station.ContractName, station.Number.ToString());
                    if (tmp.Station.MainStands.Availabilities.Bikes >= THRESHOLD_AVAILABLE_BIKES &&
                        tmp.Station.Status.Equals("OPEN", StringComparison.InvariantCultureIgnoreCase))
                    {
                        stationFound = tmp.Station;
                        dist = location.GetDistanceTo(new GeoCoordinate(stationFound.Position.Latitude,
                            stationFound.Position.Longitude));
                        if (dist < MIN_DISTANCE_TO_STATION)
                            break;
                    }
                }
            }

            if (stationFound != null)
            {
                logs.Add((DateTime.Now, new Random().Next()), (stationFound.ContractName, stationFound.Number));
            }

            return stationFound;
        }


        //delete ?
        [HttpGet("Stations/Nearest/Start/{latitude}/{longitude}")]
        public Station FindNearestStationFromStart(double latitude, double longitude)
        {
            GeoCoordinate userPosition = new GeoCoordinate(latitude, longitude);
            Station nearestStation = null;
            double distance = double.MaxValue;

            foreach (Station station in _stations)
            {
                if (userPosition.GetDistanceTo(new GeoCoordinate(station.Position.Latitude, station.Position.Longitude)) < distance)
                {
                    Station potentialNearestStation = Proxy.GetJCDecauxItem(station.ContractName, station.Number.ToString()).Result.Station;
                    if (potentialNearestStation.MainStands.Availabilities.Bikes >= THRESHOLD_AVAILABLE_BIKES && potentialNearestStation.Status.Equals("OPEN"))
                    {
                        nearestStation = potentialNearestStation;
                        distance = userPosition.GetDistanceTo(new GeoCoordinate(potentialNearestStation.Position.Latitude, potentialNearestStation.Position.Longitude));
                    }
                }
            }

            if (nearestStation != null)
            {
                logs.Add((DateTime.Now, new Random().Next()), (nearestStation.ContractName, nearestStation.Number));
            }

            return nearestStation;
        }

        [HttpGet("Stations/Nearest/End/{latitude}/{longitude}")]
        public Station FindNearestStationFromEnd(double latitude, double longitude)
        {
            GeoCoordinate userPosition = new GeoCoordinate(latitude, longitude);
            Station nearestStation = null;
            double distance = double.MaxValue;

            foreach (Station station in _stations)
            {
                if (userPosition.GetDistanceTo(new GeoCoordinate(station.Position.Latitude, station.Position.Longitude)) < distance)
                {
                    Station potentialNearestStation = Proxy.GetJCDecauxItem(station.ContractName, station.Number.ToString()).Result.Station;
                    if (potentialNearestStation.MainStands.Availabilities.Bikes >= THRESHOLD_AVAILABLE_BIKES_STANDS && potentialNearestStation.Status.Equals("OPEN"))
                    {
                        nearestStation = potentialNearestStation;
                        distance = userPosition.GetDistanceTo(new GeoCoordinate(potentialNearestStation.Position.Latitude, potentialNearestStation.Position.Longitude));
                    }
                }
            }

            if (nearestStation != null)
            {
                logs.Add((DateTime.Now, new Random().Next()), (nearestStation.ContractName, nearestStation.Number));
            }

            return nearestStation;
        }






        // OpenStreetMapNomatim
        [HttpGet("Position/{address}")]
        public async Task<Position> GetPosition(string address)
        {
            address = address.Trim();
            if (address.Equals("null") || address.Equals(string.Empty))
            {
                return null;
            }

            List<Place> places = osMapNomatim.GetPlacesFromAddress(address).Result;
            Place bestPlace = null;
            double importance = double.MinValue;

            foreach (Place place in places)
            {
                if (place.Importance > importance)
                {
                    bestPlace = place;
                    importance = place.Importance;
                }
            }

            return (bestPlace == null) ? null : new Position
            {
                Latitude = bestPlace.Latitude,
                Longitude = bestPlace.Longitude
            };
        }

        // OpenRouteService
        [HttpPost("Route/Path")]
        public GeoJson GetPath(Position[] positions)
        {
            if (Array.Exists(positions, position => position == null))
            {
                return null;
            }

            GeoJson cyclingRegularPath = GetPath(positions, "cycling-regular");
            GeoJson footWalkingPath = GetPath(new Position[] { positions[0], positions[positions.Length - 1] }, "foot-walking");

            bool chooseFootWalkingPathByDistance = footWalkingPath.features[0].properties.summary.distance < cyclingRegularPath.features[0].properties.summary.distance;
            bool chooseFootWalkingPathByDuration = footWalkingPath.features[0].properties.summary.duration < cyclingRegularPath.features[0].properties.summary.duration;

            Console.WriteLine("Distance à pied plus courte ? {0}", chooseFootWalkingPathByDistance);
            Console.WriteLine("Durée à pied plus courte ? {0}", chooseFootWalkingPathByDuration);

            return chooseFootWalkingPathByDistance && chooseFootWalkingPathByDuration ? footWalkingPath : cyclingRegularPath;
        }

        [HttpOptions("Route/Path")]
        public void PathOptions()
        {
            var responseProp = OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
            WebHeaderCollection headers = responseProp.Headers;
            headers.Add("Access-Control-Allow-Origin", "*");
            headers.Add("Access-Control-Allow-Methods", "POST");
            headers.Add("Access-Control-Allow-Headers", "Content-Type");
        }

        [HttpPost("Route/Path/Station")]
        public GeoJson GoToStation(Position[] positions)
        {
            if (Array.Exists(positions, position => position == null))
                return null;
            return GetPath(positions, "foot-walking");
        }

        [HttpOptions("Route/Path/Station")]
        public void GoToStationOptions()
        {
            var responseProp = OperationContext.Current.OutgoingMessageProperties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
            WebHeaderCollection headers = responseProp.Headers;
            headers.Add("Access-Control-Allow-Methods", "POST");
            headers.Add("Access-Control-Allow-Headers", "Content-Type");
        }

        //Locals
        private GeoJson GetPath(Position[] positions, string profile) => JsonConvert.DeserializeObject<GeoJson>(openRouteService.PostDirections(positions, profile).Result);

        //Logs
        [HttpGet("Logs")]
        public Dictionary<(DateTime, int), (string, int)> GetLogs() => logs;

        [HttpOptions("Logs/{days}")]
        public Dictionary<(DateTime, int), (string, int)> GetLogsByDays(int days) => logs.Where(log => DateTime.Compare(DateTime.Now.AddDays(days * -1), log.Key.Item1) < 0).ToDictionary(log => log.Key, log => log.Value);
    }
}
