using CupLeagueGenerator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupLeagueGenerator.Core.Services.League
{
    public class LeagueService : ILeagueServices
    {
        public LeagueService()
        {
        }

        
        public (string, bool) IsTeamsValid(LeagueModel model)
        {
            var message = "";
            var isValid = true;

            if (model.TeamsPerGroup > model.NumberOfTeams)
            {
                message = "Teams per group cannot be more than number of teams!";
                isValid = false;
            }

            return (message, isValid);
        }
    }
}
