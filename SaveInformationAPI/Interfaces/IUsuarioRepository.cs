using SaveInformationAPI.Models;

namespace SaveInformationAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> VerUsuario(int id);
        public Task<List<Usuario>> ListarUsuarios();
        public Task<bool> ModificarInformacionUsuario(int id, Usuario usuarioActualizado);
        public Task<bool> AgregarUsuario(Usuario usuario);
        public Task<bool> EliminarUsuario(int id);
    }
}
