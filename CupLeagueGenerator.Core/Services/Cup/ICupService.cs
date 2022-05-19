namespace CupLeagueGenerator.Core.Services.Cup
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ICupService
    {
        List<Fixture> GenerateCupFixtures(CupModel model);
    }
}
