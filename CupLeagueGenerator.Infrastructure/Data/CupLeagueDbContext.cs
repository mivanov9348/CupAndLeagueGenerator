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
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Draw> Draws { get; set; }

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

                fixt.HasOne(x => x.HomeParticipant)
                    .WithMany(x => x.HomeFixtures)
                    .HasForeignKey(x => x.HomeParticipantId)
                    .OnDelete(DeleteBehavior.Restrict);

                fixt.HasOne(x => x.AwayParticipant)
                    .WithMany(x => x.AwayFixtures)
                    .HasForeignKey(x => x.AwayParticipantId)
                    .OnDelete(DeleteBehavior.Restrict);
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

                group.HasOne(x => x.Draw)
                     .WithMany(x => x.Groups)
                     .HasForeignKey(x => x.DrawId);

                group.HasMany(x => x.Fixtures)
                     .WithOne(x => x.Group);

                group.HasMany(x => x.Participants)
                     .WithOne(x => x.Group);

            });

            builder.Entity<Cup>(cup =>
            {
                cup.HasKey(x => x.Id);

                cup.HasOne<ApplicationUser>()
                   .WithMany(x => x.Cups)
                   .HasForeignKey(x => x.AppUserId);

                cup.HasMany(x => x.Fixtures)
                   .WithOne(x => x.Cup);

                cup.HasMany(x => x.Participants)
                   .WithOne(x => x.Cup);

            });

            builder.Entity<League>(league =>
            {
                league.HasKey(x => x.Id);

                league.HasMany(x => x.Fixtures)
                      .WithOne(x => x.League);

                league.HasMany(x => x.Groups)
                      .WithOne(x => x.League);

                league.HasMany(x => x.Participants)
                      .WithOne(x => x.League);

                league.HasOne<ApplicationUser>()
                      .WithMany(x => x.Leagues)
                      .HasForeignKey(x => x.AppUserId);

            });

            builder.Entity<Draw>(draw =>
            {
                draw.HasKey(x => x.Id);

                draw.HasOne<ApplicationUser>()
                     .WithMany(x => x.Draws)
                     .HasForeignKey(x => x.AppUserId);

                draw.HasMany(x => x.Groups)
                      .WithOne(x => x.Draw);

                draw.HasMany(x => x.Participants)
                      .WithOne(x => x.Draw);



            });

            builder.Entity<Participant>(part =>
            {
                part.HasKey(x => x.Id);

                part.HasOne<ApplicationUser>()
                     .WithMany(x => x.Participants)
                     .HasForeignKey(x => x.AppUserId);

                part.HasOne(x => x.Draw)
                     .WithMany(x => x.Participants)
                     .HasForeignKey(x => x.DrawId);

                part.HasOne(x => x.Cup)
                     .WithMany(x => x.Participants)
                     .HasForeignKey(x => x.CupId);

                part.HasOne(x => x.League)
                     .WithMany(x => x.Participants)
                     .HasForeignKey(x => x.LeagueId);

                part.HasOne(x => x.Group)
                     .WithMany(x => x.Participants)
                     .HasForeignKey(x => x.GroupId);

                part.HasMany(x => x.HomeFixtures)
                    .WithOne(c => c.HomeParticipant)
                    .OnDelete(DeleteBehavior.Restrict);

                part.HasMany(x => x.AwayFixtures)
                    .WithOne(c => c.AwayParticipant)
                    .OnDelete(DeleteBehavior.Restrict);

            });



            base.OnModelCreating(builder);
        }
    }
}