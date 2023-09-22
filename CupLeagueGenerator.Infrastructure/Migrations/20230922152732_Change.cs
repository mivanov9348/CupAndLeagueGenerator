using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CupLeagueGenerator.Infrastructure.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamsCount",
                table: "Leagues",
                newName: "ParticipantsCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParticipantsCount",
                table: "Leagues",
                newName: "TeamsCount");
        }
    }
}
