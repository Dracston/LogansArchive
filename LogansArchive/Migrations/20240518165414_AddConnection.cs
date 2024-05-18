using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogansArchive.Migrations
{
    /// <inheritdoc />
    public partial class AddConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStudio");

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameId = table.Column<int>(type: "int", nullable: false),
                    studioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connections_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connections_Studios_studioId",
                        column: x => x.studioId,
                        principalTable: "Studios",
                        principalColumn: "studioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_gameId",
                table: "Connections",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_studioId",
                table: "Connections",
                column: "studioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

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
    }
}
