using SKTDATABASE;
using SKTRFID1.Interface;
using SKTRFID1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFID1.Service
{
    class RFIDService : IRFID
    {
        public DataModel GetDataByDump(int dump)
        {
            DataModel data = new DataModel();
            try
            {
                string connectionString = DBConnectService.data_source();                
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT dump_id,
                                             area_id,
                                             crop_year,
                                             rfid,
                                             barcode,
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
                            data.dump_id = dr["dump_id"].ToString();
                            data.area_id = Convert.ToInt32(dr["area_id"].ToString());
                            data.crop_year = dr["crop_year"].ToString();
                            data.rfid = dr["rfid"].ToString();
                            data.barcode = dr["barcode"].ToString();
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

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM (SELECT * , RANK() OVER(partition by truck_number ORDER BY rfid_lastdate DESC) as rank  
                                                       from tb_rfid) as temp
                                                       WHERE temp.rank = 1", cn);

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
                    SqlCommand cmd = new SqlCommand($@"UPDATE tb_rfid SET rfid=N'{data.rfid}',
                                                                          barcode=N'{data.barcode}',
                                                                          cane_type='{data.cane_type}',
                                                                          allergen='{data.allergen}',
                                                                          truck_number=N'{data.truck_number}', 
                                                                          rfid_lastdate='{data.rfid_lastdate}',
                                                                          truck_type='{data.truck_type}',
                                                                          weight_type='{data.weight_type}',
                                                                          queue_status='{data.queue_status}'
                                                                          WHERE dump_id='{data.dump_id}' ", cn);
                    
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
