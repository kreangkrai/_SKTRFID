using OMRON.Compolet.CIP;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using SKTRFIDLIBRARY.Service;
using SKTRFIDSHIFT.Interface;
using SKTRFIDSHIFT.Model;
using SKTRFIDSHIFT.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDSHIFT
{
    public partial class Form1 : Form
    {
        int phase = 0;
        CJ2Compolet cj2;
        private ISetting Setting;
        SettingModel setting;
        bool isManual = true;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            Setting = new SettingService(phase);
            setting = Setting.GetSetting();
            this.Text = "SKT RFID SHIFT PHASE " + phase;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cj2 = new CJ2Compolet();
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = setting.ip_plc;
            cj2.LocalPort = 2;
            cj2.Active = true;

            bool mode_cut_queue = (bool)cj2.ReadVariable("Mode_Cut_Queue");
            
            if (mode_cut_queue) // Auto
            {
                btnManual.BackColor = Color.Red;
                isManual = false;
                btnManualConfirm.Enabled = false;
            }
            else // Manual
            {
                isManual = true;
                btnManual.BackColor = Color.GreenYellow;
                btnManualConfirm.Enabled = true;
            }
            string last_barcode = (string)cj2.ReadVariable("LD_BarID");
            string last_queue = (string)cj2.ReadVariable("LD_Queue");
            string queue_running = (string)cj2.ReadVariable("Queue_Running");
            int last_dump = (int)cj2.ReadVariable("LD_Dump");
            txtQueue.Text = last_queue.ToString();
            txtBarcode.Text = last_barcode;
            txtDump.Text = last_dump.ToString();
            txtQueueRunning.Text = queue_running;
        }
        private void btnManualConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("MN_Cut_Queue", true);
            }
            Thread.Sleep(500);
            cj2.WriteVariable("MN_Cut_Queue", false);
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (isManual)
            {
                isManual = false;
                btnManual.BackColor = Color.Red;
                btnManualConfirm.Enabled = false;
                cj2.WriteVariable("Mode_Cut_Queue", true); // Auto
            }
            else
            {
                btnManual.BackColor = Color.GreenYellow;
                isManual = true;
                btnManualConfirm.Enabled = true;
                cj2.WriteVariable("Mode_Cut_Queue", false); // Manual
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cj2.IsConnected)
            {
                cj2.Active = false;
                cj2.Dispose();
            }
        }
    }
}
