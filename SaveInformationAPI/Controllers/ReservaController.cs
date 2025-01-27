using Microsoft.AspNetCore.Mvc;
using SaveInformationAPI.Interfaces;
using SaveInformationAPI.Models;
using SaveInformationAPI.Repositories;

namespace SaveInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController(ReservaRepository repository) : ControllerBase
    {
        private readonly IReservaRepository _repository = repository;

        [HttpGet]
        [Route("GetAllReservas")]
        public ActionResult<IEnumerable<Reserva>> GetAll()
        {
            var response = _repository.ListarReservas();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetReservaById/{id}")]
        public ActionResult<Cancha> GetById(int id)
        {
            var response = _repository.VerReserva(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddNewReserva")]
        public ActionResult<Reserva> AddNew([FromBody] Reserva reserva)
        {
            var status = _repository.AgregarReserva(reserva);
            return Ok(status);
        }

        [HttpPut]
        [Route("ModifyReservaById/{id}")]
        public ActionResult<Reserva> ModifyById(int id, [FromBody] Reserva reservaActualizada)
        {
            var response = _repository.ModificarInformacionReserva(id, reservaActualizada);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteReservaById/{id}")]
        public ActionResult<Reserva> DeleteById(int id)
        {
            var response = _repository.EliminarReserva(id);
            return Ok(response);
        }
    }
}
