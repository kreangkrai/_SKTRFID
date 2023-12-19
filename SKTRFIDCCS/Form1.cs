using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMRON.Compolet.CIP;
using System.Windows.Forms;

namespace SKTRFIDCCS1
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult dialog = MessageBox.Show("Do you want to exit?","SKT CCS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox1.Cursor = Cursors.Hand;
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }           
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Arrow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cj2 = new CJ2Compolet();
            cj2.HeartBeatTimer = 3000;
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = "192.168.250.10";
            cj2.LocalPort = 2;
            cj2.OnHeartBeatTimer += Cj2_OnHeartBeatTimer;
            cj2.Active = true;
        }

        private void Cj2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                //bool manual_d1 = (bool)cj2.ReadVariable("manual_dump01");
                //if (manual_d1)
                //{
                //    //cj2.WriteVariable("manual_dump01", false);
                //    button2.BackColor = Color.FromArgb(255, 0, 0);
                //}
                //else
                //{
                //    //cj2.WriteVariable("manual_dump01", true);
                //    button2.BackColor = Color.FromArgb(0, 255, 0);
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cj2.WriteVariable("manual_dump01", true);
            cj2.WriteVariable("Bar_ID1", "999999");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //cj2.WriteVariable("manual_dump01", false);
            cj2.WriteVariable("Bar_ID1", 888888);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit?", "SKT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
