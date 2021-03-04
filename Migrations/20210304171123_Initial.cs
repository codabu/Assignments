using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignments.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "wo", "Winter Olympics" },
                    { "so", "Summer Olympics" },
                    { "p", "Paralympics" },
                    { "yo", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportID", "Name" },
                values: new object[,]
                {
                    { "curl", "Curling/Indoor" },
                    { "bobs", "Bobsleigh/Outdoor" },
                    { "dive", "Diving/Indoor" },
                    { "cycl", "Road Cycling/Outdoor" },
                    { "arch", "Archery/Indoor" },
                    { "cano", "Canoe Sprint/Outdoor" },
                    { "brea", "Breakdancing/Indoor" },
                    { "skat", "Skateboarding/Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "GameID", "LogoImage", "Name", "SportID" },
                values: new object[,]
                {
                    { "can", "wo", "canada.png", "Canada", "curl" },
                    { "fin", "yo", "finland.png", "Finland", "skat" },
                    { "rus", "yo", "russia.png", "Russia", "brea" },
                    { "fra", "yo", "france.png", "France", "brea" },
                    { "cyp", "yo", "cyprus.png", "Cyprus", "brea" },
                    { "zim", "p", "zimbabwe.png", "Zimbabwe", "cano" },
                    { "pak", "p", "pakistan.png", "Pakistan", "cano" },
                    { "aus", "p", "austria.png", "Austria", "cano" },
                    { "uru", "p", "uruguay.png", "Uruguay", "arch" },
                    { "ukr", "p", "ukraine.png", "Ukraine", "arch" },
                    { "tha", "p", "thailand.png", "Thailand", "arch" },
                    { "usa", "so", "usa.png", "U.S.A", "cycl" },
                    { "net", "so", "netherlands.png", "Netherlands", "cycl" },
                    { "bra", "so", "brazil.png", "Brazil", "cycl" },
                    { "mex", "so", "mexico.png", "Mexico", "dive" },
                    { "ger", "so", "germany.png", "Germany", "dive" },
                    { "chi", "so", "china.png", "China", "dive" },
                    { "jap", "wo", "japan.png", "Japan", "bobs" },
                    { "jam", "wo", "jamaica.png", "Jamaica", "bobs" },
                    { "ita", "wo", "italy.png", "Italy", "bobs" },
                    { "uni", "wo", "unitedkingdom.png", "United Kingdom", "curl" },
                    { "swe", "wo", "sweden.png", "Sweden", "curl" },
                    { "por", "yo", "portugal.png", "Portugal", "skat" },
                    { "slo", "yo", "slovakia.png", "Slovakia", "skat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportID",
                table: "Countries",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
