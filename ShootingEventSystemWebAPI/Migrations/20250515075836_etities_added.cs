using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShootingEventSystemWebAPI.Migrations
{
    public partial class etities_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArbiterTournament_Arbiter_ArbitersId",
                table: "ArbiterTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Clubs_ClubId",
                table: "Competitor");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Users_UserId",
                table: "Competitor");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitorTournament_Competitor_CompetitorsId",
                table: "CompetitorTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Arbiter_ArbiterId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Competitor_CompetitorId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_AddressId",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitor",
                table: "Competitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arbiter",
                table: "Arbiter");

            migrationBuilder.RenameTable(
                name: "Competitor",
                newName: "Competitors");

            migrationBuilder.RenameTable(
                name: "Arbiter",
                newName: "Arbiters");

            migrationBuilder.RenameIndex(
                name: "IX_Competitor_UserId",
                table: "Competitors",
                newName: "IX_Competitors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitor_ClubId",
                table: "Competitors",
                newName: "IX_Competitors_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitors",
                table: "Competitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arbiters",
                table: "Arbiters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AddressId",
                table: "Clubs",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArbiterTournament_Arbiters_ArbitersId",
                table: "ArbiterTournament",
                column: "ArbitersId",
                principalTable: "Arbiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Clubs_ClubId",
                table: "Competitors",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Users_UserId",
                table: "Competitors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitorTournament_Competitors_CompetitorsId",
                table: "CompetitorTournament",
                column: "CompetitorsId",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Arbiters_ArbiterId",
                table: "Results",
                column: "ArbiterId",
                principalTable: "Arbiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Competitors_CompetitorId",
                table: "Results",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArbiterTournament_Arbiters_ArbitersId",
                table: "ArbiterTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Clubs_ClubId",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Users_UserId",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitorTournament_Competitors_CompetitorsId",
                table: "CompetitorTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Arbiters_ArbiterId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Competitors_CompetitorId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_AddressId",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitors",
                table: "Competitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arbiters",
                table: "Arbiters");

            migrationBuilder.RenameTable(
                name: "Competitors",
                newName: "Competitor");

            migrationBuilder.RenameTable(
                name: "Arbiters",
                newName: "Arbiter");

            migrationBuilder.RenameIndex(
                name: "IX_Competitors_UserId",
                table: "Competitor",
                newName: "IX_Competitor_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitors_ClubId",
                table: "Competitor",
                newName: "IX_Competitor_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitor",
                table: "Competitor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arbiter",
                table: "Arbiter",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AddressId",
                table: "Clubs",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArbiterTournament_Arbiter_ArbitersId",
                table: "ArbiterTournament",
                column: "ArbitersId",
                principalTable: "Arbiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Clubs_ClubId",
                table: "Competitor",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Users_UserId",
                table: "Competitor",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitorTournament_Competitor_CompetitorsId",
                table: "CompetitorTournament",
                column: "CompetitorsId",
                principalTable: "Competitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Arbiter_ArbiterId",
                table: "Results",
                column: "ArbiterId",
                principalTable: "Arbiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Competitor_CompetitorId",
                table: "Results",
                column: "CompetitorId",
                principalTable: "Competitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
