using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CupLeagueGenerator.Infrastructure.Migrations
{
    public partial class AddTeamsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamsCount",
                table: "Leagues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamsCount",
                table: "Cups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamsCount",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "TeamsCount",
                table: "Cups");
        }
    }
}
