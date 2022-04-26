using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.RoutingWCF
{
    internal class OpenRouteAPI
    {
        private static readonly HttpClient _client = new();
        private static readonly string _apiToken = "5b3ce3597851110001cf6248b0767c7d723a4189966a94487a346ca9";
        
        private static readonly Lazy<string> _apiRoot = new(() => $"https://api.openrouteservice.org/{{0}}?api_key={_apiToken}&");

        private static async Task<HttpContent> PerformRequest(string endpoint, Dictionary<string, object>? args = null)
        {
            var url = string.Format(_apiRoot.Value, endpoint);

            if (args != null)
            {
                var query = HttpUtility.ParseQueryString("");
                foreach (var entry in args)
                {
                    query.Add(entry.Key, entry.Value.ToString());
                }

                url += query.ToString();
            }

            Log($"Fetching {url}");
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return response.Content;
        }

        /// <summary>
        /// Sends a GET request to the specified endpoint asynchronously.
        /// </summary>
        /// <param name="endpoint">An API endpoint.</param>
        /// <param name="args">The parameters to the endpoint, as a dictionary.</param>
        /// <param name="cached">Whether to cache the request or not.</param>
        /// <returns>A task yielding the response as a stream.</returns>
        public static async Task<Stream> GetAsync(string endpoint, Dictionary<string, object>? args = null)
        {
            var content = await PerformRequest(endpoint, args);
            return await content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Sends a GET request to the specified endpoint asynchronously.
        /// </summary>
        /// <param name="endpoint">An API endpoint.</param>
        /// <param name="args">The parameters to the endpoint, as a dictionary.</param>
        /// <param name="cached">Whether to cache the request or not.</param>
        /// <returns>A task yielding the response as a raw string.</returns>
        public static async Task<string> GetAsyncString(string endpoint, Dictionary<string, object>? args = null)
        {
            var content = await PerformRequest(endpoint, args);
            return await content.ReadAsStringAsync();
        }
    }
}
