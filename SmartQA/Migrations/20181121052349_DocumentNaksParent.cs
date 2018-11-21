using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocumentNaksParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentDocumentNaks_ID",
                table: "p_DocumentNaks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_ParentDocumentNaks_ID",
                table: "p_DocumentNaks",
                column: "ParentDocumentNaks_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_DocumentNaks_ParentDocumentNaks_ID",
                table: "p_DocumentNaks",
                column: "ParentDocumentNaks_ID",
                principalTable: "p_DocumentNaks",
                principalColumn: "DocumentNaks_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_DocumentNaks_ParentDocumentNaks_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaks_ParentDocumentNaks_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropColumn(
                name: "ParentDocumentNaks_ID",
                table: "p_DocumentNaks");
        }
    }
}
