namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    public class Fixture
    {
        public int Id { get; set; }     
        public int Round { get; set; }
        public string CompetitionName { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int? HomeParticipantId { get; set; }
        public int? AwayParticipantId { get; set; }
        public int? LeagueId { get; set; }
        public League League { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public int? CupId { get; set; }
        public Cup Cup { get; set; }          
        public virtual Participant HomeParticipant { get; set; }
        public virtual Participant AwayParticipant { get; set; }
        public int HomeParticipantScore { get; set; }
        public int AwayParticipantScore { get; set; }
        public bool IsPlayed { get; set; }
        public int? WinnerTeamId { get; set; }
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
