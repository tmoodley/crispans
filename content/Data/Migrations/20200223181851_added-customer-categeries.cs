using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedcustomercategeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCapability",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    CapabilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCapability", x => new { x.CustomerId, x.CapabilityId });
                    table.ForeignKey(
                        name: "FK_CustomerCapability_Capabilities_CapabilityId",
                        column: x => x.CapabilityId,
                        principalTable: "Capabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCapability_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCertification",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    CertificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCertification", x => new { x.CustomerId, x.CertificationId });
                    table.ForeignKey(
                        name: "FK_CustomerCertification_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCertification_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCompanyType",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    CompanyTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCompanyType", x => new { x.CustomerId, x.CompanyTypeId });
                    table.ForeignKey(
                        name: "FK_CustomerCompanyType_CompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCompanyType_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFileType",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    FileTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFileType", x => new { x.CustomerId, x.FileTypeId });
                    table.ForeignKey(
                        name: "FK_CustomerFileType_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFileType_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerIndustry",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    IndustryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerIndustry", x => new { x.CustomerId, x.IndustryId });
                    table.ForeignKey(
                        name: "FK_CustomerIndustry_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerIndustry_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMachine",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    MachineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMachine", x => new { x.CustomerId, x.MachineId });
                    table.ForeignKey(
                        name: "FK_CustomerMachine_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaterial",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaterial", x => new { x.CustomerId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_CustomerMaterial_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNaics",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    NaicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNaics", x => new { x.CustomerId, x.NaicsId });
                    table.ForeignKey(
                        name: "FK_CustomerNaics_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerNaics_Naics_NaicsId",
                        column: x => x.NaicsId,
                        principalTable: "Naics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCapability_CapabilityId",
                table: "CustomerCapability",
                column: "CapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCertification_CertificationId",
                table: "CustomerCertification",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCompanyType_CompanyTypeId",
                table: "CustomerCompanyType",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFileType_FileTypeId",
                table: "CustomerFileType",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIndustry_IndustryId",
                table: "CustomerIndustry",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMachine_MachineId",
                table: "CustomerMachine",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMaterial_MaterialId",
                table: "CustomerMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNaics_NaicsId",
                table: "CustomerNaics",
                column: "NaicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCapability");

            migrationBuilder.DropTable(
                name: "CustomerCertification");

            migrationBuilder.DropTable(
                name: "CustomerCompanyType");

            migrationBuilder.DropTable(
                name: "CustomerFileType");

            migrationBuilder.DropTable(
                name: "CustomerIndustry");

            migrationBuilder.DropTable(
                name: "CustomerMachine");

            migrationBuilder.DropTable(
                name: "CustomerMaterial");

            migrationBuilder.DropTable(
                name: "CustomerNaics");
        }
    }
}
