using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class updatedjobcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Mpn",
            //    table: "Products",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductBOM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Line = table.Column<int>(nullable: false),
                    BOMQty = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    BOMType = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBOM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBOM_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBOM_ProductId",
                table: "ProductBOM",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBOM");

            migrationBuilder.DropColumn(
                name: "Mpn",
                table: "Products");
        }
    }
}
