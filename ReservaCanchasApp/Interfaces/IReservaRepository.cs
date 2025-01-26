using ReservaCanchasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Interfaces
{
    public interface IReservaRepository
    {
        public Reserva ObtenerReservaPorId(int idReserva);
        public bool VerificarEstado(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin);
        public List<Reserva> ObtenerTodasLasReservas();
        public bool CrearReserva(Reserva reserva); 
        public bool ActualizarReserva(Reserva reservaActualizada);
        public bool EliminarReserva(int idReserva);
    }
}
