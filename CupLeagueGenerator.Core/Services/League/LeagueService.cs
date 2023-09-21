namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;

    public class LeagueService : ILeagueService
    {
        private Random rnd;
        private readonly CupLeagueDbContext data;
        public LeagueService(CupLeagueDbContext data)
        {
            this.rnd = new Random();
            this.data = data;
        }
        public League CreateLeague(LeagueModel model, string userId)
        {
            var newLeague = new League
            {
                Name = model.LeagueName,
                AppUserId = userId,
                TeamsCount = model.NumberOfTeams
            };
            this.data.Leagues.Add(newLeague);
            this.data.SaveChanges();
            return newLeague;
        }
        public List<Group> GenerateGroups(LeagueModel model, string userId)
        {
            var groups = model.NumberOfTeams / model.TeamsPerGroup;
            var currentLeague = this.data.Leagues.FirstOrDefault(x => x.Id == model.Id);
            var groupsList = new List<Group>();
            for (int i = 1; i <= groups; i++)
            {
                var newGroup = new Group
                {
                    Name = $"{i}",
                    TeamsCount = model.NumberOfTeams,
                    AppUserId = userId,
                    LeagueId = model.Id
                };

                this.data.Groups.Add(newGroup);
                currentLeague.Groups.Add(newGroup);
                groupsList.Add(newGroup);
            }
            this.data.SaveChanges();
            return groupsList;
        }
        public List<Group> FillTeamsInGroups(LeagueModel model, string userId)
        {
            // var allTeams = model.Participants;
            //
            // foreach (var group in model.Groups)
            // {
            //     for (int i = 0; i < model.TeamsPerGroup; i++)
            //     {
            //         var team = allTeams[rnd.Next(0, allTeams.Count())];
            //
            //         var newTeam = new Participant
            //         {
            //             Name = team,
            //             GroupId = group.Id
            //         };
            //         this.data.Participants.Add(newTeam);
            //         allTeams.Remove(team);
            //     }
            // }
            // this.data.SaveChanges();
            return model.Groups;
        }
        //  public List<Fixture> GetFixtures(LeagueModel model, string userId)
        //  {
        //      var fixtures = new List<Fixture>();
        //      foreach (var group in model.Groups)
        //      {
        //          Shuffle(group.Participants);
        //          var numOfMatches = group.Participants.Count / 2 * (group.Participants.Count - 1);
        //          int numFixt = 0;
        //
        //          while (numFixt < numOfMatches)
        //          {
        //              var match = 1;
        //              for (int i = 0; i < group.Participants.Count() / 2; i += 1)
        //              {
        //                  var ht = group.Participants[i];
        //                  var at = group.Participants[(group.Participants.Count() - 1 - i)];
        //
        //                  var newFixt = new Fixture
        //                  {
        //                      HomeParticipant = ht.,
        //                      AwayParticipant = at.Name,
        //                      AppUserId = userId,
        //                      LeagueId = group.LeagueId,
        //                      GroupId = group.Id
        //                  };
        //
        //                  this.data.Fixtures.Add(newFixt);
        //                  fixtures.Add(newFixt);
        //                  numFixt++;
        //                  match++;
        //              }
        //
        //              for (int i = group.Teams.Count - 1; i > 1; i--)
        //              {
        //                  var temp = group.Teams[i - 1];
        //                  group.Teams[i - 1] = group.Teams[i];
        //                  group.Teams[i] = temp;
        //              }
        //          }
        //      }
        //      this.data.SaveChanges();
        //      return fixtures;
        //  }
        public (string, bool) IsTeamsValid(LeagueModel model)
        {
            var message = "";
            var isValid = true;

            if (model.TeamsPerGroup > model.NumberOfTeams)
            {
                message = "Teams per group cannot be more than number of teams!";
                isValid = false;
            }

            return (message, isValid);
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
        public List<League> GetUsersLeagues(string userId)
        {
            var currentLeagues = this.data.Leagues.Where(x => x.AppUserId == userId).Include(x => x.Participants).ToList();
            return currentLeagues;
        }
        public void DeleteLeague(int id)
        {
            var currentLeague = this.data.Leagues.FirstOrDefault(x => x.Id == id);
            var groups = this.data.Groups.Where(x => x.LeagueId == currentLeague.Id).ToList();
            var fixtures = this.data.Fixtures.Where(x => x.LeagueId == currentLeague.Id).ToList();
            var teams = this.data.Participants.ToList();

            foreach (var group in groups)
            {
                group.Participants.RemoveRange(0, group.Participants.Count());
            }

            this.data.Fixtures.RemoveRange(fixtures);
            this.data.Groups.RemoveRange(groups);
            this.data.Leagues.Remove(currentLeague);
            this.data.SaveChanges();
        }
        public League GetCurrentLeague(int leagueId) => this.data.Leagues.FirstOrDefault(x => x.Id == leagueId);
        public List<Group> GetLeagueGroups(League currentLeague)
        {
            var groups = this.data.Groups.Where(x => x.LeagueId == currentLeague.Id).ToList();

            foreach (var group in groups)
            {
                var teams = this.data.Participants.Where(x => x.GroupId == group.Id).ToList();
            }

            return groups;
        }

        public void GenerateLeague(LeagueModel model, string userId)
        {
            var newLeague = new League
            {
                AppUserId = userId,
                Name = model.LeagueName,
                Participants = model.Participants
            };
            this.data.Leagues.Add(newLeague);

            var groupNum = 0;

            foreach (var group in model.Groups)
            {
                groupNum++;

                var newGroup = new Group
                {
                    AppUserId = userId,
                    LeagueId = newLeague.Id,
                    League = newLeague,
                    Name = groupNum.ToString(),
                    TeamsCount = model.TeamsPerGroup,
                };
                this.data.Groups.Add(group);
            }
            this.data.SaveChanges();
        }
    }
}

