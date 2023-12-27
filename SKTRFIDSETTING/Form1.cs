using SKTRFIDSETTING.Interface;
using SKTRFIDSETTING.Model;
using SKTRFIDSETTING.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDSETTING
{
    public partial class Form1 : Form
    {
        int phase = 0;
        private ISetting Settings;
        DataModel data = new DataModel();
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            Settings = new SettingService(phase);
            this.Text = "SKT RFID SETTING PHASE " + phase;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtArea.Text.Trim() != "" && txtYear.Text.Trim() != "")
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Confirm data?", "SKT Setting", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    DataModel _data = new DataModel()
                    {
                        no = data.no,
                        area_id = Convert.ToInt32(txtArea.Text.Trim()),
                        crop_year = txtYear.Text.Trim(),
                    };
                    string message = Settings.Update(_data);
                    MessageBox.Show(message);
                }
            }
            else
            {
                MessageBox.Show("กรอกข้อมูลไม่ครบ");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            data = Settings.GetData();
            if (data.crop_year != "")
            {
                txtArea.Text = data.area_id.ToString();
                txtYear.Text = data.crop_year.ToString();
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
            }
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '/') && ((sender as TextBox).Text.IndexOf('/') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
