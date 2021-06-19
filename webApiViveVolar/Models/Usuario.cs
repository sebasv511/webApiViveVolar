using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiViveVolar.Models
{
    public class Usuario
    {
        public string login { get; set; }
        public string nombre { get; set; }
        public string p_apellido { get; set; }
        public string s_apellido { get; set; }
    }
}