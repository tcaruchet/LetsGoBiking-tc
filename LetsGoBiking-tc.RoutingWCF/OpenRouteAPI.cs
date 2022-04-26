using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LetsGoBiking_tc.RoutingWCF.Models;
using static LetsGoBiking_tc.Lib.Helpers;

namespace LetsGoBiking_tc.RoutingWCF
{
    internal class OpenRouteAPI
    {
        private static readonly HttpClient _client = new();
        private static readonly string _apiToken = "5b3ce3597851110001cf6248b0767c7d723a4189966a94487a346ca9";
        
        private static readonly Lazy<string> _apiRoot = new(() => $"https://api.openrouteservice.org/{{0}}?api_key={_apiToken}&");

        public static async Task<string> PostDirections(string request, string data)
        {
            try
            {
                Log($"Fetching url {request}");
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpRequestMessage httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(request),
                    Method = HttpMethod.Post,
                    Content = content
                };
                httpRequest.Headers.Add("Authorization", _apiToken);

                HttpResponseMessage response = await _client.SendAsync(httpRequest);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public static async Task<string> PostDirections(JCDPosition[] positions, string profile)
        {
            string request = "https://api.openrouteservice.org/v2/directions/" + profile + "/geojson";
            return await PostDirections(request, BuildDataForPOSTCall(positions));
        }

        private static string BuildDataForPOSTCall(JCDPosition[] positions)
        {
            string data = "{\"coordinates\":[";
            
            foreach (JCDPosition position in positions)
                data += "[" + position.longitude.ToString(new System.Globalization.CultureInfo("fr-FR")).Replace(",", ".") + "," + position.latitude.ToString(new System.Globalization.CultureInfo("fr-FR")).Replace(",", ".") + "],";

            data += "],\"instructions\":\"true\",\"language\":\"fr\",\"preference\":\"shortest\",\"units\":\"m\"}";

            return data.Replace("],],", "]],");
        }
    }
}

