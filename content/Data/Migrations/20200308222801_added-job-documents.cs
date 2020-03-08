using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedjobdocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CadFileDocumentId",
                table: "Jobs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractDocumentId",
                table: "Jobs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NdaDocumentId",
                table: "Jobs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TermsDocumentId",
                table: "Jobs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isNda",
                table: "Jobs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadFileDocumentId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ContractDocumentId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "NdaDocumentId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TermsDocumentId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "isNda",
                table: "Jobs");
        }
    }
}
