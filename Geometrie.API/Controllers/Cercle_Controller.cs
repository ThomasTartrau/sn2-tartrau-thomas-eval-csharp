using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Cercle_Controller : Controller
    {
        private ICercle_Service service;

        public Cercle_Controller(ICercle_Service service)
        {
            this.service = service;
        }

        //On mappe toutes les méthodes de service dans des méthodes de contrôleurs

        [HttpPost]
        public Cercle_DTO Add(Cercle_DTO cercle)
        {
            return service.Add(cercle);
        }

        [HttpPost]
        [ActionName("DeleteObject")]
        public IActionResult Delete(Cercle_DTO cercle)
        {
            return Ok(service.Delete(cercle));
        }

        [HttpPost]
        [ActionName("DeleteById")]
        public IActionResult Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        [HttpGet]
        public IEnumerable<Cercle_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet]
        public Cercle_DTO? GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public Cercle_DTO Update(Cercle_DTO cercle)
        {
            return service.Update(cercle);
        }
    }
}
