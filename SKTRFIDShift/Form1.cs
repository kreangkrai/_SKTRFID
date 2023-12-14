using SKTRFIDSHIFT.Interface;
using SKTRFIDSHIFT.Model;
using SKTRFIDSHIFT.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDSHIFT
{
    public partial class Form1 : Form
    {
        private IShift Shift;
        List<ShiftModel> datas = new List<ShiftModel> ();
        List<ShiftModel> old_shift = new List<ShiftModel>();
        public Form1()
        {
            InitializeComponent();
            Shift = new ShiftService();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
                {
                    var dateStart = DateTime.ParseExact(dataGridView1[1, e.RowIndex].Value.ToString(),"dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    var dateStop = DateTime.ParseExact(dataGridView1[2, e.RowIndex].Value.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    string label = "";
                    var date = DateTime.ParseExact(dataGridView1[0, e.RowIndex].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if (e.ColumnIndex == 1)
                    {
                        label = "เริ่มต้น";
                    }
                    if (e.ColumnIndex == 2)
                    {
                        label = "สิ้นสุด";
                    }
                    DateForm form = new DateForm(date, dateStart,dateStop, label);
                    form.Show(this);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePickerStop.Value = dateTimePickerStop.Value.AddDays(7);
            LoadData();
        }

        void LoadData()
        {
            old_shift = new List<ShiftModel>();
            dataGridView1.Rows.Clear();
            datas = Shift.GetShifts(dateTimePickerStart.Value.Date, dateTimePickerStop.Value.Date);    

            int i = 0;            
            for (DateTime date = dateTimePickerStart.Value; date < dateTimePickerStop.Value; date = date.AddDays(1))
            {
                ShiftModel shift = new ShiftModel();
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Height = 35;
                bool check_have_date = datas.Any(a => a.date.Date == date.Date);
                if (check_have_date)
                {
                    ShiftModel _shift = datas.Where(w => w.date.Date == date.Date).FirstOrDefault();
                    DateTime _date = date.Date;
                    DateTime _date_start = _shift.date_start;
                    DateTime _date_stop = _shift.date_stop;
                    row.Cells[0].Value = _date.ToString("dd/MM/yyyy");
                    row.Cells[1].Value = _date_start.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[2].Value = _date_stop.ToString("dd/MM/yyyy HH:mm:ss");

                    shift = new ShiftModel()
                    {
                        date = _date,
                        date_start = _date_start,
                        date_stop = _date_stop
                    };
                    old_shift.Add(_shift);
                }
                else
                {
                    DateTime _date = date.Date;
                    DateTime _date_start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    DateTime _date_stop = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

                    row.Cells[0].Value = _date.ToString("dd/MM/yyyy");
                    row.Cells[1].Value = _date_start.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells[2].Value = _date_stop.ToString("dd/MM/yyyy HH:mm:ss");

                    shift = new ShiftModel()
                    {
                        date = _date,
                        date_start = _date_start,
                        date_stop = _date_stop
                    };
                    old_shift.Add(shift);
                }
                dataGridView1.Rows.Add(row);
                i++;               
            }

            old_shift = old_shift.OrderBy(o => o.date).ToList();
        }
        private void dateTimePickerStop_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStop.Value < dateTimePickerStart.Value)
            {
                dateTimePickerStop.Value = dateTimePickerStart.Value;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();

            //Insert
            List<ShiftModel> insert = old_shift.Where(w => !datas.Select(s => s.date.Date).Contains(w.date.Date)).ToList();
            List<string> messagesInsert = new List<string>();
            for (int i = 0; i < insert.Count; i++)
            {
                ShiftModel data = new ShiftModel()
                {
                    date = insert[i].date,
                    date_start = insert[i].date_start,
                    date_stop = insert[i].date_stop,
                };
                string message = Shift.Insert(data);
                messagesInsert.Add(message);
            }
            if (messagesInsert.Count > 0)
            {
                bool check_message = messagesInsert.All(a => a == "Success");
                //if (check_message)
                //{
                //    MessageBox.Show("Insert Success");
                //}
                //else
                //{
                //    MessageBox.Show("Insert Fail");
                //}
            }
        }
    }
}
