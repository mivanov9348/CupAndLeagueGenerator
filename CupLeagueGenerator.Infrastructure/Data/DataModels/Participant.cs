namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public int? CupId { get; set; }
        public Cup Cup { get; set; }
        public int? LeagueId { get; set; }
        public League League { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public int? DrawId { get; set; }
        public Draw Draw { get; set; }
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<Fixture> HomeFixtures{ get; set; } = new HashSet<Fixture>();
        public virtual ICollection<Fixture> AwayFixtures { get; set; } = new HashSet<Fixture>();

    }
}
