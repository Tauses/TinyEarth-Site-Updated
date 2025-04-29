using Microsoft.AspNetCore.Mvc;
using TinyEarth.Models;

namespace TinyEarth.Controllers
{
    public class StatsController : Controller
    {
        private readonly PlanService _planService;
        private readonly Guid _serverUUID = Guid.Parse("499ae95b-46e3-4652-abbb-122f60c45ce4");

        public StatsController(PlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GETS PLAYER FROM SEARCH INPUT
        [HttpPost]
        public async Task<IActionResult> SearchPlayer(string playerName)
        {
            var playerUUID = await _planService.FetchUUIDOfAsync(playerName);
            if (playerUUID == null)
            {
                ViewBag.ErrorMessage = "Player not found.";
                return View("Index");
            }

            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var weekAgo = now - (7L * 24 * 60 * 60 * 1000); // 7 dage bagud

            var playtime = await _planService.FetchPlaytimeAsync(playerUUID.Value, _serverUUID, weekAgo, now);
            var lastSeen = await _planService.FetchLastSeenAsync(playerUUID.Value, _serverUUID);
            var activityIndex = await _planService.FetchActivityIndexAsync(playerUUID.Value, now);

            var model = new PlayerStatsViewModel
            {
                PlayerName = playerName,
                PlayerUUID = playerUUID.Value,
                Playtime = playtime,
                LastSeen = lastSeen,
                ActivityIndex = activityIndex
            };

            return View("PlayerStats", model);
        }

    }
}
