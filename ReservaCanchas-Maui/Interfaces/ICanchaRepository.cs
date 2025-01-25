using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface ICanchaRepository
    {
        public Cancha ObtenerCanchaPorId(int idCancha);
        public List<Cancha> ObtenerTodasLasCanchas();
        public bool CrearCancha(Cancha cancha);
        public bool ActualizarCancha(Cancha cancha);
        public bool EliminarCancha(int idCancha); 
    }
}
