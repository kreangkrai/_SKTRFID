﻿
namespace SKTRFIDCENTER
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
            this.btnCropYear_AreaId = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnShift = new System.Windows.Forms.Button();
            this.btnEditDump = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnReadWriteRFID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhase = new System.Windows.Forms.TextBox();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnCheckHardware = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendRFID = new System.Windows.Forms.Button();
            this.btnReadAPI = new System.Windows.Forms.Button();
            this.btnMuteSound = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCropYear_AreaId
            // 
            this.btnCropYear_AreaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCropYear_AreaId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCropYear_AreaId.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCropYear_AreaId.Location = new System.Drawing.Point(23, 190);
            this.btnCropYear_AreaId.Margin = new System.Windows.Forms.Padding(4);
            this.btnCropYear_AreaId.Name = "btnCropYear_AreaId";
            this.btnCropYear_AreaId.Size = new System.Drawing.Size(256, 151);
            this.btnCropYear_AreaId.TabIndex = 0;
            this.btnCropYear_AreaId.Text = "ตั้งค่าปี/พื้นที่";
            this.btnCropYear_AreaId.UseVisualStyleBackColor = false;
            this.btnCropYear_AreaId.Click += new System.EventHandler(this.btnCropYear_AreaId_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Font = new System.Drawing.Font("Angsana New", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(308, 32);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(256, 151);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnShift
            // 
            this.btnShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShift.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShift.Location = new System.Drawing.Point(300, 190);
            this.btnShift.Margin = new System.Windows.Forms.Padding(4);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(256, 151);
            this.btnShift.TabIndex = 2;
            this.btnShift.Text = "ตัดรอบอ้อย";
            this.btnShift.UseVisualStyleBackColor = false;
            this.btnShift.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // btnEditDump
            // 
            this.btnEditDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditDump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDump.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDump.Location = new System.Drawing.Point(23, 348);
            this.btnEditDump.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditDump.Name = "btnEditDump";
            this.btnEditDump.Size = new System.Drawing.Size(256, 151);
            this.btnEditDump.TabIndex = 3;
            this.btnEditDump.Text = "รีเซตดัมพ์";
            this.btnEditDump.UseVisualStyleBackColor = false;
            this.btnEditDump.Click += new System.EventHandler(this.btnEditDump_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMonitor.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonitor.Location = new System.Drawing.Point(28, 31);
            this.btnMonitor.Margin = new System.Windows.Forms.Padding(4);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(256, 151);
            this.btnMonitor.TabIndex = 4;
            this.btnMonitor.Text = "จดบันทึกการดัมพ์";
            this.btnMonitor.UseVisualStyleBackColor = false;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // btnReadWriteRFID
            // 
            this.btnReadWriteRFID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReadWriteRFID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadWriteRFID.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadWriteRFID.Location = new System.Drawing.Point(300, 348);
            this.btnReadWriteRFID.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadWriteRFID.Name = "btnReadWriteRFID";
            this.btnReadWriteRFID.Size = new System.Drawing.Size(256, 151);
            this.btnReadWriteRFID.TabIndex = 5;
            this.btnReadWriteRFID.Text = "อ่าน/เขียนบัตร";
            this.btnReadWriteRFID.UseVisualStyleBackColor = false;
            this.btnReadWriteRFID.Click += new System.EventHandler(this.btnReadWriteRFID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(515, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "PHASE";
            // 
            // txtPhase
            // 
            this.txtPhase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhase.Location = new System.Drawing.Point(664, 6);
            this.txtPhase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhase.Name = "txtPhase";
            this.txtPhase.ReadOnly = true;
            this.txtPhase.Size = new System.Drawing.Size(27, 38);
            this.txtPhase.TabIndex = 7;
            this.txtPhase.Text = "1";
            // 
            // btnKill
            // 
            this.btnKill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKill.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKill.Location = new System.Drawing.Point(23, 31);
            this.btnKill.Margin = new System.Windows.Forms.Padding(4);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(256, 151);
            this.btnKill.TabIndex = 8;
            this.btnKill.Text = "ลบโปรแกรมดัมพ์";
            this.btnKill.UseVisualStyleBackColor = false;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // btnCheckHardware
            // 
            this.btnCheckHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCheckHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckHardware.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckHardware.Location = new System.Drawing.Point(300, 31);
            this.btnCheckHardware.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckHardware.Name = "btnCheckHardware";
            this.btnCheckHardware.Size = new System.Drawing.Size(256, 151);
            this.btnCheckHardware.TabIndex = 9;
            this.btnCheckHardware.Text = "ตรวจสอบฮาร์ดแวร์";
            this.btnCheckHardware.UseVisualStyleBackColor = false;
            this.btnCheckHardware.Click += new System.EventHandler(this.btnCheckHardware_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKill);
            this.groupBox1.Controls.Add(this.btnCheckHardware);
            this.groupBox1.Controls.Add(this.btnCropYear_AreaId);
            this.groupBox1.Controls.Add(this.btnReadWriteRFID);
            this.groupBox1.Controls.Add(this.btnEditDump);
            this.groupBox1.Controls.Add(this.btnShift);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(641, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(581, 516);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETTING";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSendRFID);
            this.groupBox2.Controls.Add(this.btnReadAPI);
            this.groupBox2.Controls.Add(this.btnMuteSound);
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Controls.Add(this.btnMonitor);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(40, 50);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(593, 516);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monitor";
            // 
            // btnSendRFID
            // 
            this.btnSendRFID.BackColor = System.Drawing.Color.Olive;
            this.btnSendRFID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendRFID.Font = new System.Drawing.Font("Angsana New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendRFID.Location = new System.Drawing.Point(308, 357);
            this.btnSendRFID.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendRFID.Name = "btnSendRFID";
            this.btnSendRFID.Size = new System.Drawing.Size(256, 151);
            this.btnSendRFID.TabIndex = 7;
            this.btnSendRFID.Text = "ส่งข้อมูลดัมพ์";
            this.btnSendRFID.UseVisualStyleBackColor = false;
            this.btnSendRFID.Click += new System.EventHandler(this.btnSendRFID_Click);
            // 
            // btnReadAPI
            // 
            this.btnReadAPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReadAPI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadAPI.Font = new System.Drawing.Font("Angsana New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadAPI.Location = new System.Drawing.Point(307, 195);
            this.btnReadAPI.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadAPI.Name = "btnReadAPI";
            this.btnReadAPI.Size = new System.Drawing.Size(256, 151);
            this.btnReadAPI.TabIndex = 6;
            this.btnReadAPI.Text = "อ่านบัตรออนไลน์";
            this.btnReadAPI.UseVisualStyleBackColor = false;
            this.btnReadAPI.Click += new System.EventHandler(this.btnReadAPI_Click);
            // 
            // btnMuteSound
            // 
            this.btnMuteSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMuteSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuteSound.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuteSound.Location = new System.Drawing.Point(28, 195);
            this.btnMuteSound.Margin = new System.Windows.Forms.Padding(4);
            this.btnMuteSound.Name = "btnMuteSound";
            this.btnMuteSound.Size = new System.Drawing.Size(256, 151);
            this.btnMuteSound.TabIndex = 5;
            this.btnMuteSound.Text = "เปิด-ปิด เสียง";
            this.btnMuteSound.UseVisualStyleBackColor = false;
            this.btnMuteSound.Click += new System.EventHandler(this.btnMuteSound_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 586);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPhase);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKT RFID CENTER PHASE 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCropYear_AreaId;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.Button btnEditDump;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnReadWriteRFID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhase;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnCheckHardware;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMuteSound;
        private System.Windows.Forms.Button btnReadAPI;
        private System.Windows.Forms.Button btnSendRFID;
    }
}

