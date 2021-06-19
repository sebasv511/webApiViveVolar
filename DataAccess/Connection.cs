using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Connection
    {
        public static bool ExecuteSp(string connectionString, string sp_name, Dictionary<string, object> sp_params, ref DataTable data)
        {
            bool response = false;
            if (connectionString == string.Empty || sp_name == string.Empty)
            {
                return response;
            }

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sp_name, sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (sp_params != null)
                    {
                        foreach (var par in sp_params)
                        {
                            //Se agregan los parámetros enviados a través del Diccionario sp_params
                            cmd.Parameters.AddWithValue(par.Key, par.Value);
                        }
                    }                    

                    sqlConn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            response = true;
                            data = GenerateDataTable(dr);
                        }
                    }
                    sqlConn.Close();
                }
                catch (Exception)
                {
                    sqlConn.Close();
                }
            }
            return response;
        }
        private static DataTable GenerateDataTable(SqlDataReader dr)
        {
            DataTable data = new DataTable();
            try
            {
                if (dr.HasRows)
                {
                    for (int i = 0; i <= dr.VisibleFieldCount - 1; i++)
                    {
                        //Se crean las columnas devueltas en la respuesta del SP
                        if (dr.GetName(i) != string.Empty)
                        {
                            data.Columns.Add(dr.GetName(i));
                        }
                    }

                    while (dr.Read())
                    {
                        DataRow r = data.NewRow();
                        for (int i = 0; i <= dr.VisibleFieldCount - 1; i++)
                        {
                            r[dr.GetName(i)] = dr.GetValue(i);
                        }
                        data.Rows.Add(r);
                    }
                }
            }
            catch (Exception)
            {
            }
            return data;
        }
    }
}
