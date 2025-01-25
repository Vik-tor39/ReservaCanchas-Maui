using Azure;
using Microsoft.AspNetCore.Mvc;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;
using SaveInformationAPI.Repositories;

namespace SaveInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplejoController(ComplejoRepository repository) : ControllerBase
    {
        private readonly IComplejoRepository _repository = repository;

        [HttpGet]
        [Route("GetAllComplejos")]
        public ActionResult<IEnumerable<Complejo>> GetAll()
        {
            var response = _repository.ListarComplejos();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetComplejoById/{id}")]
        public ActionResult<Cancha> GetById(int id)
        {
            var response = _repository.VerComplejo(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddNewComplejo")]
        public ActionResult<Complejo> AddNew([FromBody] Complejo complejo)
        {
            var response = _repository.AgregarComplejo(complejo);
            return Ok(response);
        }

        [HttpPut]
        [Route("ModifyComplejoById/{id}")]
        public ActionResult<Complejo> ModifyById(int id, [FromBody] Complejo complejoActualizado)
        {
            var response = _repository.ModificarInformacionComplejo(id, complejoActualizado);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteComplejoById/{id}")]
        public ActionResult<Complejo> DeleteById(int id)
        {
            var response = _repository.EliminarComplejo(id);
            return Ok(response);
        }
    }
}
