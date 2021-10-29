using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BettingTypes",
                columns: table => new
                {
                    strID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    vName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    eName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    vDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BettingTypes", x => x.strID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    FifaAlphaCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.FifaAlphaCode);
                });

            migrationBuilder.CreateTable(
                name: "Federations",
                columns: table => new
                {
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federations", x => x.FName);
                });

            migrationBuilder.CreateTable(
                name: "TeamTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTypes", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FederationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                    table.ForeignKey(
                        name: "FK_Tournaments_Federations_FederationName",
                        column: x => x.FederationName,
                        principalTable: "Federations",
                        principalColumn: "FName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FifaAlphaCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamName);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_FifaAlphaCode",
                        column: x => x.FifaAlphaCode,
                        principalTable: "Countries",
                        principalColumn: "FifaAlphaCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_TeamTypes_TypeName",
                        column: x => x.TypeName,
                        principalTable: "TeamTypes",
                        principalColumn: "TypeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SeasonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TournamentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MatchNumber = table.Column<int>(type: "int", nullable: false),
                    DateMatch = table.Column<DateTime>(type: "date", nullable: false),
                    TimeMatch = table.Column<TimeSpan>(type: "time", nullable: false),
                    MatchYear = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Round = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HTeam = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HGoal = table.Column<int>(type: "int", nullable: true),
                    GGoal = table.Column<int>(type: "int", nullable: true),
                    GTeam = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    WinNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visistors = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_GTeam",
                        column: x => x.GTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HTeam",
                        column: x => x.HTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GTeam",
                table: "Matches",
                column: "GTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HTeam",
                table: "Matches",
                column: "HTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TournamentId",
                table: "Seasons",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_FifaAlphaCode",
                table: "Teams",
                column: "FifaAlphaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TypeName",
                table: "Teams",
                column: "TypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_FederationName",
                table: "Tournaments",
                column: "FederationName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BettingTypes");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "TeamTypes");

            migrationBuilder.DropTable(
                name: "Federations");
        }
    }
}
