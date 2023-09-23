namespace CupLeagueGenerator.Infrastructure.Models
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using System.Collections.Generic;

    public class LeagueViewModel
    {

        public string LeagueName { get; set; }
        public int LeagueId { get; set; }
        public int ParticipantCount { get; set; }
        public int TeamsPerGroup { get; set; }
        public bool IsGroupsDrawed { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Fixture> LeagueFixtures { get; set; } = new List<Fixture>();
        public List<Participant> LeagueParticipants { get; set; } = new List<Participant>();

    }
}
