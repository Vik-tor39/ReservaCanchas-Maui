using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Repositories
{
    public class UsuarioRepository(ApplicationDBContext context) : IUsuarioRepository
    {
        private readonly ApplicationDBContext _context = context;

        public bool AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
            { return false; }

            try
            {
                _context.Usuario.Add(usuario);
                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al agregar un nuevo usuario en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al agregar un nuevo usuario", ex);
            }
        }

        public bool EliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuario.Find(id);

                if (usuario == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.Usuario.Remove(usuario);

                int changes = _context.SaveChanges();

                return changes > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al eliminar el usuario en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar el usuario", ex);
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                var list = _context.Usuario.ToList();
                return list;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al listar los usuarios en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al listar los usuarios", ex);
            }
        }

        public bool ModificarInformacionUsuario(int id, Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            try
            {
                var usuarioActualizado = _context.Usuario.Find(id);

                if (usuarioActualizado == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.Usuario.Update(usuarioActualizado);

                int cambios = _context.SaveChanges();
                return cambios > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al modificar el usuario con #{id} en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado el modificar el usuario", ex);
            }
        }

        public Usuario VerUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuario.Find(id);

                if (usuario == null)
                {
                    throw new ArgumentException("El ID proporcionado es incorrecto", nameof(id));
                }

                _context.SaveChanges();

                return usuario;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al visualizar el usuario en la base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al visualizar el usuario", ex);
            }
        }
    }
}
