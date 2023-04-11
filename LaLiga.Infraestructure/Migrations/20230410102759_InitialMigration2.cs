using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaLiga.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "color",
                table: "teams",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "teams",
                newName: "TeamsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "matches",
                newName: "MatchesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "teams",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "TeamsId",
                table: "teams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MatchesId",
                table: "matches",
                newName: "Id");
        }
    }
}
