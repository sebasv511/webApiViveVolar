using System;
using System.Collections.Generic;
using System.Web.Http;
using webApiViveVolar.Models;
using webApiViveVolar.Data;

namespace webApiViveVolar.Controllers
{
    public class DistritoController : ApiController
    {        
        public List<Distrito> Get(int id_pais)
        {
            return DistritoData.GetDistritos(id_pais);
        }        
    }
}