namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.League;
    using CupLeagueGenerator.Core.Services.Participant;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    public class LeagueController : Controller
    {
        private readonly ILeagueService leagueService;
        private readonly IParticipantService participantService;
        public LeagueController(ILeagueService leagueService, IParticipantService participantService)
        {
            this.leagueService = leagueService;
            this.participantService = participantService;
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            var leagues = leagueService.GetUsersLeagues(userId);
            return View(new LeagueModel
            {
                Leagues = leagues
            });
        }
        public IActionResult GenerateLeague()
        {
            return View(new LeagueModel());
        }

        public IActionResult SaveLeague(LeagueModel model)
        {
            var userId = GetUserId();
            leagueService.GenerateLeague(model, userId);
            return View("Index");
        }

        public IActionResult TeamsInput()
        {
            return View(new LeagueModel { });
        }

        public IActionResult AddTeams(int leagueId)
        {
            var userId = GetUserId();
            var league = this.leagueService.GetCurrentLeague(leagueId);
            participantService.SaveLeagueParticipants(league, userId);

            return RedirectToAction();
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
