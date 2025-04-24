using Microsoft.AspNetCore.Mvc;

namespace TinyEarth.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Stats()
        {
            return View();
        }
    }
}
