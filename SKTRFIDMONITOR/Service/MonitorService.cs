using SKTDATABASE;
using SKTRFIDMONITOR.Interface;
using SKTRFIDMONITOR.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDMONITOR.Service
{
    class MonitorService : IMonitor
    {
        public List<DataModel> GetDatas()
        {
            List<DataModel> datas = new List<DataModel>();
            try
            {
                string connectionString = DBConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT rfid.dump_id,
	                                                   CCS.Queue as queue,
	                                                   rfid.area_id,
	                                                   rfid.barcode,
	                                                   rfid.crop_year,
	                                                   rfid.cane_type,
	                                                   rfid.rfid,
	                                                   rfid.truck_number,
                                                       rfid.allergen,
	                                                   CCS.DumpDate as date,
                                                       CCS.DumpTime as time FROM tb_rfid_log as rfid 
                                                LEFT JOIN
                                                (SELECT * FROM [192.168.250.2,1798].[CCS].[dbo].[Loading]) as CCS ON rfid.barcode = CCS.Barcode
                                                ORDER BY CCS.DumpDate,CCS.DumpTime DESC", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                dump_id = Int32.Parse(dr["dump_id"].ToString()),
                                queue = Int32.Parse(dr["queue"].ToString()),
                                area_id = Int32.Parse(dr["area_id"].ToString()),
                                allergen = dr["allergen"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                cane_type = Int32.Parse(dr["cane_type"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                date = dr["date"].ToString(),
                                time = dr["time"].ToString(),
                                truck_number = dr["truck_number"].ToString()
                            };
                            datas.Add(data);
                        }
                    }
                    dr.Close();
                }
                return datas;
            }
            catch
            {
                return datas;
            }
        }

        public List<DataModel> GetDatasByBarCode(string barcode)
        {
            List<DataModel> datas = new List<DataModel>();
            if (barcode.Trim() == "")
            {
                return datas;
            }
            try
            {
                string connectionString = DBConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT rfid.dump_id,
	                                                   CCS.Queue as queue,
	                                                   rfid.area_id,
	                                                   rfid.barcode,
	                                                   rfid.crop_year,
	                                                   rfid.cane_type,
	                                                   rfid.rfid,
	                                                   rfid.truck_number,
                                                       rfid.allergen,
	                                                   CCS.DumpDate as date,
                                                       CCS.DumpTime as time FROM tb_rfid_log as rfid 
                                                LEFT JOIN
                                                (SELECT * FROM [192.168.250.2,1798].[CCS].[dbo].[Loading]) as CCS ON rfid.barcode = CCS.Barcode
                                                WHERE rfid.barcode LIKE '%{barcode}%'
                                                ORDER BY CCS.DumpDate,CCS.DumpTime DESC", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                dump_id = Int32.Parse(dr["dump_id"].ToString()),
                                queue = Int32.Parse(dr["queue"].ToString()),
                                area_id = Int32.Parse(dr["area_id"].ToString()),
                                allergen = dr["allergen"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                cane_type = Int32.Parse(dr["cane_type"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                date = dr["date"].ToString(),
                                time = dr["time"].ToString(),
                                truck_number = dr["truck_number"].ToString()
                            };
                            datas.Add(data);
                        }
                    }
                    dr.Close();
                }
                return datas;
            }
            catch
            {
                return datas;
            }
        }

        public List<DataModel> GetDatasByDate(DateTime start, DateTime stop)
        {
            List<DataModel> datas = new List<DataModel>();
            try
            {
                string connectionString = DBConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT rfid.dump_id,
	                                                   CCS.Queue,
	                                                   rfid.area_id,
	                                                   rfid.barcode,
	                                                   rfid.crop_year,
	                                                   rfid.cane_type,
	                                                   rfid.rfid,
	                                                   rfid.truck_number,
	                                                   rfid.allergen,
	                                                   CCS.DumpDate as date,
	                                                   CCS.DumpTime as time FROM tb_rfid_log as rfid 
                                                LEFT JOIN
                                                (SELECT * FROM [192.168.250.2,1798].[CCS].[dbo].[Loading]) as CCS ON rfid.barcode = CCS.Barcode
                                                WHERE CONVERT(date, CCS.DumpDate,103) BETWEEN '{start.Date.ToString("yyyy-MM-dd")}' AND '{stop.Date.ToString("yyyy-MM-dd")}'
                                                ORDER BY CCS.DumpDate,CCS.DumpTime DESC", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                dump_id = Int32.Parse(dr["dump_id"].ToString()),
                                queue = Int32.Parse(dr["queue"].ToString()),
                                area_id = Int32.Parse(dr["area_id"].ToString()),
                                allergen = dr["allergen"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                cane_type = Int32.Parse(dr["cane_type"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                date = dr["date"].ToString(),
                                time = dr["time"].ToString(),
                                truck_number = dr["truck_number"].ToString()
                            };
                            datas.Add(data);
                        }
                    }
                    dr.Close();
                }
                return datas;
            }
            catch
            {
                return datas;
            }
        }
    }
}
