using ReservaCanchas_Maui.Interfaces;
using ReservaCanchas_Maui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public string _dbPath;
        public string? StatusMessage { get; set; }

        private SQLiteConnection? conn;
        public UsuarioRepository(string dbpath)
        {
            _dbPath = dbpath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Usuario>();
        }

        public bool ActualizarUsuario(Usuario usuarioActualizado)
        {
            int result = 0;

            try
            {
                Init();

                var usuario = ObtenerUsuarioPorId(usuarioActualizado.IdUsuario);

                if (usuario == null)
                    throw new Exception("Valid object required");

                result = conn!.Update(usuarioActualizado);

                StatusMessage = string.Format("{0} record(s) add (Name: {1})", result, usuarioActualizado.NombreUsuario);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", usuarioActualizado.NombreUsuario, ex.Message);
                return false;
            }
        }

        public bool CrearUsuario(Usuario usuario)
        {
            int result = 0;

            try
            {
                Init();
                if (usuario == null)
                    throw new Exception("Valid object required");

                result = conn!.Insert(usuario);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, usuario.NombreUsuario);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", usuario.NombreUsuario, ex.Message);
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            int result = 0;

            try
            {
                Init();

                if (conn != null)
                    result = conn.Delete<Usuario>(idUsuario);

                StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, idUsuario);

                return result != 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete data. {0}", ex.Message);
                return false;
            }
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            try
            {
                Init();
                StatusMessage = string.Format("Success");

                return conn!.Table<Usuario>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Usuario>();
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            try
            {
                var list = ObtenerTodosLosUsuarios();
                var response = list.FirstOrDefault(c => c.IdUsuario == idUsuario);

                if (response != null)
                {
                    return response;
                }

                return null!;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                return null!;
            }
        }

        public bool ActualizarTipoDeUsuario(int idUsuario, TipoDeUsuario nuevoTipo)
        {
            try
            {
                var list = ObtenerTodosLosUsuarios();
                var response = list.FirstOrDefault(c => c.IdUsuario == idUsuario);

                if (response != null)
                {
                    response.Tipo = nuevoTipo;

                    var methodResult = ActualizarUsuario(response);
                    
                    if (methodResult!)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
