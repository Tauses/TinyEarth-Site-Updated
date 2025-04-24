using Microsoft.AspNetCore.Mvc;

namespace TinyEarth.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
