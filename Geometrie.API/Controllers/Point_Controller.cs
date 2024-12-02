using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    public class Point_Controller : Controller
    {
        private Point_Service service;

        public Point_Controller(Point_Service service)
        {
            this.service = service;
        }


    }
}
