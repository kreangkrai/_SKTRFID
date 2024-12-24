using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDCCS2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] process = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("SKT RFID CCS 2")).ToArray();
            if (process.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());

                Form1 f = new Form1();
                Screen[] screen = Screen.AllScreens.OrderBy(o => o.WorkingArea.X).ToArray();
                if (screen.Length > 2)
                {
                    f.Location = screen[2].WorkingArea.Location;
                }
                else
                {
                    f.Location = screen[screen.Length - 1].WorkingArea.Location;
                }
                Application.Run(f);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
