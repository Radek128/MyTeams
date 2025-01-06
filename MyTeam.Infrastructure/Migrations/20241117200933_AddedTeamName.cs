using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTeam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeamName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teams");
        }
    }
}
