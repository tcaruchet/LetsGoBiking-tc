namespace LetsGoBiking_tc.Lib
{
    public class JCDecaux
    {
        public static HttpClient Client = new();
        private const string ApiKey = "47ff5058c14817b9c348ab9622c16f96fe818454";

        private const string Url = "https://api.jcdecaux.com/vls/v3/";


        public static string GetUrl(string parameters)
        {
            return Url + parameters + $"{(parameters.Contains('?') ? "&" : "?")}apiKey={ApiKey}";
        }
    }
}
