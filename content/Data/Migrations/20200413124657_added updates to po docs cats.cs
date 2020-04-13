using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedupdatestopodocscats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CadFileDocumentId",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractDocumentId",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NdaDocumentId",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TermsDocumentId",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isNda",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PurchaseOrderCategory",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderCategory", x => new { x.PurchaseOrderId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderCategory_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderCategory_CategoryId",
                table: "PurchaseOrderCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderCategory");

            migrationBuilder.DropColumn(
                name: "CadFileDocumentId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "ContractDocumentId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "NdaDocumentId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "TermsDocumentId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "isNda",
                table: "PurchaseOrder");
        }
    }
}
