namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    public class CupController : Controller
    {
        private readonly ICupService cupService;
        public CupController(ICupService cupService)
        {
            this.cupService = cupService;
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            var userCups = cupService.GetUserCups(userId);
            return View(new CupModel
            {
                UserCups = userCups
            });
        }
        public IActionResult TeamsInput(CupModel model)
        {
            return View(model);
        }
        public IActionResult CupFixtures(CupModel model)
        {
            var userId = GetUserId();
            var currentCup = cupService.GetCurrentCup(model.Id);

            if (model.Fixtures != null)
            {              
                model.Fixtures = cupService.GetCupFixtures(currentCup);
                return View(model);
            }
            
            var fixtures = cupService.GenerateCupFixtures(model, userId);
            model.Matches = fixtures.Count();
            model.Fixtures = fixtures;

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
