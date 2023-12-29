﻿using OMRON.Compolet.CIP;
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

namespace SKTCLEARBARCODE2
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        private ISetting Setting;
        public Form1()
        {
            InitializeComponent();
            Setting = new SettingService(2);
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

        private void btnDump8_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID8", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID9", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump10_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID10", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump11_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID11", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump12_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID12", "000000");
                RefreshBarcode();
            }
        }

        private void btnDump13_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                cj2.WriteVariable("Bar_ID13", "000000");
                RefreshBarcode();
            }
        }
        private void RefreshBarcode()
        {
            string barcode8 = (string)cj2.ReadVariable("Bar_ID8");
            string barcode9 = (string)cj2.ReadVariable("Bar_ID9");
            string barcode10 = (string)cj2.ReadVariable("Bar_ID10");
            string barcode11 = (string)cj2.ReadVariable("Bar_ID11");
            string barcode12 = (string)cj2.ReadVariable("Bar_ID12");
            string barcode13 = (string)cj2.ReadVariable("Bar_ID13");

            if (barcode8 != "" && barcode8 != "000000")
            {
                btnDump8.Enabled = true;
            }
            else
            {
                btnDump8.Enabled = false;
            }

            if (barcode9 != "" && barcode9 != "000000")
            {
                btnDump9.Enabled = true;
            }
            else
            {
                btnDump9.Enabled = false;
            }

            if (barcode10 != "" && barcode10 != "000000")
            {
                btnDump10.Enabled = true;
            }
            else
            {
                btnDump10.Enabled = false;
            }

            if (barcode11 != "" && barcode11 != "000000")
            {
                btnDump11.Enabled = true;
            }
            else
            {
                btnDump11.Enabled = false;
            }

            if (barcode12 != "" && barcode12 != "000000")
            {
                btnDump12.Enabled = true;
            }
            else
            {
                btnDump12.Enabled = false;
            }

            if (barcode13 != "" && barcode13 != "000000")
            {
                btnDump13.Enabled = true;
            }
            else
            {
                btnDump13.Enabled = false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBarcode();
        }
    }
}
