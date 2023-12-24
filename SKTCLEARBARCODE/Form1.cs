using OMRON.Compolet.CIP;
using SKTCLEARBARCODE.Interface;
using SKTCLEARBARCODE.Model;
using SKTCLEARBARCODE.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTCLEARBARCODE
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        private ISetting Setting;
        public Form1()
        {
            InitializeComponent();
            Setting = new SettingService();
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
                cj2.WriteVariable("Bar_ID1", "");
            }
        }

        private void btnDump2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                string x = "";
                cj2.WriteVariable("Bar_ID2", x);
            }
        }

        private void btnDump3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID3", "");
            }
        }

        private void btnDump4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID4", "000000000000000");
            }
        }

        private void btnDump5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID5", "");
            }
        }

        private void btnDump6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID6", "");
            }
        }

        private void btnDump7_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID7", "");
            }
        }
    }
}
