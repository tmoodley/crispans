using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class purchase_order_bids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POBidLineItems",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<string>(nullable: false),
                    BidderId = table.Column<Guid>(nullable: false),
                    PurchaseOrderItemId = table.Column<Guid>(nullable: false),
                    PurchaseOrderId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POBidLineItems", x => new { x.PurchaseOrderId, x.BidderId, x.PurchaseOrderItemId });
                    table.ForeignKey(
                        name: "FK_POBidLineItems_Bidders_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POBidLineItems_PurchaseOrder_PurchaseOrderId1",
                        column: x => x.PurchaseOrderId1,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POBidLineItems_PurchaseOrderItem_PurchaseOrderItemId",
                        column: x => x.PurchaseOrderItemId,
                        principalTable: "PurchaseOrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "POBids",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(nullable: false),
                    BidderId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    TermsDocumentId = table.Column<Guid>(nullable: false),
                    ContractDocumentId = table.Column<Guid>(nullable: false),
                    NdaDocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POBids", x => new { x.PurchaseOrderId, x.BidderId });
                    table.ForeignKey(
                        name: "FK_POBids_Bidders_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POBids_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_POBidLineItems_BidderId",
                table: "POBidLineItems",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_POBidLineItems_PurchaseOrderId1",
                table: "POBidLineItems",
                column: "PurchaseOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_POBidLineItems_PurchaseOrderItemId",
                table: "POBidLineItems",
                column: "PurchaseOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_POBids_BidderId",
                table: "POBids",
                column: "BidderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POBidLineItems");

            migrationBuilder.DropTable(
                name: "POBids");
        }
    }
}
