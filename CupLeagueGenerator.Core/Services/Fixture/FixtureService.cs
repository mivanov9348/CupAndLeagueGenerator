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
            CurrentCup.Rounds= rounds;
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

        public void GenerateLeagueFixtures()
        {
            throw new NotImplementedException();
        }

        public void RemoveCurrentFixtures(int cupId)
        {
            this.data.Fixtures.RemoveRange(this.data.Fixtures.Where(x => x.CupId == cupId).ToList());
            this.data.SaveChanges();
        }
    }
}
