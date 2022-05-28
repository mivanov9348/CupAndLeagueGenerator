namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ILeagueServices
    {
        (string, bool) IsTeamsValid(LeagueModel model);

        League CreateLeague(LeagueModel model,string userId);
        List<Group> GenerateGroups(LeagueModel model, string userId);
        List<Group> FillTeamsInGroups(LeagueModel model, string userId);
        List<Fixture> GetFixtures(LeagueModel model, string userId);
    }
}
