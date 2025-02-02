﻿using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using SKTRFIDLIBRARY.Service;
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
using DataModel = SKTRFIDMONITOR.Model.DataModel;

namespace SKTRFIDMONITOR
{
    public partial class Form1 : Form
    {
        int phase = 0;
        private IMonitor Monitor;
        private ISetting Setting;
        SettingModel setting;
        private ICodeType CodeType;
        public Form1(string _phase)
        {
            InitializeComponent();
            phase = Int32.Parse(_phase);
            Monitor = new MonitorService(phase);
            Setting = new SettingService(phase);
            setting = Setting.GetSetting();
            CodeType = new CodeTypeService();
            this.Text = "SKT RFID MONITOR PHASE " + phase;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<DataModel> datas = Monitor.GetLastUpdate(setting.crop_year);
            LoadData(datas);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 30000;
            timer.Tick += Timer_Tick;
            timer.Start();

            List<DataModel> datas = Monitor.GetLastUpdate(setting.crop_year);
            LoadData(datas);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            List<DataModel> datas = Monitor.GetLastUpdate(setting.crop_year);
            LoadData(datas);
        }

        void LoadData(List<DataModel> datas)
        {
            dataGridView1.Rows.Clear();
            if (phase == 1)
            {
                for (int j = 1; j <= 7; j++)
                {
                    DataModel data = datas.Where(w => w.dump_id == j).FirstOrDefault();
                    if (data != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[j - 1].Clone();
                        row.Height = 35;
                        row.Cells[0].Value = data.barcode;
                        row.Cells[1].Value = data.farmer_name;
                        row.Cells[2].Value = data.dump_id;
                        row.Cells[3].Value = data.rfid_lastdate.ToString("dd/MM/yyyy HH:mm:ss");
                        double diff_minute = DateTime.Now.Subtract(data.rfid_lastdate).TotalMinutes;
                        if (diff_minute >= 10.0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        row.Cells[4].Value = data.truck_number;
                        row.Cells[5].Value = CodeType.CaneType(data.cane_type);
                        string allergen = data.allergen;
                        row.Cells[6].Value = CodeType.allergenType(allergen);
                        if (allergen == "No" || allergen == "")
                        {
                            row.Cells[6].Style.BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            row.Cells[6].Style.BackColor = Color.Red;
                        }
                        row.Cells[7].Value = CodeType.truckType(data.truck_type);
                        dataGridView1.Rows.Add(row);
                    }
                    else
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[j - 1].Clone();
                        row.Height = 35;
                        row.Cells[0].Value = "";
                        row.Cells[1].Value = "";
                        row.Cells[2].Value = j;
                        row.Cells[3].Value = "";
                        row.Cells[4].Value = "";
                        row.Cells[5].Value = "";
                        row.Cells[6].Value = "";
                        row.Cells[7].Value = "";
                        row.DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        
            if (phase == 2)
            {
                for (int j = 8; j <= 13; j++)
                {
                    DataModel data = datas.Where(w => w.dump_id == j).FirstOrDefault();
                    if (data != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[j - 8].Clone();
                        row.Height = 35;
                        row.Cells[0].Value = data.barcode;
                        row.Cells[1].Value = data.farmer_name;
                        row.Cells[2].Value = data.dump_id;
                        row.Cells[3].Value = data.rfid_lastdate.ToString("dd/MM/yyyy HH:mm:ss");
                        double diff_minute = DateTime.Now.Subtract(data.rfid_lastdate).TotalMinutes;
                        if (diff_minute >= 10.0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        row.Cells[4].Value = data.truck_number;
                        row.Cells[5].Value = CodeType.CaneType(data.cane_type);
                        string allergen = data.allergen;
                        row.Cells[6].Value = CodeType.allergenType(allergen);
                        if (allergen == "No" || allergen == "")
                        {
                            row.Cells[6].Style.BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            row.Cells[6].Style.BackColor = Color.Red;
                        }
                        row.Cells[7].Value = CodeType.truckType(data.truck_type);
                        dataGridView1.Rows.Add(row);
                    }
                    else
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[j - 8].Clone();
                        row.Height = 35;
                        row.Cells[0].Value = "";
                        row.Cells[1].Value = "";
                        row.Cells[2].Value = j;
                        row.Cells[3].Value = "";
                        row.Cells[4].Value = "";
                        row.Cells[5].Value = "";
                        row.Cells[6].Value = "";
                        row.Cells[7].Value = "";
                        row.DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
        }
    }
}
