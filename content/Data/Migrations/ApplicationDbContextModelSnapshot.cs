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

                    b.Property<string>("CompanyName");

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

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Vue2Spa.Models.Naics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Vue2Spa.Models.Category", b =>
                {
                    b.HasOne("Vue2Spa.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
