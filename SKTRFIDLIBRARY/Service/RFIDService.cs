using SKTDATABASE;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDLIBRARY.Service
{
    public class RFIDService : IRFID
    {
        string connectionString = "";
        public RFIDService(int phase)
        {
            if (phase == 1)
            {
                connectionString = DBPHASE1ConnectService.data_source();
            }
            if (phase == 2)
            {
                connectionString = DBPHASE2ConnectService.data_source();
            }
        }
        public DataModel GetDataByDump(int dump)
        {
            DataModel data = new DataModel();
            try
            {              
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT queue,
                                             dump_id,
                                             area_id,
                                             crop_year,
                                             rfid,
                                             barcode,
                                             farmer_name
                                             cane_type,
                                             allergen,
                                             truck_number,
                                             truck_type,
                                             weight_type,
                                             queue_status,
                                             convert(nvarchar,rfid_lastdate,120) as rfid_lastdate
                                    from dbo.tb_rfid Where dump_id= '{dump}'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            data.queue = Int32.Parse(dr["queue"].ToString());
                            data.dump_id = dr["dump_id"].ToString();
                            data.area_id = Convert.ToInt32(dr["area_id"].ToString());
                            data.crop_year = dr["crop_year"].ToString();
                            data.rfid = dr["rfid"].ToString();
                            data.barcode = dr["barcode"].ToString();
                            data.farmer_name = dr["farmer_name"].ToString();
                            data.cane_type = Convert.ToInt32(dr["cane_type"].ToString());
                            data.allergen = dr["allergen"].ToString();
                            data.truck_number = dr["truck_number"].ToString();
                            data.truck_type = Convert.ToInt32(dr["truck_type"].ToString());
                            data.weight_type = Convert.ToInt32(dr["weight_type"].ToString());
                            data.queue_status = Convert.ToInt32(dr["queue_status"].ToString());
                            data.rfid_lastdate = Convert.ToDateTime(dr["rfid_lastdate"].ToString());
                        }
                    }
                    dr.Close();
                }
                return data;
            }
            catch
            {
                return data;
            }
        }

        public List<DataModel> GetDatas(string crop_year)
        {
            List<DataModel> datas = new List<DataModel>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT * , RANK() OVER(partition by truck_number ORDER BY rfid_lastdate DESC) as rank  from tb_rfid where crop_year = '{crop_year}' and barcode not like '9%' union all
                                                    SELECT * , '1'  from tb_rfid where crop_year = '{crop_year}' and barcode like '9%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                dump_id = dr["dump_id"].ToString(),
                                area_id = Convert.ToInt32(dr["area_id"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                farmer_name = dr["farmer_name"].ToString(),
                                cane_type = Convert.ToInt32(dr["cane_type"].ToString()),
                                allergen = dr["allergen"].ToString(),
                                truck_number = dr["truck_number"].ToString(),
                                truck_type = Convert.ToInt32(dr["truck_type"].ToString()),
                                weight_type = Convert.ToInt32(dr["weight_type"].ToString()),
                                queue_status = Convert.ToInt32(dr["queue_status"].ToString()),
                                rfid_lastdate = dr["rfid_lastdate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["rfid_lastdate"].ToString())
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

        public List<DataModel> GetDatasByAreaYear(int area_id, string crop_year)
        {
            List<DataModel> datas = new List<DataModel>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT
                                             dump_id,
                                             area_id,
                                             crop_year,
                                             rfid,
                                             barcode,
                                             farmer_name,
                                             cane_type,
                                             allergen,
                                             truck_number,
                                             truck_type,
                                             weight_type,
                                             queue_status,
                                             convert(nvarchar, rfid_lastdate, 120) as rfid_lastdate
                                    from dbo.tb_rfid Where area_id = '{area_id}' AND crop_year='{crop_year}'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {
                                dump_id = dr["dump_id"].ToString(),
                                area_id = Convert.ToInt32(dr["area_id"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                farmer_name = dr["farmer_name"].ToString(),
                                cane_type = Convert.ToInt32(dr["cane_type"].ToString()),
                                allergen = dr["allergen"].ToString(),
                                truck_number = dr["truck_number"].ToString(),
                                truck_type = Convert.ToInt32(dr["truck_type"].ToString()),
                                weight_type = Convert.ToInt32(dr["weight_type"].ToString()),
                                queue_status = Convert.ToInt32(dr["queue_status"].ToString()),
                                rfid_lastdate = dr["rfid_lastdate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["rfid_lastdate"].ToString())
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

        public string InsertRFID(List<DataModel> datas)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    for (int i = 0; i < datas.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand($@"INSERT INTO tb_rfid VALUES('{datas[i].dump_id}','{datas[i].area_id}',
                                                                                      '{datas[i].crop_year}','{datas[i].rfid}','{datas[i].barcode}',N'{datas[i].farmer_name}',
                                                                                      '{datas[i].cane_type}','{datas[i].allergen}',N'{datas[i].truck_number}',
                                                                                      '{datas[i].truck_type}','{datas[i].weight_type}','{datas[i].queue_status}','{datas[i].rfid_lastdate}')", cn);
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public string InsertRFIDLog(DataModel data)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"INSERT INTO tb_rfid_log VALUES('{data.queue}','{data.dump_id}','{data.area_id}',
                                                                                      '{data.crop_year}','{data.rfid}','{data.barcode}',N'{data.farmer_name}',
                                                                                      '{data.cane_type}','{data.allergen}',N'{data.truck_number}',
                                                                                      '{data.truck_type}','{data.weight_type}','{data.queue_status}','{data.rfid_lastdate}')", cn);
                    cmd.ExecuteNonQuery();
                }
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public string UpdateBarcodeRFID(DataModel data)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand($@"UPDATE tb_rfid SET barcode=N'{data.barcode}'
                                                                          WHERE dump_id='{data.dump_id}' AND area_id='{data.area_id}' AND crop_year='{data.crop_year}' ", cn);

                    cmd.ExecuteNonQuery();
                }
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public string UpdateRFID(DataModel data)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand($@"UPDATE tb_rfid SET rfid=N'{data.rfid}',
                                                                          barcode=N'{data.barcode}',
                                                                          farmer_name = N'{data.farmer_name}',
                                                                          cane_type='{data.cane_type}',
                                                                          allergen='{data.allergen}',
                                                                          truck_number=N'{data.truck_number}', 
                                                                          rfid_lastdate='{data.rfid_lastdate}',
                                                                          truck_type='{data.truck_type}',
                                                                          weight_type='{data.weight_type}',
                                                                          queue_status='{data.queue_status}'
                                                                          WHERE dump_id='{data.dump_id}' AND area_id='{data.area_id}' AND crop_year='{data.crop_year}' ", cn);

                    cmd.ExecuteNonQuery();
                }
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }
    }
}
