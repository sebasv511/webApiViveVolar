using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webApiViveVolar.Models;
using System.Data;
using DataAccess;
using System.Configuration;

namespace webApiViveVolar.Data
{
    public class ClienteData
    {
        public static Cliente GetCliente(string tipo_doc, string num_doc)
        {
            Cliente cliente = new Cliente();
            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@tipo_doc", tipo_doc);
                sql_param.Add("@num_doc", num_doc);

                
                Connection.ExecuteSp(Global.connectionString, "sp_reserva_insert", sql_param, ref data);
                if (data.Rows.Count > 0)
                {
                    DataRow r = data.Rows[0];
                    cliente.id = Convert.ToInt32(r["id"]);
                    cliente.tipo_doc = r["tipo_doc"].ToString();
                    cliente.documento = r["num_doc"].ToString();
                    cliente.nombre = r["nombre"].ToString();
                    cliente.p_apellido = r["p_apellido"].ToString();
                    cliente.s_apellido = r["s_apellido"].ToString();
                    cliente.email = r["email"].ToString();
                }
            }
            catch (Exception)
            {
            }

            return cliente;
        }
    }
}