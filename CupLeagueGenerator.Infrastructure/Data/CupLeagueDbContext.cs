namespace CupLeagueGenerator.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class CupLeagueDbContext : IdentityDbContext
    {
        public CupLeagueDbContext(DbContextOptions<CupLeagueDbContext> options)
            : base(options)
        {

        }
    }
}