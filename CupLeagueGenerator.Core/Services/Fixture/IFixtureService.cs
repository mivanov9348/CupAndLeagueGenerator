namespace CupLeagueGenerator.Core.Services.Fixture
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    
    public interface IFixtureService
    {
        void GenerateCupFixtures(Cup currentCup);
        void GenerateLeagueFixtures(League currentLeague);
        void RemoveCurrentFixtures(int competitionId);
        int CalculateRounds(Cup CurrentCup);
    }
}
