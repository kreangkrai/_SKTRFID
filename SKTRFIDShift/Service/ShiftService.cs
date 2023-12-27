using SKTDATABASE;
using SKTRFIDSHIFT.Interface;
using SKTRFIDSHIFT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDSHIFT.Service
{
    class ShiftService : IShift
    {
        public ShiftModel GetShift(DateTime date)
        {
            ShiftModel data = new ShiftModel();
            try
            {
                string connectionString = DBPHASE1ConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM tb_shift WHERE date = '{date.Date}'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            data.date = Convert.ToDateTime(dr["date"].ToString());
                            data.date_start = Convert.ToDateTime(dr["date_start"].ToString());
                            data.date_stop = Convert.ToDateTime(dr["date_stop"].ToString());
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

        public List<ShiftModel> GetShifts(DateTime start, DateTime stop)
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

        public string Insert(ShiftModel data)
        {
            try
            {
                string connectionString = DBPHASE1ConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"INSERT INTO tb_shift VALUES('{data.date}','{data.date_start}','{data.date_stop}')", cn);
                    cmd.ExecuteNonQuery();
                }
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public string Update(ShiftModel data)
        {
            try
            {
                string connectionString = DBPHASE1ConnectService.data_source();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCommand cmd = new SqlCommand($@"UPDATE tb_shift SET date_start='{data.date_start}',
                                                                          date_stop='{data.date_stop}'      
                                                                          WHERE date='{data.date}'", cn);
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
