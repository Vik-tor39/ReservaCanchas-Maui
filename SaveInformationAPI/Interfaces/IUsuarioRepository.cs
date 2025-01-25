using SaveInformationAPI.Models;

namespace SaveInformationAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario VerUsuario(int id);
        public List<Usuario> ListarUsuarios();
        public bool ModificarInformacionUsuario(int id, Usuario usuarioActualizado);
        public bool AgregarUsuario(Usuario usuario);
        public bool EliminarUsuario(int id);
    }
}

