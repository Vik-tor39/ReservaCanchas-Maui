using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Repositories
{
    public class ReservaRepository(ApplicationDBContext context) : IReservaRepository
    {
        private readonly ApplicationDBContext _context = context;

        public bool AgregarReserva(Reserva reserva)
        {
            if (reserva == null)
            { return false; }

            try
            {
                _context.Reserva.Add(reserva);
                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al realizar una nueva reserva en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar una nueva reserva", ex);
            }
        }

        public bool EliminarReserva(int id)
        {
            try
            {
                var reserva = _context.Reserva.Find(id);

                if (reserva == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.Reserva.Remove(reserva);

                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar la reserva en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar la reserva ", ex);
            }
        }

        public List<Reserva> ListarReservas()
        {
            try
            {
                var list = _context.Reserva.ToList();
                return list;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al listar las reservas en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar las reservas", ex);
            }
        }

        public bool ModificarInformacionReserva(int id, Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva));
            }

            try
            {
                var reservaActualizada = _context.Reserva.Find(id);

                if (reservaActualizada == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.Reserva.Update(reservaActualizada);

                int cambios = _context.SaveChanges();
                return cambios > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al modificar la reserva con #{id} en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al modificar la reserva", ex);
            }
        }

        public Reserva VerReserva(int id)
        {
            try
            {
                var reserva = _context.Reserva.Find(id);

                if (reserva == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.SaveChanges();

                return reserva;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al visualizar la reserva en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al visualizar la reserva", ex);
            }
        }
    }
}
