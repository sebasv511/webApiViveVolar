using System;
using System.Collections.Generic;
using System.Data;
using webApiViveVolar.Models;
using DataAccess;

namespace webApiViveVolar.Data
{
    public class VueloData
    {
        public static Response InsertarVuelo(string login, int ciudad_origen, int ciudad_destino, int puestos, decimal precio, DateTime fecha)
        {
            Response response = new Response();
            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@login", login);
                sql_param.Add("@id_ciudad_origen", ciudad_origen);
                sql_param.Add("@id_ciudad_destino", ciudad_destino);
                sql_param.Add("@puestos", puestos);
                sql_param.Add("@precio", precio);
                sql_param.Add("@fecha", fecha);

                Connection.ExecuteSp(Global.connectionString, "sp_vuelo_insert", sql_param, ref data);
                if (data.Rows.Count > 0)
                {
                    if (!DBNull.Value.Equals(data.Rows[0]["error_number"]) && data.Rows[0]["error_number"] != null)
                    {
                        response.error_number = Convert.ToInt32(data.Rows[0]["error_number"]);
                    }
                    if (!DBNull.Value.Equals(data.Rows[0]["error_message"]) && data.Rows[0]["error_message"] != null)
                    {
                        response.error_message = data.Rows[0]["error_message"].ToString();
                    }
                    if (!DBNull.Value.Equals(data.Rows[0]["id_vuelo"]) && data.Rows[0]["id_vuelo"] != null)
                    {
                        response.detail = Convert.ToInt32(data.Rows[0]["id_vuelo"]);
                    }
                }
            }
            catch (Exception)
            {
            }
            return response;
        }
        public static List<Vuelo> GetVuelosDisponibles(DateTime fecha, int? id_ciudad_origen = null, int? id_ciudad_destino = null, int? puestos = null)
        {
            List<Vuelo> vuelos = new List<Vuelo>();

            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@fecha", fecha);
                if (id_ciudad_origen == null)
                {
                    sql_param.Add("@id_ciudad_origen", DBNull.Value);
                }
                else
                {
                    sql_param.Add("@id_ciudad_origen", id_ciudad_origen);
                }

                if (id_ciudad_destino == null)
                {
                    sql_param.Add("@id_ciudad_destino", DBNull.Value);
                }
                else
                {
                    sql_param.Add("@id_ciudad_destino", id_ciudad_destino);
                }
                if (puestos == null)
                {
                    sql_param.Add("@puestos", DBNull.Value);
                }
                else
                {
                    sql_param.Add("@puestos", puestos);
                }


                Connection.ExecuteSp(Global.connectionString, "sp_vuelo_select", sql_param, ref data);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i <= data.Rows.Count - 1; i++)
                    {
                        DataRow r = data.Rows[i];
                        Vuelo vuelo = new Vuelo();
                        vuelo.id = Convert.ToInt32(r["codigo_vuelo"]);
                        vuelo.id_ciudad_origen = Convert.ToInt32(r["id_origen"]);
                        vuelo.ciudad_origen = r["origen"].ToString();
                        vuelo.id_ciudad_destino = Convert.ToInt32(r["id_destino"]);
                        vuelo.ciudad_destino = r["destino"].ToString();
                        vuelo.num_pasajeros = Convert.ToInt32(r["puestos_disponibles"]);
                        vuelo.precio = Convert.ToDecimal(r["precio"]);
                        vuelo.fecha = Convert.ToDateTime(r["fecha"]);

                        vuelos.Add(vuelo);
                    }
                }
            }
            catch (Exception)
            {
            }

            return vuelos;
        }
    }
}