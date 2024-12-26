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
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SKTRFID1
{
    public partial class Form1 : Form
    {
        private ISetting Setting;
        CJ2Compolet cj2;
        private IRFID RFID;
        private ICodeType CodeType;
        LabelModel labels;
        string phase = "1";
        bool isManual = false;
        List<bool> isManuals;
        SettingModel setting;
        private IAPI API;

        string last_queue = string.Empty;
    
        public Form1()
        {
            InitializeComponent();
            RFID = new RFIDService(1);
            labels = new LabelModel();
            Setting = new SettingService(1);
            setting = Setting.GetSetting();
            API = new APIService();
            CodeType = new CodeTypeService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DataModel> datas = RFID.GetDatasByAreaYear(setting.area_id, setting.crop_year);
            if (datas.Count < 1)
            {
                //Insert New RFID Area,Year DUMP 1-7
                List<DataModel> data_new = new List<DataModel>();
                for (int i = 1; i <= 7; i++)
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

            try
            {
                cj2 = new CJ2Compolet();
                cj2.HeartBeatTimer = 3000;
                cj2.ConnectionType = ConnectionType.UCMM;
                cj2.UseRoutePath = false;
                cj2.PeerAddress = setting.ip_plc;
                cj2.LocalPort = 2;
                cj2.ReceiveTimeLimit = (long)2000;
                cj2.OnHeartBeatTimer += Cj3_OnHeartBeatTimer;
                cj2.Active = true;

            }
            catch (Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_plc.txt";
                File.AppendAllText(loca, DateTime.Now + " SKTRFID2 " + ex.Message + " " + Environment.NewLine);
            }
            isManuals = new List<bool>();
        }


        private void Cj3_OnHeartBeatTimer(object sender, EventArgs e)
        {
            try
            {
                List<DataModel> datas = RFID.GetDatas(setting.crop_year);

                string queue_trig = (string)cj2.ReadVariable("Queue_Running");

                if (last_queue != queue_trig )
                {
                    bool trig_D1 = (bool)cj2.ReadVariable("Trig_D1");
                    bool trig_D2 = (bool)cj2.ReadVariable("Trig_D2");
                    bool trig_D3 = (bool)cj2.ReadVariable("Trig_D3");
                    bool trig_D4 = (bool)cj2.ReadVariable("Trig_D4");
                    bool trig_D5 = (bool)cj2.ReadVariable("Trig_D5");
                    bool trig_D6 = (bool)cj2.ReadVariable("Trig_D6");
                    bool trig_D7 = (bool)cj2.ReadVariable("Trig_D7");


                    DataModel data_trig = new DataModel();
                    if (trig_D1)
                    {
                        data_trig = datas.Where(w => w.dump_id == "1").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 1);
                        }
                    }
                    else if (trig_D2)
                    {
                        data_trig = datas.Where(w => w.dump_id == "2").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 2);
                        }
                    }
                    else if(trig_D3)
                    {
                        data_trig = datas.Where(w => w.dump_id == "3").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 3);
                        }
                    }
                    else if (trig_D4)
                    {
                        data_trig = datas.Where(w => w.dump_id == "4").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 4);
                        }
                    }
                    else if (trig_D5)
                    {
                        data_trig = datas.Where(w => w.dump_id == "5").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 5);
                        }
                    }
                    else if (trig_D6)
                    {
                        data_trig = datas.Where(w => w.dump_id == "6").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 6);
                        }
                    }
                    else if (trig_D7)
                    {
                        data_trig = datas.Where(w => w.dump_id == "7").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 1, 7);
                        }
                    }                   
                }
                last_queue = queue_trig;

                //Read Barcode
                bool b_D1 = true;
                bool b_D2 = true;
                bool b_D3 = true;
                bool b_D4 = true;
                bool b_D5 = true;
                bool b_D6 = true;
                bool b_D7 = true;
                string bar_D1 = (string)cj2.ReadVariable("Bar_ID1");
                b_D1 = bar_D1 == "" ? false : true;
                string bar_D2 = (string)cj2.ReadVariable("Bar_ID2");
                b_D2 = bar_D2 == "" ? false : true;
                string bar_D3 = (string)cj2.ReadVariable("Bar_ID3");
                b_D3 = bar_D3 == "" ? false : true;
                string bar_D4 = (string)cj2.ReadVariable("Bar_ID4");
                b_D4 = bar_D4 == "" ? false : true;
                string bar_D5 = (string)cj2.ReadVariable("Bar_ID5");
                b_D5 = bar_D5 == "" ? false : true;
                string bar_D6 = (string)cj2.ReadVariable("Bar_ID6");
                b_D6 = bar_D6 == "" ? false : true;
                string bar_D7 = (string)cj2.ReadVariable("Bar_ID7");
                b_D7 = bar_D7 == "" ? false : true;

                
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
                
                Process[] process_common = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("COMMON DUMP")).ToArray();
                
                bool manual_d1 = (bool)cj2.ReadVariable("MN_SCAN_D1");
                if (manual_d1)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 1")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d1);
                    cj2.WriteVariable("MN_SCAN_D1", false);
                    StartProcess("COMMON", setting.ip2, "1", phase);
                }

                bool manual_d2 = (bool)cj2.ReadVariable("MN_SCAN_D2");
                if (manual_d2)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 2")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d2);
                    cj2.WriteVariable("MN_SCAN_D2", false);
                    StartProcess("COMMON", setting.ip2, "2", phase);
                }

                bool manual_d3 = (bool)cj2.ReadVariable("MN_SCAN_D3");
                if (manual_d3)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 3")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d3);
                    cj2.WriteVariable("MN_SCAN_D3", false);
                    StartProcess("COMMON", setting.ip2, "3", phase);
                }

                bool manual_d4 = (bool)cj2.ReadVariable("MN_SCAN_D4");
                if (manual_d4)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 4")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d4);
                    cj2.WriteVariable("MN_SCAN_D4", false);
                    StartProcess("COMMON", setting.ip2, "4", phase);
                }

                bool manual_d5 = (bool)cj2.ReadVariable("MN_SCAN_D5");
                if (manual_d5)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 5")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d5);
                    cj2.WriteVariable("MN_SCAN_D5", false);
                    StartProcess("COMMON", setting.ip2, "5", phase);
                }

                bool manual_d6 = (bool)cj2.ReadVariable("MN_SCAN_D6");
                if (manual_d6)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 6")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d6);
                    cj2.WriteVariable("MN_SCAN_D6", false);
                    StartProcess("COMMON", setting.ip2, "6", phase);
                }

                bool manual_d7 = (bool)cj2.ReadVariable("MN_SCAN_D7");
                if (manual_d7)
                {
                    foreach (var p in process_common)
                    {
                        if (p.MainWindowTitle != "COMMON DUMP 7")
                        {
                            p.Kill();
                        }
                    }

                    isManuals.Add(manual_d7);
                    cj2.WriteVariable("MN_SCAN_D7", false);
                    StartProcess("COMMON", setting.ip2, "7", phase);
                }

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
                    Process[] process_auto = Process.GetProcesses().Where(w=>w.MainWindowTitle.Contains("AUTO DUMP")).ToArray();

                    setting = Setting.GetSetting();

                    bool auto_d1 = (bool)cj2.ReadVariable("Call_D1");                  
                    if (auto_d1) // Detect AUTO 1
                    {
                        StartProcess("AUTO",setting.ip1, "1", phase);
                    }
                    else // NOT Detect AUTO 1
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 1")
                            {
                                p.Kill();
 
                            }
                        }
                    }

                    bool auto_d2 = (bool)cj2.ReadVariable("Call_D2");
                    if (auto_d2)
                    {
                        StartProcess("AUTO", setting.ip1, "2", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 2")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d3 = (bool)cj2.ReadVariable("Call_D3");
                    if (auto_d3)
                    {
                        StartProcess("AUTO", setting.ip1, "3", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 3")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d4 = (bool)cj2.ReadVariable("Call_D4");
                    if (auto_d4)
                    {
                        StartProcess("AUTO", setting.ip1, "4", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 4")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d5 = (bool)cj2.ReadVariable("Call_D5");
                    if (auto_d5)
                    {
                        StartProcess("AUTO", setting.ip2, "5", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 5")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d6 = (bool)cj2.ReadVariable("Call_D6");
                    if (auto_d6)
                    {
                        StartProcess("AUTO", setting.ip2, "6", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 6")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d7 = (bool)cj2.ReadVariable("Call_D7");
                    if (auto_d7)
                    {
                        StartProcess("AUTO", setting.ip2, "7", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 7")
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
                File.AppendAllText(loca, DateTime.Now + " SKTRFID1 " + ex.Message + " " + Environment.NewLine);
            }
            finally
            {
                isManuals = new List<bool>();
            }
        }

        private async void SendData(int queue, DataModel rfid, int phase, int dump)
        {
            try
            {

                bool CheckInternet = API.checkInternet();
                //Check Local Internet
                if (CheckInternet)  // Online Read data from api
                {
                    //Insert Data to API
                    if (rfid.barcode != "")
                    {
                        DataUpdateModel dataInsert = await API.InsertDataAPI(rfid.area_id, rfid.crop_year, rfid.barcode, phase, dump, "ADD");
                        if (dataInsert.Data[0].StatusDb != 0) // Send Complete
                        {
                            string loca = @"D:\log_api.txt";
                            File.AppendAllText(loca, DateTime.Now + " Barcode " + rfid.barcode + " Queue " + queue + " DUMP " + dump + " " + " Code " + dataInsert.Data[0].StatusDb + " " + Environment.NewLine);
                          
                        }
                    }
                }
                else
                {
                    string path = Directory.GetCurrentDirectory();
                    try
                    {
                        SoundPlayer dump_wave_file = new SoundPlayer();
                        dump_wave_file.SoundLocation = Path.Combine(path, $"VOICE_DUMP\\d{dump}.wav");
                        dump_wave_file.PlaySync();
                    }
                    catch
                    {

                    }
                    try
                    {
                        SoundPlayer dump_wave_file = new SoundPlayer();
                        dump_wave_file.SoundLocation = Path.Combine(path, $"VOICE_DUMP\\noserver.wav");
                        dump_wave_file.PlaySync();
                    }
                    catch
                    {

                    }
                }

                //Insert Data RFID Log

                DateTime now = DateTime.Now;
                DataModel data_rfid = new DataModel()
                {
                    queue = queue,
                    dump_id = dump.ToString(),
                    area_id = rfid.area_id,
                    crop_year = rfid.crop_year,
                    allergen = rfid.allergen,
                    truck_number = rfid.truck_number,
                    farmer_name = rfid.farmer_name,
                    barcode = rfid.barcode,
                    cane_type = Convert.ToInt32(rfid.cane_type),
                    weight_type = Convert.ToInt32(rfid.weight_type),
                    truck_type = Convert.ToInt32(rfid.truck_type),
                    rfid = rfid.rfid,
                    queue_status = 3,
                    rfid_lastdate = now
                };

                string message_insert = RFID.InsertRFIDLog(data_rfid);

                //Update Clear Barcode Data to Local Database
                DataModel dataDump = new DataModel()
                {
                    queue = queue,
                    dump_id = dump.ToString(),
                    area_id = rfid.area_id,
                    crop_year = rfid.crop_year,
                    allergen = rfid.allergen,
                    truck_number = rfid.truck_number,
                    farmer_name = rfid.farmer_name,
                    barcode = "000000",
                    cane_type = Convert.ToInt32(rfid.cane_type),
                    weight_type = Convert.ToInt32(rfid.weight_type),
                    truck_type = Convert.ToInt32(rfid.truck_type),
                    rfid = rfid.rfid,
                    queue_status = 3,
                    rfid_lastdate = now
                };
                string message_update = RFID.UpdateRFID(dataDump);
            }
            catch (Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_net.txt";
                File.AppendAllText(loca, DateTime.Now + " SKTRFID2 " + ex.Message + " " + Environment.NewLine);
            }
        }
        private void ShowDisplay(Label truck_license, Label truck_date, Label cane_type,Label truck_type, List<DataModel> datas ,string dump,bool isShow)
        {
            try
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
                        cane_type.Text = CodeType.CaneType(data.cane_type);
                        truck_type.Text = CodeType.truckType(data.truck_type);
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
            catch (Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_display.txt";
                File.AppendAllText(loca, DateTime.Now + " SKTRFID2 " + ex.Message + " " + Environment.NewLine);
            }
        }
        private void StartProcess(string mode, string server, string dump, string phase)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cj2.IsConnected)
            {
                cj2.Active = false;
                cj2.Dispose();
            }
            Application.Exit();
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
