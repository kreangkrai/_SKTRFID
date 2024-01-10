using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDMUTESOUND1
{
    public partial class Form1 : Form
    {
        string path = @"D:\SKT PROGRAM\RFID\Voice\";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDump1_Click(object sender, EventArgs e)
        {
            if (btnDump1.BackColor == Color.Red) {

                string old_path = filePath("dump$1.wav");
                string new_path = filePath("dump1.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump1.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump1.wav");
                string new_path = filePath("dump$1.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump1.BackColor = Color.Red;
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> files = ReadFIleName().ToList();
            files = files.Where(w => w.Contains("dump")).ToList();

            bool dump1 = files.Any(w => w.Contains("dump1.wav"));
            bool dump2 = files.Any(w => w.Contains("dump2.wav"));
            bool dump3 = files.Any(w => w.Contains("dump3.wav"));
            bool dump4 = files.Any(w => w.Contains("dump4.wav"));
            bool dump5 = files.Any(w => w.Contains("dump5.wav"));
            bool dump6 = files.Any(w => w.Contains("dump6.wav"));
            bool dump7 = files.Any(w => w.Contains("dump7.wav"));

            if (dump1)
            {
                btnDump1.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump1.BackColor = Color.Red;
            }

            if (dump2)
            {
                btnDump2.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump2.BackColor = Color.Red;
            }

            if (dump3)
            {
                btnDump3.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump3.BackColor = Color.Red;
            }

            if (dump4)
            {
                btnDump4.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump4.BackColor = Color.Red;
            }

            if (dump5)
            {
                btnDump5.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump5.BackColor = Color.Red;
            }

            if (dump6)
            {
                btnDump6.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump6.BackColor = Color.Red;
            }

            if (dump7)
            {
                btnDump7.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump7.BackColor = Color.Red;
            }
        }
        private string filePath(string name)
        {
            return path + name;
        }
        string[] ReadFIleName()
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                return files;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new string[0];
            }
        }

        private void btnDump2_Click(object sender, EventArgs e)
        {
            if (btnDump2.BackColor == Color.Red)
            {

                string old_path = filePath("dump$2.wav");
                string new_path = filePath("dump2.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump2.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump2.wav");
                string new_path = filePath("dump$2.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump2.BackColor = Color.Red;
            }
        }

        private void btnDump3_Click(object sender, EventArgs e)
        {
            if (btnDump3.BackColor == Color.Red)
            {

                string old_path = filePath("dump$3.wav");
                string new_path = filePath("dump3.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump3.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump3.wav");
                string new_path = filePath("dump$3.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump3.BackColor = Color.Red;
            }
        }

        private void btnDump4_Click(object sender, EventArgs e)
        {
            if (btnDump4.BackColor == Color.Red)
            {

                string old_path = filePath("dump$4.wav");
                string new_path = filePath("dump4.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump4.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump4.wav");
                string new_path = filePath("dump$4.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump4.BackColor = Color.Red;
            }
        }

        private void btnDump5_Click(object sender, EventArgs e)
        {
            if (btnDump5.BackColor == Color.Red)
            {

                string old_path = filePath("dump$5.wav");
                string new_path = filePath("dump5.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump5.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump5.wav");
                string new_path = filePath("dump$5.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump5.BackColor = Color.Red;
            }
        }

        private void btnDump6_Click(object sender, EventArgs e)
        {
            if (btnDump6.BackColor == Color.Red)
            {

                string old_path = filePath("dump$6.wav");
                string new_path = filePath("dump6.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump6.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump6.wav");
                string new_path = filePath("dump$6.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump6.BackColor = Color.Red;
            }
        }

        private void btnDump7_Click(object sender, EventArgs e)
        {
            if (btnDump7.BackColor == Color.Red)
            {

                string old_path = filePath("dump$7.wav");
                string new_path = filePath("dump7.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump7.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump7.wav");
                string new_path = filePath("dump$7.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump7.BackColor = Color.Red;
            }
        }
    }
}
