using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedpartnercontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PartnerId = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    SubscriptionPlan = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    GivenName = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ReferenceId = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
