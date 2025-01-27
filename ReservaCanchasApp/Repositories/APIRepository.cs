using Newtonsoft.Json;
using ReservaCanchasApp.Interfaces;
using ReservaCanchasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Repositories
{
    public class APIRepository : IAPIRepository
    {
        private readonly HttpClient _httpClient;
        public APIRepository() 
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> AgregarCanchaAsync(Cancha cancha)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Cancha/AddNewCancha";

            CanchaAPI canchaAPI = new CanchaAPI()
            {
                idComplejo = cancha.IdComplejo,
                imagenCancha = cancha.ImagenCancha,
                horaApertura = cancha.HoraApertura.ToString(),
                horaCierre = cancha.HoraCierre.ToString(),
                precioPorHora = (int) cancha.PrecioPorHora,
                nombreCancha = cancha.NombreCancha,
                numeroJugadores = cancha.NumeroJugadores,
            };

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(canchaAPI);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync<CanchaAPI>(url, canchaAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        

        public async Task<bool> AgregarComplejoAsync(Complejo complejo)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Complejo/AddNewComplejo";

            ComplejoAPI complejoAPI = new ComplejoAPI()
            {
                idAdministrador = complejo.IdAdministrador,
                imagenComplejo = complejo.ImagenComplejo,
                nombreComplejo = complejo.NombreComplejo,
            };

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(complejoAPI);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync<ComplejoAPI>(url, complejoAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> AgregarReservaAsync(Reserva reserva)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Reserva/AddNewReserva";

            ReservaAPI reservaAPI = new ReservaAPI()
            {
                idUsuario = reserva.IdUsuario,
                idCancha = reserva.IdCancha,
                fecha = reserva.Fecha,
                horaFin = reserva.HoraFin.ToString(),
                horaInicio = reserva.HoraInicio.ToString(),
            };


            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(reservaAPI);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync<ReservaAPI>(url, reservaAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> AgregarUsuarioAsync(Usuario usuario)
        {
            // URL de la API
            string url = "http://localhost:5002/api/Usuario/AddNewUsuario";

            int userType = 0;

            if (usuario.Tipo.Equals(TipoDeUsuario.Normal))
            {
                userType = 0;
            }

            if (usuario.Tipo.Equals(TipoDeUsuario.Administrador))
            {
                userType = 1;
            }

            if (usuario.Tipo.Equals(TipoDeUsuario.Superusuario))
            {
                userType = 2;
            }


            UsuarioAPI usuarioAPI = new UsuarioAPI()
            {
                nombreUsuario = usuario.NombreUsuario,
                correoUsuario = usuario.CorreoUsuario,
                passwordUsuario = usuario.PasswordUsuario,
                tipo = userType,
            };

            // Serializar el objeto a JSON
            string jsonData = JsonConvert.SerializeObject(usuarioAPI);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync<UsuarioAPI>(url,usuarioAPI,default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> EliminarCanchaAsync(int idCancha)
        {
            // URL de la API con el ID de la cancha a eliminar
            string url = $"http://localhost:5002/api/Cancha/DeleteCanchaById/{idCancha}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url,default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> EliminarComplejoAsync(int idComplejo)
        {
            string url = $"http://localhost:5002/api/Complejo/DeleteComplejoById/{idComplejo}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }            
        }

        public async Task<bool> EliminarReservaAsync(int idReserva)
        {
            string url = $"http://localhost:5002/api/Reserva/DeleteReservaById/{idReserva}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> EliminarUsuarioAsync(int idUsuario)
        {
            string url = $"http://localhost:5002/api/Usuario/DeleteUsuarioById/{idUsuario}";

            using(HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> ModificarCanchaAsync(int idCancha, Cancha cancha)
        {
            string url = $"http://localhost:5002/api/Cancha/ModifyCanchaById/{idCancha}";

            CanchaAPI canchaAPI = new CanchaAPI()
            {
                idCancha = idCancha,
                idComplejo = cancha.IdComplejo,
                imagenCancha = cancha.ImagenCancha,
                horaApertura = cancha.HoraApertura.ToString(),
                horaCierre = cancha.HoraCierre.ToString(),
                precioPorHora = (int)cancha.PrecioPorHora,
                nombreCancha = cancha.NombreCancha,
                numeroJugadores = cancha.NumeroJugadores,
            };

            string jsonData = JsonConvert.SerializeObject(cancha);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync<CanchaAPI>(url, canchaAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }          
        }

        public async Task<bool> ModificarComplejoAsync(int idComplejo, Complejo complejo)
        {
            string url = $"http://localhost:5002/api/Complejo/ModifyComplejoById/{idComplejo}";

            ComplejoAPI complejoAPI = new ComplejoAPI()
            {
                idComplejo = idComplejo,
                idAdministrador = complejo.IdAdministrador,
                imagenComplejo = complejo.ImagenComplejo,
                nombreComplejo = complejo.NombreComplejo,
            };

            string jsonData = JsonConvert.SerializeObject(complejo);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync<ComplejoAPI>(url, complejoAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> ModificarReservaAsync(int idReserva, Reserva reserva)
        {
            string url = $"http://localhost:5002/api/Reserva/ModifyReservaById/{idReserva}";

            ReservaAPI reservaAPI = new ReservaAPI()
            {
                idReserva = idReserva,
                idUsuario = reserva.IdUsuario,
                idCancha = reserva.IdCancha,
                fecha = reserva.Fecha,
                horaFin = reserva.HoraFin.ToString(),
                horaInicio = reserva.HoraInicio.ToString(),
            };

            string jsonData = JsonConvert.SerializeObject(reserva);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync<ReservaAPI>(url, reservaAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public async Task<bool> ModificarUsuarioAsync(int idUsuario, Usuario usuario)
        {
            string url = $"http://localhost:5002/api/Usuario/ModifyUsuarioById/{idUsuario}";

            int userType = 0;

            if (usuario.Tipo.Equals(TipoDeUsuario.Normal))
            {
                userType = 0;
            }

            if (usuario.Tipo.Equals(TipoDeUsuario.Administrador))
            {
                userType = 1;
            }

            if (usuario.Tipo.Equals(TipoDeUsuario.Superusuario))
            {
                userType = 2;
            }

            UsuarioAPI usuarioAPI = new UsuarioAPI()
            {
                idUsuario = idUsuario,
                nombreUsuario = usuario.NombreUsuario,
                correoUsuario = usuario.CorreoUsuario,
                passwordUsuario = usuario.PasswordUsuario,
                tipo = userType,
            };

            string jsonData = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync<UsuarioAPI>(url, usuarioAPI, default);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
    }
}
