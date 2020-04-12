using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addednewpopertity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "PurchaseOrder",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "PurchaseOrder",
                newName: "Total");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "PurchaseOrder");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "PurchaseOrder",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "PurchaseOrder",
                newName: "PaymentDate");
        }
    }
}
