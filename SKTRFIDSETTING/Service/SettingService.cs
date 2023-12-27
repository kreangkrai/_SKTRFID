using SKTDATABASE;
using SKTRFIDSETTING.Interface;
using SKTRFIDSETTING.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDSETTING.Service
{
    class SettingService : ISetting
    {
        string connectionString = "";
        public SettingService(int phase)
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
        public DataModel GetData()
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

                        SqlCommand cmd = new SqlCommand($@"SELECT no,area_id,crop_year,ip1,ip2,ip_plc FROM tb_setting", cn);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                data.no = Convert.ToInt32(dr["no"].ToString());
                                data.area_id = Convert.ToInt32(dr["area_id"].ToString());
                                data.crop_year = dr["crop_year"].ToString();
                                data.ip1 = dr["ip1"].ToString();
                                data.ip2 = dr["ip2"].ToString();
                                data.ip_plc = dr["ip_plc"].ToString();
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

        public string Update(DataModel setting)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"UPDATE tb_setting SET area_id=N'{setting.area_id}',
                                                                          crop_year=N'{setting.crop_year}'
                                                                          WHERE no='{setting.no}' ", cn);
                    cmd.ExecuteNonQuery();
                }
                return "เรียบร้อย";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
