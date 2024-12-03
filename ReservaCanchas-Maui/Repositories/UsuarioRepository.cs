using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "users.json");
        public void CrearUsuario(Usuario usuario)
        {
            List<Usuario> listaUsers = new List<Usuario>();
            if(File.Exists(_fileName))
            {
                var contenido = File.ReadAllText(_fileName);
                listaUsers = JsonSerializer.Deserialize<List<Usuario>>(contenido) ?? new List<Usuario>();
            }

            listaUsers.Add(usuario);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(listaUsers, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void EliminarUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
