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
    public class PaisController : ApiController
    {        
        public List<Pais> Get()
        {
            return PaisData.GetPaises();
        }
    }
}