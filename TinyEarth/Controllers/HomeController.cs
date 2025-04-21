using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TinyEarth.Models;

namespace TinyEarth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }
        public IActionResult Media()
        {
            return View();
        }
        public IActionResult Safety()
        {
            return View();
        }
        public IActionResult Vote()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
