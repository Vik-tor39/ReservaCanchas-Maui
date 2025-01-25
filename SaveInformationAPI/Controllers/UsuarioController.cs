using Azure;
using Microsoft.AspNetCore.Mvc;
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
            var response = _repository.ListarUsuarios();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUsuarioById/{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var response = _repository.VerUsuario(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddNewUsuario")]
        public ActionResult<bool> AddNew([FromBody] Usuario usuario)
        {
            var response = _repository.AgregarUsuario(usuario);
            return Ok(response);
        }

        [HttpPut]
        [Route("ModifyUsuarioById/{id}")]
        public ActionResult<bool> ModifyById(int id, [FromBody] Usuario usuarioActualizado)
        {
            var response = _repository.ModificarInformacionUsuario(id, usuarioActualizado);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteUsuarioById/{id}")]
        public ActionResult<bool> DeleteById(int id)
        {
            var response = _repository.EliminarUsuario(id);
            return Ok(response);
        }
    }
}

