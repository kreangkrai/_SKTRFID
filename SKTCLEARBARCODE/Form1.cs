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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTCLEARBARCODE1
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        private ISetting Setting;
        public Form1()
        {
            InitializeComponent();
            Setting = new SettingService(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SettingModel setting = Setting.GetSetting();
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
                cj2.WriteVariable("Bar_ID1", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID2", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID3", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID4", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID5", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID6", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump7_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID7", "000000");
                RefreshBarcode();
            }
        }
        private void RefreshBarcode()
        {
            string barcode1 = (string)cj2.ReadVariable("Bar_ID1");
            string barcode2 = (string)cj2.ReadVariable("Bar_ID2");
            string barcode3 = (string)cj2.ReadVariable("Bar_ID3");
            string barcode4 = (string)cj2.ReadVariable("Bar_ID4");
            string barcode5 = (string)cj2.ReadVariable("Bar_ID5");
            string barcode6 = (string)cj2.ReadVariable("Bar_ID6");
            string barcode7 = (string)cj2.ReadVariable("Bar_ID7");

            if (barcode1 != "" && barcode1 != "000000")
            {
                btnDump1.Enabled = true;
            }
            else
            {
                btnDump1.Enabled = false;
            }

            if (barcode2 != "" && barcode2 != "000000")
            {
                btnDump2.Enabled = true;
            }
            else
            {
                btnDump2.Enabled = false;
            }

            if (barcode3 != "" && barcode3 != "000000")
            {
                btnDump3.Enabled = true;
            }
            else
            {
                btnDump3.Enabled = false;
            }

            if (barcode4 != "" && barcode4 != "000000")
            {
                btnDump4.Enabled = true;
            }
            else
            {
                btnDump4.Enabled = false;
            }

            if (barcode5 != "" && barcode5 != "000000")
            {
                btnDump5.Enabled = true;
            }
            else
            {
                btnDump5.Enabled = false;
            }

            if (barcode6 != "" && barcode6 != "000000")
            {
                btnDump6.Enabled = true;
            }
            else
            {
                btnDump6.Enabled = false;
            }

            if (barcode7 != "" && barcode7 != "000000")
            {
                btnDump7.Enabled = true;
            }
            else
            {
                btnDump7.Enabled = false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBarcode();
        }
    }
}
