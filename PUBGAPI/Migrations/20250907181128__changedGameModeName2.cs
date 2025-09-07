using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class _changedGameModeName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "solo");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "duo");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "squad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "solo-tpp");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "duo-tpp");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "squad-tpp");
        }
    }
}
