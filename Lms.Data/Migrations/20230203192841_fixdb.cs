using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_TournamentId",
                table: "Game",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Tournament_TournamentId",
                table: "Game",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Tournament_TournamentId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_TournamentId",
                table: "Game");
        }
    }
}
