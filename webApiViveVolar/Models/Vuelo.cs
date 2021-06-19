using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiViveVolar.Models
{
    public class Vuelo
    {
        public int id { get; set; }
        public string usuario_crea { get; set; }
        public DateTime fecha_crea { get; set; }
        public string usuario_modi { get; set; }
        public DateTime fecha_modi { get; set; }
        public int id_ciudad_origen { get; set; }
        public string ciudad_origen { get; set; }
        public int id_ciudad_destino { get; set; }
        public string ciudad_destino { get; set; }
        public int num_pasajeros { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
    }
}