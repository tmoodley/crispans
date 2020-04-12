using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedupdatedguid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId1",
                table: "PurchaseOrderItem");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId1",
                table: "PurchaseOrderItem");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId1",
                table: "PurchaseOrderItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseOrderId",
                table: "PurchaseOrderItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseOrderItem");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId",
                table: "PurchaseOrderItem");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseOrderId",
                table: "PurchaseOrderItem",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseOrderId1",
                table: "PurchaseOrderItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId1",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId1",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId1",
                principalTable: "PurchaseOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
