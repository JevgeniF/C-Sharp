using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameOptions",
                columns: table => new
                {
                    GameOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardSide = table.Column<int>(type: "int", nullable: false),
                    BoatsCount = table.Column<int>(type: "int", nullable: false),
                    EBoatsCanTouch = table.Column<int>(type: "int", nullable: false),
                    ENextMoveAfterHit = table.Column<int>(type: "int", nullable: false),
                    SavedGameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOptions", x => x.GameOptionId);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    GameOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                    table.ForeignKey(
                        name: "FK_Boats_GameOptions_GameOptionId",
                        column: x => x.GameOptionId,
                        principalTable: "GameOptions",
                        principalColumn: "GameOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedGames",
                columns: table => new
                {
                    SavedGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SerializedSavedGameData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameOptionsGameOptionId = table.Column<int>(type: "int", nullable: false),
                    SavedGameName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedGames", x => x.SavedGameId);
                    table.ForeignKey(
                        name: "FK_SavedGames_GameOptions_GameOptionsGameOptionId",
                        column: x => x.GameOptionsGameOptionId,
                        principalTable: "GameOptions",
                        principalColumn: "GameOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boats_GameOptionId",
                table: "Boats",
                column: "GameOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedGames_GameOptionsGameOptionId",
                table: "SavedGames",
                column: "GameOptionsGameOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "SavedGames");

            migrationBuilder.DropTable(
                name: "GameOptions");
        }
    }
}
