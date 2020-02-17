using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHands.Data.Migrations
{
    public partial class addparenttonaics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Naics",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NaicsId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Naics_ParentId",
                table: "Naics",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ParentId",
                table: "Materials",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MaterialId",
                table: "Categories",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NaicsId",
                table: "Categories",
                column: "NaicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Materials_MaterialId",
                table: "Categories",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Naics_NaicsId",
                table: "Categories",
                column: "NaicsId",
                principalTable: "Naics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Categories_ParentId",
                table: "Materials",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Naics_Categories_ParentId",
                table: "Naics",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Materials_MaterialId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Naics_NaicsId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Categories_ParentId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Naics_Categories_ParentId",
                table: "Naics");

            migrationBuilder.DropIndex(
                name: "IX_Naics_ParentId",
                table: "Naics");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ParentId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MaterialId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NaicsId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Naics");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NaicsId",
                table: "Categories");
        }
    }
}
