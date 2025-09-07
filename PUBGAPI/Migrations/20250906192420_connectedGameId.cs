using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class connectedGameId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedGame_GameAccount_AccountId",
                table: "ConnectedGame");

            migrationBuilder.DropIndex(
                name: "IX_ConnectedGame_AccountId",
                table: "ConnectedGame");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "ConnectedGame");

            migrationBuilder.AddColumn<int>(
                name: "ConnectedGameId",
                table: "GameAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameAccount_ConnectedGameId",
                table: "GameAccount",
                column: "ConnectedGameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameAccount_ConnectedGame_ConnectedGameId",
                table: "GameAccount",
                column: "ConnectedGameId",
                principalTable: "ConnectedGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameAccount_ConnectedGame_ConnectedGameId",
                table: "GameAccount");

            migrationBuilder.DropIndex(
                name: "IX_GameAccount_ConnectedGameId",
                table: "GameAccount");

            migrationBuilder.DropColumn(
                name: "ConnectedGameId",
                table: "GameAccount");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "ConnectedGame",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedGame_AccountId",
                table: "ConnectedGame",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedGame_GameAccount_AccountId",
                table: "ConnectedGame",
                column: "AccountId",
                principalTable: "GameAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
