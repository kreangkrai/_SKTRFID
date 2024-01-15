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

namespace SKTRFIDREADAPI
{
    public partial class Form1 : Form
    {
        int phase = 0;
        private IAPI API;
        private ICodeType CodeType;
        private ISetting Setting;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            API = new APIService();
            CodeType = new CodeTypeService();
            Setting = new SettingService(phase);
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
                    txtAllergen.Text = CodeType.allergenType(rfid.Data[0].Allergen);
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล","SKT",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
