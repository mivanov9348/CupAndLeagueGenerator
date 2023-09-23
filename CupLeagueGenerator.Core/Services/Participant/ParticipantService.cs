namespace CupLeagueGenerator.Core.Services.Participant
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Threading.Tasks;

    public class ParticipantService : IParticipantService
    {
        private readonly CupLeagueDbContext data;
        public ParticipantService(CupLeagueDbContext data)
        {
            this.data = data;
        }

        public void DeleteCurrentCupParticipants(Cup currentCup)
        {
            var currentParticipants = this.data.Participants.Where(x=>x.CupId== currentCup.Id).ToList();
            this.data.Participants.RemoveRange(currentParticipants);
            this.data.SaveChanges();
        }

        public void DeleteCurrentLeagueParticipants(League currentLeague)
        {
            var currentParticipants = this.data.Participants.Where(x => x.LeagueId == currentLeague.Id).ToList();
            this.data.Participants.RemoveRange(currentParticipants);
            this.data.SaveChanges();
        }

        public List<Participant> GetLeagueParticipants(int leagueId)
        {
            return this.data.Participants.Where(x => x.LeagueId == leagueId).ToList();
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

        public void SaveLeagueParticipants(League currentLeague,LeagueModel model, string userId)
        {
            foreach (var participant in model.InputParticipants)
            {
                var newParticipant = new Participant
                {
                    Name = participant,
                    LeagueId = currentLeague.Id,
                    AppUserId = userId,
                    League = currentLeague,                    
                };
                this.data.Participants.Add(newParticipant);
                currentLeague.Participants.Add(newParticipant);
            }                   
         
          this.data.SaveChanges();
        }
    }
}
