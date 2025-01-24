using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Data;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaController (ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;   

        [HttpGet]
        public ActionResult<IEnumerable<Cancha>> GetProducts()
        {
            return _context.Cancha;
        }

        [HttpPost]
        public ActionResult<Cancha> PostProduct(Cancha Cancha)
        {
            _context.Cancha.Add(Cancha);
            _context.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = Cancha.IdCancha }, Cancha);
        }
    }
}
