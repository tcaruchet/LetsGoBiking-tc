using LetsGoBiking_tc.Lib;
using LetsGoBiking_tc.Lib.Models;
using LetsGoBiking_tc.Proxy.Models;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.Routing.Externals
{
    public class EJCDecauxProxy
    {
        private async Task<JCDecauxObject> GetJCDecauxItem(string request)
        {
            try
            {
                Console.WriteLine("[{0}] Requête GET vers le Proxy\n", DateTime.Now);
                string response = await JCDecaux.Client.GetStringAsync(request);
                return JsonConvert.DeserializeObject<JCDecauxObject>(response);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<JCDecauxObject> GetJCDecauxItem(string contractName, string stationNumber)
        {
            return await GetJCDecauxItem(JCDecaux.GetUrl($"stations/?city={contractName}&number={stationNumber}"));
        }
    }
}
