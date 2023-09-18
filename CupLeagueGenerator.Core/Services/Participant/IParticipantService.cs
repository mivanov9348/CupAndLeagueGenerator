namespace CupLeagueGenerator.Core.Services.Participant
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;

    public interface IParticipantService
    {
        void SaveCupParticipants(Cup currentCup,CupModel model, string userId);
    }
}
