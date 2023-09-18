namespace CupLeagueGenerator.Core.Services.Fixture
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    
    public interface IFixtureService
    {
        void GenerateCupFixtures(Cup currentCup);

        void GenerateLeagueFixtures();
        void RemoveCurrentFixtures(int cupId);
    }
}
