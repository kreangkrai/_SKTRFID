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
        string connectionString = "";
        public MonitorService(int phase)
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

        public List<DataModel> GetLastUpdate(string crop_year)
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

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_rfid where crop_year='{crop_year}'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataModel data = new DataModel()
                            {                              
                                dump_id = Int32.Parse(dr["dump_id"].ToString()),   
                                area_id = Int32.Parse(dr["area_id"].ToString()),
                                allergen = dr["allergen"].ToString(),
                                barcode = dr["barcode"].ToString(),
                                farmer_name = dr["farmer_name"].ToString(),
                                cane_type = Int32.Parse(dr["cane_type"].ToString()),
                                crop_year = dr["crop_year"].ToString(),
                                rfid = dr["rfid"].ToString(),
                                truck_type = Int32.Parse(dr["truck_type"].ToString()),
                                rfid_lastdate = Convert.ToDateTime(dr["rfid_lastdate"].ToString()),
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
