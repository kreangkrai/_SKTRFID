﻿
namespace SKTRFIDTAG
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchRFID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.txtTypeTruck = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtTypeCane = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTypeWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtQueue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "RFID";
            // 
            // txtSearchRFID
            // 
            this.txtSearchRFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchRFID.Location = new System.Drawing.Point(96, 7);
            this.txtSearchRFID.Name = "txtSearchRFID";
            this.txtSearchRFID.Size = new System.Drawing.Size(188, 29);
            this.txtSearchRFID.TabIndex = 10;
            this.txtSearchRFID.TextChanged += new System.EventHandler(this.txtSearchRFID_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.tag,
            this.rfid,
            this.tag_date});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(17, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(676, 211);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // no
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.DefaultCellStyle = dataGridViewCellStyle7;
            this.no.HeaderText = "ลำดับ";
            this.no.Name = "no";
            this.no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.no.Width = 80;
            // 
            // tag
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag.DefaultCellStyle = dataGridViewCellStyle8;
            this.tag.HeaderText = "ข้อมูลบัตร";
            this.tag.MinimumWidth = 24;
            this.tag.Name = "tag";
            this.tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tag.Width = 250;
            // 
            // rfid
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rfid.DefaultCellStyle = dataGridViewCellStyle9;
            this.rfid.HeaderText = "RFID";
            this.rfid.Name = "rfid";
            this.rfid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tag_date
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag_date.DefaultCellStyle = dataGridViewCellStyle10;
            this.tag_date.HeaderText = "วันที่";
            this.tag_date.MinimumWidth = 20;
            this.tag_date.Name = "tag_date";
            this.tag_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tag_date.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtQueue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTypeWeight);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTypeCane);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.txtTypeTruck);
            this.groupBox1.Controls.Add(this.txtTruck);
            this.groupBox1.Controls.Add(this.txtRFID);
            this.groupBox1.Font = new System.Drawing.Font("Angsana New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 371);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลในบัตร";
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(133, 37);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(155, 44);
            this.txtRFID.TabIndex = 0;
            // 
            // txtTruck
            // 
            this.txtTruck.Location = new System.Drawing.Point(133, 84);
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(155, 44);
            this.txtTruck.TabIndex = 1;
            // 
            // txtTypeTruck
            // 
            this.txtTypeTruck.Location = new System.Drawing.Point(133, 131);
            this.txtTypeTruck.Name = "txtTypeTruck";
            this.txtTypeTruck.Size = new System.Drawing.Size(154, 44);
            this.txtTypeTruck.TabIndex = 2;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(133, 178);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(154, 44);
            this.txtBarcode.TabIndex = 3;
            // 
            // txtTypeCane
            // 
            this.txtTypeCane.Location = new System.Drawing.Point(132, 225);
            this.txtTypeCane.Name = "txtTypeCane";
            this.txtTypeCane.Size = new System.Drawing.Size(155, 44);
            this.txtTypeCane.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 30);
            this.label8.TabIndex = 20;
            this.label8.Text = "รหัส RFID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTypeWeight
            // 
            this.txtTypeWeight.Location = new System.Drawing.Point(133, 272);
            this.txtTypeWeight.Name = "txtTypeWeight";
            this.txtTypeWeight.Size = new System.Drawing.Size(155, 44);
            this.txtTypeWeight.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "ทะเบียนรถ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 30);
            this.label2.TabIndex = 23;
            this.label2.Text = "ประเภทรถ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 30);
            this.label4.TabIndex = 24;
            this.label4.Text = "ประเถทอ้อย";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 30);
            this.label5.TabIndex = 25;
            this.label5.Text = "รหัสชั่ง";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 30);
            this.label6.TabIndex = 26;
            this.label6.Text = "ประเภทชั่ง";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrite.Location = new System.Drawing.Point(363, 535);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(330, 95);
            this.btnWrite.TabIndex = 14;
            this.btnWrite.Text = "เขียนบัตร";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Font = new System.Drawing.Font("Angsana New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(366, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 182);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "วิธีใช้งาน";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(15, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(300, 132);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "1. วางบัตร RFID ลงในเครื่องอ่านเขียนบัตรตัวที่ 8\n2. เลือกข้อมูลบัตรที่ตรงกับเลขบั" +
    "ตร RFID\n3. กดเขียนบัตร\n";
            // 
            // txtTag
            // 
            this.txtTag.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTag.Location = new System.Drawing.Point(363, 460);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(330, 44);
            this.txtTag.TabIndex = 27;
            // 
            // txtQueue
            // 
            this.txtQueue.Location = new System.Drawing.Point(133, 321);
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(155, 44);
            this.txtQueue.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Angsana New", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 30);
            this.label7.TabIndex = 28;
            this.label7.Text = "สถานะคิว";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 642);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchRFID);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKT RFID TAG";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchRFID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag_date;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTypeWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTypeCane;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtTypeTruck;
        private System.Windows.Forms.TextBox txtTruck;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQueue;
    }
}

