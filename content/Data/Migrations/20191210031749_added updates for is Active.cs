using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedupdatesforisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Customers");
        }
    }
}
