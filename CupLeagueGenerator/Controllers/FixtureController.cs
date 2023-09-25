namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Core.Services.Fixture;
    using CupLeagueGenerator.Core.Services.League;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    public class FixtureController : Controller
    {
        private readonly ICupService cupService;
        private readonly ILeagueService leagueService;
        private readonly IFixtureService fixtureService;

        public FixtureController(ICupService cupService, IFixtureService fixtureService, ILeagueService leagueService)
        {
            this.cupService = cupService;
            this.fixtureService = fixtureService;
            this.leagueService = leagueService; 
        }
        public IActionResult GenerateCupFixtures(int cupId)
        {
            var currentCup = cupService.GetCurrentCup(cupId);
            fixtureService.RemoveCurrentFixtures(cupId);
            fixtureService.GenerateCupFixtures(currentCup);
            return RedirectToAction("OpenCup", "Cup", new { cupId = currentCup.Id });
        }
        public IActionResult GenerateLeagueFixtures(int leagueId)
        {
            var currentLeague = leagueService.GetCurrentLeague(leagueId);
            fixtureService.RemoveCurrentFixtures(leagueId);
            fixtureService.GenerateLeagueFixtures(currentLeague);
            return RedirectToAction("OpenLeague", "League", new { leagueId = leagueId });
        }
    }
}
