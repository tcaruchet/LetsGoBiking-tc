using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LetsGoBiking_tc.WF.RoutingService;

namespace LetsGoBiking_tc.WF
{
    public partial class Form1 : Form
    {
        private List<Station> Stations;
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnGetStations_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now;
            string url = "";
            try
            {
                var client = new BikeRoutingServiceClient();
                //if client is not opened
                var stations = await client.GetStationsAsync();
                Stations = new List<Station>(stations);
                this.DtgStations.DataSource = null;
                this.DtgStations.Rows.Clear();
                this.DtgStations.DataSource = Stations;
                url = client.Endpoint.Address.Uri.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DateTime endDate = DateTime.Now;
            LblUrlRequest.Text = $"URL : {url}";
            LblTimeLastRequest.Text = $"Time : {endDate.Subtract(startDate).TotalMilliseconds} ms";
            LblSizeRequest.Text = $"Size : 4567899 bytes";
        }

        private async void BtnOrderByContract_Click(object sender, EventArgs e)
        {
            //clear dtgstations

            this.DtgStations.DataSource = null;
            this.DtgStations.Rows.Clear();
            if (this.Stations != null && this.Stations.Any())
            {
                var orderedStations = Stations.OrderBy(s => s.contractName).ToList();
                this.DtgStations.DataSource = orderedStations;
            }
            else
            {
                DateTime startDate = DateTime.Now;
                try
                {
                    var client = new BikeRoutingServiceClient();
                    var stations = await client.GetStationsAsync();
                    Stations = new List<Station>(stations);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DateTime endDate = DateTime.Now;
                var orderedStations = this.Stations.OrderBy(s => s.contractName).ToList();
                this.DtgStations.DataSource = orderedStations;
            }
        }

        private async void BtnSearchRoute_ClickAsync(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now;
            string url = "";
            try
            {
                var client = new BikeRoutingServiceClient();
                //if client is not opened
                //get Position for start and end
                JCDPosition positionStart = await client.GetPositionAsync(TxtStartAddress.Text);
                JCDPosition positionEnd = await client.GetPositionAsync(TxtEndAddress.Text);
                if (positionStart == null )
                {
                    MessageBox.Show("Adresse de départ non trouvée");
                    return;
                }
                if (positionEnd == null)
                {
                    MessageBox.Show("Adresse d'arrivée non trouvée");
                    return;
                }
                this.TxtStartGeo.Text = positionStart.latitude.ToString(CultureInfo.InvariantCulture);
                this.TxtEndGeo.Text = positionEnd.latitude.ToString(CultureInfo.InvariantCulture);
                GeoJson geoJson = await client.GetRouteAsync(new JCDPosition[] { positionStart, positionEnd });
                this.DtgRoute.DataSource = null;
                this.DtgRoute.Rows.Clear();
                List<Step> steps = new List<Step>();
                foreach (var feature in geoJson.features)
                    foreach (var seg in feature.properties.segments)
                        steps.AddRange(seg.steps);
                this.DtgRoute.DataSource = steps;
                url = client.Endpoint.Address.Uri.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DateTime endDate = DateTime.Now;
            LblUrlRequest.Text = $"URL : {url}";
            LblTimeLastRequest.Text = $"Time : {endDate.Subtract(startDate).TotalMilliseconds} ms";
            LblSizeRequest.Text = $"Size : 67555 bytes";
        }
    }
}
