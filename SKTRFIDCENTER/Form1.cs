using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDCENTER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCropYear_AreaId_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\SETTING\\SKTRFIDSETTING.exe";
            p.StartInfo.Arguments = txtPhase.Text;
            p.Start();  
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\REPORT\\SKTRFIDREPORT.exe";
            p.StartInfo.Arguments = txtPhase.Text;
            p.Start();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\SHIFT\\SKTRFIDSHIFT.exe";
            p.StartInfo.Arguments = txtPhase.Text;
            p.Start();
        }

        private void btnEditDump_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\BARCODE\\SKTCLEARBARCODE1.exe";
            p.Start();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\MONITOR\\SKTRFIDMONITOR.exe";
            p.StartInfo.Arguments = txtPhase.Text;
            p.Start();
        }

        private void btnReadWriteRFID_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\TAG\\SKTRFIDTAG.exe";
            p.StartInfo.Arguments = txtPhase.Text;
            p.Start();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\KILL\\SKTRFIDCLEARPROGRAM.exe";
            p.Start();
        }

        private void btnCheckHardware_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\HARDWARE\\SKTRFIDCHECKHARDWAREPHASE.exe";
            p.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
