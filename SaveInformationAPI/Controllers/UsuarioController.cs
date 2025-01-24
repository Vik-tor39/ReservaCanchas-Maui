using Microsoft.AspNetCore.Mvc;
using SaveInformationAPI.Data;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Controllers
{
    public class UsuarioController (ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public Task<IEnumerable<Usuario>> GetUser() =>
            _context.Usuario.OrderBy(p => p.NombreUsuario).ToListAsync();
        

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUserById(int id)
        {
            return _context.Usuario;
        }

        [HttpPost]
        public ActionResult<Cancha> AddUser(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { id = usuario.IdUsuario }, usuario);
        }
    }
}
