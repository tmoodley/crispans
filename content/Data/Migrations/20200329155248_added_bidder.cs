using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class added_bidder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    TermsOfService = table.Column<string>(nullable: true),
                    LegalCompanyName = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    TaxRegistrationHST = table.Column<string>(nullable: true),
                    TaxRegistrationGST = table.Column<string>(nullable: true),
                    TaxRegistrationFEIN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerCompanyType",
                columns: table => new
                {
                    PartnerId = table.Column<Guid>(nullable: false),
                    CompanyTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerCompanyType", x => new { x.PartnerId, x.CompanyTypeId });
                    table.ForeignKey(
                        name: "FK_PartnerCompanyType_CompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerCompanyType_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerCompanyType_CompanyTypeId",
                table: "PartnerCompanyType",
                column: "CompanyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bidders");

            migrationBuilder.DropTable(
                name: "PartnerCompanyType");
        }
    }
}
