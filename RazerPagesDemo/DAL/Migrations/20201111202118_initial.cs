using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GpsSessions",
                columns: table => new
                {
                    GpsSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionLength = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpsSessions", x => x.GpsSessionId);
                });

            migrationBuilder.CreateTable(
                name: "GpsLocations",
                columns: table => new
                {
                    GpsLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GpsSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpsLocations", x => x.GpsLocationId);
                    table.ForeignKey(
                        name: "FK_GpsLocations_GpsSessions_GpsSessionId",
                        column: x => x.GpsSessionId,
                        principalTable: "GpsSessions",
                        principalColumn: "GpsSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GpsLocations_GpsSessionId",
                table: "GpsLocations",
                column: "GpsSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GpsLocations");

            migrationBuilder.DropTable(
                name: "GpsSessions");
        }
    }
}
