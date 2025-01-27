using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaCanchasApp.Models
{
    public class UsuarioAPI
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string passwordUsuario { get; set; }
        public int tipo { get; set; }
    }
}
