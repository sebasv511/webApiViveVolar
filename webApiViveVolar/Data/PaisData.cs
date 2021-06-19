using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webApiViveVolar.Models;
using System.Data;
using DataAccess;

namespace webApiViveVolar.Data
{
    public class PaisData
    {
        public static List<Pais> GetPaises()
        {
            List<Pais> paises = new List<Pais>();
            try
            {
                DataTable data = new DataTable();
                Connection.ExecuteSp(Global.connectionString, "sp_pais_select", null, ref data);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i <= data.Rows.Count - 1; i++)
                    {
                        DataRow r = data.Rows[i];
                        Pais pais = new Pais();
                        pais.id = Convert.ToInt32(r["id"]);
                        pais.prefijo = r["prefijo"].ToString();
                        pais.nombre = r["nombre"].ToString();

                        paises.Add(pais);
                    }

                }
            }
            catch (Exception)
            {
            }

            return paises;
        }
    }
}