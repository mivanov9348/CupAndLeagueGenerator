namespace CupLeagueGenerator.Core.Services.Fixture
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;

    public class FixtureService : IFixtureService
    {
        private readonly CupLeagueDbContext data;
        private Random rnd;
        public FixtureService(CupLeagueDbContext data)
        {
            this.data = data;
            this.rnd = new Random();
        }

        public int CalculateRounds(Cup CurrentCup)
        {
            var rounds = (int)Math.Ceiling(Math.Log(CurrentCup.Participants.Count(), 2));
            CurrentCup.Rounds = rounds;
            this.data.SaveChanges();
            return rounds;
        }

        public void GenerateCupFixtures(Cup currentCup)
        {
            var fixtures = new List<Fixture>();
            var participants = this.data.Participants.Where(x => x.CupId == currentCup.Id).ToList();
            var matches = participants.Count() / 2;

            for (int i = 0; i < matches; i++)
            {
                var homeTeam = participants[rnd.Next(0, participants.Count)];
                participants.Remove(homeTeam);
                var awayTeam = participants[rnd.Next(0, participants.Count)];
                participants.Remove(awayTeam);

                var newFixt = new Fixture
                {
                    AppUserId = currentCup.AppUserId,
                    HomeParticipant = homeTeam,
                    AwayParticipant = awayTeam,
                    Round = 1,
                    Cup = currentCup,
                    CupId = currentCup.Id
                };
                this.data.Fixtures.Add(newFixt);
                fixtures.Add(newFixt);
            }
            this.data.SaveChanges();
        }

        public void GenerateLeagueFixtures(League currentLeague)
        {
            var leagueGroups = this.data.Groups.Where(x => x.LeagueId == currentLeague.Id).ToList();

            foreach (var group in leagueGroups)
            {
                var participants = this.data.Participants.Where(x => x.GroupId == group.Id).ToList();

                for (int i = 0; i < participants.Count - 1; i++)
                {
                    for (int j = i + 1; j < participants.Count; j++)
                    {
                        var homeTeam = participants[i];
                        var awayTeam = participants[j];

                        var newFixt = new Fixture
                        {
                            AppUserId = currentLeague.AppUserId,
                            HomeParticipant = homeTeam,
                            AwayParticipant = awayTeam,
                            Round = 1,
                            League = currentLeague,
                            LeagueId = currentLeague.Id
                        };

                        this.data.Fixtures.Add(newFixt);

                    }
                }
            }
        }

        public void RemoveCurrentFixtures(int competitionId)
        {
            this.data.Fixtures.RemoveRange(this.data.Fixtures.Where(x => x.CupId == competitionId && x.LeagueId == competitionId).ToList());
            this.data.SaveChanges();
        }
    }
}
