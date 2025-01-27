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
        Task<bool> AgregarComplejoAsync(Complejo complejo);
        Task<bool> AgregarCanchaAsync(Cancha cancha);
        Task<bool> AgregarReservaAsync(Reserva reserva);
        Task<bool> AgregarUsuarioAsync(Usuario usuario);
        Task<bool> EliminarComplejoAsync(int idComplejo);
        Task<bool> EliminarCanchaAsync(int idCancha);
        Task<bool> EliminarReservaAsync(int idReserva);
        Task<bool> EliminarUsuarioAsync(int idUsuario);
        Task<bool> ModificarComplejoAsync(int idComplejo, Complejo complejo);
        Task<bool> ModificarCanchaAsync(int idCancha, Cancha cancha);
        Task<bool> ModificarReservaAsync(int idReserva, Reserva reserva);
        Task<bool> ModificarUsuarioAsync(int idUsuario, Usuario usuario);

    }
}
