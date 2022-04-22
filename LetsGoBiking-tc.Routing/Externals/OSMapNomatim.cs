using LetsGoBiking_tc.Routing.Models;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.Routing.Externals
{
    public class OSMapNomatim
    {
        private static readonly HttpClient client = new();

        public async Task<List<Place>> GetPlaces(string request)
        {
            try
            {
                Console.WriteLine($"[{DateTime.Now}] Requête GET vers OpenStreetMap pour avoir le point le plus près d'une adresse avec l'URL : {request}\n");
                HttpResponseMessage response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Place>>(responseBody);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<ReversePlace> GetReversePlace(string request)
        {
            try
            {
                Console.WriteLine($"[{DateTime.Now}] Requête GET vers OpenStreetMap pour avoir une adresse à partir d'un point GPS avec l'URL : {request}\n");
                HttpResponseMessage response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ReversePlace>(responseBody);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<List<Place>> GetPlacesFromAddress(string address)
        {
            string request = "https://nominatim.openstreetmap.org/search?email=thomas.caruchet@etu.univ-cotedazur.fr&format=json&q=" + address;
            return await GetPlaces(request);
        }

        public async Task<string> GetCity(double latitude, double longitude)
        {
            string request =
                "https://nominatim.openstreetmap.org/reverse?email=thomas.caruchet@etu.univ-cotedazur.fr&format=json&lat=" +
                latitude.ToString().Replace(",",".") + "&lon=" + longitude.ToString().Replace(",", ".");
            ReversePlace reversePlace = await GetReversePlace(request);
            return reversePlace.address.city;
        }
    }
}
