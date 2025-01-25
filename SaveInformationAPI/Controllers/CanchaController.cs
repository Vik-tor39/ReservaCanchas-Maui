using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SaveInformationAPI.Data;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;
using SaveInformationAPI.Repositories;

namespace SaveInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaController (CanchaRepository repository) : ControllerBase
    {
        private readonly ICanchaRepository _repository = repository;

        [HttpGet]
        [Route("GetAllCanchas")]
        public ActionResult<IEnumerable<Cancha>> GetAll()
        {
            var response =  _repository.ListarCanchas();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCanchaById/{id}")]
        public ActionResult<Cancha> GetById(int id)
        {
            var response = _repository.VerCancha(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddNewCancha")]
        public ActionResult<Cancha> AddNew([FromBody] Cancha cancha)
        {
            var status = _repository.AgregarCancha(cancha);
            return Ok(status);
        }

        [HttpPut]
        [Route("ModifyCanchaById/{id}")]
        public ActionResult<Cancha> ModifyById(int id,[FromBody] Cancha canchaActualizada)
        {
            var response = _repository.ModificarInformacionCancha(id, canchaActualizada);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCanchaById/{id}")]
        public ActionResult<Cancha> DeleteById(int id)
        {
            var response = _repository.EliminarCancha(id);
            return Ok(response);
        }
    }
}
