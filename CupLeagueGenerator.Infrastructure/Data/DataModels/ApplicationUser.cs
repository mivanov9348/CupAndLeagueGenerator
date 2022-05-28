namespace CupLeagueGenerator.Infrastructure.Data.DataModels
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Cup> Cups { get; set; } = new List<Cup>();
        public List<League> Leagues { get; set; } = new List<League>();
    }
}
