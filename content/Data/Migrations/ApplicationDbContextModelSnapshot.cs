﻿// <auto-generated />
using System;
using HelpingHands.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpingHands.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelpingHands.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("HelpingHands.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("CellPhone");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FamilyName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("GivenName")
                        .IsRequired();

                    b.Property<string>("Nickname");

                    b.Property<string>("Note");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<string>("PartnerId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode")
                        .IsRequired();

                    b.Property<string>("PrimarySourceMemberId");

                    b.Property<string>("ReferenceId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("SubscriptionPlan")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username");

                    b.Property<string>("WorkPhone");

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HelpingHands.Models.Dependent", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("CustomerId");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FamilyName")
                        .IsRequired();

                    b.Property<string>("GivenName")
                        .IsRequired();

                    b.Property<string>("Nickname");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("HelpingHands.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("SubscriptionPlan");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HelpingHands.Models.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("CellPhone");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FamilyName");

                    b.Property<string>("GivenName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Nickname");

                    b.Property<string>("Note");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<string>("OrganizationName");

                    b.Property<string>("PartnerId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ReferenceId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("State");

                    b.Property<string>("SubscriptionPlan");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username");

                    b.Property<string>("WorkPhone");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.Job", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualAnnualValue");

                    b.Property<string>("ActualContractValue");

                    b.Property<bool>("AllowBidDocumentPreview");

                    b.Property<bool>("AllowFullBidDetailsUrl");

                    b.Property<bool>("AllowMultipleSubmissions");

                    b.Property<string>("BidFormsHeadingText");

                    b.Property<bool>("BidNotApproved");

                    b.Property<string>("BondHeadingText");

                    b.Property<string>("BondTitle");

                    b.Property<string>("BondTitle2");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("DateAvailable");

                    b.Property<DateTime>("DateAvailableUtc");

                    b.Property<DateTime?>("DateAwarded");

                    b.Property<DateTime>("DateClosing");

                    b.Property<DateTime?>("DateClosingSecondary");

                    b.Property<DateTime>("DateClosingUtc");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("EstimatedAnnualValue");

                    b.Property<string>("EstimatedValue");

                    b.Property<bool>("Evaluations");

                    b.Property<bool>("HasReferenceTable");

                    b.Property<bool>("HasSubContractorTable");

                    b.Property<bool>("HasSummaryTable");

                    b.Property<bool>("IncludeOtherDocument");

                    b.Property<string>("InstructionPageText");

                    b.Property<bool>("IsAttendanceTrackingOn");

                    b.Property<bool>("IsCloseQuestionsAfterDeadline");

                    b.Property<bool>("IsCloseRegistrationAfterMeetingDate");

                    b.Property<bool>("IsSubTotalOnSummary");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<bool>("LeadAgency");

                    b.Property<string>("Name");

                    b.Property<int>("NumReferencesRequired");

                    b.Property<string>("Number");

                    b.Property<int?>("NumberOfAgencies");

                    b.Property<string>("OpeningProcess");

                    b.Property<string>("ParticipatingAgencies");

                    b.Property<string>("PickupLocation");

                    b.Property<DateTime?>("PlannedIssueDate");

                    b.Property<bool?>("PostCloseBidException");

                    b.Property<bool>("PreQualSubContractorsOnly");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("PricePickup");

                    b.Property<decimal>("PriceShipping");

                    b.Property<int>("Procedure");

                    b.Property<bool>("ProvideInstructionsPage");

                    b.Property<DateTime?>("QuestionDeadline");

                    b.Property<string>("QuestionHeadingText");

                    b.Property<string>("ReferenceHeadingText");

                    b.Property<string>("Scope");

                    b.Property<string>("SelectedTablesForSummary");

                    b.Property<bool>("ShowOnWebsite");

                    b.Property<bool>("ShowPlanTakers");

                    b.Property<bool>("ShowPurchasingRepsOnPublic");

                    b.Property<bool>("ShowSubmitted");

                    b.Property<bool>("ShowTeamMembers");

                    b.Property<bool>("ShowTeamMembersContact");

                    b.Property<bool>("ShowUnofficial");

                    b.Property<string>("Status");

                    b.Property<string>("SubContractorHeadingText");

                    b.Property<string>("Summary");

                    b.Property<string>("SummaryTableFooterText");

                    b.Property<string>("SummaryTableHeadingText");

                    b.Property<string>("SummaryTableName");

                    b.Property<string>("Tax");

                    b.Property<string>("TaxPickup");

                    b.Property<string>("TaxShipping");

                    b.Property<string>("TermsAndConditionsChevronLabel");

                    b.Property<string>("TermsAndConditionsHeadingText");

                    b.Property<decimal?>("TotalContractAmount");

                    b.Property<bool?>("UnsealManually");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobCategory", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("JobId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("JobCategory");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobCertification", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("CertificationId");

                    b.HasKey("JobId", "CertificationId");

                    b.HasIndex("CertificationId");

                    b.ToTable("JobCertification");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobCompanyType", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("CompanyTypeId");

                    b.HasKey("JobId", "CompanyTypeId");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("JobCompanyType");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobFileType", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("FileTypeId");

                    b.HasKey("JobId", "FileTypeId");

                    b.HasIndex("FileTypeId");

                    b.ToTable("JobFileType");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobIndustry", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("IndustryId");

                    b.HasKey("JobId", "IndustryId");

                    b.HasIndex("IndustryId");

                    b.ToTable("JobIndustry");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobMachine", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("MachineId");

                    b.HasKey("JobId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("JobMachine");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobMaterial", b =>
                {
                    b.Property<string>("JobId");

                    b.Property<Guid>("MaterialId");

                    b.HasKey("JobId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("JobMaterial");
                });

            modelBuilder.Entity("Vue2Spa.Models.Capability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Capabilities");
                });

            modelBuilder.Entity("Vue2Spa.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vue2Spa.Models.Certification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("Vue2Spa.Models.CompanyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyTypes");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCapability", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("CapabilityId");

                    b.HasKey("CustomerId", "CapabilityId");

                    b.HasIndex("CapabilityId");

                    b.ToTable("CustomerCapability");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCategory", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("CustomerId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CustomerCategory");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCertification", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("CertificationId");

                    b.HasKey("CustomerId", "CertificationId");

                    b.HasIndex("CertificationId");

                    b.ToTable("CustomerCertification");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCompanyType", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("CompanyTypeId");

                    b.HasKey("CustomerId", "CompanyTypeId");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("CustomerCompanyType");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerFileType", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("FileTypeId");

                    b.HasKey("CustomerId", "FileTypeId");

                    b.HasIndex("FileTypeId");

                    b.ToTable("CustomerFileType");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerIndustry", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("IndustryId");

                    b.HasKey("CustomerId", "IndustryId");

                    b.HasIndex("IndustryId");

                    b.ToTable("CustomerIndustry");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerMachine", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("MachineId");

                    b.HasKey("CustomerId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("CustomerMachine");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerMaterial", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("MaterialId");

                    b.HasKey("CustomerId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("CustomerMaterial");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerNaics", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<Guid>("NaicsId");

                    b.HasKey("CustomerId", "NaicsId");

                    b.HasIndex("NaicsId");

                    b.ToTable("CustomerNaics");
                });

            modelBuilder.Entity("Vue2Spa.Models.FileType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("Vue2Spa.Models.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("Vue2Spa.Models.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Vue2Spa.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Vue2Spa.Models.Naics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Naics");
                });

            modelBuilder.Entity("HelpingHands.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ReferenceId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("HelpingHands.Models.Dependent", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("HelpingHands.Models.Invoice", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customers")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.Job", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customers")
                        .WithMany("Jobs")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobCategory", b =>
                {
                    b.HasOne("Vue2Spa.Models.Category", "Category")
                        .WithMany("JobCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobCategories")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobCertification", b =>
                {
                    b.HasOne("Vue2Spa.Models.Certification", "Certification")
                        .WithMany("JobCertifications")
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobCertifications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobCompanyType", b =>
                {
                    b.HasOne("Vue2Spa.Models.CompanyType", "CompanyType")
                        .WithMany("JobCompanyTypes")
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobCompanyTypes")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobFileType", b =>
                {
                    b.HasOne("Vue2Spa.Models.FileType", "FileType")
                        .WithMany("JobFileTypes")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobFileTypes")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobIndustry", b =>
                {
                    b.HasOne("Vue2Spa.Models.Industry", "Industry")
                        .WithMany("JobIndustries")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobIndustries")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobMachine", b =>
                {
                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobMachines")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.Machine", "Machine")
                        .WithMany("JobMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Areas.Portal.Models.JobMaterial", b =>
                {
                    b.HasOne("Vue2Spa.Areas.Portal.Models.Job", "Job")
                        .WithMany("JobMaterials")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.Material", "Material")
                        .WithMany("JobMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.Category", b =>
                {
                    b.HasOne("Vue2Spa.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCapability", b =>
                {
                    b.HasOne("Vue2Spa.Models.Capability", "Capability")
                        .WithMany("CustomerCapabilities")
                        .HasForeignKey("CapabilityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerCapabilities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCategory", b =>
                {
                    b.HasOne("Vue2Spa.Models.Category", "Category")
                        .WithMany("CustomerCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerCategories")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCertification", b =>
                {
                    b.HasOne("Vue2Spa.Models.Certification", "Certification")
                        .WithMany("CustomerCertifications")
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerCertifications")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerCompanyType", b =>
                {
                    b.HasOne("Vue2Spa.Models.CompanyType", "CompanyType")
                        .WithMany("CustomerCompanyTypes")
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerCompanyTypes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerFileType", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerFileTypes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.FileType", "FileType")
                        .WithMany("CustomerFileTypes")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerIndustry", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerIndustries")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.Industry", "Industry")
                        .WithMany("CustomerIndustries")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerMachine", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerMachines")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.Machine", "Machine")
                        .WithMany("CustomerMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerMaterial", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerMaterials")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.Material", "Material")
                        .WithMany("CustomerMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.CustomerNaics", b =>
                {
                    b.HasOne("HelpingHands.Models.Customer", "Customer")
                        .WithMany("CustomerNaics")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vue2Spa.Models.Naics", "Naics")
                        .WithMany("CustomerNaics")
                        .HasForeignKey("NaicsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vue2Spa.Models.Material", b =>
                {
                    b.HasOne("Vue2Spa.Models.Material", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Vue2Spa.Models.Naics", b =>
                {
                    b.HasOne("Vue2Spa.Models.Naics", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
