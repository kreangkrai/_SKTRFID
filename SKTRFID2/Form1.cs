using OMRON.Compolet.CIP;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using SKTRFIDLIBRARY.Service;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFID2
{
    public partial class Form1 : Form
    {
        private ISetting Setting;
        CJ2Compolet cj2;
        private IRFID RFID;
        LabelModel labels;
        string phase = "2";
        bool isManual = false;
        List<bool> isManuals;
        SettingModel setting;
        Process[] process;
        public Form1()
        {
            InitializeComponent();
            RFID = new RFIDService(2);
            labels = new LabelModel();
            Setting = new SettingService(2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DataModel> datas = RFID.GetDatasByAreaYear(setting.area_id, setting.crop_year);
            if (datas.Count < 1)
            {
                //Insert New RFID Area,Year DUMP 8-13
                List<DataModel> data_new = new List<DataModel>();
                for (int i = 8; i <= 13; i++)
                {
                    DataModel d = new DataModel()
                    {
                        dump_id = i.ToString(),
                        allergen = "No",
                        area_id = setting.area_id,
                        crop_year = setting.crop_year,
                        barcode = "",
                        rfid = "",
                        cane_type = -1,
                        farmer_name = "",
                        queue_status = -1,
                        truck_number = "",
                        truck_type = -1,
                        weight_type = -1,
                        rfid_lastdate = DateTime.Now

                    };
                    data_new.Add(d);
                }
                string message = RFID.InsertRFID(data_new);
            }

            setting = Setting.GetSetting();

            cj2 = new CJ2Compolet();
            cj2.HeartBeatTimer = 3000;
            cj2.ConnectionType = ConnectionType.UCMM;
            cj2.UseRoutePath = false;
            cj2.PeerAddress = setting.ip_plc;
            cj2.LocalPort = 2;
            cj2.OnHeartBeatTimer += Cj2_OnHeartBeatTimer;
            cj2.Active = true;

            isManuals = new List<bool>();
        }

        private void Cj2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                List<DataModel> datas = RFID.GetDatas(setting.crop_year);

                //Read Barcode
                bool b_D8 = true;
                bool b_D9 = true;
                bool b_D10 = true;
                bool b_D11 = true;
                bool b_D12 = true;
                bool b_D13 = true;

                string bar_D8 = (string)cj2.ReadVariable("Bar_ID8");
                string bar_D9 = (string)cj2.ReadVariable("Bar_ID9");
                string bar_D10 = (string)cj2.ReadVariable("Bar_ID10");
                string bar_D11 = (string)cj2.ReadVariable("Bar_ID11");
                string bar_D12 = (string)cj2.ReadVariable("Bar_ID12");
                string bar_D13 = (string)cj2.ReadVariable("Bar_ID13");

                b_D8 = bar_D8 == "" ? false : true;
                b_D9 = bar_D9 == "" ? false : true;
                b_D10 = bar_D10 == "" ? false : true;
                b_D11 = bar_D11 == "" ? false : true;
                b_D12 = bar_D12 == "" ? false : true;
                b_D13 = bar_D13 == "" ? false : true;


                if (datas.Count > 0)
                {
                    ShowDisplay(truck_license8, truck_date8, cane_type8, truck_type8, datas, "8", b_D8);
                    ShowDisplay(truck_license9, truck_date9, cane_type9, truck_type9, datas, "9", b_D9);
                    ShowDisplay(truck_license10, truck_date10, cane_type10, truck_type10, datas, "10", b_D10);
                    ShowDisplay(truck_license11, truck_date11, cane_type11, truck_type11, datas, "11", b_D11);
                    ShowDisplay(truck_license12, truck_date12, cane_type12, truck_type12, datas, "12", b_D12);
                    ShowDisplay(truck_license13, truck_date13, cane_type13, truck_type13, datas, "13", b_D13);
                }

                bool manual_d8 = (bool)cj2.ReadVariable("MN_SCAN_D8");
                bool manual_d9 = (bool)cj2.ReadVariable("MN_SCAN_D9");
                bool manual_d10 = (bool)cj2.ReadVariable("MN_SCAN_D10");
                bool manual_d11 = (bool)cj2.ReadVariable("MN_SCAN_D11");
                bool manual_d12 = (bool)cj2.ReadVariable("MN_SCAN_D12");
                bool manual_d13 = (bool)cj2.ReadVariable("MN_SCAN_D13");

                process = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("COMMON DUMP")).ToArray();

                if (manual_d8)
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 8")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d8);
                    cj2.WriteVariable("MN_SCAN_D8", false);
                    StartProcess("COMMON", setting.ip2, "8", phase);
                }

                if (manual_d9)
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 9")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d9);
                    cj2.WriteVariable("MN_SCAN_D9", false);
                    StartProcess("COMMON", setting.ip2, "9", phase);
                }

                if (manual_d10)
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 10")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d10);
                    cj2.WriteVariable("MN_SCAN_D10", false);
                    StartProcess("COMMON", setting.ip2, "10", phase);
                }

                if (manual_d11)
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 11")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d11);
                    cj2.WriteVariable("MN_SCAN_D11", false);
                    StartProcess("COMMON", setting.ip2, "11", phase);
                }

                if (manual_d12)
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 12")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d12);
                    cj2.WriteVariable("MN_SCAN_D12", false);
                    StartProcess("COMMON", setting.ip2, "12", phase);
                }

                if (manual_d13)
                {
                    foreach (var p in process)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 13")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d13);
                    cj2.WriteVariable("MN_SCAN_D13", false);
                    StartProcess("COMMON", setting.ip2, "13", phase);
                }


                bool auto_d8 = (bool)cj2.ReadVariable("Call_D8");
                bool auto_d9 = (bool)cj2.ReadVariable("Call_D9");
                bool auto_d10 = (bool)cj2.ReadVariable("Call_D10");
                bool auto_d11 = (bool)cj2.ReadVariable("Call_D11");
                bool auto_d12 = (bool)cj2.ReadVariable("Call_D12");
                bool auto_d13 = (bool)cj2.ReadVariable("Call_D13");

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

                //Check Manual except kill program ; false
                isManual = isManuals.Any(a => a == true);
                if (!isManual)
                {
                    process = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("AUTO DUMP")).ToArray();

                    setting = Setting.GetSetting();

                    if (auto_d8) // Detect AUTO 8
                    {
                        StartProcess("AUTO", setting.ip1, "8", phase);
                    }
                    else // NOT Detect AUTO 8
                    {
                        foreach (var p in process)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 8")
                            {
                                p.Kill();
                            }
                        }
                    }

                    if (auto_d9)
                    {
                        StartProcess("AUTO", setting.ip1, "9", phase);
                    }
                    else
                    {
                        foreach (var p in process)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 9")
                            {
                                p.Kill();
                            }
                        }
                    }

                    if (auto_d10)
                    {
                        StartProcess("AUTO", setting.ip1, "10", phase);
                    }
                    else
                    {
                        foreach (var p in process)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 10")
                            {
                                p.Kill();
                            }
                        }
                    }

                    if (auto_d11)
                    {
                        StartProcess("AUTO", setting.ip1, "11", phase);
                    }
                    else
                    {
                        foreach (var p in process)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 11")
                            {
                                p.Kill();
                            }
                        }
                    }

                    if (auto_d12)
                    {
                        StartProcess("AUTO", setting.ip2, "12", phase);
                    }
                    else
                    {
                        foreach (var p in process)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 12")
                            {
                                p.Kill();
                            }
                        }
                    }

                    if (auto_d13)
                    {
                        StartProcess("AUTO", setting.ip2, "13", phase);
                    }
                    else
                    {
                        foreach (var p in process)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 13")
                            {
                                p.Kill();
                            }
                        }
                    }
                }

                isManuals = new List<bool>();
            }

            catch (Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_plc.txt";
                File.AppendAllText(loca, DateTime.Now + " " + ex.Message + " " + Environment.NewLine);
            }
            finally
            {
                isManuals = new List<bool>();
            }
        }           
        private void ShowDisplay(Label truck_license, Label truck_date, Label cane_type, Label truck_type, List<DataModel> datas, string dump, bool isShow)
        {
            if (isShow)
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("th-TH");
                var data = datas.Where(w => w.dump_id == dump).FirstOrDefault();
                if (data != null)
                {
                    int check_trailer_truck = data.truck_number.IndexOf('/');
                    if (check_trailer_truck == -1) // truck
                    {
                        truck_license.Text = data.truck_number;
                    }
                    else // trailer truck
                    {
                        truck_license.Text = data.truck_number.Substring(0, check_trailer_truck) +
                            Environment.NewLine +
                            data.truck_number.Substring(check_trailer_truck + 1, data.truck_number.Length - (check_trailer_truck + 1));
                    }
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
        //private void LastUpdateDisplay(Label labelDump, Label labelTruckLicense, Label labelCaneType, Label labelLastDate)
        //{
        //    labelDump.BackColor = Color.FromArgb(47, 216, 54);
        //    labelTruckLicense.ForeColor = Color.Red;
        //    labelCaneType.ForeColor = Color.Red;
        //    labelLastDate.ForeColor = Color.Red;
        //}
        //private void ClearLastDisplay(Label labelDump, Label labelTruckLicense, Label labelCaneType, Label labelLastDate)
        //{
        //    labelDump.BackColor = Color.FromArgb(28, 184, 185);
        //    labelTruckLicense.ForeColor = Color.Black;
        //    labelCaneType.ForeColor = Color.Black;
        //    labelLastDate.ForeColor = Color.Black;
        //}
        private void StartProcess(string mode,string server, string dump, string phase)
        {
            // Check duplicate Program
            List<string> windows_titles = new List<string>();
            Process[] process;
            if (mode == "AUTO") // AUTO MODE
            {
                process = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("AUTO DUMP")).ToArray();
                foreach (var p in process)
                {
                    windows_titles.Add(p.MainWindowTitle);
                }
            }
            else //COMMON MODE
            {
                process = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("COMMON DUMP")).ToArray();
                foreach (var p in process)
                {
                    windows_titles.Add(p.MainWindowTitle);
                }
            }

            string title = mode + " DUMP " + dump;
            if (!windows_titles.Any(a => a == title))
            {
                Process p = new Process();
                p.StartInfo.FileName = "Server\\SKTRFIDSERVER.exe";
                p.StartInfo.Arguments = mode + " " + server + " " + dump + " " + phase;
                p.Start();
            }
        }
        //private void StartProcessCommon(string dump, string phase)
        //{
        //    Process p = new Process();
        //    p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
        //    p.StartInfo.Arguments = dump + " " + phase;
        //    p.Start();
        //    p.WaitForExit();
        //}
        private string CaneType(int n)
        {
            if (n == -1)
            {
                return "";
            }
            List<string> canes_type = new List<string>();           
            canes_type.Add("สดลำ");
            canes_type.Add("ไฟไหม้ลำ");
            canes_type.Add("สดท่อน");
            canes_type.Add("ไฟไหม้ท่อน");

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
    }
    public class LabelModel
    {
        public Label labelDump { get; set; }
        public Label labelTruckLicense { get; set; }
        public Label labelCaneType { get; set; }
        public Label labelTruckType { get; set; }
        public Label labelLastDate { get; set; }
    }
}
