using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class _changedGameModeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "solo-fpp");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "duo-fpp");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "squad-fpp");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Solo FPP");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Duo FPP");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Squad FPP");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Solo");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Duo");

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Squad");
        }
    }
}
