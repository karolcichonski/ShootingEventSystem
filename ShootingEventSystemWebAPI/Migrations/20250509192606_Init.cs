using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShootingEventSystemWebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arbiter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbiter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxScore = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    MaxCompetitorsCount = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsSignUpOpen = table.Column<bool>(type: "bit", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArbiterTournament",
                columns: table => new
                {
                    ArbitersId = table.Column<int>(type: "int", nullable: false),
                    TournamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbiterTournament", x => new { x.ArbitersId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_ArbiterTournament_Arbiter_ArbitersId",
                        column: x => x.ArbitersId,
                        principalTable: "Arbiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbiterTournament_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitor_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitorTournament",
                columns: table => new
                {
                    CompetitorsId = table.Column<int>(type: "int", nullable: false),
                    TournamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitorTournament", x => new { x.CompetitorsId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_CompetitorTournament_Competitor_CompetitorsId",
                        column: x => x.CompetitorsId,
                        principalTable: "Competitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitorTournament_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitorId = table.Column<int>(type: "int", nullable: false),
                    ArbiterId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    IsDisqualified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Arbiter_ArbiterId",
                        column: x => x.ArbiterId,
                        principalTable: "Arbiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Competitor_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArbiterTournament_TournamentsId",
                table: "ArbiterTournament",
                column: "TournamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AddressId",
                table: "Clubs",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_ClubId",
                table: "Competitor",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_UserId",
                table: "Competitor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitorTournament_TournamentsId",
                table: "CompetitorTournament",
                column: "TournamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ArbiterId",
                table: "Results",
                column: "ArbiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CompetitorId",
                table: "Results",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TournamentId",
                table: "Results",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_CompetitionId",
                table: "Tournaments",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClubId",
                table: "Users",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArbiterTournament");

            migrationBuilder.DropTable(
                name: "CompetitorTournament");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Arbiter");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
