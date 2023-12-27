using SKTRFIDMONITOR.Interface;
using SKTRFIDMONITOR.Model;
using SKTRFIDMONITOR.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDMONITOR
{
    public partial class Form1 : Form
    {
        int phase = 0;
        private IMonitor Monitor;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            Monitor = new MonitorService(phase);
            this.Text = "SKT RFID MONITOR PHASE " + phase;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<DataModel> datas = Monitor.GetDatasByDate(dateTimePickerStat.Value.Date,dateTimePickerStop.Value.Date.AddDays(1));
            LoadData(datas);
        }

        private void txtSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            List<DataModel> datas = Monitor.GetDatasByBarCode(txtSearchBarcode.Text);
            LoadData(datas);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DataModel> datas = Monitor.GetDatasByDate(DateTime.Now.Date,DateTime.Now.Date);
            LoadData(datas);
        }

        void LoadData(List<DataModel> datas)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < datas.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Height = 35;
                row.Cells[0].Value = datas[i].queue;
                row.Cells[1].Value = datas[i].dump_id;
                row.Cells[2].Value = datas[i].date + " " + datas[i].time;
                row.Cells[3].Value = datas[i].area_id;
                row.Cells[4].Value = datas[i].crop_year;
                row.Cells[5].Value = datas[i].barcode;
                row.Cells[6].Value = datas[i].farmer_name;
                row.Cells[7].Value = CaneType(datas[i].cane_type);
                string allergen = datas[i].allergen;
                row.Cells[8].Value = allergenType(allergen);
                if (allergen == "No")
                {
                    row.Cells[8].Style.BackColor = Color.GreenYellow;
                }
                else
                {
                    row.Cells[8].Style.BackColor = Color.Red;
                }
                row.Cells[9].Value = datas[i].truck_number;
                row.Cells[10].Value = datas[i].rfid;
                dataGridView1.Rows.Add(row);
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
        private string allergenType(string n)
        {
            if (n == "No")
            {
                return "ไม่มี";
            }
            else
            {
                return "มี";
            }
        }
    }
}
