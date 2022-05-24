namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    public class Fixture
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public string HomeTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public string AwayTeam { get; set; }
        public int AwayTeamGoals { get; set; }
        public string Winner { get; set; }
    }
}
