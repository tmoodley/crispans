using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedjobnaicscapabilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCapability",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    CapabilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCapability", x => new { x.JobId, x.CapabilityId });
                    table.ForeignKey(
                        name: "FK_JobCapability_Capabilities_CapabilityId",
                        column: x => x.CapabilityId,
                        principalTable: "Capabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCapability_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobNaics",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    NaicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobNaics", x => new { x.JobId, x.NaicsId });
                    table.ForeignKey(
                        name: "FK_JobNaics_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobNaics_Naics_NaicsId",
                        column: x => x.NaicsId,
                        principalTable: "Naics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCapability_CapabilityId",
                table: "JobCapability",
                column: "CapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobNaics_NaicsId",
                table: "JobNaics",
                column: "NaicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCapability");

            migrationBuilder.DropTable(
                name: "JobNaics");
        }
    }
}
