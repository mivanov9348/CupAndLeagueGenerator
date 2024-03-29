﻿namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParticipantsCount { get; set; }    
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Participant> Participants { get; set; } = new List<Participant>();

    }
}
