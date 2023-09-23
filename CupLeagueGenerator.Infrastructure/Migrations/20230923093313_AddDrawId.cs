using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CupLeagueGenerator.Infrastructure.Migrations
{
    public partial class AddDrawId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Draws_DrawId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "DrawId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Draws_DrawId",
                table: "Groups",
                column: "DrawId",
                principalTable: "Draws",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Draws_DrawId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "DrawId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Draws_DrawId",
                table: "Groups",
                column: "DrawId",
                principalTable: "Draws",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
