﻿
namespace SKTRFIDMONITOR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle77 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStop = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStat = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dump_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crop_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cane_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allergen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.truck_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(844, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 26);
            this.label3.TabIndex = 19;
            this.label3.Text = "บาร์โค้ด";
            // 
            // txtSearchBarcode
            // 
            this.txtSearchBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBarcode.Location = new System.Drawing.Point(928, 12);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.Size = new System.Drawing.Size(152, 29);
            this.txtSearchBarcode.TabIndex = 18;
            this.txtSearchBarcode.TextChanged += new System.EventHandler(this.txtSearchBarcode_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(553, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(210, 40);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "รีเฟรช";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "วันสิ้นสุด";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "วันเริ่มต้น";
            // 
            // dateTimePickerStop
            // 
            this.dateTimePickerStop.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStop.Location = new System.Drawing.Point(381, 14);
            this.dateTimePickerStop.Name = "dateTimePickerStop";
            this.dateTimePickerStop.Size = new System.Drawing.Size(156, 32);
            this.dateTimePickerStop.TabIndex = 11;
            // 
            // dateTimePickerStat
            // 
            this.dateTimePickerStat.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStat.Location = new System.Drawing.Point(110, 14);
            this.dateTimePickerStat.Name = "dateTimePickerStat";
            this.dateTimePickerStat.Size = new System.Drawing.Size(143, 32);
            this.dateTimePickerStat.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle73.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle73.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle73.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle73.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle73.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle73;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.dump_no,
            this.date,
            this.area_id,
            this.crop_year,
            this.barcode,
            this.cane_type,
            this.allergen,
            this.truck_number,
            this.rfid});
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle84.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle84.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle84.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle84.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle84.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle84.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle84;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1357, 642);
            this.dataGridView1.TabIndex = 17;
            // 
            // no
            // 
            dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle74.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.DefaultCellStyle = dataGridViewCellStyle74;
            this.no.HeaderText = "ลำดับ";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.no.Width = 80;
            // 
            // dump_no
            // 
            dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle75.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dump_no.DefaultCellStyle = dataGridViewCellStyle75;
            this.dump_no.HeaderText = "ดัมพ์";
            this.dump_no.Name = "dump_no";
            this.dump_no.ReadOnly = true;
            this.dump_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dump_no.Width = 80;
            // 
            // date
            // 
            dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.date.DefaultCellStyle = dataGridViewCellStyle76;
            this.date.HeaderText = "วันที่";
            this.date.MinimumWidth = 20;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.Width = 200;
            // 
            // area_id
            // 
            dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle77.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.area_id.DefaultCellStyle = dataGridViewCellStyle77;
            this.area_id.HeaderText = "พื้นที่";
            this.area_id.Name = "area_id";
            this.area_id.ReadOnly = true;
            this.area_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // crop_year
            // 
            dataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle78.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crop_year.DefaultCellStyle = dataGridViewCellStyle78;
            this.crop_year.HeaderText = "ปี";
            this.crop_year.Name = "crop_year";
            this.crop_year.ReadOnly = true;
            this.crop_year.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // barcode
            // 
            dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle79.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcode.DefaultCellStyle = dataGridViewCellStyle79;
            this.barcode.HeaderText = "บาร์โค้ด";
            this.barcode.MinimumWidth = 20;
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.barcode.Width = 150;
            // 
            // cane_type
            // 
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle80.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cane_type.DefaultCellStyle = dataGridViewCellStyle80;
            this.cane_type.HeaderText = "ชนิดอ้อย";
            this.cane_type.MinimumWidth = 15;
            this.cane_type.Name = "cane_type";
            this.cane_type.ReadOnly = true;
            this.cane_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cane_type.Width = 150;
            // 
            // allergen
            // 
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle81.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allergen.DefaultCellStyle = dataGridViewCellStyle81;
            this.allergen.HeaderText = "สารปนเปื้อน";
            this.allergen.Name = "allergen";
            this.allergen.ReadOnly = true;
            this.allergen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.allergen.Width = 150;
            // 
            // truck_number
            // 
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle82.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truck_number.DefaultCellStyle = dataGridViewCellStyle82;
            this.truck_number.HeaderText = "ทะเบียนรถ";
            this.truck_number.Name = "truck_number";
            this.truck_number.ReadOnly = true;
            this.truck_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.truck_number.Width = 150;
            // 
            // rfid
            // 
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle83.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rfid.DefaultCellStyle = dataGridViewCellStyle83;
            this.rfid.HeaderText = "รหัส RFID";
            this.rfid.Name = "rfid";
            this.rfid.ReadOnly = true;
            this.rfid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rfid.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 701);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchBarcode);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStop);
            this.Controls.Add(this.dateTimePickerStat);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKT RFID MONITOR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStop;
        private System.Windows.Forms.DateTimePicker dateTimePickerStat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dump_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn crop_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cane_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn allergen;
        private System.Windows.Forms.DataGridViewTextBoxColumn truck_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfid;
    }
}

