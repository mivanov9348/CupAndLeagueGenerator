namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
   
    using System.Collections.Generic;   
    public class Cup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamsCount { get; set; }
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
