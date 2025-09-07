using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class _applyChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameAccount_ConnectedGame_ConnectedGameId",
                table: "GameAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Users_UserId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "TournamentQueues");

            migrationBuilder.DropTable(
                name: "WorkerQueueProgress");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Players",
                newName: "GameAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_UserId",
                table: "Players",
                newName: "IX_Players_GameAccountId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "Matches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameAccount_ConnectedGame_ConnectedGameId",
                table: "GameAccount",
                column: "ConnectedGameId",
                principalTable: "ConnectedGame",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_GameAccount_GameAccountId",
                table: "Players",
                column: "GameAccountId",
                principalTable: "GameAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameAccount_ConnectedGame_ConnectedGameId",
                table: "GameAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_GameAccount_GameAccountId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "GameAccountId",
                table: "Players",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_GameAccountId",
                table: "Players",
                newName: "IX_Players_UserId");

            migrationBuilder.CreateTable(
                name: "TournamentQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentQueues_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentQueues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerQueueProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastQueueId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerQueueProgress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentQueues_TournamentId",
                table: "TournamentQueues",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentQueues_UserId",
                table: "TournamentQueues",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameAccount_ConnectedGame_ConnectedGameId",
                table: "GameAccount",
                column: "ConnectedGameId",
                principalTable: "ConnectedGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Users_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
