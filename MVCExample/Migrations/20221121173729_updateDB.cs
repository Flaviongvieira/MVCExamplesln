using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCExample.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchID",
                table: "Matches",
                newName: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Matches",
                newName: "MatchID");
        }
    }
}
