namespace CupLeagueGenerator.Core.Services.Cup
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public interface ICupService
    {
       // List<Fixture> GenerateCupFixtures(CupModel model, string userId);
        List<Cup> GetUserCups(string userId);
        Cup GetCurrentCup(int id);
        List<Fixture> GetCupFixtures(Cup currentCup);
        void DeleteCup(int id);
    }
}
