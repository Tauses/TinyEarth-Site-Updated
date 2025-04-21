using Microsoft.AspNetCore.Mvc;

namespace TinyEarth.Controllers
{
    public class Store : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
