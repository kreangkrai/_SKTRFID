using OMRON.Compolet.CIP;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using SKTRFIDLIBRARY.Service;
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

namespace SKTCLEARBARCODE1
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        private ISetting Setting;
        private IRFID RFID;
        SettingModel setting;
        public Form1()
        {
            InitializeComponent();
            Setting = new SettingService(1);
            RFID = new RFIDService(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setting = Setting.GetSetting();
            cj2 = new CJ2Compolet();
            cj2.HeartBeatTimer = 0;
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = setting.ip_plc;
            cj2.LocalPort = 2;
            cj2.Active = true;
        }

        private void btnDump1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID1", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID1", false);
        }

        private void btnDump2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID2", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID2", false);
        }

        private void btnDump3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID3", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID3", false);
        }

        private void btnDump4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID4", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID4", false);
        }

        private void btnDump5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID5", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID5", false);
        }

        private void btnDump6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID6", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID6", false);
        }

        private void btnDump7_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID7", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID7", false);
        }
        private void RefreshBarcode()
        {
            List<DataModel> rfid = RFID.GetDatas(setting.crop_year);



            string barcode1 = (string)cj2.ReadVariable("Bar_ID1");
            string barcode2 = (string)cj2.ReadVariable("Bar_ID2");
            string barcode3 = (string)cj2.ReadVariable("Bar_ID3");
            string barcode4 = (string)cj2.ReadVariable("Bar_ID4");
            string barcode5 = (string)cj2.ReadVariable("Bar_ID5");
            string barcode6 = (string)cj2.ReadVariable("Bar_ID6");
            string barcode7 = (string)cj2.ReadVariable("Bar_ID7");


            if (barcode1 != "" && barcode1 != "000000")
            {
                txtDump1.Text = rfid.Where(w=>w.barcode == barcode1).Select(s=>s.truck_number).FirstOrDefault();
                btnDump1.Enabled = true;
            }
            else
            {
                txtDump1.Text = "";
                btnDump1.Enabled = false;
            }

            if (barcode2 != "" && barcode2 != "000000")
            {
                txtDump2.Text = rfid.Where(w => w.barcode == barcode2).Select(s => s.truck_number).FirstOrDefault();
                btnDump2.Enabled = true;
            }
            else
            {
                txtDump2.Text = "";
                btnDump2.Enabled = false;
            }

            if (barcode3 != "" && barcode3 != "000000")
            {
                txtDump3.Text = rfid.Where(w => w.barcode == barcode3).Select(s => s.truck_number).FirstOrDefault();
                btnDump3.Enabled = true;
            }
            else
            {
                txtDump3.Text = "";
                btnDump3.Enabled = false;
            }

            if (barcode4 != "" && barcode4 != "000000")
            {
                txtDump4.Text = rfid.Where(w => w.barcode == barcode4).Select(s => s.truck_number).FirstOrDefault();
                btnDump4.Enabled = true;
            }
            else
            {
                txtDump4.Text = "";
                btnDump4.Enabled = false;
            }

            if (barcode5 != "" && barcode5 != "000000")
            {
                txtDump5.Text = rfid.Where(w => w.barcode == barcode5).Select(s => s.truck_number).FirstOrDefault();
                btnDump5.Enabled = true;
            }
            else
            {
                txtDump5.Text = "";
                btnDump5.Enabled = false;
            }

            if (barcode6 != "" && barcode6 != "000000")
            {
                txtDump6.Text = rfid.Where(w => w.barcode == barcode6).Select(s => s.truck_number).FirstOrDefault();
                btnDump6.Enabled = true;
            }
            else
            {
                txtDump6.Text = "";
                btnDump6.Enabled = false;
            }

            if (barcode7 != "" && barcode7 != "000000")
            {
                txtDump7.Text = rfid.Where(w => w.barcode == barcode7).Select(s => s.truck_number).FirstOrDefault();
                btnDump7.Enabled = true;
            }
            else
            {
                txtDump7.Text = "";
                btnDump7.Enabled = false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBarcode();
        }

        private void btnDump1_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID1", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID1", false);
        }

        private void btnDump1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
