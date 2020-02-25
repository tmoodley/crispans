using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedcustomertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Tax = table.Column<string>(nullable: true),
                    TaxPickup = table.Column<string>(nullable: true),
                    TaxShipping = table.Column<string>(nullable: true),
                    DateAvailable = table.Column<DateTime>(nullable: false),
                    DateAvailableUtc = table.Column<DateTime>(nullable: false),
                    DateClosing = table.Column<DateTime>(nullable: false),
                    DateClosingUtc = table.Column<DateTime>(nullable: false),
                    DateClosingSecondary = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Scope = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PickupLocation = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OpeningProcess = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PricePickup = table.Column<decimal>(nullable: false),
                    PriceShipping = table.Column<decimal>(nullable: false),
                    Procedure = table.Column<int>(nullable: false),
                    ShowUnofficial = table.Column<bool>(nullable: false),
                    ShowSubmitted = table.Column<bool>(nullable: false),
                    ShowPlanTakers = table.Column<bool>(nullable: false),
                    ShowTeamMembers = table.Column<bool>(nullable: false),
                    ShowTeamMembersContact = table.Column<bool>(nullable: false),
                    HasReferenceTable = table.Column<bool>(nullable: false),
                    HasSubContractorTable = table.Column<bool>(nullable: false),
                    PreQualSubContractorsOnly = table.Column<bool>(nullable: false),
                    NumReferencesRequired = table.Column<int>(nullable: false),
                    HasSummaryTable = table.Column<bool>(nullable: false),
                    SummaryTableName = table.Column<string>(nullable: true),
                    IsSubTotalOnSummary = table.Column<bool>(nullable: false),
                    SelectedTablesForSummary = table.Column<string>(nullable: true),
                    BidFormsHeadingText = table.Column<string>(nullable: true),
                    TermsAndConditionsHeadingText = table.Column<string>(nullable: true),
                    ReferenceHeadingText = table.Column<string>(nullable: true),
                    SubContractorHeadingText = table.Column<string>(nullable: true),
                    QuestionHeadingText = table.Column<string>(nullable: true),
                    SummaryTableHeadingText = table.Column<string>(nullable: true),
                    SummaryTableFooterText = table.Column<string>(nullable: true),
                    QuestionDeadline = table.Column<DateTime>(nullable: true),
                    IsCloseQuestionsAfterDeadline = table.Column<bool>(nullable: false),
                    IncludeOtherDocument = table.Column<bool>(nullable: false),
                    AllowBidDocumentPreview = table.Column<bool>(nullable: false),
                    BondHeadingText = table.Column<string>(nullable: true),
                    BondTitle = table.Column<string>(nullable: true),
                    BondTitle2 = table.Column<string>(nullable: true),
                    TermsAndConditionsChevronLabel = table.Column<string>(nullable: true),
                    InstructionPageText = table.Column<string>(nullable: true),
                    ProvideInstructionsPage = table.Column<bool>(nullable: false),
                    EstimatedValue = table.Column<string>(nullable: true),
                    TotalContractAmount = table.Column<decimal>(nullable: true),
                    ShowPurchasingRepsOnPublic = table.Column<bool>(nullable: false),
                    AllowFullBidDetailsUrl = table.Column<bool>(nullable: false),
                    AllowMultipleSubmissions = table.Column<bool>(nullable: false),
                    ShowOnWebsite = table.Column<bool>(nullable: false),
                    Evaluations = table.Column<bool>(nullable: false),
                    BidNotApproved = table.Column<bool>(nullable: false),
                    DateAwarded = table.Column<DateTime>(nullable: true),
                    LeadAgency = table.Column<bool>(nullable: false),
                    ParticipatingAgencies = table.Column<string>(nullable: true),
                    NumberOfAgencies = table.Column<int>(nullable: true),
                    EstimatedAnnualValue = table.Column<string>(nullable: true),
                    ActualContractValue = table.Column<string>(nullable: true),
                    ActualAnnualValue = table.Column<string>(nullable: true),
                    PostCloseBidException = table.Column<bool>(nullable: true),
                    UnsealManually = table.Column<bool>(nullable: true),
                    PlannedIssueDate = table.Column<DateTime>(nullable: true),
                    IsAttendanceTrackingOn = table.Column<bool>(nullable: false),
                    IsCloseRegistrationAfterMeetingDate = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => new { x.JobId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_JobCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCategory_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCertification",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    CertificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCertification", x => new { x.JobId, x.CertificationId });
                    table.ForeignKey(
                        name: "FK_JobCertification_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCertification_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCompanyType",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    CompanyTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCompanyType", x => new { x.JobId, x.CompanyTypeId });
                    table.ForeignKey(
                        name: "FK_JobCompanyType_CompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCompanyType_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobFileType",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    FileTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFileType", x => new { x.JobId, x.FileTypeId });
                    table.ForeignKey(
                        name: "FK_JobFileType_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobFileType_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobIndustry",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    IndustryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobIndustry", x => new { x.JobId, x.IndustryId });
                    table.ForeignKey(
                        name: "FK_JobIndustry_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobIndustry_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobMachine",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    MachineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMachine", x => new { x.JobId, x.MachineId });
                    table.ForeignKey(
                        name: "FK_JobMachine_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobMaterial",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMaterial", x => new { x.JobId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_JobMaterial_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_CategoryId",
                table: "JobCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCertification_CertificationId",
                table: "JobCertification",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCompanyType_CompanyTypeId",
                table: "JobCompanyType",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFileType_FileTypeId",
                table: "JobFileType",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobIndustry_IndustryId",
                table: "JobIndustry",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobMachine_MachineId",
                table: "JobMachine",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_JobMaterial_MaterialId",
                table: "JobMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "JobCertification");

            migrationBuilder.DropTable(
                name: "JobCompanyType");

            migrationBuilder.DropTable(
                name: "JobFileType");

            migrationBuilder.DropTable(
                name: "JobIndustry");

            migrationBuilder.DropTable(
                name: "JobMachine");

            migrationBuilder.DropTable(
                name: "JobMaterial");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
