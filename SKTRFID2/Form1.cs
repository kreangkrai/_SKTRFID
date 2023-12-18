using OMRON.Compolet.CIP;
using SKTRFID2.Interface;
using SKTRFID2.Model;
using SKTRFID2.Service;
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

namespace SKTRFID2
{
    public partial class Form1 : Form
    {
        private ISetting Setting;
        CJ2Compolet cj2;
        private IRFID RFID;
        List<string> windows_title;
        LabelModel labels;
        string phase = "2";
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
        }

        private void Cj2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                bool auto_d8 = (bool)cj2.ReadVariable("auto_dump08");
                bool auto_d9 = (bool)cj2.ReadVariable("auto_dump09");
                bool auto_d10 = (bool)cj2.ReadVariable("auto_dump10");
                bool auto_d11 = (bool)cj2.ReadVariable("auto_dump11");
                bool auto_d12 = (bool)cj2.ReadVariable("auto_dump12");
                bool auto_d13 = (bool)cj2.ReadVariable("auto_dump13");

                bool manual_d8 = (bool)cj2.ReadVariable("manual_dump08");
                bool manual_d9 = (bool)cj2.ReadVariable("manual_dump09");
                bool manual_d10 = (bool)cj2.ReadVariable("manual_dump10");
                bool manual_d11 = (bool)cj2.ReadVariable("manual_dump11");
                bool manual_d12 = (bool)cj2.ReadVariable("manual_dump12");
                bool manual_d13 = (bool)cj2.ReadVariable("manual_dump13");

                windows_title = new List<string>();
                Process[] process = Process.GetProcesses();
                foreach (var p in process)
                {
                    if (p.MainWindowTitle != "")
                    {
                        windows_title.Add(p.MainWindowTitle);
                    }
                }

                SettingModel setting = Setting.GetSetting();

                if (auto_d8)
                {
                    StartProcess(setting.ip1, "8", phase);
                }
                if (auto_d9)
                {
                    StartProcess(setting.ip1, "9", phase);
                }
                if (auto_d10)
                {
                    StartProcess(setting.ip1, "10", phase);
                }
                if (auto_d11)
                {
                    StartProcess(setting.ip1, "11", phase);
                }
                if (auto_d12)
                {
                    StartProcess(setting.ip2, "12", phase);
                }
                if (auto_d13)
                {
                    StartProcess(setting.ip2, "13", phase);
                }

                // Button Common
                if (manual_d8)
                {
                    cj2.WriteVariable("manual_dump08", false);
                    StartProcessCommon("8", phase);
                }

                if (manual_d9)
                {
                    cj2.WriteVariable("manual_dump09", false);
                    StartProcessCommon("9", phase);
                }

                if (manual_d10)
                {
                    cj2.WriteVariable("manual_dump10", false);
                    StartProcessCommon("10", phase);
                }

                if (manual_d11)
                {
                    cj2.WriteVariable("manual_dump11", false);
                    StartProcessCommon("11", phase);
                }

                if (manual_d12)
                {
                    cj2.WriteVariable("manual_dump12", false);
                    StartProcessCommon("12", phase);
                }

                if (manual_d13)
                {
                    cj2.WriteVariable("manual_dump13", false);
                    StartProcessCommon("13", phase);
                }

                List<DataModel> datas = RFID.GetDatas();
                if (datas.Count > 0)
                {
                    ShowDisplay(truck_license8, truck_date8, cane_type8, datas, "8");
                    ShowDisplay(truck_license9, truck_date9, cane_type9, datas, "9");
                    ShowDisplay(truck_license10, truck_date10, cane_type10, datas, "10");
                    ShowDisplay(truck_license11, truck_date11, cane_type11, datas, "11");
                    ShowDisplay(truck_license12, truck_date12, cane_type12, datas, "12");
                    ShowDisplay(truck_license13, truck_date13, cane_type13, datas, "13");

                    DataModel last_data = datas.OrderByDescending(o => o.rfid_lastdate).FirstOrDefault();

                    //Clear Label Dump Last Data Update
                    if (labels.labelDump != null)
                    {
                        ClearLastDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
                    }

                    if (last_data.dump_id == "8")
                    {
                        labels.labelDump = labelDump8;
                        labels.labelTruckLicense = truck_license8;
                        labels.labelCaneType = cane_type8;
                        labels.labelLastDate = truck_date8;
                        LastUpdateDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
                    }
                    if (last_data.dump_id == "9")
                    {
                        labels.labelDump = labelDump9;
                        labels.labelTruckLicense = truck_license9;
                        labels.labelCaneType = cane_type9;
                        labels.labelLastDate = truck_date9;
                        LastUpdateDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
                    }
                    if (last_data.dump_id == "10")
                    {
                        labels.labelDump = labelDump10;
                        labels.labelTruckLicense = truck_license10;
                        labels.labelCaneType = cane_type10;
                        labels.labelLastDate = truck_date10;
                        LastUpdateDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
                    }
                    if (last_data.dump_id == "11")
                    {
                        labels.labelDump = labelDump11;
                        labels.labelTruckLicense = truck_license11;
                        labels.labelCaneType = cane_type11;
                        labels.labelLastDate = truck_date11;
                        LastUpdateDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
                    }
                    if (last_data.dump_id == "12")
                    {
                        labels.labelDump = labelDump12;
                        labels.labelTruckLicense = truck_license12;
                        labels.labelCaneType = cane_type12;
                        labels.labelLastDate = truck_date12;
                        LastUpdateDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
                    }
                    if (last_data.dump_id == "13")
                    {
                        labels.labelDump = labelDump13;
                        labels.labelTruckLicense = truck_license13;
                        labels.labelCaneType = cane_type13;
                        labels.labelLastDate = truck_date13;
                        LastUpdateDisplay(labels.labelDump, labels.labelTruckLicense, labels.labelCaneType, labels.labelLastDate);
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
        private void ShowDisplay(Label truck_license, Label truck_date, Label cane_type, List<DataModel> datas, string dump)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("th-TH");
            var data = datas.Where(w => w.dump_id == dump).FirstOrDefault();
            if (data != null)
            {
                truck_license.Text = data.truck_number;
                truck_date.Text = data.rfid_lastdate.ToString("dd MMM yyyy HH:mm:ss", culture);
                cane_type.Text = CaneType(data.cane_type);
            }
            else
            {
                truck_license.Text = "";
                truck_date.Text = "";
                cane_type.Text = "";
            }
        }
        private void LastUpdateDisplay(Label labelDump, Label labelTruckLicense, Label labelCaneType, Label labelLastDate)
        {
            labelDump.BackColor = Color.FromArgb(47, 216, 54);
            labelTruckLicense.ForeColor = Color.Red;
            labelCaneType.ForeColor = Color.Red;
            labelLastDate.ForeColor = Color.Red;
        }
        private void ClearLastDisplay(Label labelDump, Label labelTruckLicense, Label labelCaneType, Label labelLastDate)
        {
            labelDump.BackColor = Color.FromArgb(28, 184, 185);
            labelTruckLicense.ForeColor = Color.Black;
            labelCaneType.ForeColor = Color.Black;
            labelLastDate.ForeColor = Color.Black;
        }
        private void StartProcess(string server, string dump, string phase)
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
        private void StartProcessCommon(string dump, string phase)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Server\\SKTRFIDCOMMON.exe";
            p.StartInfo.Arguments = dump + " " + phase;
            p.Start();
            p.WaitForExit();
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
    }
}
