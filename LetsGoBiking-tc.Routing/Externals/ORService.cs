using System.Text;
using LetsGoBiking_tc.Lib.Models;

namespace LetsGoBiking_tc.Routing.Externals
{
    public class ORService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string API_KEY = "5b3ce3597851110001cf6248b0767c7d723a4189966a94487a346ca9";

        public async Task<string> PostDirections(string request, string data)
        {
            try
            {
                Console.WriteLine($"[{DateTime.Now}] Requête POST vers OpenRouteService avec l'URL : {request} et les données : {data}\n");
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpRequestMessage httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(request),
                    Method = HttpMethod.Post,
                    Content = content
                };
                httpRequest.Headers.Add("Authorization", API_KEY);

                HttpResponseMessage response = await client.SendAsync(httpRequest);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<string> PostDirections(Position[] positions, string profile)
        {
            string request = "https://api.openrouteservice.org/v2/directions/" + profile + "/geojson";
            return await PostDirections(request, BuildDataForPOSTCall(positions));
        }

        private string BuildDataForPOSTCall(Position[] positions)
        {
            string data = "{\"coordinates\":[";

            foreach (Position position in positions)
                data += "[" + position.Longitude.ToString(new System.Globalization.CultureInfo("fr-FR")).Replace(",", ".") + "," + position.Latitude.ToString(new System.Globalization.CultureInfo("fr-FR")).Replace(",", ".") + "],";

            data += "],\"instructions\":\"true\",\"language\":\"fr\",\"preference\":\"shortest\",\"units\":\"m\"}";

            return data.Replace("],],", "]],");
        }
    }
}
