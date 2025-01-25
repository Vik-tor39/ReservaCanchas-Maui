using SaveInformationAPI.Models;

namespace SaveInformationAPI.Interfaces
{
    public interface IReservaRepository
    {
        public Reserva VerReserva(int id);
        public List<Reserva> ListarReservas();
        public bool ModificarInformacionReserva(int id, Reserva reservaActualizado);
        public bool AgregarReserva(Reserva reserva);
        public bool EliminarReserva(int id);
    }
}
