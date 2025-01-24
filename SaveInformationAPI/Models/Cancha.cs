using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? NombreCancha { get; set; }
        [Range(0, int.MaxValue)]
        public int NumeroJugadores { get; set; }
        [Range(0, int.MaxValue)]
        [DataType(DataType.Currency)]
        public float? PrecioPorHora { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? HoraApertura { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? HoraCierre { get; set; }
        [MaxLength(500)]
        public string? ImagenCancha { get; set; } 
        public Complejo? complejo { get; set; }
        [ForeignKey(nameof(Complejo))]
        public int IdComplejo { get; set; }
    }
}
