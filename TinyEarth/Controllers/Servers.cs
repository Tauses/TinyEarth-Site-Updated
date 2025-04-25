using Microsoft.AspNetCore.Mvc;

namespace TinyEarth.Controllers
{
    public class Servers : Controller
    {
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
