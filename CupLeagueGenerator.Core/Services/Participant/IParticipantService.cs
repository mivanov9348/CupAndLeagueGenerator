namespace CupLeagueGenerator.Core.Services.Participant
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;

    public interface IParticipantService
    {
        void SaveLeagueParticipants(League currentLeague, LeagueModel model, string userId);
        void SaveCupParticipants(Cup currentCup, CupModel model, string userId);
        void DeleteCurrentCupParticipants(Cup currentCup);
        void DeleteCurrentLeagueParticipants(League currentLeague);
        List<Participant> GetLeagueParticipants(int leagueId);
    }
}
