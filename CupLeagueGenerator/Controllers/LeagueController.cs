namespace CupLeagueGenerator.Controllers
{
    using CupLeagueGenerator.Core.Services.Cup;
    using CupLeagueGenerator.Core.Services.Fixture;
    using CupLeagueGenerator.Core.Services.League;
    using CupLeagueGenerator.Core.Services.Participant;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Security.Claims;
    using System.Text.RegularExpressions;

    public class LeagueController : Controller
    {
        private readonly ILeagueService leagueService;
        private readonly IFixtureService fixtureService;
        private readonly IParticipantService participantService;
        public LeagueController(ILeagueService leagueService, IParticipantService participantService, IFixtureService fixtureService)
        {
            this.leagueService = leagueService;
            this.participantService = participantService;
            this.fixtureService = fixtureService;
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
            var league = leagueService.GenerateLeague(model, userId);
            leagueService.GenerateGroups(league, model, userId);
            return RedirectToAction("Index");
        }
        public IActionResult OpenLeague(int leagueId)
        {
            var currentLeague = leagueService.GetCurrentLeague(leagueId);
            var groups = currentLeague.Groups;
            var participants = participantService.GetLeagueParticipants(leagueId);
            var teamsPerGroup = groups.First().TeamsCount;
            var fixtures = fixtureService.GetFixturesById(currentLeague.Id);

            return View("LeaguePreview", new LeagueViewModel
            {
                LeagueId = currentLeague.Id,
                LeagueName = currentLeague.Name,
                Groups = groups,
                LeagueParticipants = participants,
                TeamsPerGroup = teamsPerGroup,
                LeagueFixtures = fixtures

            });
        }
        public IActionResult DeleteLeague(int leagueId)
        {
            var league = leagueService.GetCurrentLeague(leagueId);
            leagueService.DeleteLeague(league);
            return RedirectToAction("Index");
        }
        public IActionResult TeamsInput(int leagueId)
        {
            var league = this.leagueService.GetCurrentLeague(leagueId);

            return View(new LeagueModel
            {
                LeagueId = leagueId,
                NumberOfTeams = league.ParticipantsCount
            });
        }
        public IActionResult AddTeams(LeagueModel model)
        {
            var userId = GetUserId();
            var league = this.leagueService.GetCurrentLeague(model.LeagueId);
            participantService.DeleteCurrentLeagueParticipants(league);
            participantService.SaveLeagueParticipants(league, model, userId);
            return RedirectToAction("Index");
        }

        public IActionResult OneLeague()
        {
            var newLeagueModel = new LeagueModel
            {
                IsOneLeague = true
            };

            return View("GenerateLeague",newLeagueModel);
        }
        public IActionResult DrawGroups(int leagueId)
        {
            var league = leagueService.GetCurrentLeague(leagueId);
            leagueService.DeleteGroupParticipants(league);
            leagueService.DrawGroups(league);
            var groups = league.Groups;
            var participants = participantService.GetLeagueParticipants(leagueId);
            var teamsPerGroup = groups.First().TeamsCount;

            return View("LeaguePreview", new LeagueViewModel
            {
                LeagueId = league.Id,
                LeagueName = league.Name,
                Groups = groups,
                LeagueParticipants = participants,
                TeamsPerGroup = teamsPerGroup,

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
