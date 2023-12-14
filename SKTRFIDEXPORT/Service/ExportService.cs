using OfficeOpenXml;
using SKTRFIDEXPORT.Interface;
using SKTRFIDEXPORT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEXPORT.Service
{
    class ExportService : IExport
    {
        private IShift Shift;
        public ExportService()
        {
            Shift = new ShiftService();
        }
        public string Export(List<ReportModel> reports)
        {
            try { 
                string fileName = "skt_report.xlsm";
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                List<string> dates = reports.GroupBy(g => g.date.Date).Select(s => s.Key.Date.ToString("dd/MM/yyyy")).ToList();
                FileInfo template = new FileInfo(Path.Combine(path, fileName));
                using (var package = new ExcelPackage(template))
                {
                    for (int k = 0; k < dates.Count; k++)
                    {
                        List<ReportModel> _reports = reports.Where(w => w.date.ToString("dd/MM/yyyy") == dates[k]).ToList();
                        var workbook = package.Workbook;
                        var worksheet = workbook.Worksheets.Copy("template", dates[k]);
                        int startRows = 3;
                        for (int i = 0; i < _reports.Count; i++)
                        {
                            worksheet.Cells["A" + (i + startRows)].Value = _reports[i].dump_id;
                            worksheet.Cells["B" + (i + startRows)].Value = _reports[i].date;
                            worksheet.Cells["C" + (i + startRows)].Value = _reports[i].round;
                            worksheet.Cells["D" + (i + startRows)].Value = _reports[i].area_id;
                            worksheet.Cells["E" + (i + startRows)].Value = _reports[i].crop_year;
                            worksheet.Cells["F" + (i + startRows)].Value = _reports[i].barcode;
                            worksheet.Cells["G" + (i + startRows)].Value = CaneType(_reports[i].cane_type);
                            worksheet.Cells["H" + (i + startRows)].Value = allergenType(_reports[i].allergen);
                            worksheet.Cells["I" + (i + startRows)].Value = _reports[i].truck_number;
                            worksheet.Cells["J" + (i + startRows)].Value = _reports[i].rfid;
                        }
                    }
                    package.SaveAs(new FileInfo("D:\\Report\\skt_report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsm"));
                }
                return "เรียบร้อย";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ReportModel> GetReportByDate(DateTime start, DateTime stop)
        {
            List<ShiftModel> shifts = Shift.GetShiftByDate(start.Date, stop.Date);

            List<ReportModel> reports = new List<ReportModel>();
            try
            {
                List<DataModel> datas = new List<DataModel>();

                string connectionString = DBConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_rfid_log WHERE rfid_lastdate BETWEEN '{start.Date}' AND '{stop.Date}' ORDER BY rfid_lastdate,dump_id ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                dump_id = Convert.ToInt32(dr["dump_id"].ToString()),
                                area_id = Convert.ToInt32(dr["area_id"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                cane_type = Convert.ToInt32(dr["cane_type"].ToString()),
                                allergen = Convert.ToInt32(dr["allergen"].ToString()),
                                truck_number = dr["truck_number"].ToString(),
                                rfid_lastdate = Convert.ToDateTime(dr["rfid_lastdate"].ToString())
                            };
                            datas.Add(data);
                        }
                    }
                    dr.Close();
                }

                datas = datas.OrderBy(o => o.rfid_lastdate).ThenBy(t => t.dump_id).ToList();

                int current_round = 1;
                for (int i = 0; i < shifts.Count; i++)
                {
                    DateTime _start = shifts[i].date_start;
                    DateTime _stop = shifts[i].date_stop;
                    List<DataModel> _datas = datas.Where(w => w.rfid_lastdate >= _start && w.rfid_lastdate <= _stop).ToList();
                    current_round = 1;
                    string last_date = "";
                    for (int j = 0; j < _datas.Count; j++)
                    {
                        
                        var last_round = reports.Where(w => w.round == current_round).ToList();
                        bool check_dump_less = last_round
                                                .Where(w => w.date.ToString("dd-MM-yyyy").Equals(_datas[j].rfid_lastdate.ToString("dd-MM-yyyy")))
                                                .Any(a => a.dump_id >= _datas[j].dump_id);

                        if (check_dump_less)
                        {
                            current_round++;
                        }
                        if (last_date != _datas[j].rfid_lastdate.ToString("dd-MM-yyyy"))
                        {
                            current_round = 1;
                        }
                        reports.Add(new ReportModel()
                        {
                            dump_id = _datas[j].dump_id,
                            date = _datas[j].rfid_lastdate,
                            area_id = _datas[j].area_id,
                            crop_year = _datas[j].crop_year,
                            barcode = _datas[j].barcode,
                            cane_type = _datas[j].cane_type,
                            allergen = _datas[j].allergen,
                            rfid = _datas[j].rfid,
                            truck_number = _datas[j].truck_number,
                            round = current_round
                        });
                        last_date = _datas[j].rfid_lastdate.ToString("dd-MM-yyyy");
                    }
                }              
                return reports;
            }
            catch
            {
                return reports;
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
        private string allergenType(int n)
        {
            List<string> contams = new List<string>();
            contams.Add("ไม่มี");
            contams.Add("มี");
            return contams[n];
        }
    }
}
