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
    public class CiudadController : ApiController
    {                
        public List<Ciudad> Get(int id_distrito)
        {
            return CiudadData.GetCiudades(id_distrito);
        }
    }
}