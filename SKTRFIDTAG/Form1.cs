﻿using SKTRFIDTAG.Interface;
using SKTRFIDTAG.Model;
using SKTRFIDTAG.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDTAG
{
    public partial class Form1 : Form
    {
        private ITagLog TagLog;
        List<TagLogModel> tags = new List<TagLogModel>();
        public Form1()
        {
            InitializeComponent();
            TagLog = new TagLogService();
        }

        private void txtSearchRFID_TextChanged(object sender, EventArgs e)
        {
            tags = TagLog.GetTagLogByRFID(txtSearchRFID.Text);

            dataGridView1.Rows.Clear();
            for (int i = 0; i < tags.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Height = 35;
                row.Cells[0].Value = (i + 1);
                row.Cells[1].Value = tags[i].tag;
                row.Cells[2].Value = tags[i].rfid;
                row.Cells[3].Value = tags[i].tag_date.ToString("dd/MM/yyyy HH:mm:ss");
                dataGridView1.Rows.Add(row);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT RFID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string tag = tags[e.RowIndex].tag;
            string rfid_code = string.Empty;
            string license_plate1 = string.Empty;
            string license_plate2 = string.Empty;
            string license_plate3 = string.Empty;
            string truck_type = string.Empty;
            string weight_code = string.Empty;
            string cane_type = string.Empty;
            string weight_type = string.Empty;
            string queue_status = string.Empty;
            string dump_no = string.Empty;

            rfid_code = int.Parse(tag.Substring(0, 4), System.Globalization.NumberStyles.HexNumber).ToString().PadLeft(6, '0');
            license_plate1 = "XX";
            license_plate2 = tag.Substring(8, 2);
            license_plate3 = tag.Substring(10, 4);
            truck_type = tag.Substring(14, 1);
            weight_code = tag.Substring(15, 5);
            cane_type = tag.Substring(20, 1);
            weight_type = tag.Substring(21, 1);
            queue_status = tag.Substring(22, 1);
            dump_no = "0";

            txtRFID.Text = rfid_code;
            txtTruck.Text = license_plate1 + int.Parse(license_plate2, System.Globalization.NumberStyles.HexNumber).ToString() + "-" +
                                            int.Parse(license_plate3, System.Globalization.NumberStyles.HexNumber).ToString();
            txtTypeTruck.Text = truckType(Int32.Parse(truck_type));
            txtBarcode.Text = int.Parse(weight_code, System.Globalization.NumberStyles.HexNumber).ToString();
            txtTypeCane.Text = CaneType(Int32.Parse(cane_type));
            txtTypeWeight.Text = weightType(Int32.Parse(weight_type));
            txtQueue.Text = queueStatus(Int32.Parse(queue_status));
        }
        private string CaneType(int n)
        {
            if (n == -1)
            {
                return "";
            }
            List<string> canes_type = new List<string>();
            canes_type.Add("สดท่อน");
            canes_type.Add("ไฟไหม้ท่อน");
            canes_type.Add("สดลำ");
            canes_type.Add("ไฟไหม้ลำ");

            return canes_type[n];
        }
        private string truckType(int n)
        {
            if (n == -1)
            {
                return "";
            }
            List<string> trucks_type = new List<string>();
            trucks_type.Add("");
            trucks_type.Add("รถเดี่ยว");
            trucks_type.Add("พ่วงแม่");
            trucks_type.Add("พ่วงลูก");
            return trucks_type[n];
        }
        private string weightType(int n)
        {
            List<string> weights_type = new List<string>();
            weights_type.Add("");
            weights_type.Add("ชั่งรวม");
            weights_type.Add("ชั่งแยก");
            return weights_type[n];
        }
        private string queueStatus(int n)
        {
            List<string> queues_status = new List<string>();
            queues_status.Add("");
            queues_status.Add("แจ้งคิวแล้ว");
            queues_status.Add("ชั่งเข้าแล้ว");
            queues_status.Add("ดัมพ์แล้ว");
            return queues_status[n];
        }
    }
}
