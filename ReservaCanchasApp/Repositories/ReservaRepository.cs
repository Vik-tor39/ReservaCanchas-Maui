using ReservaCanchasApp.Interfaces;
using ReservaCanchasApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private Reserva _reserva;
        public string _dbPath;
        public string? StatusMessage { get; set; }

        private SQLiteConnection? conn;
        public ReservaRepository(string dbpath)
        {
            _dbPath = dbpath;

            _reserva = new Reserva
            {
                Fecha = DateTime.Today.AddDays(3),
                HoraInicio = new TimeSpan(14, 0, 0),
                HoraFin = new TimeSpan(16, 0, 0),
                IdCancha = 1,
                IdUsuario = 2,
                EstaDisponible = false
            };

            CrearReserva(_reserva);
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Reserva>();
        }

        public bool ActualizarReserva(Reserva reservaActualizada)
        {
            int result = 0;

            try
            {
                Init();

                var reserva = ObtenerReservaPorId(reservaActualizada.IdReserva);

                if (reserva == null)
                    throw new Exception("Valid object required");

                result = conn!.Update(reservaActualizada);

                StatusMessage = string.Format("{0} record(s) added (Id: {1})", result, reservaActualizada.IdReserva);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", reservaActualizada.IdReserva, ex.Message);
                return false;
            }
        }

        public bool CrearReserva(Reserva reserva)
        {
            int result = 0;

            try
            {
                Init();
                if (reserva == null)
                    throw new Exception("Valid object required");

                result = conn!.Insert(reserva);

                StatusMessage = string.Format("{0} record(s) added (Id: {1})", result, reserva.IdReserva);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", reserva.IdReserva, ex.Message);
                return false;
            }
        }

        public bool EliminarReserva(int idReserva)
        {
            int result = 0;

            try
            {
                Init();

                if (conn != null)
                    result = conn.Delete<Reserva>(idReserva);

                StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, idReserva);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete data. {0}", ex.Message);
                return false;
            }
        }

        public List<Reserva> ObtenerTodasLasReservas()
        {
            try
            {
                Init();
                StatusMessage = string.Format("Success");

                return conn!.Table<Reserva>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Reserva>();
        }

        public Reserva ObtenerReservaPorId(int idReserva)
        {
            try
            {
                var list = ObtenerTodasLasReservas();
                var response = list.FirstOrDefault(c => c.IdReserva == idReserva);

                if (response != null)
                {
                    return response;
                }

                return null!;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                return null!;
            }
        }

        public bool VerificarEstado(int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            try
            {
                var list = ObtenerTodasLasReservas();

                foreach (var reserva in list)
                {
                    // Verificar si es la misma cancha y misma fecha
                    if (reserva.IdCancha == idCancha && reserva.Fecha.Date == fecha.Date)
                    {
                        // Verificar superposición de horarios
                        if ((horaInicio < reserva.HoraFin && horaFin > reserva.HoraInicio) ||
                            (horaInicio == reserva.HoraInicio && horaFin == reserva.HoraFin))
                        {
                            return false; // Hay una reserva que se superpone
                        }
                    }
                }

                return false; // No hay superposición
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                return false;
            }
        }
    }

}
