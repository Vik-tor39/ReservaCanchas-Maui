using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Models
{
    [Table("cancha")]
    public class Cancha
    {
        [PrimaryKey, AutoIncrement]
        public int IdCancha { get; set; }
        [MaxLength(100)]
        public string NombreCancha { get; set; } 
        public int NumeroJugadores { get; set; }
        public decimal PrecioPorHora { get; set; }
        public TimeSpan HoraApertura { get; set; } 
        public TimeSpan HoraCierre { get; set; } 
        public string ImagenCancha { get; set; }
        public int IdComplejo { get; set; }
    }
}
