namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ILeagueServices
    {
        (string, bool) IsTeamsValid(LeagueModel model);
    }
}
