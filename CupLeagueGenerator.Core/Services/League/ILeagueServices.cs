namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ILeagueServices
    {
        (string, bool) IsTeamsValid(LeagueModel model);
              
        List<Group> GenerateGroups(LeagueModel model);
        List<Group> FillTeamsInGroups(LeagueModel model);
        List<Fixture> GetFixtures(LeagueModel model);
    }
}
