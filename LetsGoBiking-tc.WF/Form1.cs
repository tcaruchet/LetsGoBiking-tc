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

        private void BtnGetAllStations_Click(object sender, EventArgs e)
        {
            // get all stations with HTTP request in SOAP
            var soapString = Helpers.Helpers.ConstructSoapRequest(0,0);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("SOAPAction", "http://localhost:5157/api/LGBiking");
                var soapResponse = client.GetStringAsync("http://localhost:5157/api/LGBiking").Result;
                stations = Helpers.Helpers.ParseSoapResponse(soapResponse);
                this.DtgStations.DataSource = stations;
            }
        }

        private void BtnFindStationsByCityAndContractName_Click(object sender, EventArgs e)
        {

        }
    }
}