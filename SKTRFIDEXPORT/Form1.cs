using SKTRFIDEXPORT.Interface;
using SKTRFIDEXPORT.Service;
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

namespace SKTRFIDEXPORT
{
    public partial class Form1 : Form
    {
        private IExport Export;
        public Form1()
        {
            InitializeComponent();
            Export = new ExportService();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to export data?", "SKT Report", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                string message =  Export.Export(dateTimePickerStat.Value.ToString("yyyy-MM-dd 00:00:00"), dateTimePickerStop.Value.ToString("yyyy-MM-dd 23:59:59"));
                MessageBox.Show(message);
            }
        }
        private void btnFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", "D:\\Report");
        }
    }
}
