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
                JCDecauxObject jcdO = new JCDecauxObject();
                await jcdO.UpdateStation(request);
                return jcdO;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JsonReaderException))
                    Console.WriteLine("[{0}] Erreur de lecture du JSON\n", DateTime.Now);
                else if (ex.GetType() == typeof(HttpRequestException))
                    Console.WriteLine("[{0}] Erreur de connexion au Proxy\n", DateTime.Now);
                else
                    Console.WriteLine("[{0}] Erreur inconnue\n", DateTime.Now);
                return null;
            }
        }

        public async Task<JCDecauxObject> GetJCDecauxItem(string contractName, string stationNumber)
        {
            return await GetJCDecauxItem(JCDecaux.GetUrl($"stations/{stationNumber}?contract={contractName}"));
        }
    }
}
