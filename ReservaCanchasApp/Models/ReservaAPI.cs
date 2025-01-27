using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Models
{
    public class ReservaAPI
    {
        public int idReserva { get; set; }
        public DateTime fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int idUsuario { get; set; }
        public int idCancha { get; set; }
    }
}
