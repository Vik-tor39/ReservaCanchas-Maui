using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveInformationAPI.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Inicio")]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Fin")]
        public TimeSpan HoraFin { get; set; }
        public Cancha? cancha { get; set; }
        [ForeignKey(nameof(Cancha))]
        public int IdCancha { get; set; } 
    }
}
