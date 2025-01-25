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
        public List<Usuario> ObtenerTodosLosUsuarios();
        public Usuario ObtenerUsuario(int idUsuario);
        public bool CrearUsuario(Usuario usuario);
        public bool EliminarUsuario(int idUsuario);
        public bool ActualizarUsuario(Usuario usuario);
        public bool ActualizarTipoDeUsuario(int idUsuario, TipoDeUsuario nuevoTipo);
    }
}
