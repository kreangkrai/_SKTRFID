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
        private IAPI API;
        private ICodeType CodeType;
        string last_queue = string.Empty;

        public Form1()
        {
            InitializeComponent();
            RFID = new RFIDService(2);
            labels = new LabelModel();
            Setting = new SettingService(2);
            setting = Setting.GetSetting();
            API = new APIService();
            CodeType = new CodeTypeService();
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
            catch(Exception ex)
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

                if (last_queue != queue_trig)
                {
                    bool trig_D8 = (bool)cj2.ReadVariable("Trig_D8");
                    bool trig_D9 = (bool)cj2.ReadVariable("Trig_D9");
                    bool trig_D10 = (bool)cj2.ReadVariable("Trig_D10");
                    bool trig_D11 = (bool)cj2.ReadVariable("Trig_D11");
                    bool trig_D12 = (bool)cj2.ReadVariable("Trig_D12");
                    bool trig_D13 = (bool)cj2.ReadVariable("Trig_D13");

                    DataModel data_trig = new DataModel();
                    if (trig_D8)
                    {
                        data_trig = datas.Where(w => w.dump_id == "8").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 2, 8);
                        }
                    }
                    else if (trig_D9)
                    {
                        data_trig = datas.Where(w => w.dump_id == "9").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 2, 9);
                        }
                    }
                    else if (trig_D10)
                    {
                        data_trig = datas.Where(w => w.dump_id == "10").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 2, 10);
                        }
                    }
                    else if (trig_D11)
                    {
                        data_trig = datas.Where(w => w.dump_id == "11").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 2, 11);
                        }
                    }
                    else if (trig_D12)
                    {
                        data_trig = datas.Where(w => w.dump_id == "12").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 2, 12);
                        }
                    }
                    else if (trig_D13)
                    {
                        data_trig = datas.Where(w => w.dump_id == "13").FirstOrDefault();
                        if (data_trig != null)
                        {
                            SendData(Int32.Parse(queue_trig), data_trig, 2, 13);
                        }
                    }  
                }
                last_queue = queue_trig;

                //Read Barcode
                bool b_D8 = true;
                bool b_D9 = true;
                bool b_D10 = true;
                bool b_D11 = true;
                bool b_D12 = true;
                bool b_D13 = true;
       
                string bar_D8 = (string)cj2.ReadVariable("Bar_ID8");
                b_D8 = bar_D8 == "" ? false : true;
                string bar_D9 = (string)cj2.ReadVariable("Bar_ID9");
                b_D9 = bar_D9 == "" ? false : true;
                string bar_D10 = (string)cj2.ReadVariable("Bar_ID10");
                b_D10 = bar_D10 == "" ? false : true;
                string bar_D11 = (string)cj2.ReadVariable("Bar_ID11");
                b_D11 = bar_D11 == "" ? false : true;
                string bar_D12 = (string)cj2.ReadVariable("Bar_ID12");
                b_D12 = bar_D12 == "" ? false : true;
                string bar_D13 = (string)cj2.ReadVariable("Bar_ID13");
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
                
                Process[] process_common = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("COMMON DUMP")).ToArray();
                
                bool manual_d8 = (bool)cj2.ReadVariable("MN_SCAN_D8");
                if (manual_d8)
                {
                    foreach (var p in process_common)
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

                bool manual_d9 = (bool)cj2.ReadVariable("MN_SCAN_D9");
                if (manual_d9)
                {
                    foreach (var p in process_common)
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

                bool manual_d10 = (bool)cj2.ReadVariable("MN_SCAN_D10");
                if (manual_d10)
                {
                    foreach (var p in process_common)
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

                bool manual_d11 = (bool)cj2.ReadVariable("MN_SCAN_D11");
                if (manual_d11)
                {
                    foreach (var p in process_common)
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

                bool manual_d12 = (bool)cj2.ReadVariable("MN_SCAN_D12");
                if (manual_d12)
                {
                    foreach (var p in process_common)
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

                bool manual_d13 = (bool)cj2.ReadVariable("MN_SCAN_D13");
                if (manual_d13)
                {
                    foreach (var p in process_common)
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
                    Process[] process_auto = Process.GetProcesses().Where(w => w.MainWindowTitle.Contains("AUTO DUMP")).ToArray();

                    setting = Setting.GetSetting();

                    bool auto_d8 = (bool)cj2.ReadVariable("Call_D8");
                    if (auto_d8) // Detect AUTO 8
                    {
                        StartProcess("AUTO", setting.ip1, "8", phase);
                    }
                    else // NOT Detect AUTO 8
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 8")
                            {
                                p.Kill();

                            }
                        }
                    }

                    bool auto_d9 = (bool)cj2.ReadVariable("Call_D9");
                    if (auto_d9)
                    {
                        StartProcess("AUTO", setting.ip1, "9", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 9")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d10 = (bool)cj2.ReadVariable("Call_D10");
                    if (auto_d10)
                    {
                        StartProcess("AUTO", setting.ip1, "10", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 10")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d11 = (bool)cj2.ReadVariable("Call_D11");
                    if (auto_d11)
                    {
                        StartProcess("AUTO", setting.ip1, "11", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 11")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d12 = (bool)cj2.ReadVariable("Call_D12");
                    if (auto_d12)
                    {
                        StartProcess("AUTO", setting.ip2, "12", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
                        {
                            if (p.MainWindowTitle == "AUTO DUMP 12")
                            {
                                p.Kill();
                            }
                        }
                    }

                    bool auto_d13 = (bool)cj2.ReadVariable("Call_D13");
                    if (auto_d13)
                    {
                        StartProcess("AUTO", setting.ip2, "13", phase);
                    }
                    else
                    {
                        foreach (var p in process_auto)
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
                File.AppendAllText(loca, DateTime.Now + " SKTRFID2 " + ex.Message + " " + Environment.NewLine);
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
                    dump_id = dump.ToString(),
                    area_id = rfid.area_id,
                    crop_year = rfid.crop_year,
                    barcode = "0",
                };
                string message_update = RFID.UpdateBarcodeRFID(dataDump);
            }
            catch(Exception ex)
            {
                //Weite Data to text file
                string loca = @"D:\log_net.txt";
                File.AppendAllText(loca, DateTime.Now + " SKTRFID2 " + ex.Message + " " + Environment.NewLine);
            }
        }
        private void ShowDisplay(Label truck_license, Label truck_date, Label cane_type, Label truck_type, List<DataModel> datas, string dump, bool isShow)
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
            catch(Exception ex)
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
