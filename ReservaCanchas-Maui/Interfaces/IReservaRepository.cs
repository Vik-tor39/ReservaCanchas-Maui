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
        public List<Reserva> ObtenerTodasLasReservas();
        public bool EstaDisponible(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin);
        public void CrearReserva(Reserva reserva); 
    }
}
