using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webApiViveVolar.Models;
using System.Data;
using DataAccess;

namespace webApiViveVolar.Data
{
    public class DistritoData
    {
        public static List<Distrito> GetDistritos(int id_pais)
        {
            List<Distrito> distritos = new List<Distrito>();
            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@id_pais", id_pais);

                Connection.ExecuteSp(Global.connectionString, "sp_distrito_select", sql_param, ref data);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i <= data.Rows.Count - 1; i++)
                    {
                        DataRow r = data.Rows[i];
                        Distrito distrito = new Distrito();
                        distrito.id = Convert.ToInt32(r["id"]);
                        distrito.id_pais = Convert.ToInt32(r["id_pais"]);
                        distrito.prefijo = r["prefijo"].ToString();
                        distrito.nombre = r["nombre"].ToString();

                        distritos.Add(distrito);
                    }
                }                
            }
            catch (Exception)
            {
            }

            return distritos;
        }
    }
}