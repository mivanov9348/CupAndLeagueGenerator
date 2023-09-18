namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Core.Services.Participant;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    public class CupController : Controller
    {
        private readonly ICupService cupService;
        private readonly IParticipantService participantService;

        private string userId;
        public CupController(ICupService cupService, IParticipantService participantService)
        {
            this.cupService = cupService;
            this.participantService = participantService;
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
            return RedirectToAction("Index");
        }

        // public IActionResult CupFixtures(CupModel model)
        // {
        //     var userId = GetUserId();
        //     var currentCup = cupService.GetCurrentCup(model.Id);
        //
        //     if (model.Fixtures != null)
        //     {              
        //         model.Fixtures = cupService.GetCupFixtures(currentCup);
        //         return View(model);
        //     }
        //     
        //     var fixtures = cupService.GenerateCupFixtures(model, userId);
        //     model.Matches = fixtures.Count();
        //     model.Fixtures = fixtures;
        //
        //     return View(model);
        // }
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
