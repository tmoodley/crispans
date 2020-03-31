using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedclassificaton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Type",
            //    table: "Jobs",
            //    nullable: true);

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
                name: "PartnerCompanyType");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Jobs");
        }
    }
}
