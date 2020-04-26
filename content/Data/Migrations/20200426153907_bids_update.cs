using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class bids_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "POBidLineItems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "POBidLineItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "POBidLineItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "POBidBidderId",
                table: "POBidLineItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "POBidPurchaseOrderId",
                table: "POBidLineItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "POBidLineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_POBidLineItems_POBidPurchaseOrderId_POBidBidderId",
                table: "POBidLineItems",
                columns: new[] { "POBidPurchaseOrderId", "POBidBidderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_POBidLineItems_POBids_POBidPurchaseOrderId_POBidBidderId",
                table: "POBidLineItems",
                columns: new[] { "POBidPurchaseOrderId", "POBidBidderId" },
                principalTable: "POBids",
                principalColumns: new[] { "PurchaseOrderId", "BidderId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POBidLineItems_POBids_POBidPurchaseOrderId_POBidBidderId",
                table: "POBidLineItems");

            migrationBuilder.DropIndex(
                name: "IX_POBidLineItems_POBidPurchaseOrderId_POBidBidderId",
                table: "POBidLineItems");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "POBidLineItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "POBidLineItems");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "POBidLineItems");

            migrationBuilder.DropColumn(
                name: "POBidBidderId",
                table: "POBidLineItems");

            migrationBuilder.DropColumn(
                name: "POBidPurchaseOrderId",
                table: "POBidLineItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "POBidLineItems");
        }
    }
}
