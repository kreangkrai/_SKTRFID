using OfficeOpenXml;
using SKTDATABASE;
using SKTRFIDREPORT.Interface;
using SKTRFIDREPORT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKTRFIDREPORT.Service
{
    class ExportService : IExport
    {
        private IShift Shift;
        string connectionString = "";
        public ExportService(int phase)
        {
            Shift = new ShiftService();
            if (phase == 1)
            {
                connectionString = DBPHASE1ConnectService.data_source();
            }
            if (phase == 2)
            {
                connectionString = DBPHASE2ConnectService.data_source();
            }
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
                            worksheet.Cells["G" + (i + startRows)].Value = _reports[i].farmer_name;
                            worksheet.Cells["H" + (i + startRows)].Value = CaneType(_reports[i].cane_type);
                            worksheet.Cells["I" + (i + startRows)].Value = allergenType(_reports[i].allergen);
                            worksheet.Cells["J" + (i + startRows)].Value = _reports[i].truck_number;
                            worksheet.Cells["K" + (i + startRows)].Value = _reports[i].rfid;
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
            List<ShiftModel> shifts = Shift.GetShiftByDate(start.Date.Date, stop.Date.Date);

            List<ReportModel> reports = new List<ReportModel>();
            try
            {
                List<DataModel> datas = new List<DataModel>();

                
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    //SqlCommand cmd = new SqlCommand($@"SELECT rfid.dump_id,
	                   //                                CCS.Queue as queue,
	                   //                                rfid.area_id,
	                   //                                rfid.barcode,
                    //                                   rfid.farmer_name,
	                   //                                rfid.crop_year,
	                   //                                rfid.cane_type,
	                   //                                rfid.rfid,
	                   //                                rfid.truck_number,
	                   //                                rfid.allergen,
	                   //                                rfid.rfid_lastdate FROM tb_rfid_log as rfid 
                    //                            LEFT JOIN
                    //                            (SELECT * FROM [192.168.250.2,1798].[CCS].[dbo].[Loading]) as CCS ON rfid.barcode = CCS.Barcode
                    //                            WHERE rfid.rfid_lastdate BETWEEN '{start.ToString("yyyy-MM-dd 00:00:00")}' AND '{stop.Date.ToString("yyyy-MM-dd 23:59:59")}' AND CCS.queue IS NOT NULL
                    //                            ORDER BY rfid.rfid_lastdate", cn);
                    SqlCommand cmd = new SqlCommand($@"SELECT rfid.dump_id,
	                                                   rfid.queue,
	                                                   rfid.area_id,
	                                                   rfid.barcode,
                                                       rfid.farmer_name,
	                                                   rfid.crop_year,
	                                                   rfid.cane_type,
	                                                   rfid.rfid,
	                                                   rfid.truck_number,
	                                                   rfid.allergen,
	                                                   rfid.rfid_lastdate FROM tb_rfid_log as rfid 
                                                WHERE rfid.rfid_lastdate BETWEEN '{start.ToString("yyyy-MM-dd 00:00:00")}' AND '{stop.Date.ToString("yyyy-MM-dd 23:59:59")}'
                                                ORDER BY rfid.rfid_lastdate", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                queue = Convert.ToInt32(dr["queue"].ToString()),
                                dump_id = Convert.ToInt32(dr["dump_id"].ToString()),
                                area_id = Convert.ToInt32(dr["area_id"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                farmer_name = dr["farmer_name"].ToString(),
                                cane_type = Convert.ToInt32(dr["cane_type"].ToString()),
                                allergen = dr["allergen"].ToString(),
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
                int current_dump = datas[0].dump_id;
                for (int i = 0; i < datas.Count; i++)
                {
                   
                    int last_dump = reports.Count> 0 ? reports.LastOrDefault().dump_id : current_dump;
                    if (current_dump > last_dump)
                    {
                        
                        current_round++;
                    }
                    else
                    {
                        current_round = 1;
                    }
                    reports.Add(new ReportModel()
                    {
                        queue = datas[i].queue,
                        dump_id = datas[i].dump_id,
                        date = datas[i].rfid_lastdate,
                        area_id = datas[i].area_id,
                        crop_year = datas[i].crop_year,
                        barcode = datas[i].barcode,
                        farmer_name = datas[i].farmer_name,
                        cane_type = datas[i].cane_type,
                        allergen = datas[i].allergen,
                        rfid = datas[i].rfid,
                        truck_number = datas[i].truck_number,
                        round = current_round
                    });

                }
                //int current_round = 1;
                //for (int i = 0; i < shifts.Count; i++)
                //{
                //    DateTime _start = shifts[i].date_start;
                //    DateTime _stop = shifts[i].date_stop;
                //    List<DataModel> _datas = datas.Where(w => w.rfid_lastdate >= _start && w.rfid_lastdate <= _stop).ToList();
                //    current_round = 1;
                //    string last_date = "";
                //    for (int j = 0; j < _datas.Count; j++)
                //    {

                //        var last_round = reports.Where(w => w.round == current_round).ToList();
                //        bool check_dump_less = last_round
                //                                .Where(w => w.date.ToString("dd-MM-yyyy").Equals(_datas[j].rfid_lastdate.ToString("dd-MM-yyyy")))
                //                                .Any(a => a.dump_id >= _datas[j].dump_id);

                //        if (check_dump_less)
                //        {
                //            current_round++;
                //        }
                //        if (last_date != _datas[j].rfid_lastdate.ToString("dd-MM-yyyy"))
                //        {
                //            current_round = 1;
                //        }
                //        reports.Add(new ReportModel()
                //        {
                //            queue = _datas[j].queue,
                //            dump_id = _datas[j].dump_id,
                //            date = _datas[j].rfid_lastdate,
                //            area_id = _datas[j].area_id,
                //            crop_year = _datas[j].crop_year,
                //            barcode = _datas[j].barcode,
                //            farmer_name = _datas[j].farmer_name,
                //            cane_type = _datas[j].cane_type,
                //            allergen = _datas[j].allergen,
                //            rfid = _datas[j].rfid,
                //            truck_number = _datas[j].truck_number,
                //            round = current_round
                //        });
                //        last_date = _datas[j].rfid_lastdate.ToString("dd-MM-yyyy");
                //    }
                //}              
                return reports;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return reports;
            }
        }

        private string CaneType(int n)
        {
            if (n < 1)
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
        private string allergenType(string n)
        {
            if(n == "No")
            {
                return "ไม่มี";
            }
            else
            {
                return "มี";
            }
        }
        int typeCaneIndex(string s)
        {
            List<string> canes = new List<string>();
            canes.Add("สดท่อน");
            canes.Add("ไฟไหม้ท่อน");
            canes.Add("สดลำ");
            canes.Add("ไฟไหม้ลำ");
            return canes.FindIndex(w => w == s);
        }
        int typeAllergenIndex(string s)
        {
            List<string> contaminants = new List<string>();
            contaminants.Add("ไม่มี");
            contaminants.Add("มี");
            return contaminants.FindIndex(w => w == s);
        }
        public List<ReportModel> GetReportByDBarCode(string barcode)
        {
            List<ShiftModel> shifts = Shift.GetShiftByDate(DateTime.Now.AddYears(-3).Date, DateTime.Now.Date);

            List<ReportModel> reports = new List<ReportModel>();
            try
            {
                List<DataModel> datas = new List<DataModel>();

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_rfid_log WHERE barcode LIKE '%{barcode}%' ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                queue = Convert.ToInt32(dr["queue"].ToString()),
                                dump_id = Convert.ToInt32(dr["dump_id"].ToString()),
                                area_id = Convert.ToInt32(dr["area_id"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                farmer_name = dr["farmer_name"].ToString(),
                                cane_type = Convert.ToInt32(dr["cane_type"].ToString()),
                                allergen = dr["allergen"].ToString(),
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return reports;
            }
        }
    }
}
