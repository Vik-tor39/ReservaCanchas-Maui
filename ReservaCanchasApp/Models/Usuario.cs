using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservaCanchasApp.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        [MaxLength(100)]
        public string NombreUsuario { get; set; }
        [MaxLength(100)]
        public string CorreoUsuario { get; set; }
        [MaxLength(100)]
        public string PasswordUsuario { get; set; }
        public TipoDeUsuario Tipo { get; set; }
        public List<int> ComplejosAdministrados { get; set; } = new List<int>();
    }

    public enum TipoDeUsuario
    {
        Normal, 
        Administrador, 
        Superusuario
    }
}
