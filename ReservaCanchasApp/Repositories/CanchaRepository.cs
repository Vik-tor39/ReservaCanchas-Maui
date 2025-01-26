using ReservaCanchasApp.Interfaces;
using ReservaCanchasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SQLite;
using System.Diagnostics;

namespace ReservaCanchasApp.Repositories
{
    public class CanchaRepository : ICanchaRepository
    {
        private Cancha _cancha;
        public string _dbPath;
        public string? StatusMessage { get; set; }
        
        private SQLiteConnection? conn;
        public CanchaRepository(string dbpath)
        {
            _dbPath = dbpath;

            _cancha = new Cancha
            {
                IdComplejo = 1,
                ImagenCancha = "dotnet_bot.png",
                NumeroJugadores = 20,
                PrecioPorHora = 500,
                HoraApertura = new TimeSpan(14, 0, 0),
                HoraCierre = new TimeSpan(16, 0, 0),
                NombreCancha = "Cancha Central"
            };
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Cancha>();
        }

        
        public bool CrearCancha(Cancha cancha)
        {
            int result = 0;

            try
            {
                Init();
                if (cancha == null)
                    throw new Exception("Valid object required");

                result = conn!.Insert(cancha);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, cancha.NombreCancha);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", cancha.NombreCancha, ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }


        public bool ActualizarCancha(Cancha canchaActualizada)
        {
            int result = 0;

            try
            {
                Init();

                var cancha = ObtenerCanchaPorId(canchaActualizada.IdCancha);

                if (cancha == null)
                    throw new Exception("Valid object required");

                result = conn!.Update(canchaActualizada);

                StatusMessage = string.Format("{0} record(s) add (Name: {1})", result, cancha.NombreCancha);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", canchaActualizada.NombreCancha, ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool EliminarCancha(int idCancha)
        {
            int result = 0;

            try
            {
                Init();

                if (conn != null)
                    result = conn.Delete<Cancha>(idCancha);

                StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, idCancha);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete data. {0}", ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Cancha ObtenerCanchaPorId(int idCancha)
        {
            try
            {
                var list = ObtenerTodasLasCanchas();
                var response = list.FirstOrDefault(c => c.IdCancha == idCancha);

                if (response != null) {
                    return response;
                }

                return null!;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return null!;
            }
        }

        public List<Cancha> ObtenerTodasLasCanchas()
        {
            try
            {
                Init();
                StatusMessage = string.Format("Success");

                return conn!.Table<Cancha>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            return new List<Cancha>();
        }
    }
}
