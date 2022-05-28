namespace CupLeagueGenerator.Data
{
    using CupLeagueGenerator.Infrastructure.Data.DataModels;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class CupLeagueDbContext : IdentityDbContext
    {
        public CupLeagueDbContext(DbContextOptions<CupLeagueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Cup> Cups { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Fixture>(fixt =>
            {
                fixt.HasKey(x => x.Id);

                fixt.HasOne<ApplicationUser>()
                    .WithMany(x => x.Fixtures)
                    .HasForeignKey(x => x.AppUserId);

                fixt.HasOne(x => x.Cup)
                    .WithMany(x => x.Fixtures)
                    .HasForeignKey(x => x.CupId);

                fixt.HasOne(x => x.Group)
                    .WithMany(x => x.Fixtures)
                    .HasForeignKey(x => x.GroupId);

                fixt.HasOne(x => x.League)
                    .WithMany(x => x.Fixtures)
                    .HasForeignKey(x => x.LeagueId);
            });

            builder.Entity<Group>(group =>
            {
                group.HasKey(x => x.Id);

                group.HasOne<ApplicationUser>()
                    .WithMany(x => x.Groups)
                    .HasForeignKey(x => x.AppUserId);

                group.HasOne(x => x.League)
                     .WithMany(x => x.Groups)
                     .HasForeignKey(x => x.LeagueId);

                group.HasMany(x => x.Fixtures)
                     .WithOne(x => x.Group);
                              

            });

            builder.Entity<Cup>(cup =>
            {
                cup.HasKey(x => x.Id);

                cup.HasMany(x => x.Fixtures)
                   .WithOne(x => x.Cup);

                cup.HasOne<ApplicationUser>()
                   .WithMany(x => x.Cups)
                   .HasForeignKey(x => x.AppUserId);
            });

            builder.Entity<League>(league =>
            {
                league.HasKey(x => x.Id);

                league.HasMany(x => x.Fixtures)
                      .WithOne(x => x.League);

                league.HasMany(x => x.Groups)
                      .WithOne(x => x.League);

                league.HasOne<ApplicationUser>()
                      .WithMany(x => x.Leagues)
                      .HasForeignKey(x => x.AppUserId);

            });

            builder.Entity<Team>(team =>
            {
                team.HasKey(x => x.Id);              
            });



            base.OnModelCreating(builder);
        }
    }
}