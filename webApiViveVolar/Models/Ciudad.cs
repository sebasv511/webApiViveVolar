using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiViveVolar.Models
{
    public class Ciudad
    {
        public int id { get; set; }
        public int id_distrito { get; set; }
        public string prefijo { get; set; }
        public string nombre { get; set; }
    }
}