using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiViveVolar.Models;
using webApiViveVolar.Data;

namespace webApiViveVolar.Controllers
{
    public class UsuarioController : ApiController
    {
        public Usuario Get(string login)
        {
            return UsuarioData.GetUsuario(login);
        }

        public Response Get(string login, string password)
        {
            return UsuarioData.ValidarLogin(login, password);
        }
    }
}