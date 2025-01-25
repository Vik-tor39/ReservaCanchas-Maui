using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Repositories
{
    public class ComplejoRepository : IComplejoRepository
    {
        public string _dbPath;
        public string? StatusMessage { get; set; }

        private SQLiteConnection? conn;
        public ComplejoRepository(string dbpath)
        {
            _dbPath = dbpath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Complejo>();
        }

        public bool ActualizarComplejo(Complejo complejoActualizado)
        {
            int result = 0;

            try
            {
                Init();

                var complejo = ObtenerComplejoPorId(complejoActualizado.IdComplejo);

                if (complejo == null)
                    throw new Exception("Valid object required");

                result = conn!.Update(complejoActualizado);

                StatusMessage = string.Format("{0} record(s) add (Name: {1})", result, complejoActualizado.NombreComplejo);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", complejoActualizado.NombreComplejo, ex.Message);
                return false;
            }
        }

        public bool CrearComplejo(Complejo complejo)
        {
            int result = 0;

            try
            {
                Init();
                if (complejo == null)
                    throw new Exception("Valid object required");

                result = conn!.Insert(complejo);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, complejo.NombreComplejo);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", complejo.NombreComplejo, ex.Message);
                return false;
            }
        }

        public bool EliminarComplejo(int idComplejo)
        {
            int result = 0;

            try
            {
                Init();

                if (conn != null)
                    result = conn.Delete<Complejo>(idComplejo);

                StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, idComplejo);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete data. {0}", ex.Message);
                return false;
            }
        }

        public List<Complejo> ObtenerTodosLosComplejos()
        {
            try
            {
                Init();
                StatusMessage = string.Format("Success");

                return conn!.Table<Complejo>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Complejo>();
        }

        public Complejo ObtenerComplejoPorId(int idComplejo)
        {
            try
            {
                var list = ObtenerTodosLosComplejos();
                var response = list.FirstOrDefault(c => c.IdComplejo == idComplejo);

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
    }
}
