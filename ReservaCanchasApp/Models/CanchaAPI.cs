using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Models
{
    public class CanchaAPI
    {
        public int idCancha { get; set; }
        public string nombreCancha { get; set; }
        public int numeroJugadores { get; set; }
        public int precioPorHora { get; set; }
        public string horaApertura { get; set; }
        public string horaCierre { get; set; }
        public string imagenCancha { get; set; }
        public int idComplejo { get; set; }
    }
}
