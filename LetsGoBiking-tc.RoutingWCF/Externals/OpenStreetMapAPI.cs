using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using LetsGoBiking_tc.RoutingWCF.Models;
using Newtonsoft.Json;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.RoutingWCF.Externals
{
    internal class OpenStreetMapAPI
    {
        private static readonly HttpClient client = new();
        //private static readonly string _apiToken = "";
        
        //private static readonly Lazy<string> _apiRoot = new(() => $"https://api.openrouteservice.org/{{0}}?api_key={_apiToken}&");

        //private static async Task<HttpContent> PerformRequest(string endpoint, Dictionary<string, object>? args = null)
        //{
        //    var url = string.Format(_apiRoot.Value, endpoint);

        //    if (args != null)
        //    {
        //        var query = HttpUtility.ParseQueryString("");
        //        foreach (var entry in args)
        //        {
        //            query.Add(entry.Key, entry.Value.ToString());
        //        }

        //        url += query.ToString();
        //    }

        //    Log($"Fetching {url}");
        //    var response = await _client.GetAsync(url);
        //    response.EnsureSuccessStatusCode();
        //    return response.Content;
        //}

        ///// <summary>
        ///// Sends a GET request to the specified endpoint asynchronously.
        ///// </summary>
        ///// <param name="endpoint">An API endpoint.</param>
        ///// <param name="args">The parameters to the endpoint, as a dictionary.</param>
        ///// <param name="cached">Whether to cache the request or not.</param>
        ///// <returns>A task yielding the response as a stream.</returns>
        //public static async Task<Stream> GetAsync(string endpoint, Dictionary<string, object>? args = null)
        //{
        //    var content = await PerformRequest(endpoint, args);
        //    return await content.ReadAsStreamAsync();
        //}

        ///// <summary>
        ///// Sends a GET request to the specified endpoint asynchronously.
        ///// </summary>
        ///// <param name="endpoint">An API endpoint.</param>
        ///// <param name="args">The parameters to the endpoint, as a dictionary.</param>
        ///// <param name="cached">Whether to cache the request or not.</param>
        ///// <returns>A task yielding the response as a raw string.</returns>
        //public static async Task<string> GetAsyncString(string endpoint, Dictionary<string, object>? args = null)
        //{
        //    var content = await PerformRequest(endpoint, args);
        //    return await content.ReadAsStringAsync();
        //}
        
        public static async Task<List<OSMPlace>> GetPlaces(string request)
        {
            try
            {
                Log($"Requête GET vers OpenStreetMap pour avoir le point le plus près d'une adresse avec l'URL : {request}\n");
                HttpResponseMessage response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<OSMPlace>>(responseBody);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public static async Task<OSMReversePlace> GetReversePlace(string request)
        {
            try
            {
                Log($"Requête GET vers OpenStreetMap pour avoir une adresse à partir d'un point GPS avec l'URL : {request}\n");
                HttpResponseMessage response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<OSMReversePlace>(responseBody);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public static async Task<List<OSMPlace>> GetPlacesFromAddress(string address)
        {
            string request = "https://nominatim.openstreetmap.org/search?email=thomas.caruchet@etu.univ-cotedazur.fr&format=json&q=" + address;
            return await GetPlaces(request);
        }

        public static async Task<string> GetCity(double latitude, double longitude)
        {
            string request =
                "https://nominatim.openstreetmap.org/reverse?email=thomas.caruchet@etu.univ-cotedazur.fr&format=json&lat=" +
                latitude.ToString().Replace(",", ".") + "&lon=" + longitude.ToString().Replace(",", ".");
            OSMReversePlace reversePlace = await GetReversePlace(request);
            return reversePlace.address.city;
        }
    }
}
