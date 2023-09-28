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
            var allGroups = this.data.Groups.Where(x => x.LeagueId == currentLeague.Id);

            foreach (var group in allGroups)
            {
                var participants = this.data.Participants.Where(x => x.GroupId == group.Id).ToList();
                Shuffle(participants);
                var numOfMatches = participants.Count / 2 * (participants.Count - 1);
                int numFixt = 0;
                var round = 1;
                var dayCount = 0;

                while (numFixt < numOfMatches)
                {
                    for (int i = 0; i < participants.Count() / 2; i += 1)
                    {
                        var htId = participants[i].Id;
                        var atId = participants[(participants.Count() - 1 - i)].Id;
                        var ht = this.data.Participants.FirstOrDefault(x => x.Id == htId);
                        var at = this.data.Participants.FirstOrDefault(x => x.Id == atId);

                        var newFixt = new Fixture
                        {
                            Round = round,
                            HomeParticipant = ht,
                            AwayParticipant = at,
                            HomeTeamName = ht.Name,
                            AwayTeamName = at.Name,
                            HomeParticipantScore = 0,
                            AwayParticipantScore = 0,
                            LeagueId = currentLeague.Id,
                            League = currentLeague,
                            HomeParticipantId = htId,
                            AwayParticipantId = atId,
                            Group = group,
                            GroupId = group.Id,
                            AppUserId = currentLeague.AppUserId,
                            IsPlayed = false
                        };

                        this.data.Fixtures.Add(newFixt);
                        numFixt++;
                    }

                    round++;
                    dayCount++;

                    for (int i = participants.Count - 1; i > 1; i--)
                    {
                        Participant temp = participants[i - 1];
                        participants[i - 1] = participants[i];
                        participants[i] = temp;
                    }
                }
            }
            this.data.SaveChanges();
        }

        public List<Fixture> GetFixturesById(int competitionId)
        {
            return this.data.Fixtures.Where(x => x.CupId == competitionId || x.LeagueId == competitionId).ToList();
        }

        public void RemoveCurrentFixtures(int competitionId)
        {
            this.data.Fixtures.RemoveRange(this.data.Fixtures.Where(x => x.CupId == competitionId || x.LeagueId == competitionId).ToList());
            this.data.SaveChanges();
        }

        private void Shuffle(List<Participant> teams)
        {
            Random rnd = new Random();
            int n = teams.Count;

            for (int i = n - 1; i > 1; i--)
            {
                int random = rnd.Next(i + 1);

                var value = teams[random];
                teams[random] = teams[i];
                teams[i] = value;
            }
        }
    }
}
