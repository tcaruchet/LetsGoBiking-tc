using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using LetsGoBiking_tc.Lib;
using LetsGoBiking_tc.Lib.Models;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.WF
{
    public partial class Form1 : Form
    {
        private HttpClient httpClient;
        private List<Station> stations;

        public Form1()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5157/api/LGBiking");
            
            InitializeComponent();
        }

        private async void BtnGetAllStations_Click(object sender, EventArgs e)
        {
            // get all stations with HTTP request in SOAP
            DateTime startDate = DateTime.Now;
            var soapString = Helpers.Helpers.ConstructSoapRequest(0,0);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("SOAPAction", "http://localhost:5157/api/LGBiking/");
                var soapResponse = await client.GetAsync("http://localhost:5157/api/LGBiking/");
                soapResponse.EnsureSuccessStatusCode();
                DateTime endDate = DateTime.Now;                
                string response = await soapResponse.Content.ReadAsStringAsync();
                stations = Helpers.Helpers.ParseSoapResponse(response);
                this.DtgStations.DataSource = stations;
                LblUrl.Text = $"URL : http://localhost:5157/api/LGBiking/";
                LblTime.Text = $"Time : {endDate.Subtract(startDate).TotalMilliseconds} ms";
                LblSize.Text = $"Size : {response.Length} bytes";                
            }
        }

        private async void BtnFindStationsByCityAndContractName_Click(object sender, EventArgs e)
        {
            // get station with HTTP request in SOAP
            DateTime startDate = DateTime.Now;
            var soapString = Helpers.Helpers.ConstructSoapRequest(0, 0);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("SOAPAction", $"http://localhost:5157/api/LGBiking/Stations/{TxtCity.Text.ToLowerInvariant()}/{TxtContractName.Text.ToLowerInvariant()}");
                var soapResponse = await client.GetAsync("http://localhost:5157/api/LGBiking/Stations/{TxtCity.Text.ToLowerInvariant()}/{TxtContractName.Text.ToLowerInvariant()}");
                soapResponse.EnsureSuccessStatusCode();
                DateTime endDate = DateTime.Now;
                string response = await soapResponse.Content.ReadAsStringAsync();
                stations = Helpers.Helpers.ParseSoapResponse(response);
                this.DtgStations.DataSource = stations;
                
                LblUrl.Text = $"URL : http://localhost:5157/api/LGBiking/Stations/{TxtCity.Text.ToLowerInvariant()}/{TxtContractName.Text.ToLowerInvariant()}";
                LblTime.Text = $"Time : {endDate.Subtract(startDate).TotalMilliseconds} ms";
                LblSize.Text = $"Size : {response.Length} bytes";
            }
        }
    }
}