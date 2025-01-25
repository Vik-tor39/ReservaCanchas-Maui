using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface IReservaRepository
    {
        public Reserva ObtenerReservaPorId(int idReserva);
        public List<Reserva> ObtenerTodasLasReservas();
        public bool CrearReserva(Reserva reserva); 
        public bool ActualizarReserva(Reserva reservaActualizada);
        public bool EliminarReserva(int idReserva);
    }
}
