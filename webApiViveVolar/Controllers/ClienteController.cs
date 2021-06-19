using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiViveVolar.Models;
using webApiViveVolar.Data;

namespace webApiViveVolar.Controllers
{
    public class ClienteController : ApiController
    {        
        public Cliente Get(string tipo_doc, string num_doc)
        {
            return ClienteData.GetCliente(tipo_doc, num_doc);
        }        
    }
}