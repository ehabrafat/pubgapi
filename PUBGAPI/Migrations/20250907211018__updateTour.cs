using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class _updateTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameModeId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameModeId",
                value: 1);
        }
    }
}
