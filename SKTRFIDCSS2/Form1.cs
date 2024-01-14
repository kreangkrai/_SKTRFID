using OMRON.Compolet.CIP;
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

namespace SKTRFIDCCS2
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        private ISetting Setting;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            Setting = new SettingService(2);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult dialog = MessageBox.Show("Do you want to exit?", "SKT CCS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
            SettingModel setting = Setting.GetSetting();
            cj2 = new CJ2Compolet();
            cj2.HeartBeatTimer = 3000;
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = setting.ip_plc;
            cj2.LocalPort = 2;
            cj2.OnHeartBeatTimer += Cj2_OnHeartBeatTimer;
            cj2.Active = true;
        }

        private void Cj2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                int DSP_01 = (int)cj2.ReadVariable("DSP_01");
                int DSP_02 = (int)cj2.ReadVariable("DSP_02");
                int DSP_03 = (int)cj2.ReadVariable("DSP_03");
                int DSP_04 = (int)cj2.ReadVariable("DSP_04");
                int DSP_05 = (int)cj2.ReadVariable("DSP_05");
                int DSP_06 = (int)cj2.ReadVariable("DSP_06");
                int DSP_07 = (int)cj2.ReadVariable("DSP_07");
                int DSP_08 = (int)cj2.ReadVariable("DSP_08");
                int DSP_09 = (int)cj2.ReadVariable("DSP_09");
                int DSP_10 = (int)cj2.ReadVariable("DSP_10");
                int DSP_11 = (int)cj2.ReadVariable("DSP_11");
                int DSP_12 = (int)cj2.ReadVariable("DSP_12");
                int DSP_13 = (int)cj2.ReadVariable("DSP_13");
                int DSP_14 = (int)cj2.ReadVariable("DSP_14");
                int DSP_15 = (int)cj2.ReadVariable("DSP_15");
                int DSP_16 = (int)cj2.ReadVariable("DSP_16");



                if (DSP_01 + 7 == 13) // DUMP 13
                {
                    picDump13.Visible = false;

                }
                else
                {
                    picDump13.Visible = true;
                }

                if (DSP_02 + 7 == 12) // DUMP 12
                {
                    picDump12.Visible = false;
                }
                else
                {
                    picDump12.Visible = true;
                }

                if (DSP_03 + 7 == 11) // DUMP 11
                {
                    picDump11.Visible = false;
                }
                else
                {
                    picDump11.Visible = true;
                }

                if (DSP_04 + 7 == 10) // DUMP 10
                {
                    picDump10.Visible = false;
                }
                else
                {
                    picDump10.Visible = true;
                }

                if (DSP_05 + 7 == 9) // DUMP 9
                {
                    picDump9.Visible = false;
                }
                else
                {
                    picDump9.Visible = true;
                }


                if (DSP_06 + 7 == 8) // DUMP 8
                {
                    picDump8.Visible = false;
                }
                else
                {
                    picDump8.Visible = true;
                }


                if (DSP_09 != 0) //
                {
                    picLamp2_1.Visible = true;
                    picLamp2_2.Visible = true;
                }
                else
                {
                    picLamp2_1.Visible = false;
                    picLamp2_2.Visible = false;
                }

                if (DSP_11 != 0)
                {
                    picLamp2_3.Visible = true;
                }
                else
                {
                    picLamp2_3.Visible = false;
                }

                if (DSP_12 != 0) //
                {
                    picLamp3.Visible = true;
                }
                else
                {
                    picLamp3.Visible = false;
                }

                if (DSP_13 != 0) //
                {
                    picLamp4.Visible = true;
                }
                else
                {
                    picLamp4.Visible = false;
                }

                if (DSP_14 != 0) //
                {
                    picLamp5_1.Visible = true;
                    picLamp5_2.Visible = true;
                    picLamp5_3.Visible = true;
                }
                else
                {
                    picLamp5_1.Visible = false;
                    picLamp5_2.Visible = false;
                    picLamp5_3.Visible = false;
                }

                if (DSP_15 != 0) //
                {
                    picLamp6_1.Visible = true;
                    picLamp6_2.Visible = true;
                }
                else
                {
                    picLamp6_1.Visible = false;
                    picLamp6_2.Visible = false;
                }

                if (DSP_16 != 0) //
                {
                    picLamp7_1.Visible = true;
                    picLamp7_2.Visible = true;
                    picLamp7_3.Visible = true;
                }
                else
                {
                    picLamp7_1.Visible = false;
                    picLamp7_2.Visible = false;
                    picLamp7_3.Visible = false;
                }



                if (DSP_01 + 7 > 9)
                {
                    lblDSP_01.Font =  new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_01.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_02 + 7 > 9)
                {
                    lblDSP_02.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_02.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_03 + 7 > 9)
                {
                    lblDSP_03.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_03.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_04 + 7 > 9)
                {
                    lblDSP_04.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_04.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_05 + 7 > 9)
                {
                    lblDSP_05.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_05.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_06 + 7 > 9)
                {
                    lblDSP_06.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_06.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_07 + 7 > 9)
                {
                    lblDSP_07.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_07.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_08 + 7 > 9)
                {
                    lblDSP_08.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_08.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_09 + 7 > 9)
                {
                    lblDSP_09.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_09.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_10 + 7 > 9)
                {
                    lblDSP_10.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_10.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_11 + 7 > 9)
                {
                    lblDSP_11.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_11.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_12 + 7 > 9)
                {
                    lblDSP_12.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_12.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_13 + 7 > 9)
                {
                    lblDSP_13.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_13.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_14 + 7 > 9)
                {
                    lblDSP_14.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_14.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_15 + 7 > 9)
                {
                    lblDSP_15.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_15.Font = new Font("Microsoft Sans Serif", 30);
                }

                if (DSP_16 + 7 > 9)
                {
                    lblDSP_16.Font = new Font("Microsoft Sans Serif", 25);
                }
                else
                {
                    lblDSP_16.Font = new Font("Microsoft Sans Serif", 30);
                }


                lblDSP_01.Text = DSP_01 == 0 ? "" : (DSP_01 + 7).ToString();
                lblDSP_02.Text = DSP_02 == 0 ? "" : (DSP_02 + 7).ToString();
                lblDSP_03.Text = DSP_03 == 0 ? "" : (DSP_03 + 7).ToString();
                lblDSP_04.Text = DSP_04 == 0 ? "" : (DSP_04 + 7).ToString();
                lblDSP_05.Text = DSP_05 == 0 ? "" : (DSP_05 + 7).ToString();
                lblDSP_06.Text = DSP_06 == 0 ? "" : (DSP_06 + 7).ToString();
                lblDSP_07.Text = DSP_07 == 0 ? "" : (DSP_07 + 7).ToString();
                lblDSP_08.Text = DSP_08 == 0 ? "" : (DSP_08 + 7).ToString();
                lblDSP_09.Text = DSP_09 == 0 ? "" : (DSP_09 + 7).ToString();
                lblDSP_10.Text = DSP_10 == 0 ? "" : (DSP_10 + 7).ToString();
                lblDSP_11.Text = DSP_11 == 0 ? "" : (DSP_11 + 7).ToString();
                lblDSP_12.Text = DSP_12 == 0 ? "" : (DSP_12 + 7).ToString();
                lblDSP_13.Text = DSP_13 == 0 ? "" : (DSP_13 + 7).ToString();
                lblDSP_14.Text = DSP_14 == 0 ? "" : (DSP_14 + 7).ToString();
                lblDSP_15.Text = DSP_15 == 0 ? "" : (DSP_15 + 7).ToString();
                lblDSP_16.Text = DSP_16 == 0 ? "" : (DSP_16 + 7).ToString();
            }
            catch
            {

            }
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
