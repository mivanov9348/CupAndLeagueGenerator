namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.League;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    public class LeagueController : Controller
    {
        private readonly ILeagueServices leagueService;
        public LeagueController(ILeagueServices leagueService)
        {
            this.leagueService = leagueService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeamsInput(LeagueModel model)
        {
            (string, bool) IsTeamsValid = leagueService.IsTeamsValid(model);

            if (IsTeamsValid.Item2 == false)
            {
                TempData["error"] = IsTeamsValid.Item1;
                return View("Index", model);
            }

            return View(model);
        }
    }
}
