using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using TinyEarth.Models;

namespace TinyEarth.Controllers
{
    public class StatsController : Controller
    {
        private readonly PlanService _planService;

        public StatsController(PlanService planService)
        {
            _planService = planService;
        }

        public async Task<IActionResult> Index()
        {
            var players = await _planService.GetPlayersAsync();
            return View(players);
        }

        [HttpPost]
        public async Task<IActionResult> SearchPlayer(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                ViewBag.ErrorMessage = "Please enter a valid player name.";
                return View("Index");
            }

            var player = await _planService.SearchPlayerByNameAsync(playerName);

            if (player == null)
            {
                ViewBag.ErrorMessage = $"Player '{playerName}' not found.";
                return View("Index");
            }

            // Du kan lave en ny viewmodel senere, men for nu:
            return View("PlayerDetails", player);
        }
    }
}
