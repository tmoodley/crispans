using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class update_tobidders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Bidders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Bidders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkPhone",
                table: "Bidders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Bidders");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Bidders");

            migrationBuilder.DropColumn(
                name: "WorkPhone",
                table: "Bidders");
        }
    }
}
