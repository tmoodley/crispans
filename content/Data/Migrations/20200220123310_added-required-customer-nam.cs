using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedrequiredcustomernam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
