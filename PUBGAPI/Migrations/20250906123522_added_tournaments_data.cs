using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class added_tournaments_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Third-person duo", "Duo" });

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Third-person squad (4 players)", "Squad" });

            migrationBuilder.InsertData(
                table: "GameMode",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "GameId", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Third-person solo", 1, false, "Solo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "GameModeId", "IsDeleted", "Name", "Players", "PrizePool", "Ticket", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, "Rambo", 5, 12m, 3.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, "Ice", 7, 20m, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Third-person solo", "Solo" });

            migrationBuilder.UpdateData(
                table: "GameMode",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Third-person duo", "Duo" });

            migrationBuilder.InsertData(
                table: "GameMode",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "GameId", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Third-person squad (4 players)", 1, false, "Squad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
