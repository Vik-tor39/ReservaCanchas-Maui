using Newtonsoft.Json;
using ReservaCanchasApp.Interfaces;
using ReservaCanchasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Repositories
{
    public class APIRepository : IAPIRepository
    {
        HttpClient _httpClient;
        public APIRepository() 
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> AgregarCanchaAsync(Cancha cancha)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Cancha/AddNewCancha";

            cancha.IdCancha = 0;

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(cancha);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Cancha agregada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        

        public async Task<bool> AgregarComplejoAsync(Complejo complejo)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Complejo/AddNewComplejo";

            complejo.IdComplejo = 0;

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(complejo);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Complejo agregado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AgregarReservaAsync(Reserva reserva)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Reserva/AddNewReserva";

            reserva.IdReserva = 0;

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(reserva);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reserva agregada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AgregarUsuarioAsync(Usuario usuario)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Usuario/AddNewUsuario";

            // Eliminar el ID de usuario
            usuario.IdUsuario = 0;
            usuario.Tipo = 0;

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Usuario agregado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarCanchaAsync(int idCancha)
        {
            // URL de la API con el ID de la cancha a eliminar
            string url = $"http://localhost:5002/api/Cancha/DeleteCanchaById/{idCancha}";

            try
            {
                // Enviar la solicitud DELETE
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Cancha eliminada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar la cancha: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarComplejoAsync(int idComplejo)
        {
            string url = $"http://localhost:5002/api/Complejo/DeleteComplejoById/{idComplejo}";

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Complejo eliminado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar el complejo: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarReservaAsync(int idReserva)
        {
            string url = $"http://localhost:5002/api/Reserva/DeleteReservaById/{idReserva}";

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reserva eliminada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar la reserva: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarUsuarioAsync(int idUsuario)
        {
            string url = $"http://localhost:5002/api/Usuario/DeleteUsuarioById/{idUsuario}";

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Usuario eliminado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar el usuario: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ModificarCanchaAsync(int idCancha, Cancha cancha)
        {
            string url = $"http://localhost:5002/api/Cancha/ModifyCanchaById/{idCancha}";


            string jsonData = JsonConvert.SerializeObject(cancha);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Cancha modificada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ModificarComplejoAsync(int idComplejo, Complejo complejo)
        {
            string url = $"http://localhost:5002/api/Complejo/ModifyComplejoById/{idComplejo}";


            string jsonData = JsonConvert.SerializeObject(complejo);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Complejo modificado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ModificarReservaAsync(int idReserva, Reserva reserva)
        {
            string url = $"http://localhost:5002/api/Reserva/ModifyReservaById/{idReserva}";


            string jsonData = JsonConvert.SerializeObject(reserva);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reserva modificada correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ModificarUsuarioAsync(int idUsuario, Usuario usuario)
        {
            string url = $"http://localhost:5002/api/Usuario/ModifyUsuarioById/{idUsuario}";


            string jsonData = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Usuario modificado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la API: {ex.Message}");
                return false;
            }
        }
    }
}
