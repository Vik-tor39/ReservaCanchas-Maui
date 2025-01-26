using ReservaCanchasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Interfaces
{
    public interface IAPIRepository
    {
        public bool AgregarComplejo(Complejo complejo);
        public bool AgregarCancha(Cancha cancha);
        public bool AgregarReserva(Reserva reserva);
        public bool AgregarUsuario(Usuario usuario);
        public bool EliminarComplejo(int idComplejo);
        public bool EliminarCancha(int idCancha);
        public bool EliminarReserva(int idReserva);
        public bool EliminarUsuario(int idUsuario);
        public bool ModificarComplejo(int idComplejo, Complejo complejo);
        public bool ModificarCancha(int idCancha, Cancha cancha);
        public bool ModificarReserva(int idReserva, Reserva reserva);
        public bool ModificarUsuario(int idUsuario, Usuario usuario);

    }
}
