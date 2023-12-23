using OMRON.Compolet.CIP;
using SKTRFID1.Interface;
using SKTRFID1.Model;
using SKTRFID1.Properties;
using SKTRFID1.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaClient;
namespace SKTRFID1
{
    public partial class Form1 : Form
    {
        private ISetting Setting;
        CJ2Compolet cj2;
        CJ2Compolet cj1;
        private IRFID RFID;
        List<string> windows_title;
        LabelModel labels;
        string phase = "1";
        public Form1()
        {
            InitializeComponent();
            RFID = new RFIDService();
            windows_title = new List<string>();
            labels = new LabelModel();
            Setting = new SettingService();
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

            cj1 = new CJ2Compolet();
            cj1.HeartBeatTimer = 1000;
            cj1.ConnectionType = ConnectionType.UCMM;
            cj1.UseRoutePath = false;
            cj1.PeerAddress = setting.ip_plc_common;
            cj1.LocalPort = 2;
            cj1.OnHeartBeatTimer += Cj1_OnHeartBeatTimer;
            cj1.Active = true;
        }

        private void Cj1_OnHeartBeatTimer(object sender, EventArgs e)
        {
            bool manual_d1 = (bool)cj1.ReadVariable("MN_SCAN_D1");
            bool manual_d2 = (bool)cj1.ReadVariable("MN_SCAN_D2");
            bool manual_d3 = (bool)cj1.ReadVariable("MN_SCAN_D3");
            bool manual_d4 = (bool)cj1.ReadVariable("MN_SCAN_D4");
            bool manual_d5 = (bool)cj1.ReadVariable("MN_SCAN_D5");
            bool manual_d6 = (bool)cj1.ReadVariable("MN_SCAN_D6");
            bool manual_d7 = (bool)cj1.ReadVariable("MN_SCAN_D7");

            if (manual_d1)
            {
                cj1.WriteVariable("MN_SCAN_D1", false);
                StartProcessCommon("1", phase);
            }

            if (manual_d2)
            {
                cj1.WriteVariable("MN_SCAN_D2", false);
                StartProcessCommon("2", phase);
            }

            if (manual_d3)
            {
                cj1.WriteVariable("MN_SCAN_D3", false);
                StartProcessCommon("3", phase);
            }

            if (manual_d4)
            {
                cj1.WriteVariable("MN_SCAN_D4", false);
                StartProcessCommon("4", phase);
            }

            if (manual_d5)
            {
                cj1.WriteVariable("MN_SCAN_D5", false);
                StartProcessCommon("5", phase);
            }

            if (manual_d6)
            {
                cj1.WriteVariable("MN_SCAN_D6", false);
                StartProcessCommon("6", phase);
            }

            if (manual_d7)
            {
                cj1.WriteVariable("MN_SCAN_D7", false);
                StartProcessCommon("7", phase);
            }
        }

        private void Cj2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                //Read Barcode
                bool b_D1 = true;
                bool b_D2 = true;
                bool b_D3 = true;
                bool b_D4 = true;
                bool b_D5 = true;
                bool b_D6 = true;
                bool b_D7 = true;
                string bar_D1 = (string)cj2.ReadVariable("Bar_ID1");
                string bar_D2 = (string)cj2.ReadVariable("Bar_ID2");
                string bar_D3 = (string)cj2.ReadVariable("Bar_ID3");
                string bar_D4 = (string)cj2.ReadVariable("Bar_ID4");
                string bar_D5 = (string)cj2.ReadVariable("Bar_ID5");
                string bar_D6 = (string)cj2.ReadVariable("Bar_ID6");
                string bar_D7 = (string)cj2.ReadVariable("Bar_ID7");

                b_D1 = bar_D1 == "" ? false : true;
                b_D2 = bar_D2 == "" ? false : true;
                b_D3 = bar_D3 == "" ? false : true;
                b_D4 = bar_D4 == "" ? false : true;
                b_D5 = bar_D5 == "" ? false : true;
                b_D6 = bar_D6 == "" ? false : true;
                b_D7 = bar_D7 == "" ? false : true;

                List<DataModel> datas = RFID.GetDatas();
                if (datas.Count > 0)
                {
                    ShowDisplay(truck_license1, truck_date1, cane_type1, truck_type1, datas, "1", b_D1);
                    ShowDisplay(truck_license2, truck_date2, cane_type2, truck_type2, datas, "2", b_D2);
                    ShowDisplay(truck_license3, truck_date3, cane_type3, truck_type3, datas, "3", b_D3);
                    ShowDisplay(truck_license4, truck_date4, cane_type4, truck_type4, datas, "4", b_D4);
                    ShowDisplay(truck_license5, truck_date5, cane_type5, truck_type5, datas, "5", b_D5);
                    ShowDisplay(truck_license6, truck_date6, cane_type6, truck_type6, datas, "6", b_D6);
                    ShowDisplay(truck_license7, truck_date7, cane_type7, truck_type7, datas, "7", b_D7);
                }

                bool auto_d1 = (bool)cj2.ReadVariable("Call_D1");
                bool auto_d2 = (bool)cj2.ReadVariable("Call_D2");
                bool auto_d3 = (bool)cj2.ReadVariable("Call_D3");
                bool auto_d4 = (bool)cj2.ReadVariable("Call_D4");
                bool auto_d5 = (bool)cj2.ReadVariable("Call_D5");
                bool auto_d6 = (bool)cj2.ReadVariable("Call_D6");
                bool auto_d7 = (bool)cj2.ReadVariable("Call_D7");


                int sound_d = (int)cj2.ReadVariable("NUM_SOUND_D");

                

                if (sound_d > 0)
                {
                    // Call Dump
                    try
                    {
                        string path = Directory.GetCurrentDirectory();
                        SoundPlayer dump_wave_file = new SoundPlayer();
                        dump_wave_file.SoundLocation = Path.Combine(path, $"voice\\dump{sound_d}.wav");
                        dump_wave_file.PlaySync();
                    }
                    catch
                    {

                    }
                }

                windows_title = new List<string>();
                Process[] process = Process.GetProcesses();
                foreach(var p in process)
                {
                    if (p.MainWindowTitle != "")
                    {
                        windows_title.Add(p.MainWindowTitle);
                    }
                }

                SettingModel setting = Setting.GetSetting();
                if (auto_d1)
                {
                    StartProcess(setting.ip1, "1", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip1 + " : 1")
                        {
                            p.Kill();
                        }
                    }
                }

                if (auto_d2)
                {
                    StartProcess(setting.ip1, "2", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip1 + " : 2")
                        {
                            p.Kill();
                        }
                    }
                }

                if (auto_d3)
                {
                    StartProcess(setting.ip1, "3", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip1 + " : 3")
                        {
                            p.Kill();
                        }
                    }
                }

                if (auto_d4)
                {
                    StartProcess(setting.ip1, "4", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip1 + " : 4")
                        {
                            p.Kill();
                        }
                    }
                }

                if (auto_d5)
                {
                    StartProcess(setting.ip2, "5", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip2 + " : 5")
                        {
                            p.Kill();
                        }
                    }
                }

                if (auto_d6)
                {
                    StartProcess(setting.ip2, "6", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip2 + " : 6")
                        {
                            p.Kill();
                        }
                    }
                }

                if (auto_d7)
                {
                    StartProcess(setting.ip2, "7", phase);
                }
                else
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle == setting.ip2 + " : 7")
                        {
                            p.Kill();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_plc.txt";
                File.AppendAllText(loca, DateTime.Now + " " + ex.Message + " " + Environment.NewLine);
            }
        }

        private void ShowDisplay(Label truck_license, Label truck_date, Label cane_type,Label truck_type, List<DataModel> datas ,string dump,bool isShow)
        {
            if (isShow)
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("th-TH");
                var data = datas.Where(w => w.dump_id == dump).FirstOrDefault();
                if (data != null)
                {
                    truck_license.Text = data.truck_number;
                    truck_date.Text = data.rfid_lastdate == DateTime.MinValue ? "" : data.rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type.Text = CaneType(data.cane_type);
                    truck_type.Text = truckType(data.truck_type);
                }
                else
                {
                    truck_license.Text = "";
                    truck_date.Text = "";
                    cane_type.Text = "";
                    truck_type.Text = "";
                }
            }
            else
            {
                truck_license.Text = "";
                truck_date.Text = "";
                cane_type.Text = "";
                truck_type.Text = "";
            }
        }
        //private void LastUpdateDisplay(Label labelDump, Label labelTruckLicense, Label labelCaneType,Label labelTruckType, Label labelLastDate)
        //{
        //    labelDump.BackColor = Color.FromArgb(47, 216, 54);
        //    labelTruckLicense.ForeColor = Color.Red;
        //    labelCaneType.ForeColor = Color.Red;
        //    labelTruckType.ForeColor = Color.Red;
        //    labelLastDate.ForeColor = Color.Red;
        //}
        //private void ClearLastDisplay(Label labelDump, Label labelTruckLicense, Label labelCaneType, Label labelTruckType, Label labelLastDate)
        //{
        //    labelDump.BackColor = Color.FromArgb(28, 184, 185);
        //    labelTruckLicense.ForeColor = Color.Black;
        //    labelCaneType.ForeColor = Color.Black;
        //    labelTruckType.ForeColor = Color.Black;
        //    labelLastDate.ForeColor = Color.Black;
        //}
        private void StartProcess(string server,string dump,string phase)
        {
            string title = server + " : " + dump;
            if (!windows_title.Any(a => a == title))
            {
                Process p = new Process();
                p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                p.StartInfo.Arguments = server + " " + dump + " " + phase;
                p.Start();
            }
        }
        private void StartProcessCommon(string dump,string phase)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
            p.StartInfo.Arguments = dump + " " + phase;
            p.Start();
            p.WaitForExit();
        }
        private string CaneType(int n)
        {
            if (n == -1)
            {
                return "";
            }
            List<string> canes_type = new List<string>();
            canes_type.Add("สดท่อน");
            canes_type.Add("ไฟไหม้ท่อน");
            canes_type.Add("สดลำ");
            canes_type.Add("ไฟไหม้ลำ");

            return canes_type[n];
        }
        private string truckType(int n)
        {
            if (n == -1)
            {
                return "";
            }
            List<string> trucks_type = new List<string>();
            trucks_type.Add("");
            trucks_type.Add("รถเดี่ยว");
            trucks_type.Add("พ่วงแม่");
            trucks_type.Add("พ่วงลูก");
            return trucks_type[n];
        }
        //private string weightType(int n)
        //{
        //    List<string> weights_type = new List<string>();
        //    weights_type.Add("");
        //    weights_type.Add("ชั่งรวม");
        //    weights_type.Add("ชั่งแยก");
        //    return weights_type[n];
        //}
        //private string queueStatus(int n)
        //{
        //    List<string> queues_status = new List<string>();
        //    queues_status.Add("");
        //    queues_status.Add("แจ้งคิวแล้ว");
        //    queues_status.Add("ชั่งเข้าแล้ว");
        //    queues_status.Add("ดัมพ์แล้ว");
        //    return queues_status[n];
        //}
    }
}
