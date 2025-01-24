using Microsoft.AspNetCore.Mvc;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;
using SaveInformationAPI.Repositories;

namespace SaveInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(UsuarioRepository repository) : ControllerBase
    {
        private readonly IUsuarioRepository _repository = repository;

        [HttpGet]
        [Route("GetAllUsuarios")]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            var cancha = _repository.ListarUsuarios();
            return Ok(cancha);
        }

        [HttpGet]
        [Route("GetUsuarioById")]
        public ActionResult<Cancha> GetById(int id)
        {
            var cancha = _repository.VerUsuario(id);
            return Ok(cancha);
        }

        [HttpPost]
        [Route("AddNewUsuario")]
        public ActionResult<Cancha> AddNew(Usuario cancha)
        {
            var status = _repository.AgregarUsuario(cancha);
            return Ok(status);
        }

        [HttpPut]
        [Route("ModifyUsuarioById")]
        public ActionResult<Cancha> ModifyById(int id, Usuario usuarioActualizado)
        {
            var status = _repository.ModificarInformacionUsuario(id, usuarioActualizado);
            return Ok(status);
        }

        [HttpDelete]
        [Route("DeleteUsuarioById")]
        public ActionResult<Cancha> DeleteById(int id)
        {
            var status = _repository.EliminarUsuario(id);
            return Ok(status);
        }
    }
}
