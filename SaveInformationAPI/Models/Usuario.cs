using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SaveInformationAPI.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required, MaxLength(50)]
        public string? NombreUsuario { get; set; }
        [Required, EmailAddress]
        public string? CorreoUsuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 10)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d.,\-@$!%*#?&]{8,}$")]
        public string? PasswordUsuario { get; set; }        
        public TipoDeUsuario Tipo { get; set; }
        [Required]
        public string? tipoUsuario { get; set; }
        public List<int> ComplejosAdministrados { get; set; } = new List<int>();
    }

    public enum TipoDeUsuario
    {
        Normal, 
        Administrador, 
        Superusuario
    }
}
