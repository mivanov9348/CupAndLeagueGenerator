namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Core.Services.League;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class SaveController : Controller
    {
        private readonly ILeagueService leagueService;
        private readonly ICupService cupService;

        public SaveController(ILeagueService leagueService, ICupService cupService)
        {
            this.leagueService = leagueService;
            this.cupService = cupService;
        }

        public IActionResult Saves()
        {
            var userId = GetCurrentUserId();
            var userCups = cupService.GetUserCups(userId);
            var userLeagues = leagueService.GetUsersLeagues(userId);
            return View(new SavesModel
            {
                Cups = userCups,
                Leagues = userLeagues
            });
        }

        public IActionResult LoadCup(int id)
        {
            var currentCup = cupService.GetCurrentCup(id);
            var fixtures = cupService.GetCupFixtures(currentCup);
            var model = new CupModel
            {
                Matches = currentCup.Fixtures.Count(),
                CupName = currentCup.Name,
                Fixtures = fixtures,
                Id = currentCup.Id
            };
            return RedirectToAction("CupFixtures", "Cup", model);
        }

        public IActionResult DeleteCup(int id)
        {
            cupService.DeleteCup(id);
            return RedirectToAction("Saves");
        }
        public IActionResult LoadLeague()
        {
            var userId = GetCurrentUserId();
            var userCups = cupService.GetUserCups(userId);
            var userLeagues = leagueService.GetUsersLeagues(userId);
            return View(new SavesModel
            {
                Cups = userCups,
                Leagues = userLeagues
            });
        }
        public IActionResult DeleteLeague(int id)
        {
            leagueService.DeleteLeague(id);
            return RedirectToAction("Saves");
        }

        private string GetCurrentUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
