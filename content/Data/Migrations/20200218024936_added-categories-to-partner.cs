using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addedcategoriestopartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PartnerId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PartnerId",
                table: "Categories",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Partners_PartnerId",
                table: "Categories",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Partners_PartnerId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PartnerId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Categories");
        }
    }
}
