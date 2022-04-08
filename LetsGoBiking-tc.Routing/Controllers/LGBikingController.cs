using System.Threading.Tasks.Dataflow;
using GeoCoordinatePortable;
using LetsGoBiking_tc.Lib;
using LetsGoBiking_tc.Lib.Models;
using LetsGoBiking_tc.Proxy.Models;
using LetsGoBiking_tc.Proxy.Services;
using LetsGoBiking_tc.Routing.Externals;
using LetsGoBiking_tc.Routing.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsGoBiking_tc.Routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LGBikingController : ControllerBase
    {
        private static readonly EJCDecauxProxy Proxy = new();

        private readonly OSMapNomatim osMapNomatim = new();
        //private readonly OpenRouteService openRouteService = new OpenRouteService();

        private static List<Station> _stations = EJCDecaux.GetStations().Result; //TODO: Update stations when specific ones are queried
        private static readonly Dictionary<(DateTime, int), (string, int)> logs = new();

        private static readonly int THRESHOLD_AVAILABLE_BIKES = 2;
        private static readonly int THRESHOLD_AVAILABLE_BIKES_STANDS = 2;



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
                if (location.GetDistanceTo(new GeoCoordinate(station.Position.Latitude, station.Position.Longitude)) >
                    dist)
                {
                    JCDecauxObject tmp = await Proxy.GetJCDecauxItem(station.ContractName, station.Number.ToString());
                    if (tmp.Station.MainStands.Availabilities.Bikes >= THRESHOLD_AVAILABLE_BIKES &&
                        tmp.Station.Status.Equals("OPEN", StringComparison.InvariantCultureIgnoreCase))
                    {
                        stationFound = tmp.Station;
                        dist = location.GetDistanceTo(new GeoCoordinate(stationFound.Position.Latitude,
                            stationFound.Position.Longitude));
                    }
                }
            }

            if (stationFound != null)
            {
                logs.Add((DateTime.Now, new Random().Next()), (stationFound.ContractName, stationFound.Number));
            }

            return stationFound;
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
        
    }
}
