using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CupLeagueGenerator.Infrastructure.Migrations
{
    public partial class changenulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Cups_CupId",
                table: "Fixtures");

            migrationBuilder.AlterColumn<int>(
                name: "CupId",
                table: "Fixtures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Cups_CupId",
                table: "Fixtures",
                column: "CupId",
                principalTable: "Cups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Cups_CupId",
                table: "Fixtures");

            migrationBuilder.AlterColumn<int>(
                name: "CupId",
                table: "Fixtures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Cups_CupId",
                table: "Fixtures",
                column: "CupId",
                principalTable: "Cups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
