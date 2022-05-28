namespace CupLeagueGenerator.Infrastructure.Models
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    public class LeagueModel
    {
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public int NumberOfTeams { get; set; }
        public int TeamsPerGroup { get; set; }
        public List<string> Teams { get; set; } 
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
