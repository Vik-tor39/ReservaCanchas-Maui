using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchas_Maui.Models
{
    [Table("complejo")]
    public class Complejo
    {
        [PrimaryKey, AutoIncrement]
        public int IdComplejo { get; set; }
        [MaxLength(100)]
        public string NombreComplejo { get; set; }
        [MaxLength(100)]
        public string ImagenComplejo { get; set; }
        public List<Cancha> Canchas { get; set; } = new List<Cancha>();
        public int IdAdministrador { get; set; }
    }
}
