using System;
using System.Collections.Generic;
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

        private static List<Station> _stations;

        public async Task<List<Station>> GetStationsAsync()
        {
            try
            {
                if (_stations == null)
                {
                    _stations = JsonConvert.DeserializeObject<List<Station>>(await _proxyService.GetStationsAsync());
                }
                return _stations;
            }
            catch (Exception ex)
            {
                throw new System.ServiceModel.FaultException(ex.Message);
            }
            
        }

        public async Task<Station> GetStationAsync(string id)
        {
            return JsonConvert.DeserializeObject<Station>(await _proxyService.GetStationAsync(id));
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
                if ((await GetStationAsync(s1.number.ToString())).totalStands.availabilities.bikes > 0) 
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
