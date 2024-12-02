using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Point_Controller : Controller
    {
        private Point_Service service;

        public Point_Controller(Point_Service service)
        {
            this.service = service;
        }

        //On mappe toutes les méthodes de service dans des méthodes de contrôleurs

        [HttpPost]
        public Point_DTO Add(Point_DTO point)
        {
            return service.Add(point);
        }

        [HttpPost]
        [ActionName("DeleteObject")]
        public IActionResult Delete(Point_DTO point)
        {
            return Ok(service.Delete(point));
        }

        [HttpPost]
        [ActionName("DeleteById")]
        public IActionResult Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        [HttpGet]
        public IEnumerable<Point_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet]
        public Point_DTO? GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public Point_DTO Update(Point_DTO point)
        {
            return service.Update(point);
        }

    }
}
