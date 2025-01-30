using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Repositories
{
    public class ComplejoRepository(ApplicationDBContext context) : IComplejoRepository
    {
        private readonly ApplicationDBContext _context = context;

        public bool AgregarComplejo(Complejo complejo)
        {
            if (complejo == null)
            { return false; }

            try
            {
                _context.Complejo.Add(complejo);
                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al agregar un nuevo complejo en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar un nuevo complejo", ex);
            }
        }

        public bool EliminarComplejo(int id)
        {
            try
            {
                var complejo = _context.Complejo.Find(id);

                if (complejo == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.Complejo.Remove(complejo);

                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar el complejo en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar el complejo", ex);
            }
        }

        public List<Complejo> ListarComplejos()
        {
            try
            {
                var list = _context.Complejo.ToList();
                return list;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al listar los complejos en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar los complejos", ex);
            }
        }

        public bool ModificarInformacionComplejo(int id, Complejo complejo)
        {
            if (complejo == null)
            {
                throw new ArgumentNullException(nameof(complejo));
            }

            try
            {
                var complejoActualizado = _context.Complejo.Find(id);

                if (complejoActualizado == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.Complejo.Update(complejoActualizado);

                int cambios = _context.SaveChanges();
                return cambios > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al modificar el complejo con #{id} en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al modificar el complejo", ex);
            }
        }

        public Complejo VerComplejo(int id)
        {
            try
            {
                var complejo = _context.Complejo.Find(id);

                if (complejo == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.SaveChanges();

                return complejo;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al visualizar el complejo en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al visualizar el complejo", ex);
            }
        }
    }
}
