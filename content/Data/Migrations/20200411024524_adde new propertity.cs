using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addenewpropertity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PurchaseOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PurchaseOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "PurchaseOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "PurchaseOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "PurchaseOrder",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "PurchaseOrder");
        }
    }
}
