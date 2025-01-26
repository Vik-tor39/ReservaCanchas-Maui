using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Models
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
        public int IdAdministrador { get; set; }
    }
}
