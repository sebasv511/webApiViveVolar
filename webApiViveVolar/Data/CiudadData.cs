using System;
using System.Collections.Generic;
using webApiViveVolar.Models;
using System.Data;
using DataAccess;

namespace webApiViveVolar.Data
{
    public class CiudadData
    {
        public static List<Ciudad> GetCiudades(int id_distrito)
        {
            List<Ciudad> ciudades = new List<Ciudad>();

            DataTable data = new DataTable();
            Dictionary<string, object> sql_param = new Dictionary<string, object>();
            sql_param.Add("@id_distrito", id_distrito);

            Connection.ExecuteSp(Global.connectionString, "sp_ciudad_select", sql_param, ref data);
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i <= data.Rows.Count - 1; i++)
                {
                    DataRow r = data.Rows[i];
                    Ciudad ciudad = new Ciudad();
                    ciudad.id = Convert.ToInt32(r["id"]);
                    ciudad.id_distrito = Convert.ToInt32(r["id_distrito"]);
                    ciudad.prefijo = r["prefijo"].ToString();                    
                    ciudad.nombre = r["nombre"].ToString();

                    ciudades.Add(ciudad);
                }
            }
            return ciudades;
        }
    }
}