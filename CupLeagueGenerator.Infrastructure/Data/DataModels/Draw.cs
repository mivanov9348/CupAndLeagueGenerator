namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Draw
    {
        public int Id { get; set; }
        public int TeamsCount { get; set; }
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public List<Group> Groups { get; set; } = new List<Group>();


    }
}
