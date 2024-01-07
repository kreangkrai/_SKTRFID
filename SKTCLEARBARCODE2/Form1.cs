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

namespace SKTCLEARBARCODE2
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
            Setting = new SettingService(2);
            RFID = new RFIDService(2);
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

        private void btnDump8_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID8", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID8", false);
        }

        private void btnDump9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID9", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID9", false);
        }

        private void btnDump10_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID10", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID10", false);
        }

        private void btnDump11_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID11", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID11", false);
        }

        private void btnDump12_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID12", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID12", false);
        }

        private void btnDump13_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Clear_BarID13", true);
                RefreshBarcode();
            }
            Thread.Sleep(500);
            cj2.WriteVariable("Clear_BarID13", false);
        }
        private void RefreshBarcode()
        {
            List<DataModel> rfid = RFID.GetDatas(setting.crop_year);

            string barcode8 = (string)cj2.ReadVariable("Bar_ID8");
            string barcode9 = (string)cj2.ReadVariable("Bar_ID9");
            string barcode10 = (string)cj2.ReadVariable("Bar_ID10");
            string barcode11 = (string)cj2.ReadVariable("Bar_ID11");
            string barcode12 = (string)cj2.ReadVariable("Bar_ID12");
            string barcode13 = (string)cj2.ReadVariable("Bar_ID13");

            if (barcode8 != "" && barcode8 != "000000")
            {
                txtDump8.Text = rfid.Where(w => w.barcode == barcode8).Select(s => s.truck_number).FirstOrDefault();
                btnDump8.Enabled = true;
            }
            else
            {
                txtDump8.Text = "";
                btnDump8.Enabled = false;
            }

            if (barcode9 != "" && barcode9 != "000000")
            {
                txtDump9.Text = rfid.Where(w => w.barcode == barcode9).Select(s => s.truck_number).FirstOrDefault();
                btnDump9.Enabled = true;
            }
            else
            {
                txtDump9.Text = "";
                btnDump9.Enabled = false;
            }

            if (barcode10 != "" && barcode10 != "000000")
            {
                txtDump10.Text = rfid.Where(w => w.barcode == barcode10).Select(s => s.truck_number).FirstOrDefault();
                btnDump10.Enabled = true;
            }
            else
            {
                txtDump10.Text = "";
                btnDump10.Enabled = false;
            }

            if (barcode11 != "" && barcode11 != "000000")
            {
                txtDump11.Text = rfid.Where(w => w.barcode == barcode11).Select(s => s.truck_number).FirstOrDefault();
                btnDump11.Enabled = true;
            }
            else
            {
                txtDump11.Text = "";
                btnDump11.Enabled = false;
            }

            if (barcode12 != "" && barcode12 != "000000")
            {
                txtDump12.Text = rfid.Where(w => w.barcode == barcode12).Select(s => s.truck_number).FirstOrDefault();
                btnDump12.Enabled = true;
            }
            else
            {
                txtDump12.Text = "";
                btnDump12.Enabled = false;
            }

            if (barcode13 != "" && barcode13 != "000000")
            {
                txtDump13.Text = rfid.Where(w => w.barcode == barcode13).Select(s => s.truck_number).FirstOrDefault();
                btnDump13.Enabled = true;
            }
            else
            {
                txtDump13.Text = "";
                btnDump13.Enabled = false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBarcode();
        }
    }
}
