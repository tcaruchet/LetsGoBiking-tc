using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            try
            {
                var client = new BikeRoutingServiceClient();
                //if client is not opened
                var stations = await client.GetStationsAsync();
                Stations = new List<Station>(stations);
                this.DtgStations.DataSource = null;
                this.DtgStations.Rows.Clear();
                this.DtgStations.DataSource = Stations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DateTime endDate = DateTime.Now;
            //LblUrl.Text = $"URL : http://localhost:5157/api/LGBiking/";
            //LblTime.Text = $"Time : {endDate.Subtract(startDate).TotalMilliseconds} ms";
            //LblSize.Text = $"Size : {response.Length} bytes";
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
    }
}
