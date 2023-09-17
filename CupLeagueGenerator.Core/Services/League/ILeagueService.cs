namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ILeagueService
    {
        (string, bool) IsTeamsValid(LeagueModel model);
        League CreateLeague(LeagueModel model,string userId);
        List<Group> GenerateGroups(LeagueModel model, string userId);
        List<Group> FillTeamsInGroups(LeagueModel model, string userId);
      //  List<Fixture> GetFixtures(LeagueModel model, string userId);
        List<League> GetUsersLeagues(string userId);
        League GetCurrentLeague(int leagueId);
        List<Group> GetLeagueGroups(League currentLeague);
        List<Fixture> GetLeagueFixtures(League currentLeague);
        void DeleteLeague(int id);
    }
}
