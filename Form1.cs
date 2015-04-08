using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace meteoPanel
{
    public partial class panel : Form
    {
        public panel()
        {
            InitializeComponent();
        }

        private void panel_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            File.Delete("downld02.txt");
            
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile("http://protezionecivilecasarano.org/stazionemeteo/downld02.txt", "downld02.txt");
            }

            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file. 
            string[] lines = System.IO.File.ReadAllLines(@"downld02.txt");
            int numLines = lines.Length - 1;
            
            lines[numLines] = lines[numLines].Replace("  ", " ");
            lines[numLines] = lines[numLines].Replace("  ", " ");
            lines[numLines] = lines[numLines].Replace("  ", " ");
            lines[numLines] = lines[numLines].Replace("   ", " ");
            lines[numLines] = lines[numLines].Replace("    ", " ");

            lblDateTime.Text = lines[numLines].Split(' ')[1] + " " + lines[numLines].Split(' ')[2];
            txtTempOut.Text = lines[numLines].Split(' ')[3];
            txtMaxTemp.Text = lines[numLines].Split(' ')[4];
            txtMinTemp.Text = lines[numLines].Split(' ')[5];
            txtHumExt.Text = lines[numLines].Split(' ')[6];
            txtDewPoint.Text = lines[numLines].Split(' ')[7];
            txtWindSpeed.Text = lines[numLines].Split(' ')[8];
            txtWindDir.Text = lines[numLines].Split(' ')[9];
            txtWindRun.Text = lines[numLines].Split(' ')[10];
            txtMaxSpeed.Text = lines[numLines].Split(' ')[11];
            txtMaxDir.Text = lines[numLines].Split(' ')[12];
            txtWindChill.Text = lines[numLines].Split(' ')[13];
            txtHeatIndex.Text = lines[numLines].Split(' ')[14];
            txtTHWIndex.Text = lines[numLines].Split(' ')[15];
            txtBar.Text = lines[numLines].Split(' ')[16];
            txtRain.Text = lines[numLines].Split(' ')[17];
            txtRainRate.Text = lines[numLines].Split(' ')[18];
            txtHeatDD.Text = lines[numLines].Split(' ')[19];
            txtCoolDD.Text = lines[numLines].Split(' ')[20];
            txtInTemp.Text = lines[numLines].Split(' ')[21];
            txtInHum.Text = lines[numLines].Split(' ')[22];
            txtInDew.Text = lines[numLines].Split(' ')[23];
            txtInHeat.Text = lines[numLines].Split(' ')[24];
            txtInEMC.Text = lines[numLines].Split(' ')[25];
            txtInAirDensity.Text = lines[numLines].Split(' ')[26];
            txtWindSamp.Text = lines[numLines].Split(' ')[27];
            txtWindTx.Text = lines[numLines].Split(' ')[28];
            txtISSRecept.Text = lines[numLines].Split(' ')[29];
            txtArcInt.Text = lines[numLines].Split(' ')[30];
        }
    }
}
