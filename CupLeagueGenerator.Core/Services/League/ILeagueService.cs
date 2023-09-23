namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ILeagueService
    {
        List<Group> GenerateGroups(League currentLeague, LeagueModel model, string userId);
        List<League> GetUsersLeagues(string userId);
        League GetCurrentLeague(int leagueId);
        List<Group> GetLeagueGroups(League currentLeague);
        void DeleteLeague(League currentLeague);
        League GenerateLeague(LeagueModel model, string userId);
        void DrawGroups(League league);

        void DeleteGroupParticipants(League league);
    }
}
