using Microsoft.AspNetCore.Mvc;

namespace TinyEarth.Controllers
{
    public class ServersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ServerTowny()
        {
            return View();
        }
        public IActionResult ServerPrison()
        {
            return View();
        }
    }
}
