namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Core.Services.Fixture;
    using CupLeagueGenerator.Core.Services.Participant;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    public class CupController : Controller
    {
        private readonly ICupService cupService;
        private readonly IParticipantService participantService;
        private readonly IFixtureService fixtureService;

        private string userId;
        public CupController(ICupService cupService, IParticipantService participantService, IFixtureService fixtureService)
        {
            this.cupService = cupService;
            this.participantService = participantService;
            this.fixtureService = fixtureService;
        }
        public IActionResult Index()
        {
            GetUserId();
            return View(new CupModel
            {
                UserCups = cupService.GetUserCups(userId)
            });
        }
        public IActionResult GenerateCup()
        {
            return View();
        }
        public IActionResult TeamsInput(CupModel model)
        {
            return View(model);
        }
        public IActionResult OpenCup(int cupId)
        {
            var currentCup = cupService.GetCurrentCup(cupId);
            return View("CupPreview", new CupViewModel
            {
                CupId = currentCup.Id,
                CupFixtures = currentCup.Fixtures,
                CupName = currentCup.Name,
                CupParticipants = currentCup.Participants
            });
        }
        public IActionResult DeleteCup(int cupId)
        {
            cupService.DeleteCup(cupId);
            return RedirectToAction("Index");
        }
        public IActionResult SaveCup(CupModel model)
        {
            GetUserId();            
            var currentCup = cupService.SaveCup(model, userId);
            participantService.SaveCupParticipants(currentCup, model, userId);
            fixtureService.CalculateRounds(currentCup);
            return RedirectToAction("Index");
        }
        public IActionResult CupBrackets(int cupId)
        {
            var currentCup = cupService.GetCurrentCup(cupId);   
         
            return View(new CupViewModel
            {
                CupFixtures = currentCup.Fixtures,
                CupId = currentCup.Id,
                CupName = currentCup.Name,
                CupParticipants = currentCup.Participants,
                CupRounds = currentCup.Rounds
            });
        }

        private string GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return userId;
            }
            else
            {
                return null;
            }
        }
    }
}
