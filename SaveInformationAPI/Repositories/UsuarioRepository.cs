using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Repositories
{
    public class UsuarioRepository (ApplicationDBContext context) : IUsuarioRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<bool> AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
            { return false; }

            try
            {
                await _context.Usuario.AddAsync(usuario);
                int changes = await _context.SaveChangesAsync();

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

        public Task<bool> EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModificarInformacionUsuario(int id, Usuario usuarioActualizado)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> VerUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
