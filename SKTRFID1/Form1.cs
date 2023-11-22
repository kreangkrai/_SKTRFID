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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaClient;
namespace SKTRFID1
{
    public partial class Form1 : Form
    {
        CJ2Compolet cj2;
        private IRFID RFID;
        public Form1()
        {
            InitializeComponent();
            RFID = new RFIDService();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            cj2 = new CJ2Compolet();
            cj2.HeartBeatTimer = 3000;
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = "192.168.1.250";
            cj2.LocalPort = 2;
            cj2.OnHeartBeatTimer += Cj2_OnHeartBeatTimer;
            cj2.Active = true;
        }
        private void Cj2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("th-TH");

                bool auto_d1 = (bool)cj2.ReadVariable("auto_dump01");
                bool auto_d2 = (bool)cj2.ReadVariable("auto_dump02");
                bool auto_d3 = (bool)cj2.ReadVariable("auto_dump03");
                bool auto_d4 = (bool)cj2.ReadVariable("auto_dump04");
                bool auto_d5 = (bool)cj2.ReadVariable("auto_dump05");
                bool auto_d6 = (bool)cj2.ReadVariable("auto_dump06");
                bool auto_d7 = (bool)cj2.ReadVariable("auto_dump07");

                bool manual_d1 = (bool)cj2.ReadVariable("manual_dump01");
                bool manual_d2 = (bool)cj2.ReadVariable("manual_dump02");
                bool manual_d3 = (bool)cj2.ReadVariable("manual_dump03");
                bool manual_d4 = (bool)cj2.ReadVariable("manual_dump04");
                bool manual_d5 = (bool)cj2.ReadVariable("manual_dump05");
                bool manual_d6 = (bool)cj2.ReadVariable("manual_dump06");
                bool manual_d7 = (bool)cj2.ReadVariable("manual_dump07");
                if (auto_d1)
                {
                    cj2.WriteVariable("auto_dump01", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.253 1";
                    p.Start();
                    //p.WaitForExit();
                    

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON1" + " " + Environment.NewLine);
                }
                if (auto_d2)
                {
                    cj2.WriteVariable("auto_dump02", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.253 2";
                    p.Start();
                    //p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON2" + " " + Environment.NewLine);
                }
                if (auto_d3)
                {
                    cj2.WriteVariable("auto_dump03", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.253 3";
                    p.Start();
                    //p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON3" + " " + Environment.NewLine);
                }
                if (auto_d4)
                {
                    cj2.WriteVariable("auto_dump04", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.253 4";
                    p.Start();
                    //p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON4" + " " + Environment.NewLine);
                }
                if (auto_d5)
                {
                    cj2.WriteVariable("auto_dump05", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.254 5";
                    p.Start();
                    //p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON5" + " " + Environment.NewLine);
                }
                if (auto_d6)
                {
                    cj2.WriteVariable("auto_dump06", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.254 6";
                    p.Start();
                    //p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON6" + " " + Environment.NewLine);
                }

                if (auto_d7)
                {
                    cj2.WriteVariable("auto_dump07", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                    p.StartInfo.Arguments = "192.168.1.254 7";
                    p.Start();
                    //p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "BUTTON7" + " " + Environment.NewLine);
                }

                if (manual_d1)
                {
                    cj2.WriteVariable("manual_dump01", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "1";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON1" + " " + Environment.NewLine);
                }

                if (manual_d2)
                {
                    cj2.WriteVariable("manual_dump02", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "2";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON2" + " " + Environment.NewLine);
                }

                if (manual_d3)
                {
                    cj2.WriteVariable("manual_dump03", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "3";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON3" + " " + Environment.NewLine);
                }

                if (manual_d4)
                {
                    cj2.WriteVariable("manual_dump04", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "4";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON4" + " " + Environment.NewLine);
                }

                if (manual_d5)
                {
                    cj2.WriteVariable("manual_dump05", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "5";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON5" + " " + Environment.NewLine);
                }

                if (manual_d6)
                {
                    cj2.WriteVariable("manual_dump06", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "6";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON6" + " " + Environment.NewLine);
                }

                if (manual_d7)
                {
                    cj2.WriteVariable("manual_dump07", false);
                    Process p = new Process();
                    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
                    p.StartInfo.Arguments = "7";
                    p.Start();
                    p.WaitForExit();

                    //Weite Data to text file
                    string loca = @"D:\log_plc.txt";
                    File.AppendAllText(loca, DateTime.Now + " " + "MANUAL BUTTON7" + " " + Environment.NewLine);
                }

                List<DataModel> datas = RFID.GetDatas();
                if (datas.Count > 0)
                {
                    truck_license1.Text = datas[0].truck_number;
                    truck_date1.Text = datas[0].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type1.Text = CaneType(datas[0].cane_type);
                    truck_type1.Text = truckType(datas[0].truck_type);
                    weight_type1.Text = weightType(datas[0].weight_type);
                    queue_status1.Text = queueStatus(datas[0].queue_status);

                    truck_license2.Text = datas[1].truck_number;
                    truck_date2.Text = datas[1].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type2.Text = CaneType(datas[1].cane_type);
                    truck_type2.Text = truckType(datas[1].truck_type);
                    weight_type2.Text = weightType(datas[1].weight_type);
                    queue_status2.Text = queueStatus(datas[1].queue_status);

                    truck_license3.Text = datas[2].truck_number;
                    truck_date3.Text = datas[2].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type3.Text = CaneType(datas[2].cane_type);
                    truck_type3.Text = truckType(datas[2].truck_type);
                    weight_type3.Text = weightType(datas[2].weight_type);
                    queue_status3.Text = queueStatus(datas[2].queue_status);

                    truck_license4.Text = datas[3].truck_number;
                    truck_date4.Text = datas[3].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type4.Text = CaneType(datas[3].cane_type);
                    truck_type4.Text = truckType(datas[3].truck_type);
                    weight_type4.Text = weightType(datas[3].weight_type);
                    queue_status4.Text = queueStatus(datas[3].queue_status);

                    truck_license5.Text = datas[4].truck_number;
                    truck_date5.Text = datas[4].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type5.Text = CaneType(datas[4].cane_type);
                    truck_type5.Text = truckType(datas[4].truck_type);
                    weight_type5.Text = weightType(datas[4].weight_type);
                    queue_status5.Text = queueStatus(datas[4].queue_status);

                    truck_license6.Text = datas[5].truck_number;
                    truck_date6.Text = datas[5].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type6.Text = CaneType(datas[5].cane_type);
                    truck_type6.Text = truckType(datas[5].truck_type);
                    weight_type6.Text = weightType(datas[5].weight_type);
                    queue_status6.Text = queueStatus(datas[5].queue_status);

                    truck_license7.Text = datas[6].truck_number;
                    truck_date7.Text = datas[6].rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                    cane_type7.Text = CaneType(datas[6].cane_type);
                    truck_type7.Text = truckType(datas[6].truck_type);
                    weight_type7.Text = weightType(datas[6].weight_type);
                    queue_status7.Text = queueStatus(datas[6].queue_status);
                }

            }
            catch (Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_plc.txt";
                File.AppendAllText(loca, DateTime.Now + " " + ex.Message + " " + Environment.NewLine);
            }
        }
        private string CaneType(int n)
        {
            List<string> canes_type = new List<string>();
            canes_type.Add("สดท่อน");
            canes_type.Add("ไฟไหม้ท่อน");
            canes_type.Add("สดลำ");
            canes_type.Add("ไฟไหม้ลำ");

            return canes_type[n];
        }
        private string truckType(int n)
        {
            List<string> trucks_type = new List<string>();
            trucks_type.Add("รถเดี่ยว");
            trucks_type.Add("พ่วงแม่");
            trucks_type.Add("พ่วงลูก");
            return trucks_type[n];
        }
        private string weightType(int n)
        {
            List<string> weights_type = new List<string>();
            weights_type.Add("ชั่งรวม");
            weights_type.Add("ชั่งแยก");
            return weights_type[n];
        }
        private string queueStatus(int n)
        {
            List<string> queues_status = new List<string>();
            queues_status.Add("แจ้งคิวแล้ว");
            queues_status.Add("ชั่งเข้าแล้ว");
            queues_status.Add("ดัมพ์แล้ว");
            return queues_status[n];
        }
    }
}
