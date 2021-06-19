using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiViveVolar.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string tipo_doc { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string p_apellido { get; set; }
        public string s_apellido { get; set; }
        public string email { get; set; }
    }
}