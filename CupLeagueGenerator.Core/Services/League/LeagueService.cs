namespace CupLeagueGenerator.Core.Services.League
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    public class LeagueService : ILeagueServices
    {
        private Random rnd;
        public LeagueService()
        {
            this.rnd = new Random();
        }

        public List<Group> FillTeamsInGroups(LeagueModel model)
        {
            var allTeams = model.Teams;
            foreach (var item in model.Groups)
            {
                for (int i = 0; i < model.TeamsPerGroup; i++)
                {
                    var team = allTeams[rnd.Next(0, allTeams.Count())];
                    item.Teams.Add(team);
                    allTeams.Remove(team);
                }
            }

            return model.Groups;
        }

        public List<Group> GenerateGroups(LeagueModel model)
        {
            var groups = model.NumberOfTeams / model.TeamsPerGroup;
            var groupsList = new List<Group>();
            for (int i = 1; i <= groups; i++)
            {
                var newGroup = new Group
                {
                    Name = $"{i}",
                    TeamsCount = model.NumberOfTeams
                };
                groupsList.Add(newGroup);
            }

            return groupsList;
        }

        public List<Fixture> GetFixtures(LeagueModel model)
        {
            foreach (var group in model.Groups)
            {
                Shuffle(group.Teams);
                var numOfMatches = group.Teams.Count / 2 * (group.Teams.Count - 1);
                int numFixt = 0;

                while (numFixt < numOfMatches)
                {
                    var match = 1;
                    for (int i = 0; i < group.Teams.Count() / 2; i += 1)
                    {
                        var ht = group.Teams[i];
                        var at = group.Teams[(group.Teams.Count() - 1 - i)];

                        var newFixt = new Fixture
                        {
                            HomeTeam = ht,
                            AwayTeam = at
                        };
                        
                        group.Fixtures.Add(newFixt);
                        model.Fixtures.Add(newFixt);
                        numFixt++;
                        match++;
                    }

                    for (int i = group.Teams.Count - 1; i > 1; i--)
                    {
                        var temp = group.Teams[i - 1];
                        group.Teams[i - 1] = group.Teams[i];
                        group.Teams[i] = temp;
                    }
                }
            }
            return model.Fixtures;
        }

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
        private void Shuffle(List<string> currl)
        {
            Random rnd = new Random();
            int n = currl.Count;

            for (int i = n - 1; i > 1; i--)
            {
                int random = rnd.Next(i + 1);

                var value = currl[random];
                currl[random] = currl[i];
                currl[i] = value;
            }
        }


    }
}

