using SKTRFIDShift.Interface;
using SKTRFIDShift.Model;
using SKTRFIDShift.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDShift
{
    public partial class DateForm : Form
    {
        public DateTime date;
        public DateTime dateStart;
        public DateTime dateStop;
        private IShift Shift;
        public string label;
        public DateForm(DateTime _date, DateTime _dateStart, DateTime _dateStop,string _label)
        {
            InitializeComponent();
            date = _date;
            dateStart = _dateStart;
            dateStop = _dateStop;
            label = _label;
            Shift = new ShiftService();
        }

        private void DateForm_Load(object sender, EventArgs e)
        {
            if (label == "เริ่มต้น")
            {
                dateTimePickerDateTime.Value = date.Date;
                dateTimePickerDate.Value = dateStart.Date;
                dateTimePickerTime.Value = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, dateStart.Hour, dateStart.Minute, dateStart.Second);
            }
            else
            {
                dateTimePickerDateTime.Value = date.Date;
                dateTimePickerDate.Value = dateStop.Date;
                dateTimePickerTime.Value = new DateTime(dateStop.Year, dateStop.Month, dateStop.Day, dateStop.Hour, dateStop.Minute, dateStop.Second);
            }
            
            label2.Text = label;
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerDate.Value.Date < dateTimePickerDateTime.Value.Date)
            {
                dateTimePickerDate.Value = dateTimePickerDateTime.Value.Date;
            }
            if (label == "เริ่มต้น")
            {
                if (dateTimePickerDate.Value.Date.Subtract(dateTimePickerDateTime.Value.Date).TotalDays > 0)
                {
                    dateTimePickerDate.Value = dateTimePickerDateTime.Value.Date;
                }
            }
            else
            {
                if (dateTimePickerDate.Value.Date.Subtract(dateTimePickerDateTime.Value.Date).TotalDays > 1)
                {
                    dateTimePickerDate.Value = dateTimePickerDateTime.Value.Date.AddDays(1);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("ต้องการยืนยันหรือไม่ ?", "SKT RFID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                ShiftModel _Shift = Shift.GetShift(dateTimePickerDateTime.Value.Date);
                if (_Shift.date.Date == dateTimePickerDateTime.Value.Date) // Update
                {
                    if (label == "เริ่มต้น")
                    {
                        ShiftModel data = new ShiftModel()
                        {
                            date = _Shift.date.Date,
                            date_start = new DateTime(dateTimePickerDate.Value.Year,
                                                        dateTimePickerDate.Value.Month,
                                                        dateTimePickerDate.Value.Day,
                                                        dateTimePickerTime.Value.Hour,
                                                        dateTimePickerTime.Value.Minute,
                                                        dateTimePickerTime.Value.Second),
                            date_stop = new DateTime(dateStop.Year,
                                                        dateStop.Month,
                                                        dateStop.Day,
                                                        dateStop.Hour,
                                                        dateStop.Minute,
                                                        dateStop.Second),
                        };
                        string message = Shift.Update(data);
                        MessageBox.Show(message);
                    }
                    else
                    {
                        ShiftModel data = new ShiftModel()
                        {
                            date = _Shift.date.Date,
                            date_start = new DateTime(dateStart.Year,
                                                        dateStart.Month,
                                                        dateStart.Day,
                                                        dateStart.Hour,
                                                        dateStart.Minute,
                                                        dateStart.Second),
                            date_stop = new DateTime(dateTimePickerDate.Value.Year,
                                                        dateTimePickerDate.Value.Month,
                                                        dateTimePickerDate.Value.Day,
                                                        dateTimePickerTime.Value.Hour,
                                                        dateTimePickerTime.Value.Minute,
                                                        dateTimePickerTime.Value.Second),                           
                        };
                        string message = Shift.Update(data);
                        MessageBox.Show(message);                        
                    }
                    var frm = (Form1)this.Owner;
                    if (frm != null)
                        frm.btnRefresh.PerformClick();
                    this.Dispose();
                }
            }
        }
    }
}
