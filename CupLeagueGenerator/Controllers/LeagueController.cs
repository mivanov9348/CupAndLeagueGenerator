namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.League;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class LeagueController : Controller
    {
        private readonly ILeagueService leagueService;
        public LeagueController(ILeagueService leagueService)
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

        public IActionResult LeagueFixtures(LeagueModel model)
        {
            var userId = GetUserId();
            var currentLeague = leagueService.GetCurrentLeague(model.Id);

            if (currentLeague == null)
            {
                model.Id = leagueService.CreateLeague(model, userId).Id;
                model.Groups = leagueService.GenerateGroups(model, userId);
                model.Groups = leagueService.FillTeamsInGroups(model, userId);
                model.Fixtures = leagueService.GetFixtures(model, userId);
                return View("LeagueFixtures", model);
            }
            else
            {
                model.Fixtures = leagueService.GetLeagueFixtures(currentLeague);
                model.Groups = leagueService.GetLeagueGroups(currentLeague);
                return View("LeagueFixtures", model);
            }
                        

       
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
