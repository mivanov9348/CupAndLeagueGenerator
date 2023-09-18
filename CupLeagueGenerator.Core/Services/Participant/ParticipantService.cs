namespace CupLeagueGenerator.Core.Services.Participant
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ParticipantService : IParticipantService
    {
        private readonly CupLeagueDbContext data;
        public ParticipantService(CupLeagueDbContext data)
        {
            this.data = data;
        }      
        public void SaveCupParticipants(Cup currentCup, CupModel model, string userId)
        {
            foreach (var participant in model.InputParticipants)
            {
                var newParticipant = new Participant
                {
                    Name = participant,
                    Cup = currentCup,
                    CupId = currentCup.Id,
                    AppUserId = userId
                };
                this.data.Participants.Add(newParticipant);
            }
            this.data.SaveChanges();
        }
    }
}
