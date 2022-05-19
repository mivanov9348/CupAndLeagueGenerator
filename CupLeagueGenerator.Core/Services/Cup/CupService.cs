using CupLeagueGenerator.Infrastructure.Data.DataModels;
using CupLeagueGenerator.Infrastructure.Models;

namespace CupLeagueGenerator.Core.Services.Cup
{
    public class CupService : ICupService
    {
        private Random rnd;
        public CupService()
        {
            rnd = new Random();
        }

        public List<Fixture> GenerateCupFixtures(CupModel model)
        {
            var teams = model.Teams;
            var rounds = GetRoundsToFinal(teams.Count());
            var matches = teams.Count / 2;
            var fixtures = GenerateFixtures(teams, matches);
            return fixtures;
        }

        private List<Fixture> GenerateFixtures(List<string> teams, int matches)
        {
            var fixtures = new List<Fixture>();

            for (int i = 0; i < matches; i++)
            {
                var homeTeam = teams[rnd.Next(0, teams.Count)];
                teams.Remove(homeTeam);
                var awayTeam = teams[rnd.Next(0, teams.Count)];
                teams.Remove(awayTeam);

                var newFixt = new Fixture
                {
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    Round = 1
                };
                fixtures.Add(newFixt);
            }

            return fixtures;
        }

        private int GetRoundsToFinal(int teams)
        {
            switch (teams)
            {
                case 4: return 2;
                case 8: return 3;
                case 16: return 4;
                case 32: return 5;
                case 64: return 6;
                default: return 0;
            }
        }
    }
}
