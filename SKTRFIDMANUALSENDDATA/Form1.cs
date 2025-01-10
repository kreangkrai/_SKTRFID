using OMRON.Compolet.CIP;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using SKTRFIDLIBRARY.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDMANUALSENDDATA
{
    public partial class Form1 : Form
    {
        private IAPI API;
        private ISetting Setting;
        private ICodeType CodeType;
        SettingModel setting;
        int phase = 0;
        RFIDModel rfid;
        private IRFID RFID;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            RFID = new RFIDService(phase);
            API = new APIService();
            Setting = new SettingService(phase);
            CodeType = new CodeTypeService();
            setting = Setting.GetSetting();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            DataModel data = new DataModel();
            data.area_id = setting.area_id;
            data.crop_year = setting.crop_year;
            data.rfid = txtxRFID.Text.Trim();
            rfid = await API.CallAPI(data);

            if (rfid.Data.Count > 0)
            {
                if (rfid.Data[0].Barcode != "1")
                {
                    txtBarcode.Text = rfid.Data[0].Barcode;
                    txtCane.Text = CodeType.CaneType(Int32.Parse(rfid.Data[0].CaneType));
                    txtTruck.Text = rfid.Data[0].TruckNumber;
                    txtFamerName.Text = rfid.Data[0].FarmerName;
                    btnSend.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล","SKT",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnSend.Enabled = false;
                }
            }
            else
            {               
                btnSend.Enabled = false;
            }
        }

        private void txtxRFID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDump_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPhase.Text = phase.ToString();
            lblPhase.Text = phase.ToString();

            if (phase == 1)
            {
                numDump.Minimum = 1;
                numDump.Maximum = 7;
            }
            if (phase == 2)
            {
                numDump.Minimum = 8;
                numDump.Maximum = 13;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่?", "SKT RFID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                bool CheckInternet = API.checkInternet();
                if (CheckInternet)
                {
                    CJ2Compolet cj2 = new CJ2Compolet();
                    cj2.ConnectionType = ConnectionType.UCMM;
                    cj2.UseRoutePath = false;
                    cj2.PeerAddress = setting.ip_plc;
                    cj2.LocalPort = 2;
                    cj2.ReceiveTimeLimit = (long)5000;
                    cj2.Active = true;

                    Thread.Sleep(1000);

                    int dump = (int)numDump.Value;

                    // Send Data To PLC
                    if (rfid.Data.Count > 0)
                    {
                        if (cj2.IsConnected)
                        {
                            if (phase == 1)
                            {
                                string[] dump_plc_caneType = new string[7] {  "TY_BF_D1" ,
                                                                                          "TY_BF_D2" ,
                                                                                          "TY_BF_D3" ,
                                                                                          "TY_BF_D4" ,
                                                                                          "TY_BF_D5" ,
                                                                                          "TY_BF_D6" ,
                                                                                          "TY_BF_D7" };
                                string _caneType = "0"; // สด
                                if (rfid.Data[0].CaneType == "1" || rfid.Data[0].CaneType == "3") // ไฟไหม้
                                {
                                    _caneType = "1";
                                }
                                cj2.WriteVariable(dump_plc_caneType[dump - 1], _caneType);
                                Thread.Sleep(100);
                                string[] dump_plc_Barcode = new string[7] { "Bar_ID1" ,
                                                                                        "Bar_ID2" ,
                                                                                        "Bar_ID3" ,
                                                                                        "Bar_ID4" ,
                                                                                        "Bar_ID5" ,
                                                                                        "Bar_ID6" ,
                                                                                        "Bar_ID7" };
                                //cj2.WriteVariable(dump_plc_Barcode[dump - 1], int.Parse(rfid.Data[0].Barcode, System.Globalization.NumberStyles.HexNumber).ToString());
                                cj2.WriteVariable(dump_plc_Barcode[dump - 1], rfid.Data[0].Barcode);
                            }

                            if (phase == 2)
                            {
                                string[] dump_plc_caneType = new string[6] { "TY_BF_D8" ,
                                                                                         "TY_BF_D9" ,
                                                                                         "TY_BF_D10" ,
                                                                                         "TY_BF_D11" ,
                                                                                         "TY_BF_D12" ,
                                                                                         "TY_BF_D13" };
                                string _caneType = "0"; // สด
                                if (rfid.Data[0].CaneType == "1" || rfid.Data[0].CaneType == "3") // ไฟไหม้
                                {
                                    _caneType = "1";
                                }
                                cj2.WriteVariable(dump_plc_caneType[dump - (1 + 7)], _caneType);
                                Thread.Sleep(100);
                                string[] dump_plc_Barcode = new string[6] { "Bar_ID8" ,
                                                                                        "Bar_ID9" ,
                                                                                        "Bar_ID10" ,
                                                                                        "Bar_ID11" ,
                                                                                        "Bar_ID12" ,
                                                                                        "Bar_ID13" };
                                //cj2.WriteVariable(dump_plc_Barcode[dump - (1 + 7)], int.Parse(rfid.Data[0].Barcode, System.Globalization.NumberStyles.HexNumber).ToString());
                                cj2.WriteVariable(dump_plc_Barcode[dump - (1 + 7)], rfid.Data[0].Barcode);
                            }

                            cj2.Active = false;
                            cj2.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถส่งข้อมูล PLC ได้", "SKT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูล", "SKT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DateTime now = DateTime.Now;

                    //Update Data to Local Database
                    DataModel dataDump = new DataModel();
                    dataDump.dump_id = numDump.Value.ToString();
                    dataDump.area_id = setting.area_id;
                    dataDump.crop_year = setting.crop_year;
                    dataDump.rfid = txtxRFID.Text.Trim();
                    dataDump.truck_number = rfid.Data[0].TruckNumber;
                    dataDump.farmer_name = rfid.Data[0].FarmerName;
                    dataDump.rfid_lastdate = now;
                    dataDump.cane_type = Convert.ToInt32(rfid.Data[0].CaneType);
                    dataDump.allergen = rfid.Data[0].Allergen;
                    dataDump.barcode = rfid.Data[0].Barcode;
                    dataDump.truck_type = -1;
                    dataDump.weight_type = -1;
                    dataDump.queue_status = 3;
                    string message_update = RFID.UpdateRFID(dataDump);
                    txtStatusDatabase.Text = message_update;

                    //Log Scan
                    string loc = @"D:\log_scan.txt";
                    File.AppendAllText(loc, DateTime.Now + " RFID " + txtxRFID.Text + " Barcode " + rfid.Data[0].Barcode + " DUMP " + dump + " " + Environment.NewLine);

                    //Log Call API
                    string loc1 = @"D:\log_call_api.txt";
                    File.AppendAllText(loc1, DateTime.Now + " RFID " + txtxRFID.Text + " Barcode " + rfid.Data[0].Barcode + " DUMP " + dump + " Code " + rfid.Data[0].StatusDb + " " + Environment.NewLine);

                    

                    #region Allergen

                    //Check Allergen

                    //Call Form Alert Allergen
                    //Update Allergen to API
                    ResultUpdateAlledModel dataUpdate = await API.UpdateAlled(setting.area_id.ToString(), setting.crop_year, rfid.Data[0].Barcode, "0");

                    if (dataUpdate.Data[0].StatusDb != 0) // Send Complete
                    {
                        string loca = @"D:\log_alled.txt";
                        File.AppendAllText(loca, DateTime.Now + " RFID " + txtxRFID.Text.Trim() + " Barcode " + rfid.Data[0].Barcode + " DUMP " + dump + " Code " + dataUpdate.Data[0].StatusDb + " " + Environment.NewLine);
                    }

                    #endregion Allergen
                    if (message_update == "Success")
                    {
                        MessageBox.Show("เรียบร้อย", "SKT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถส่งข้อมูลได้", "SKT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ไม่สามารถติดต่อกับเซิร์ฟเวอร์", "SKT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
