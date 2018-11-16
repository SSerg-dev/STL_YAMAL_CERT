using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocumentNaks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "p_Person",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "p_DocumentNaks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_Person_ID",
                table: "p_DocumentNaks",
                column: "Person_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_Person_Person_ID",
                table: "p_DocumentNaks",
                column: "Person_ID",
                principalTable: "p_Person",
                principalColumn: "Person_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_Person_Person_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaks_Person_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "p_DocumentNaks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "p_Person",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
