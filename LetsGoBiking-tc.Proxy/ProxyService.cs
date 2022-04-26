using System;
using System.Threading.Tasks;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.Proxy
{
    public class ProxyService : IProxyService
    {
        private static readonly string _apiCity = "marseille";

        public async Task<string> GetStationsAsync()
        {
            Log("");
            return await JCDecauxAPI.GetAsync("stations", new() { ["contract"] = _apiCity }, false);
        }

        public async Task<string> GetStationAsync(string id)
        {
            try
            {
                Log(id);
                return await JCDecauxAPI.GetAsync("stations/" + id, new() { ["contract"] = _apiCity });
            }
            catch (Exception ex)
            {
                throw new System.ServiceModel.FaultException<string>(ex.Message);
            }
           
        }
    }
}
