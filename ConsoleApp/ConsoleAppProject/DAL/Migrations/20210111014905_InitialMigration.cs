using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameOptions",
                columns: table => new
                {
                    GameOptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardSide = table.Column<int>(type: "int", nullable: false),
                    BoatsCount = table.Column<int>(type: "int", nullable: false),
                    EBoatsCanTouch = table.Column<int>(type: "int", nullable: false),
                    ENextMoveAfterHit = table.Column<int>(type: "int", nullable: false),
                    SavedGameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOptions", x => x.GameOptionsId);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    GameOptionId = table.Column<int>(type: "int", nullable: false),
                    GameOptionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                    table.ForeignKey(
                        name: "FK_Boats_GameOptions_GameOptionsId",
                        column: x => x.GameOptionsId,
                        principalTable: "GameOptions",
                        principalColumn: "GameOptionsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedGames",
                columns: table => new
                {
                    SavedGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SerializedSavedGameData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameOptionsId = table.Column<int>(type: "int", nullable: false),
                    SavedGameName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedGames", x => x.SavedGameId);
                    table.ForeignKey(
                        name: "FK_SavedGames_GameOptions_GameOptionsId",
                        column: x => x.GameOptionsId,
                        principalTable: "GameOptions",
                        principalColumn: "GameOptionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boats_GameOptionsId",
                table: "Boats",
                column: "GameOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedGames_GameOptionsId",
                table: "SavedGames",
                column: "GameOptionsId");
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
