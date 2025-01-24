using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveInformationAPI.Models
{
    public class Complejo
    {
        [Key]
        public int IdComplejo { get; set; }
        [Required, MaxLength(100)]
        public string NombreComplejo { get; set; }
        [Required, MaxLength(100)]
        public string ImagenComplejo { get; set; }

        public List<Cancha> Canchas { get; set; } = new List<Cancha>();
        [ForeignKey(nameof(Usuario))]
        public int IdAdministrador { get; set; }
    }
}
