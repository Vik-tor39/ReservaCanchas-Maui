using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveInformationAPI.Models
{
    public class Cancha
    {
        [Key]
        public int IdCancha { get; set; }
        [MaxLength(50)]
        public string NombreCancha { get; set; }
        [DefaultValue(1)]
        public int NumeroJugadores { get; set; }

        public decimal PrecioPorHora { get; set; }
        public TimeSpan HoraApertura { get; set; } 
        public TimeSpan HoraCierre { get; set; } 
        public string ImagenCancha { get; set; } 
        public int IdComplejo { get; set; }
    }
}
