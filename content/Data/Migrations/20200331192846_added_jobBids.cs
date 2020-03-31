using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class added_jobBids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobQuestions",
                table: "JobQuestions");

            migrationBuilder.AddColumn<Guid>(
                name: "BidderId",
                table: "JobQuestions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobQuestions",
                table: "JobQuestions",
                columns: new[] { "JobId", "QuestionId", "BidderId" });

            migrationBuilder.CreateTable(
                name: "JobBids",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    BidderId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBids", x => new { x.JobId, x.BidderId });
                    table.ForeignKey(
                        name: "FK_JobBids_Bidders_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobBids_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobQuestions_BidderId",
                table: "JobQuestions",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobBids_BidderId",
                table: "JobBids",
                column: "BidderId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobQuestions_Bidders_BidderId",
                table: "JobQuestions",
                column: "BidderId",
                principalTable: "Bidders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobQuestions_Bidders_BidderId",
                table: "JobQuestions");

            migrationBuilder.DropTable(
                name: "JobBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobQuestions",
                table: "JobQuestions");

            migrationBuilder.DropIndex(
                name: "IX_JobQuestions_BidderId",
                table: "JobQuestions");

            migrationBuilder.DropColumn(
                name: "BidderId",
                table: "JobQuestions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobQuestions",
                table: "JobQuestions",
                columns: new[] { "JobId", "QuestionId" });
        }
    }
}
