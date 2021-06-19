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
    public class ReservaController : ApiController
    {
        public List<Reserva> Get(int id_cliente)
        {
            return ReservaData.GetReservasCliente(id_cliente);
        }

        public Response Post([FromBody] Reserva reserva)
        {
            return ReservaData.InsertarReserva(reserva.id_vuelo, reserva.id_cliente, reserva.cantidad);
        }
    }
}