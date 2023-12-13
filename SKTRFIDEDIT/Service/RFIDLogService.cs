using SKTRFIDEDIT.Interface;
using SKTRFIDEDIT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDEDIT.Service
{
    class RFIDLogService : IRFIDLog
    {
        public List<DataModel> GetRFID(int n,string dump,string truck_number,string date)
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

                    SqlCommand cmd = new SqlCommand($@"SELECT TOP {n} dump_id,
			                                                    area_id,
			                                                    crop_year,
			                                                    truck_number,
                                                                truck_type,
                                                                weight_type,
                                                                queue_status,
                                                                barcode,
			                                                    rfid,
			                                                    cane_type,
			                                                    allergen,
			                                                    rfid_lastdate
                                                    from tb_rfid_log
                                                    WHERE dump_id LIKE '{dump}%' AND truck_number LIKE N'%{truck_number}%' AND CONVERT(VARCHAR(25), rfid_lastdate, 126) LIKE '{date}%'ORDER BY rfid_lastdate DESC", cn);

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
                                cane_type = Convert.ToInt32(dr["cane_type"].ToString()),
                                allergen = Convert.ToInt32(dr["allergen"].ToString()),
                                truck_number = dr["truck_number"].ToString(),
                                truck_type = Convert.ToInt32(dr["truck_type"].ToString()),
                                weight_type = Convert.ToInt32(dr["weight_type"].ToString()),
                                queue_status = Convert.ToInt32(dr["queue_status"].ToString()),
                                rfid_lastdate = Convert.ToDateTime(dr["rfid_lastdate"].ToString())
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

        public string UpdateRFID(DataModel data)
        {
            try
            {
                string connectionString = DBConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"UPDATE tb_rfid_log SET cane_type='{data.cane_type}',
                                                                          allergen='{data.allergen}'      
                                                                          WHERE dump_id='{data.dump_id}' AND
                                                                                truck_number=N'{data.truck_number}' AND
                                                                                rfid_lastdate='{data.rfid_lastdate}'", cn);
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
