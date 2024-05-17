using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogansArchive.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    directorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    directorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.directorId);
                    table.ForeignKey(
                        name: "FK_Directors_Directors_directorId1",
                        column: x => x.directorId1,
                        principalTable: "Directors",
                        principalColumn: "directorId");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    gameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Console = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gameId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.gameId);
                    table.ForeignKey(
                        name: "FK_Games_Games_gameId1",
                        column: x => x.gameId1,
                        principalTable: "Games",
                        principalColumn: "gameId");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    movieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.movieId);
                    table.ForeignKey(
                        name: "FK_Movies_Movies_movieId1",
                        column: x => x.movieId1,
                        principalTable: "Movies",
                        principalColumn: "movieId");
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    showId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstDateAired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastDateAired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    episodeCount = table.Column<int>(type: "int", nullable: false),
                    showId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.showId);
                    table.ForeignKey(
                        name: "FK_Shows_Shows_showId1",
                        column: x => x.showId1,
                        principalTable: "Shows",
                        principalColumn: "showId");
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    studioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yearEstablished = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studioId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.studioId);
                    table.ForeignKey(
                        name: "FK_Studios_Studios_studioId1",
                        column: x => x.studioId1,
                        principalTable: "Studios",
                        principalColumn: "studioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_directorId1",
                table: "Directors",
                column: "directorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_gameId1",
                table: "Games",
                column: "gameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_movieId1",
                table: "Movies",
                column: "movieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_showId1",
                table: "Shows",
                column: "showId1");

            migrationBuilder.CreateIndex(
                name: "IX_Studios_studioId1",
                table: "Studios",
                column: "studioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
