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
            var client = new BikeRoutingServiceClient();
            //if client is not opened
            try
            {
                var stations = await client.GetStationsAsync();
                Stations = new List<Station>(stations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DateTime endDate = DateTime.Now;
            this.DtgStations.DataSource = Stations;
            //LblUrl.Text = $"URL : http://localhost:5157/api/LGBiking/";
            //LblTime.Text = $"Time : {endDate.Subtract(startDate).TotalMilliseconds} ms";
            //LblSize.Text = $"Size : {response.Length} bytes";
        }
    }
}
