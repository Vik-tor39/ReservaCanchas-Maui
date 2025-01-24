using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Repositories
{
    public class CanchaRepository (ApplicationDBContext context) : ICanchaRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<bool> AgregarCancha(Cancha cancha)
        {
            if (cancha == null) 
                { return false; }

            try
            {
                await _context.Cancha.AddAsync(cancha);
                int changes = await _context.SaveChangesAsync();

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

        public async Task<bool> EliminarCancha(int id)
        {
            try
            {
                var cancha = await _context.Cancha.FindAsync(id);

                if (cancha == null)
                    { return false; }

                _context.Cancha.Remove(cancha);

                int changes = await _context.SaveChangesAsync();

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

        public async Task<List<Cancha>> ListarCanchas()
        {
            try
            {
                var list = await _context.Cancha.ToListAsync();
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

        public async Task<bool> ModificarInformacionCancha(int id, Cancha cancha)
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
                var canchaActualizada = await _context.Cancha.FindAsync(id);

                if (canchaActualizada == null)
                    { return false; }

                _context.Cancha.Update(canchaActualizada);

                int cambios = await _context.SaveChangesAsync();
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

        public async Task<Cancha> VerCancha(int id)
        {
            try
            {
                var cancha = await _context.Cancha.FindAsync(id);

                if (cancha == null)
                { throw new ArgumentNullException(nameof(cancha)); }
                
                await _context.SaveChangesAsync();

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
