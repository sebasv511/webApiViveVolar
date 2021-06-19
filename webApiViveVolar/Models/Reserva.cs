using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiViveVolar.Models
{
    public class Reserva
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int id_vuelo { get; set; }
        public int id_cliente { get; set; }
        public int cantidad { get; set; }
        public int id_ciudad_origen { get; set; }
        public string ciudad_origen { get; set; }
        public int id_ciudad_destino { get; set; }
        public string ciudad_destino { get; set; }
        public DateTime fecha_vuelo { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal precio_total { get; set; }
    }
}