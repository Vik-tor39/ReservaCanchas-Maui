using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaveInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {

        // GET: CanchaController
        public ActionResult Index()
        {

        }

        // GET: CanchaController/Details/5
        public ActionResult Details(int id)
        {

        }

        // GET: CanchaController/Create
        public Task Create()
        {
            return Task.CompletedTask; 
        }

        // GET: CanchaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task Delete(int id)
        {
            return Task.CompletedTask;
        }

        // POST: CanchaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

        }
    }
}
