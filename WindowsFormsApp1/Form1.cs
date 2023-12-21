using OMRON.Compolet.CIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        public Form1()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            cj2 = new CJ2Compolet();
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = "192.168.250.1";
            cj2.LocalPort = 2;
            cj2.Active = true;
        }

        private void auto_button1_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D1", true);
        }

        private void auto_button2_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D2", true);
        }

        private void auto_button3_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D3", true);
        }

        private void auto_button4_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D4", true);
        }

        private void auto_button5_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D5", true);
        }

        private void auto_button6_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D6", true);
        }

        private void auto_button7_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D7", true);
        }

        private void manual_button1_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump01", true);
        }

        private void manual_button2_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump02", true);
        }

        private void manual_button3_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump03", true);
        }

        private void manual_button4_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump04", true);
        }

        private void manual_button5_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump05", true);
        }

        private void manual_button6_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump06", true);
        }

        private void manual_button7_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("manual_dump07", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D1", false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D2", false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D3", false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D4", false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D5", false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D6", false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cj2.WriteVariable("Call_D7", false);
        }
    }
}
