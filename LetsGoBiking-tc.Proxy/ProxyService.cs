using System;
using System.Threading.Tasks;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.Proxy
{
    public class ProxyService : IProxyService
    {

        public async Task<string> GetStationsAsync()
        {
            Log("");
            return await JCDecauxAPI.GetAsync("stations", new() { }, false);
        }

        public async Task<string> GetStationsCityAsync(string city)
        {
            Log(city);
            return await JCDecauxAPI.GetAsync("stations", new() { ["contract"] = city }, false);
        }

        public async Task<string> GetStationAsync(string city, string id)
        {
            Log(id);
            return await JCDecauxAPI.GetAsync("stations/" + id, new() { ["contract"] = city });
        }
    }
}
