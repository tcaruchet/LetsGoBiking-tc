using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.Proxy
{
    internal class JCDecauxAPI
    {
        private static readonly HttpClient Client = new();
        private static readonly string Token = "47ff5058c14817b9c348ab9622c16f96fe818454";

        private static readonly Lazy<string> Url = new(() => $"https://api.jcdecaux.com/vls/v3/{{0}}?apiKey={Token}&");
        private static readonly ProxyCache<string> Cache = new(GetAsyncFresh);

        private static async Task<string> GetAsyncFresh(string url)
        {
            Log($"Fetching {url}");
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async Task<string> GetAsync(string endpoint, Dictionary<string, object>? args = null, bool cached = true)
        {
            var url = string.Format(JCDecauxAPI.Url.Value, endpoint);
            if (args != null)
            {
                var query = HttpUtility.ParseQueryString("");
                foreach (var entry in args)
                    query.Add(entry.Key, entry.Value.ToString());
                url += query.ToString();
            }
            return await (cached ? Cache.Get(url) : GetAsyncFresh(url));
        }
    }
}
