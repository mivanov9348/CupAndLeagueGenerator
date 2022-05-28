namespace CupLeagueGenerator.Infrastructure.Models
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using System.ComponentModel.DataAnnotations;
    public class CupModel
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum characters must be 3!")]
        [MaxLength(20, ErrorMessage = "Maximum characters must be 3!")]
        public string CupName { get; set; }
        public int CupParticipants { get; set; }
        public int Matches { get; set; }
        public List<string> Teams { get; set; }
        public List<Cup> UserCups { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }
}
