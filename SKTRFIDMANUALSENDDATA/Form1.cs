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

namespace SKTRFIDMANUALSENDDATA
{
    public partial class Form1 : Form
    {
        private IAPI API;
        private ISetting Setting;
        private ICodeType CodeType;
        int phase = 0;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            API = new APIService();
            Setting = new SettingService(phase);
            CodeType = new CodeTypeService();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            SettingModel setting = Setting.GetSetting();

            DataModel data = new DataModel();
            data.area_id = setting.area_id;
            data.crop_year = setting.crop_year;
            data.rfid = txtxRFID.Text.Trim();
            RFIDModel rfid = await API.CallAPI(data);

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
                    MessageBox.Show("ไม่พบข้อมูล");
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
        }
    }
}
