namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    public class CupController : Controller
    {
        private readonly ICupService cupService;
        public CupController(ICupService cupService)
        {
            this.cupService = cupService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeamsInput(CupModel model)
        {
            return View(model);
        }
        public IActionResult CupFixtures(CupModel model)
        {
            var fixtures = cupService.GenerateCupFixtures(model);
            model.Matches = fixtures.Count();
            model.Fixtures = fixtures;

            return View(model);
        }
    }
}
