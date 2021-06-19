using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiViveVolar.Data;
using webApiViveVolar.Models;

namespace webApiViveVolar.Controllers
{
    public class VueloController : ApiController
    {
        public List<Vuelo> Get(DateTime fecha, int? id_ciudad_origen = null, int? id_ciudad_destino = null, int? puestos = null)
        {
            return VueloData.GetVuelosDisponibles(fecha, id_ciudad_origen, id_ciudad_destino, puestos);
        }
        
        public Response Post([FromBody] Vuelo vuelo)
        {
            return VueloData.InsertarVuelo(vuelo.usuario_crea, vuelo.id_ciudad_origen, vuelo.id_ciudad_destino, vuelo.num_pasajeros, vuelo.precio, vuelo.fecha);
        }
    }
}