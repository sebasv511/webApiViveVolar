using System;
using System.Collections.Generic;
using webApiViveVolar.Models;
using System.Data;
using DataAccess;

namespace webApiViveVolar.Data
{
    public class ReservaData
    {
        public static Response InsertarReserva(int id_vuelo, int id_cliente, int cantidad)
        {
            Response response = new Response();
            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@id_vuelo", id_vuelo);
                sql_param.Add("@id_cliente", id_cliente);
                sql_param.Add("@cantidad", cantidad);

                Connection.ExecuteSp(Global.connectionString, "sp_reserva_insert", sql_param, ref data);
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
                    if (!DBNull.Value.Equals(data.Rows[0]["id_reserva"]) && data.Rows[0]["id_reserva"] != null)
                    {
                        response.detail = string.Format("Vuelo reservado con el Código: {0}", data.Rows[0]["id_reserva"].ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
            return response;
        }
        public static List<Reserva> GetReservasCliente(int id_cliente)
        {
            List<Reserva> reservas = new List<Reserva>();

            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@id_cliente", id_cliente);

                //Connection.ExecuteSp("sp_reserva_select", sql_param, ref data);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i <= data.Rows.Count - 1; i++)
                    {
                        DataRow r = data.Rows[i];
                        Reserva reserva = new Reserva();
                        reserva.id = Convert.ToInt32(r["codigo_reserva"]);
                        reserva.fecha = Convert.ToDateTime(r["fecha_reserva"]);
                        reserva.id_vuelo = Convert.ToInt32(r["codigo_vuelo"]);
                        reserva.id_ciudad_origen = Convert.ToInt32(r["id_ciudad_origen"]);
                        reserva.ciudad_origen = r["ciudad_origen"].ToString();
                        reserva.id_ciudad_destino = Convert.ToInt32(r["id_ciudad_destino"]);
                        reserva.ciudad_destino = r["ciudad_destino"].ToString();
                        reserva.fecha_vuelo = Convert.ToDateTime(r["fecha_vuelo"]);
                        reserva.cantidad = Convert.ToInt32(r["puestos_reservados"]);
                        reserva.precio_unitario = Convert.ToDecimal(r["precio_unitario"]);
                        reserva.precio_total = Convert.ToDecimal(r["precio_total"]);

                        reservas.Add(reserva);
                    }
                }
            }
            catch (Exception)
            {
            }

            return reservas;
        }
    }
}