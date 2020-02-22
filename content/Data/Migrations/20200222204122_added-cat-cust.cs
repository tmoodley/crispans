using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedcatcust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capabilities_Customers_CustomerId",
                table: "Capabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Customers_CustomerId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Customers_CustomerId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTypes_Customers_CustomerId",
                table: "CompanyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_FileTypes_Customers_CustomerId",
                table: "FileTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Industries_Customers_CustomerId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Customers_CustomerId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Customers_CustomerId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Naics_Customers_CustomerId",
                table: "Naics");

            migrationBuilder.DropIndex(
                name: "IX_Naics_CustomerId",
                table: "Naics");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CustomerId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Machines_CustomerId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Industries_CustomerId",
                table: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_FileTypes_CustomerId",
                table: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_CompanyTypes_CustomerId",
                table: "CompanyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_CustomerId",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CustomerId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Capabilities_CustomerId",
                table: "Capabilities");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Naics");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "FileTypes");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CompanyTypes");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Capabilities");

            migrationBuilder.CreateTable(
                name: "CustomerCategory",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategory", x => new { x.CustomerId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CustomerCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCategory_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCategory_CategoryId",
                table: "CustomerCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCategory");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Naics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Industries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "FileTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "CompanyTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Certifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Capabilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Naics_CustomerId",
                table: "Naics",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CustomerId",
                table: "Materials",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_CustomerId",
                table: "Machines",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_CustomerId",
                table: "Industries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_CustomerId",
                table: "FileTypes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTypes_CustomerId",
                table: "CompanyTypes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_CustomerId",
                table: "Certifications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CustomerId",
                table: "Categories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_CustomerId",
                table: "Capabilities",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capabilities_Customers_CustomerId",
                table: "Capabilities",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Customers_CustomerId",
                table: "Categories",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Customers_CustomerId",
                table: "Certifications",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTypes_Customers_CustomerId",
                table: "CompanyTypes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileTypes_Customers_CustomerId",
                table: "FileTypes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_Customers_CustomerId",
                table: "Industries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Customers_CustomerId",
                table: "Machines",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Customers_CustomerId",
                table: "Materials",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Naics_Customers_CustomerId",
                table: "Naics",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
