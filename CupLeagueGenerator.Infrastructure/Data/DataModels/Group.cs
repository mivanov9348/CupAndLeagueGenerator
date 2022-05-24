namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{   
    using System.Collections.Generic;    
    public class Group
    {
        public string Name { get; set; }
        public int TeamsCount { get; set; }
        public List<string> Teams { get; set; } = new List<string>();
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
    }
}
