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
        public string Export(string start, string stop)
        {
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

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_rfid_log WHERE rfid_lastdate BETWEEN '{start}' AND '{stop}' ORDER BY rfid_lastdate,dump_id ", cn);
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
                                truck_number = dr["truck_number"].ToString(),
                                rfid_lastdate = Convert.ToDateTime(dr["rfid_lastdate"].ToString())
                            };
                            datas.Add(data);
                        }
                    }
                    dr.Close();
                }

                datas = datas.OrderBy(o => o.rfid_lastdate).ThenBy(t => t.dump_id).ToList();
                List<string> dates = datas.GroupBy(g => g.rfid_lastdate.ToString("dd-MM-yyyy")).Select(s => s.Key).ToList();
                List<ReportModel> reports = new List<ReportModel>();
                int current_round = 1;
                string last_date = "";
                for (int i = 0; i < datas.Count; i++)
                {
                    var last_round = reports.Where(w => w.round == current_round).ToList();
                    bool check_dump_less = last_round
                                            .Where(w => w.date.ToString("dd-MM-yyyy").Equals(datas[i].rfid_lastdate.ToString("dd-MM-yyyy")))
                                            .Any(a => a.dump_id >= datas[i].dump_id);

                    if (check_dump_less)
                    {
                        current_round++;
                    }
                    if (last_date != datas[i].rfid_lastdate.ToString("dd-MM-yyyy"))
                    {
                        current_round = 1;
                    }

                    reports.Add(new ReportModel()
                    {
                        dump_id = datas[i].dump_id,
                        date = datas[i].rfid_lastdate,
                        area_id = datas[i].area_id,
                        crop_year = datas[i].crop_year,
                        barcode = datas[i].barcode,
                        cane_type = datas[i].cane_type,
                        rfid = datas[i].rfid,
                        truck_number = datas[i].truck_number,
                        round = current_round
                    });

                    last_date = datas[i].rfid_lastdate.ToString("dd-MM-yyyy");
                }

                string fileName = "skt_report.xlsm";
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                FileInfo template = new FileInfo(Path.Combine(path, fileName));
                using (var package = new ExcelPackage(template))
                {
                    for (int k = 0; k < dates.Count; k++)
                    {
                        List<ReportModel> _reports = reports.Where(w => w.date.ToString("dd-MM-yyyy") == dates[k]).ToList();
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
                            worksheet.Cells["H" + (i + startRows)].Value = _reports[i].truck_number;
                            worksheet.Cells["I" + (i + startRows)].Value = _reports[i].rfid;
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
        private string CaneType(int n)
        {
            List<string> canes_type = new List<string>();
            canes_type.Add("สดท่อน");
            canes_type.Add("ไฟไหม้ท่อน");
            canes_type.Add("สดลำ");
            canes_type.Add("ไฟไหม้ลำ");

            return canes_type[n];
        }
    }
}
