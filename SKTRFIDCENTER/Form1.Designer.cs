
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
            this.SuspendLayout();
            // 
            // btnCropYear_AreaId
            // 
            this.btnCropYear_AreaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCropYear_AreaId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCropYear_AreaId.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCropYear_AreaId.Location = new System.Drawing.Point(40, 47);
            this.btnCropYear_AreaId.Name = "btnCropYear_AreaId";
            this.btnCropYear_AreaId.Size = new System.Drawing.Size(192, 123);
            this.btnCropYear_AreaId.TabIndex = 0;
            this.btnCropYear_AreaId.Text = "ตั้งค่าปี/พื้นที่";
            this.btnCropYear_AreaId.UseVisualStyleBackColor = false;
            this.btnCropYear_AreaId.Click += new System.EventHandler(this.btnCropYear_AreaId_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(255, 47);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(192, 123);
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
            this.btnShift.Location = new System.Drawing.Point(40, 192);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(192, 123);
            this.btnShift.TabIndex = 2;
            this.btnShift.Text = "ตั้งค่ากะ";
            this.btnShift.UseVisualStyleBackColor = false;
            this.btnShift.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // btnEditDump
            // 
            this.btnEditDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditDump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDump.Font = new System.Drawing.Font("Angsana New", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDump.Location = new System.Drawing.Point(255, 192);
            this.btnEditDump.Name = "btnEditDump";
            this.btnEditDump.Size = new System.Drawing.Size(192, 123);
            this.btnEditDump.TabIndex = 3;
            this.btnEditDump.Text = "แก้ไขข้อมูลการดัมพ์";
            this.btnEditDump.UseVisualStyleBackColor = false;
            this.btnEditDump.Click += new System.EventHandler(this.btnEditDump_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 364);
            this.Controls.Add(this.btnEditDump);
            this.Controls.Add(this.btnShift);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCropYear_AreaId);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKT RFID CENTER";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCropYear_AreaId;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.Button btnEditDump;
    }
}

