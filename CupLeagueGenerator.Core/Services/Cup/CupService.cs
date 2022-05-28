namespace CupLeagueGenerator.Core.Services.Cup
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public class CupService : ICupService
    {
        private Random rnd;
        private readonly CupLeagueDbContext data;
        public CupService(CupLeagueDbContext data)
        {
            this.data = data;
            rnd = new Random();
        }
        public List<Fixture> GenerateCupFixtures(CupModel model, string userId)
        {
            var teams = model.Teams;
            var rounds = GetRoundsToFinal(teams.Count());
            var matches = teams.Count / 2;
            var fixtures = GenerateFixtures(model, teams, matches, userId);
            return fixtures;
        }
        private List<Fixture> GenerateFixtures(CupModel model, List<string> teams, int matches, string userId)
        {
            var fixtures = new List<Fixture>();
            var currentUser = this.data.Users.FirstOrDefault(x => x.Id == userId);

            var newCup = new Cup
            {
                Name = model.CupName,
                AppUserId = userId,
                TeamsCount = teams.Count
            };

            this.data.Cups.Add(newCup);
            this.data.SaveChanges();

            for (int i = 0; i < matches; i++)
            {
                var homeTeam = teams[rnd.Next(0, teams.Count)];
                teams.Remove(homeTeam);
                var awayTeam = teams[rnd.Next(0, teams.Count)];
                teams.Remove(awayTeam);

                var newFixt = new Fixture
                {
                    AppUserId = userId,
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    Round = 1,
                    Cup = newCup,
                    CupId = newCup.Id
                };
                this.data.Fixtures.Add(newFixt);
                fixtures.Add(newFixt);
            }
            this.data.SaveChanges();
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

        public List<Cup> GetUserCups(string userId)
        {
            return this.data.Cups.Where(x => x.AppUserId == userId).ToList();
        }

        public Cup GetCurrentCup(int id)
        {
            return this.data.Cups.FirstOrDefault(x => x.Id == id);
        }

        public List<Fixture> GetCupFixtures(Cup currentCup)
        {
            return this.data.Fixtures.Where(x => x.CupId == currentCup.Id).ToList();
        }

        public void DeleteCup(int id)
        {
            var currentCup = this.data.Cups.FirstOrDefault(x => x.Id == id);
            var fixtures = this.data.Fixtures.Where(x => x.CupId == currentCup.Id).ToList();
            this.data.Fixtures.RemoveRange(fixtures);
            this.data.Cups.Remove(currentCup);
            this.data.SaveChanges();
        }
    }
}
