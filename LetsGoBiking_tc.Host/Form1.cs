using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LetsGoBiking_tc.RoutingWCF.Services;

namespace LetsGoBiking_tc.Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isHosted = false;
        ServiceHost host;

        private void BtnStartRouting_Click(object sender, EventArgs e)
        {
            if (!isHosted)
            {
                host = new ServiceHost(typeof(BikeRoutingService));
                host.Open();
                LblStatusRouting.Text = "Routing Service Started";
                isHosted = true;
                BtnStartRouting.Text = "Stop Routing Service";
            }
            else
            {
                host.Close();
                LblStatusRouting.Text = "Routing Service Stopped";
                isHosted = false;
                BtnStartRouting.Text = "Start Routing Service";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblStatusRouting.Text = "Routing Service Stopped";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isHosted)
            {
                host.Close();
            }
        }
    }
}
