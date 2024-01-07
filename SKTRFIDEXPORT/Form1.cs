using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Service;
using SKTRFIDREPORT.Interface;
using SKTRFIDREPORT.Model;
using SKTRFIDREPORT.Service;
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

namespace SKTRFIDREPORT
{
    public partial class Form1 : Form
    {
        int phase = 0;
        private IExport Export;
        private ICodeType CodeType;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            Export = new ExportService(phase);
            CodeType = new CodeTypeService();
            this.Text = "SKT RFID EXPORT PHASE " + phase;
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
            txtSearchBarcode.Text = "";
            List<ReportModel> reports = Export.GetReportByDate(dateTimePickerStat.Value.Date, dateTimePickerStop.Value.Date.AddDays(1));

            LoadData(reports);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Text = "";
            List<ReportModel> reports = Export.GetReportByDate(dateTimePickerStat.Value.Date, dateTimePickerStop.Value.Date.AddDays(1));

            LoadData(reports);
        }
        void LoadData(List<ReportModel> reports)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < reports.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Height = 35;
                row.Cells[0].Value = reports[i].queue;
                row.Cells[1].Value = reports[i].barcode;
                row.Cells[2].Value = reports[i].farmer_name;
                row.Cells[3].Value = reports[i].dump_id;
                row.Cells[4].Value = reports[i].round;
                row.Cells[5].Value = reports[i].date.ToString("dd/MM/yyyy HH:mm:ss");
                row.Cells[6].Value = reports[i].truck_number;
                row.Cells[7].Value = CodeType.CaneType(reports[i].cane_type);
                string allergen = reports[i].allergen;
                row.Cells[8].Value = CodeType.allergenType(allergen);
                if (allergen == "No" || allergen.Trim() == "")
                {
                    row.Cells[8].Style.BackColor = Color.GreenYellow;
                }
                else
                {
                    row.Cells[8].Style.BackColor = Color.Red;
                }
                //row.Cells[9].Value = reports[i].area_id;
                //row.Cells[10].Value = reports[i].crop_year;
                dataGridView1.Rows.Add(row);
            }
        }

        private void txtSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBarcode.Text.Trim() != "")
            {
                List<ReportModel> reports = Export.GetReportByDBarCode(txtSearchBarcode.Text);
                LoadData(reports);
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}
