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
            p.StartInfo.FileName = "Program\\CropYear_AreaId\\SKTRFIDSETTING.exe";
            p.Start();
            p.WaitForExit();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\Report\\SKTRFIDEXPORT.exe";
            p.Start();
            p.WaitForExit();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\Shift\\SKTRFIDSHIFT.exe";
            p.Start();
            p.WaitForExit();
        }

        private void btnEditDump_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Program\\Edit\\SKTRFIDEDIT.exe";
            p.Start();
            p.WaitForExit();
        }
    }
}
