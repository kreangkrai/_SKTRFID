using OfficeOpenXml;
using SKTDATABASE;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Service;
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
        private ICodeType CodeType;
        string connectionString = "";
        public ExportService(int phase)
        {
            CodeType = new CodeTypeService();
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
                            worksheet.Cells["A" + (i + startRows)].Value = _reports[i].queue;
                            worksheet.Cells["B" + (i + startRows)].Value = _reports[i].barcode;
                            worksheet.Cells["C" + (i + startRows)].Value = _reports[i].farmer_name;
                            worksheet.Cells["D" + (i + startRows)].Value = _reports[i].dump_id;
                            worksheet.Cells["E" + (i + startRows)].Value = _reports[i].round;
                            worksheet.Cells["F" + (i + startRows)].Value = _reports[i].date;
                            worksheet.Cells["G" + (i + startRows)].Value = _reports[i].truck_number;
                            worksheet.Cells["H" + (i + startRows)].Value = CodeType.CaneType(_reports[i].cane_type);
                            worksheet.Cells["I" + (i + startRows)].Value = CodeType.allergenType(_reports[i].allergen);
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
                                                WHERE rfid.rfid_lastdate BETWEEN '{start.ToString("yyyy-MM-dd 00:00:00")}' AND '{stop.Date.ToString("yyyy-MM-dd 23:59:59")}' AND queue is not null
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
                int intdex_first_1 = datas.FindIndex(a => a.queue == 1);
                if (datas.Count > 0)
                {
                    datas.RemoveRange(0, intdex_first_1); // Start Queue 1  , Remove
                }
                int current_round = 0;
                int current_dump = datas[0].dump_id;
                int current_queue = datas[0].queue;
                int last_dump = current_dump;
                int last_queue = current_queue;
                for (int i = 0; i < datas.Count; i++)
                {                    
                    current_dump = datas[i].dump_id;
                    if (current_dump <= last_dump)
                    {
                        current_round++;
                    }
                    current_queue = datas[i].queue;
                    if (current_queue < last_queue)
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
                    last_dump = current_dump;
                    last_queue = current_queue;
                }              
                return reports;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                return reports;
            }
        }
        public List<ReportModel> GetReportByDBarCode(string barcode,string crop_year)
        {
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

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_rfid_log WHERE barcode LIKE '%{barcode}%' AND crop_year='{crop_year}' AND queue is not null ", cn);
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

                for (int i = 0; i < datas.Count; i++)
                {
                    
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
                        round = 0
                    });

                }
                return reports;
            }
            catch
            {
                return reports;
            }
        }
    }
}
