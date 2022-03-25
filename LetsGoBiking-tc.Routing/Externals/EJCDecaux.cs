using LetsGoBiking_tc.Lib;
using LetsGoBiking_tc.Lib.Models;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.Routing.Externals
{
    public static class EJCDecaux
    {
        public static async Task<List<Station>> GetStations()
        {
            try
            {
                Console.WriteLine("[{0}] Requête GET vers JCDecaux pour obtenir toutes les stations \n", DateTime.Now);
                string response = await JCDecaux.Client.GetStringAsync(JCDecaux.GetUrl("stations"));
                return JsonConvert.DeserializeObject<List<Station>>(response);
            }
            catch (HttpRequestException)
            {
                return new List<Station>();
            }
        }
    }
}
