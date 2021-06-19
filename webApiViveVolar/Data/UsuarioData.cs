using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using webApiViveVolar.Models;


namespace webApiViveVolar.Data
{
    public class UsuarioData
    {
        public static Response ValidarLogin(string login, string password)
        {
            Response response = new Response();
            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@login", login);
                sql_param.Add("@password", password);

                Connection.ExecuteSp(Global.connectionString, "sp_usuario_login", sql_param, ref data);
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
                    if (!DBNull.Value.Equals(data.Rows[0]["login_ok"]) && data.Rows[0]["login_ok"] != null)
                    {
                        response.detail = Convert.ToBoolean(data.Rows[0]["login_ok"]);
                    }
                }
            }
            catch (Exception)
            {
            }
            return response;
        }
        public static Usuario GetUsuario(string login)
        {
            Usuario usuario = new Usuario();
            try
            {
                DataTable data = new DataTable();
                Dictionary<string, object> sql_param = new Dictionary<string, object>();
                sql_param.Add("@login", login);

                Connection.ExecuteSp(Global.connectionString, "sp_usuario_select", sql_param, ref data);
                if (data.Rows.Count > 0)
                {
                    usuario.login = data.Rows[0]["login"].ToString();
                    usuario.nombre = data.Rows[0]["nombres"].ToString();
                    usuario.p_apellido = data.Rows[0]["p_apellido"].ToString();
                    usuario.s_apellido = data.Rows[0]["s_apellido"].ToString();                    
                }
            }
            catch (Exception)
            {
            }
            return usuario;
        }
    }
}