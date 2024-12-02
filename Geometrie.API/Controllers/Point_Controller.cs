using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    public class Point_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
