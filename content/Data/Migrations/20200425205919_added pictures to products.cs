using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedpicturestoproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Picture1Id",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Picture2Id",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Picture3Id",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Picture4Id",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractDocumentId",
                table: "JobBids",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NdaDocumentId",
                table: "JobBids",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TermsDocumentId",
                table: "JobBids",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture1Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture2Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture3Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture4Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContractDocumentId",
                table: "JobBids");

            migrationBuilder.DropColumn(
                name: "NdaDocumentId",
                table: "JobBids");

            migrationBuilder.DropColumn(
                name: "TermsDocumentId",
                table: "JobBids");
        }
    }
}
