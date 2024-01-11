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

namespace SKTRFIDMUTESOUND2
{
    public partial class Form1 : Form
    {
        string path = @"D:\SKT PROGRAM\RFID\Voice\";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDump8_Click(object sender, EventArgs e)
        {
            if (btnDump8.BackColor == Color.Red)
            {

                string old_path = filePath("dump$8.wav");
                string new_path = filePath("dump8.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump8.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump8.wav");
                string new_path = filePath("dump$8.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump8.BackColor = Color.Red;
            }
        }

        private void btnDump9_Click(object sender, EventArgs e)
        {
            if (btnDump9.BackColor == Color.Red)
            {

                string old_path = filePath("dump$9.wav");
                string new_path = filePath("dump9.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump9.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump9.wav");
                string new_path = filePath("dump$9.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump9.BackColor = Color.Red;
            }
        }

        private void btnDump10_Click(object sender, EventArgs e)
        {
            if (btnDump10.BackColor == Color.Red)
            {

                string old_path = filePath("dump$10.wav");
                string new_path = filePath("dump10.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump10.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump10.wav");
                string new_path = filePath("dump$10.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump10.BackColor = Color.Red;
            }
        }

        private void btnDump11_Click(object sender, EventArgs e)
        {
            if (btnDump11.BackColor == Color.Red)
            {

                string old_path = filePath("dump$11.wav");
                string new_path = filePath("dump11.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump11.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump11.wav");
                string new_path = filePath("dump$11.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump11.BackColor = Color.Red;
            }
        }

        private void btnDump12_Click(object sender, EventArgs e)
        {
            if (btnDump12.BackColor == Color.Red)
            {

                string old_path = filePath("dump$12.wav");
                string new_path = filePath("dump12.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump12.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump12.wav");
                string new_path = filePath("dump$12.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump12.BackColor = Color.Red;
            }
        }

        private void btnDump13_Click(object sender, EventArgs e)
        {
            if (btnDump13.BackColor == Color.Red)
            {

                string old_path = filePath("dump$13.wav");
                string new_path = filePath("dump13.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump13.BackColor = Color.GreenYellow;
            }
            else
            {
                string old_path = filePath("dump13.wav");
                string new_path = filePath("dump$13.wav");
                System.IO.File.Move(old_path, new_path);
                btnDump13.BackColor = Color.Red;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> files = ReadFIleName().ToList();
            files = files.Where(w => w.Contains("dump")).ToList();

            bool dump8 = files.Any(w => w.Contains("dump8.wav"));
            bool dump9 = files.Any(w => w.Contains("dump9.wav"));
            bool dump10 = files.Any(w => w.Contains("dump10.wav"));
            bool dump11 = files.Any(w => w.Contains("dump11.wav"));
            bool dump12 = files.Any(w => w.Contains("dump12.wav"));
            bool dump13 = files.Any(w => w.Contains("dump13.wav"));

            if (dump8)
            {
                btnDump8.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump8.BackColor = Color.Red;
            }

            if (dump9)
            {
                btnDump9.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump9.BackColor = Color.Red;
            }

            if (dump10)
            {
                btnDump10.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump10.BackColor = Color.Red;
            }

            if (dump11)
            {
                btnDump11.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump11.BackColor = Color.Red;
            }

            if (dump12)
            {
                btnDump12.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump12.BackColor = Color.Red;
            }

            if (dump13)
            {
                btnDump13.BackColor = Color.GreenYellow;
            }
            else
            {
                btnDump13.BackColor = Color.Red;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new string[0];
            }
        }
    }
}
