using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogansArchive.Migrations
{
    /// <inheritdoc />
    public partial class AddReleaseDateToGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Directors_directorId1",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Games_gameId1",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_movieId1",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Shows_showId1",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Studios_Studios_studioId1",
                table: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_Studios_studioId1",
                table: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_Shows_showId1",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Movies_movieId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Games_gameId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Directors_directorId1",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "studioId1",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "showId1",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "movieId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "gameId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "directorId1",
                table: "Directors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Games",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "GameStudio",
                columns: table => new
                {
                    GameStudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStudio", x => x.GameStudioId);
                    table.ForeignKey(
                        name: "FK_GameStudio_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameStudio_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "studioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStudio_GameId",
                table: "GameStudio",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStudio_StudioId",
                table: "GameStudio",
                column: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStudio");

            migrationBuilder.AddColumn<int>(
                name: "studioId1",
                table: "Studios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "showId1",
                table: "Shows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "movieId1",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "gameId1",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "directorId1",
                table: "Directors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studios_studioId1",
                table: "Studios",
                column: "studioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_showId1",
                table: "Shows",
                column: "showId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_movieId1",
                table: "Movies",
                column: "movieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_gameId1",
                table: "Games",
                column: "gameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_directorId1",
                table: "Directors",
                column: "directorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Directors_directorId1",
                table: "Directors",
                column: "directorId1",
                principalTable: "Directors",
                principalColumn: "directorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Games_gameId1",
                table: "Games",
                column: "gameId1",
                principalTable: "Games",
                principalColumn: "gameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_movieId1",
                table: "Movies",
                column: "movieId1",
                principalTable: "Movies",
                principalColumn: "movieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Shows_showId1",
                table: "Shows",
                column: "showId1",
                principalTable: "Shows",
                principalColumn: "showId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_Studios_studioId1",
                table: "Studios",
                column: "studioId1",
                principalTable: "Studios",
                principalColumn: "studioId");
        }
    }
}
