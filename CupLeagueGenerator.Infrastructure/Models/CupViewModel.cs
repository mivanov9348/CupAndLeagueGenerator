namespace CupLeagueGenerator.Infrastructure.Models
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using System.Collections.Generic;
   
    public class CupViewModel
    {

        public string CupName { get; set; }
        public int CupId { get; set; }
        public int CupRounds { get; set; }
        public bool IsFixtureGenerated { get; set; }
        public List<Fixture> CupFixtures { get; set; }
        public List<Participant> CupParticipants { get; set; }

    }
}
