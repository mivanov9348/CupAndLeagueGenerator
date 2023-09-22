namespace CupLeagueGenerator.Core.Services.Participant
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;

    public interface IParticipantService
    {
        void SaveLeagueParticipants(League currentLeague, string userId);
        void SaveCupParticipants(Cup currentCup,CupModel model, string userId);
    }
}
