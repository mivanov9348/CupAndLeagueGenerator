namespace CupLeagueGenerator.Infrastructure.Models
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    public class LeagueModel
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public int NumberOfTeams { get; set; }
        public int TeamsPerGroup { get; set; }
        public List<string> InputParticipants { get; set; } = new List<string> { };
        public List<Participant> Participants { get; set; } = new List<Participant> { };
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
        public List<League> Leagues { get; set; } = new List<League>();
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
