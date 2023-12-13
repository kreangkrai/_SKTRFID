using SKTRFIDEDIT.Interface;
using SKTRFIDEDIT.Model;
using SKTRFIDEDIT.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDEDIT
{
    public partial class Form1 : Form
    {
        private IRFIDLog RFIDLog;
        List<SubDataModel> sub_datas;
        public Form1()
        {
            InitializeComponent();
            RFIDLog = new RFIDLogService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(10,txtDump.Text,txtLicensePlate.Text,dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }
        void LoadData(int n, string dump, string truck_number, string date)
        {
            dataGridView1.Rows.Clear();
            List<DataModel> datas = RFIDLog.GetRFID(n,dump,truck_number,date);

            sub_datas = datas.Select(s => new SubDataModel()
            {
                dump_id = s.dump_id,
                truck_number = s.truck_number,
                rfid_lastdate = s.rfid_lastdate,
                cane_type = caneType(s.cane_type),
                contaminants = contaminantsType(s.allergen)
            }).ToList();
            for (int i = 0; i < sub_datas.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Height = 35;
                row.Cells[0].Value = (i+1);
                row.Cells[1].Value = sub_datas[i].dump_id;
                row.Cells[2].Value = sub_datas[i].truck_number;
                row.Cells[3].Value = sub_datas[i].cane_type;
                row.Cells[4].Value = sub_datas[i].contaminants;
                row.Cells[5].Value = sub_datas[i].rfid_lastdate.ToString("dd/MM/yyyy HH:mm:ss");
                row.Cells[6].Value = "บันทึก";
                dataGridView1.Rows.Add(row);
            }
        }

        string caneType(int n)
        {
            List<string> canes = new List<string>();
            canes.Add("สดท่อน");
            canes.Add("ไฟไหม้ท่อน");
            canes.Add("สดลำ");
            canes.Add("ไฟไหม้ลำ");
            return canes[n];
        }
        string contaminantsType(int n)
        {
            List<string> contaminants = new List<string>();
            contaminants.Add("ไม่มี");
            contaminants.Add("มี");
            return contaminants[n];
        }

        int typeCaneIndex(string s)
        {
            List<string> canes = new List<string>();
            canes.Add("สดท่อน");
            canes.Add("ไฟไหม้ท่อน");
            canes.Add("สดลำ");
            canes.Add("ไฟไหม้ลำ");
            return canes.FindIndex(w => w == s);
        }
        int typeContaminantsIndex(string s)
        {
            List<string> contaminants = new List<string>();
            contaminants.Add("ไม่มี");
            contaminants.Add("มี");
            return contaminants.FindIndex(w => w == s);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
                {
                    var _data = sub_datas[e.RowIndex];
                    DataModel data = new DataModel()
                    {
                        dump_id = _data.dump_id,
                        cane_type = typeCaneIndex(dataGridView1.Rows[e.RowIndex].Cells["cane_type"].Value.ToString()),
                        allergen = typeContaminantsIndex(dataGridView1.Rows[e.RowIndex].Cells["allergen"].Value.ToString()),
                        rfid_lastdate =  _data.rfid_lastdate,
                        truck_number = _data.truck_number
                    };
                    DialogResult dialog = MessageBox.Show("ต้องการบันทึกหรือไม่ ?", "SKT RFID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        string message = RFIDLog.UpdateRFID(data);
                        MessageBox.Show(message);
                        LoadData(10, txtDump.Text, txtLicensePlate.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch
            {
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(comboBox1.Text),txtDump.Text,txtLicensePlate.Text,dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }

        private void txtDump_TextChanged(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(comboBox1.Text), txtDump.Text, txtLicensePlate.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }

        private void txtLicensePlate_TextChanged(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(comboBox1.Text), txtDump.Text, txtLicensePlate.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(comboBox1.Text), txtDump.Text, txtLicensePlate.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }
    }
}