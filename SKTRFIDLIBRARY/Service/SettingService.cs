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
    public class SettingService : ISetting
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
        public SettingModel GetSetting()
        {
            SettingModel data = new SettingModel();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT no,area_id,crop_year,ip1,ip2,ip_plc,ip_plc_common FROM tb_setting", cn);

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
                            data.ip_plc_common = dr["ip_plc_common"].ToString();
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
    }
}
