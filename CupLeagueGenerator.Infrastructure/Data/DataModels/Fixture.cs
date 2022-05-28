namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    public class Fixture
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public string HomeTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public string AwayTeam { get; set; }
        public int AwayTeamGoals { get; set; }
        public string Winner { get; set; }
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }
        public Group Group { get; set; }
        public int? GroupId { get; set; }    
        public int? CupId { get; set; }
        public Cup Cup { get; set; }
        public int? LeagueId { get; set; }
        public League League { get; set; }
    }
}
