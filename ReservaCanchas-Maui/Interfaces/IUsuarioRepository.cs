using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario ObtenerUsuarioPorId(int idUsuario);
        public List<Usuario> ObtenerTodosLosUsuarios();
        public bool CrearUsuario(Usuario usuario);
        public bool ActualizarUsuario(Usuario usuarioActualizado);
        public bool ActualizarTipoDeUsuario(int idUsuario, TipoDeUsuario nuevoTipo);
        public bool EliminarUsuario(int idUsuario);
    }
}
