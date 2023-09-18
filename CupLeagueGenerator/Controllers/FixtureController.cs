namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Core.Services.Fixture;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    public class FixtureController : Controller
    {
        private readonly ICupService cupService;
        private readonly IFixtureService fixtureService;

        public FixtureController(ICupService cupService, IFixtureService fixtureService)
        {
            this.cupService = cupService;
            this.fixtureService = fixtureService;
        }

        public IActionResult GenerateCupFixtures(int cupId)
        {
            var currentCup = cupService.GetCurrentCup(cupId);
            fixtureService.RemoveCurrentFixtures(cupId);
            fixtureService.GenerateCupFixtures(currentCup);
            return RedirectToAction("OpenCup", "Cup", new { cupId = currentCup.Id });
        }
    }
}
