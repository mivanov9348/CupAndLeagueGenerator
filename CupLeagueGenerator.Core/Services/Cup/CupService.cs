namespace CupLeagueGenerator.Core.Services.Cup
{
    using CupLeagueGenerator.Data;
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using CupLeagueGenerator.Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Text.RegularExpressions;

    public class CupService : ICupService
    {
        private Random rnd;
        private readonly CupLeagueDbContext data;
        public CupService(CupLeagueDbContext data)
        {
            this.data = data;
            rnd = new Random();
        }



        private int GetRoundsToFinal(int teams)
        {
            switch (teams)
            {
                case 4: return 2;
                case 8: return 3;
                case 16: return 4;
                case 32: return 5;
                case 64: return 6;
                default: return 0;
            }
        }

        public List<Cup> GetUserCups(string userId)
        {
            if (userId != null)
            {
                return this.data.Cups.Where(x => x.AppUserId == userId).Include(x => x.Participants).ToList();
            }
            return this.data.Cups.Include(x => x.Participants).ToList();
        }

        public Cup GetCurrentCup(int id)
        {
            return this.data.Cups.Include(x => x.Participants)
                                 .Include(x => x.Fixtures)
                                 .FirstOrDefault(x => x.Id == id);
        }

        public List<Fixture> GetCupFixtures(Cup currentCup)
        {
            return this.data.Fixtures.Where(x => x.CupId == currentCup.Id).ToList();
        }

        public void DeleteCup(int id)
        {
            var currentCup = this.data.Cups.FirstOrDefault(x => x.Id == id);
            var fixtures = this.data.Fixtures.Where(x => x.CupId == currentCup.Id).ToList();
            var participants = this.data.Participants.Where(x => x.CupId == currentCup.Id).ToList();
            this.data.Participants.RemoveRange(participants);
            this.data.Fixtures.RemoveRange(fixtures);
            this.data.Cups.Remove(currentCup);
            this.data.SaveChanges();
        }

        public Cup SaveCup(CupModel model, string userId)
        {
            var newCup = new Cup
            {
                Name = model.CupName,
                Participants = model.Participants,
                AppUserId = userId
            };
            this.data.Cups.Add(newCup);
            this.data.SaveChanges();
            return newCup;
        }
    }
}
