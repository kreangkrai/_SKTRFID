using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDCCS1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Form1 f = new Form1();
            //Screen[] screen = Screen.AllScreens;
            //if (screen.Length > 1)
            //{
            //    f.Location = Screen.AllScreens[1].WorkingArea.Location;
            //}
            //else
            //{
            //    f.Location = Screen.AllScreens[screen.Length - 1].WorkingArea.Location;
            //}
            //Application.Run(f);
        }
    }
}
