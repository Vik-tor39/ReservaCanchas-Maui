using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;
using System.Runtime.CompilerServices;

namespace SaveInformationAPI.Repositories
{
    public class CanchaRepository (ApplicationDBContext context) : ICanchaRepository
    {
        private readonly ApplicationDBContext _context = context;

        public bool AgregarCancha(Cancha cancha)
        {
            if (cancha == null) 
                { return false; }

            try
            {
                _context.Cancha.Add(cancha);
                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al agregar la cancha en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar una nueva cancha", ex);
            }
        }

        public bool EliminarCancha(int id)
        {
            try
            {
                var cancha =  _context.Cancha.Find(id);

                if (cancha == null)
                    { return false; }

                _context.Cancha.Remove(cancha);

                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar la cancha en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar la cancha", ex);
            }
        }

        public List<Cancha> ListarCanchas()
        {
            try
            {
                var list =  _context.Cancha.ToList();
                return list;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al listar las canchas en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar la cancha", ex);
            }
        }

        public bool ModificarInformacionCancha(int id, Cancha cancha)
        {
            if (cancha == null)
            {
                throw new ArgumentNullException(nameof(cancha));
            }

            if (id != cancha.IdCancha)
            {
                throw new ArgumentException("El ID proporcionado no coincide con el ID de la cancha.", nameof(id));
            }

            try
            {
                var canchaActualizada =  _context.Cancha.Find(id);

                if (canchaActualizada == null)
                    { return false; }

                _context.Cancha.Update(canchaActualizada);

                int cambios =  _context.SaveChanges();
                return cambios > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al modificar la cancha #{id} en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al actualizar la cancha", ex);
            }
        }

        public Cancha VerCancha(int id)
        {
            try
            {
                var cancha = _context.Cancha.Find(id);

                if (cancha == null)
                { throw new ArgumentNullException(nameof(cancha)); }
                
                _context.SaveChanges();

                return cancha;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al visualizar la cancha en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al visualizar la cancha", ex);
            }
        }
    }
}
