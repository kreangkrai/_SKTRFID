using SKTRFIDEXPORT.Interface;
using SKTRFIDEXPORT.Model;
using SKTRFIDEXPORT.Service;
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

namespace SKTRFIDEXPORT
{
    public partial class Form1 : Form
    {
        private IExport Export;
        public Form1()
        {
            InitializeComponent();
            Export = new ExportService();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to export data?", "SKT Report", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                List<ReportModel> reports = Export.GetReportByDate(dateTimePickerStat.Value.Date, dateTimePickerStop.Value.Date.AddDays(1));
                string message =  Export.Export(reports);
                MessageBox.Show(message);
            }
        }
        private void btnFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", "D:\\Report");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Text = "";
            List<ReportModel> reports = Export.GetReportByDate(dateTimePickerStat.Value.Date, dateTimePickerStop.Value.Date.AddDays(1));
            dataGridView1.Rows.Clear();
            for (int i = 0; i < reports.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Height = 35;
                row.Cells[0].Value = reports[i].queue;
                row.Cells[1].Value = reports[i].dump_id;
                row.Cells[2].Value = reports[i].date.ToString("dd/MM/yyyy HH:mm:ss");
                row.Cells[3].Value = reports[i].round;
                row.Cells[4].Value = reports[i].area_id;
                row.Cells[5].Value = reports[i].crop_year;
                row.Cells[6].Value = reports[i].barcode;
                row.Cells[7].Value = CaneType(reports[i].cane_type);
                string allergen = reports[i].allergen;
                row.Cells[8].Value = allergenType(allergen);
                if (allergen == "No")
                {
                    row.Cells[8].Style.BackColor = Color.GreenYellow;
                }
                else
                {
                    row.Cells[8].Style.BackColor = Color.Red;
                }
                row.Cells[9].Value = reports[i].truck_number;
                row.Cells[10].Value = reports[i].rfid;
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

        private void txtSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBarcode.Text.Trim() != "")
            {
                List<ReportModel> reports = Export.GetReportByDBarCode(txtSearchBarcode.Text);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < reports.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                    row.Height = 35;
                    row.Cells[0].Value = (i + 1);
                    row.Cells[1].Value = reports[i].dump_id;
                    row.Cells[2].Value = reports[i].date.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[3].Value = reports[i].round;
                    row.Cells[4].Value = reports[i].area_id;
                    row.Cells[5].Value = reports[i].crop_year;
                    row.Cells[6].Value = reports[i].barcode;
                    row.Cells[7].Value = CaneType(reports[i].cane_type);
                    string allergen = reports[i].allergen;
                    row.Cells[8].Value = allergenType(allergen);
                    if (allergen == "No")
                    {
                        row.Cells[8].Style.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        row.Cells[8].Style.BackColor = Color.Red;
                    }
                    row.Cells[9].Value = reports[i].truck_number;
                    row.Cells[10].Value = reports[i].rfid;
                    dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePickerStat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStop_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
