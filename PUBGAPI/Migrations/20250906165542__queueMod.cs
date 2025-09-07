using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUBGAPI.Migrations
{
    /// <inheritdoc />
    public partial class _queueMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastId",
                table: "WorkerQueueProgress",
                newName: "LastQueueId");

            migrationBuilder.AddColumn<int>(
                name: "LastMatchId",
                table: "WorkerQueueProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMatchId",
                table: "WorkerQueueProgress");

            migrationBuilder.RenameColumn(
                name: "LastQueueId",
                table: "WorkerQueueProgress",
                newName: "LastId");
        }
    }
}
