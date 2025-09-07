using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class _updPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageDealt",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DeathType",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Kills",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TimeSurvived",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WinPlace",
                table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DamageDealt",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DeathType",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Kills",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TimeSurvived",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WinPlace",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
