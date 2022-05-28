namespace CupLeagueGenerator.Infrastructure.Models
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    public class SavesModel
    {
        public List<Cup> Cups { get; set; } = new List<Cup>();
        public List<League> Leagues { get; set; } = new List<League>();

    }
}
