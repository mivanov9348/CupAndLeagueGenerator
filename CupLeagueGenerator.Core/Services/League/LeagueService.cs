namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks.Dataflow;

    public class LeagueService : ILeagueService
    {
        private Random rnd;
        private readonly CupLeagueDbContext data;
        public LeagueService(CupLeagueDbContext data)
        {
            this.rnd = new Random();
            this.data = data;
        }
        public List<Group> GenerateGroups(League currentLeague, LeagueModel model, string userId)
        {
            var groups = 0;
            if (model.IsOneLeague)
            {
                groups = 1;
            }
            else
            {
                groups = model.NumberOfTeams / model.TeamsPerGroup;
            }
        
            var groupsList = new List<Group>();
            for (int i = 1; i <= groups; i++)
            {
                var newGroup = new Group
                {
                    Name = $"{i}",
                    TeamsCount = model.TeamsPerGroup,
                    AppUserId = userId,
                    LeagueId = model.LeagueId,
                    League = currentLeague
                };

                this.data.Groups.Add(newGroup);
                currentLeague.Groups.Add(newGroup);
                groupsList.Add(newGroup);
            }
            this.data.SaveChanges();
            return groupsList;
        }
     
        public List<League> GetUsersLeagues(string userId)
        {

            if (userId != null)
            {
                return this.data.Leagues.Where(x => x.AppUserId == userId).Include(x => x.Participants).ToList();
            }
            return this.data.Leagues.Include(x => x.Participants).ToList();
        }
        public void DeleteLeague(League currentLeague)
        {
            var groups = this.data.Groups.Where(x => x.LeagueId == currentLeague.Id).ToList();
            var fixtures = this.data.Fixtures.Where(x => x.LeagueId == currentLeague.Id).ToList();
            var participants = this.data.Participants.Where(x => x.LeagueId == currentLeague.Id).ToList();


            this.data.Participants.RemoveRange(participants);
            this.data.Groups.RemoveRange(groups);
            this.data.Leagues.Remove(currentLeague);
            this.data.Fixtures.RemoveRange(fixtures);

            this.data.SaveChanges();
        }
        public League GetCurrentLeague(int leagueId)
        {
            return this.data.Leagues.Include(x => x.Groups).ThenInclude(x => x.Participants).FirstOrDefault(x => x.Id == leagueId);
        }

        public List<Group> GetLeagueGroups(League currentLeague)
        {
            var groups = this.data.Groups.Where(x => x.LeagueId == currentLeague.Id).ToList();

            foreach (var group in groups)
            {
                var teams = this.data.Participants.Where(x => x.GroupId == group.Id).ToList();
            }

            return groups;
        }
        public League GenerateLeague(LeagueModel model, string userId)
        {
            var newLeague = new League
            {
                AppUserId = userId,
                Name = model.LeagueName,
                Participants = model.Participants,
                ParticipantsCount = model.NumberOfTeams
            };
            this.data.Leagues.Add(newLeague);
            this.data.SaveChanges();

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
                newLeague.Groups.Add(group);
            }

            this.data.SaveChanges();
            return newLeague;
        }

        public void DrawGroups(League league)
        {
            var allParticipants = this.data.Participants.Where(x => x.LeagueId == league.Id).ToList();
            var groups = this.data.Groups.Where(x => x.LeagueId == league.Id).ToList();
            var teamsPerGroup = allParticipants.Count() / groups.Count();

            while (allParticipants.Count > 0)
            {
                var participant = allParticipants[rnd.Next(0, allParticipants.Count)];
                var group = GetRandomGroup(groups, teamsPerGroup);

                participant.GroupId = group.Id;               
                group.Participants.Add(participant);
                allParticipants.Remove(participant);
            }
            this.data.SaveChanges();
        }

        private Group GetRandomGroup(List<Group> currentGroups, int teamsPerGroup)
        {
            var group = currentGroups[rnd.Next(0, currentGroups.Count)];

            while (group.Participants.Count >= teamsPerGroup)
            {
                group = currentGroups[rnd.Next(0, currentGroups.Count)];
            }

            return group;
        }

        public void DeleteGroupParticipants(League league)
        {
            var participants = this.data.Participants.Where(x=>x.LeagueId==league.Id).ToList();

            foreach (var participant in participants)
            {
                participant.GroupId = null;
            }
            this.data.SaveChanges();
        }
    }
}

