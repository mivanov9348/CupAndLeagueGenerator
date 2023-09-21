﻿// <auto-generated />
using System;
using CupLeagueGenerator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CupLeagueGenerator.Infrastructure.Migrations
{
    [DbContext(typeof(CupLeagueDbContext))]
    [Migration("20230920083150_AddRoundsToCup")]
    partial class AddRoundsToCup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Cup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.Property<int>("TeamsCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Cups");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TeamsCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Draws");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Fixture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AwayParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("AwayParticipantScore")
                        .HasColumnType("int");

                    b.Property<string>("AwayTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompetitionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CupId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("HomeParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("HomeParticipantScore")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WinnerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AwayParticipantId");

                    b.HasIndex("CupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("HomeParticipantId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("UserId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DrawId")
                        .HasColumnType("int");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamsCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("DrawId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("UserId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamsCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CupId")
                        .HasColumnType("int");

                    b.Property<int?>("DrawId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CupId");

                    b.HasIndex("DrawId");

                    b.HasIndex("GroupId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Cup", b =>
                {
                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", null)
                        .WithMany("Cups")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Draw", b =>
                {
                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", null)
                        .WithMany("Draws")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Fixture", b =>
                {
                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", null)
                        .WithMany("Fixtures")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Participant", "AwayParticipant")
                        .WithMany("AwayFixtures")
                        .HasForeignKey("AwayParticipantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Cup", "Cup")
                        .WithMany("Fixtures")
                        .HasForeignKey("CupId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Group", "Group")
                        .WithMany("Fixtures")
                        .HasForeignKey("GroupId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Participant", "HomeParticipant")
                        .WithMany("HomeFixtures")
                        .HasForeignKey("HomeParticipantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.League", "League")
                        .WithMany("Fixtures")
                        .HasForeignKey("LeagueId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AwayParticipant");

                    b.Navigation("Cup");

                    b.Navigation("Group");

                    b.Navigation("HomeParticipant");

                    b.Navigation("League");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Group", b =>
                {
                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", null)
                        .WithMany("Groups")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Draw", "Draw")
                        .WithMany("Groups")
                        .HasForeignKey("DrawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.League", "League")
                        .WithMany("Groups")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Draw");

                    b.Navigation("League");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.League", b =>
                {
                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", null)
                        .WithMany("Leagues")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Participant", b =>
                {
                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", null)
                        .WithMany("Participants")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Cup", "Cup")
                        .WithMany("Participants")
                        .HasForeignKey("CupId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Draw", "Draw")
                        .WithMany("Participants")
                        .HasForeignKey("DrawId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.League", "League")
                        .WithMany("Participants")
                        .HasForeignKey("LeagueId");

                    b.HasOne("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Cup");

                    b.Navigation("Draw");

                    b.Navigation("Group");

                    b.Navigation("League");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Cup", b =>
                {
                    b.Navigation("Fixtures");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Draw", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Group", b =>
                {
                    b.Navigation("Fixtures");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.League", b =>
                {
                    b.Navigation("Fixtures");

                    b.Navigation("Groups");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.Participant", b =>
                {
                    b.Navigation("AwayFixtures");

                    b.Navigation("HomeFixtures");
                });

            modelBuilder.Entity("CupLeagueGenerator.Infrastructure.Data.DataModels.ApplicationUser", b =>
                {
                    b.Navigation("Cups");

                    b.Navigation("Draws");

                    b.Navigation("Fixtures");

                    b.Navigation("Groups");

                    b.Navigation("Leagues");

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
