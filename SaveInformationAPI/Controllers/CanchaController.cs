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
            var cancha = _repository.ListarCanchas();
            return Ok(cancha);
        }

        [HttpGet]
        [Route("GetCanchaById")]
        public ActionResult<Cancha> GetById(int id)
        {
            var cancha = _repository.VerCancha(id);
            return Ok(cancha);
        }

        [HttpPost]
        [Route("AddNewCancha")]
        public ActionResult<Cancha> AddNew(Cancha cancha)
        {
            var status = _repository.AgregarCancha(cancha);
            return Ok(status);
        }

        [HttpPut]
        [Route("ModifyCanchaById")]
        public ActionResult<Cancha> ModifyById(int id, Cancha canchaActualizada)
        {
            var status = _repository.ModificarInformacionCancha(id, canchaActualizada);
            return Ok(status);
        }

        [HttpDelete]
        [Route("DeleteCanchaById")]
        public ActionResult<Cancha> DeleteById(int id)
        {
            var status = _repository.EliminarCancha(id);
            return Ok(status);
        }
    }
}
