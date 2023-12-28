using SKTDATABASE;
using SKTRFIDREPORT.Interface;
using SKTRFIDREPORT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDREPORT.Service
{
    class ShiftService : IShift
    {
        public List<ShiftModel> GetShiftByDate(DateTime start, DateTime stop)
        {
            List<ShiftModel> datas = new List<ShiftModel>();
            try
            {
                string connectionString = DBPHASE1ConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_shift WHERE date BETWEEN '{start.Date}' AND '{stop.Date}'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ShiftModel data = new ShiftModel()
                            {
                                date = Convert.ToDateTime(dr["date"].ToString()),
                                date_start = Convert.ToDateTime(dr["date_start"].ToString()),
                                date_stop = Convert.ToDateTime(dr["date_stop"].ToString())
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
