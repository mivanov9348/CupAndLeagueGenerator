namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{   
    using System.Collections.Generic;    
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamsCount { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
    }
}
