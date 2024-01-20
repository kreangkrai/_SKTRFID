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

namespace SKTRFIDCLEARPROGRAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("AUTO DUMP")).ToArray();
            DialogResult dialogResult = MessageBox.Show("Do you want to kill program?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                foreach (var p in process)
                {
                    if (p.MainWindowTitle.Contains("AUTO DUMP"))
                    {
                        p.Kill();
                    }
                }
            }
        }
    }
}
