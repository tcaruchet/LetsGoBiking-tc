using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
                LblStatusRouting.Text = "Démarrés";
                LblStatusRouting.ForeColor = Color.Green;
                isHosted = true;
                BtnStartRouting.Text = "Arrêter";
            }
            else
            {
                host.Close();
                LblStatusRouting.Text = "Arrêtés";
                LblStatusRouting.ForeColor = Color.Red;
                isHosted = false;
                BtnStartRouting.Text = "Démarrer";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblStatusRouting.Text = "Arrêtés";
            LblStatusRouting.ForeColor = Color.Red;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isHosted)
                host.Close();
        }

        private void BtnStartWF_Click(object sender, EventArgs e)
        {
            LetsGoBiking_tc.WF.Form1 form = new LetsGoBiking_tc.WF.Form1();
            form.Show();
            form.Closed += (s, args) =>
            {
                form.Dispose();
            };
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isHosted)
                host.Close();
        }

        private void BtnStartWeb_Click(object sender, EventArgs e)
        {
            //call cmd command to start LetsGoBiking_tc.Web server.py in ../../../LetsGoBiking_tc.Web
            //Process p = new Process();
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = "cmd.exe";
            //info.RedirectStandardInput = true;
            //info.UseShellExecute = false;

            //p.StartInfo = info;
            //p.Start();

            //using (StreamWriter sw = p.StandardInput)
            //{
            //    if (sw.BaseStream.CanWrite)
            //    {
            //        sw.WriteLine("cd ..\\..\\..\\LetsGoBiking-tc.Web");
            //        sw.WriteLine("py ./server.py");
            //    }
            //}

            //p.WaitForExit();
            MessageBox.Show("Not implemented yet, Lancez le site via la commande py server.py dans le dossier LetsGoBiking-tc.Web");
        }
    }
}
