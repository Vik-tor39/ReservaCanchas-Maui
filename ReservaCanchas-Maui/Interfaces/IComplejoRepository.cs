using ReservaCanchas_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Interfaces
{
    public interface IComplejoRepository
    {
        public List<Complejo> ObtenerTodosLosComplejos();
        public Complejo ObtenerComplejo { get; set; }
        public bool CrearComplejo(Complejo complejo);
        public bool ActualizarComplejo(Complejo complejo);
        public bool EliminarComplejo(int idComplejo); 
    }
}
