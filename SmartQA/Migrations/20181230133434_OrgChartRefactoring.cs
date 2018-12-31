using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class OrgChartRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_Division_p_Contragent_Contragent_ID",
                table: "p_Division");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Position_p_Division_Division_ID",
                table: "p_Position");

            migrationBuilder.DropIndex(
                name: "IX_p_Position_Division_ID",
                table: "p_Position");

            migrationBuilder.DropIndex(
                name: "IX_p_Division_Contragent_ID",
                table: "p_Division");

            migrationBuilder.DropColumn(
                name: "Description_Eng",
                table: "p_Position");

            migrationBuilder.DropColumn(
                name: "Division_ID",
                table: "p_Position");

            migrationBuilder.DropColumn(
                name: "Contragent_ID",
                table: "p_Division");

            migrationBuilder.RenameColumn(
                name: "Division_Name",
                table: "p_Division",
                newName: "Description_Rus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description_Rus",
                table: "p_Division",
                newName: "Division_Name");

            migrationBuilder.AddColumn<string>(
                name: "Description_Eng",
                table: "p_Position",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Division_ID",
                table: "p_Position",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Contragent_ID",
                table: "p_Division",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_Division_ID",
                table: "p_Position",
                column: "Division_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_Contragent_ID",
                table: "p_Division",
                column: "Contragent_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_p_Division_p_Contragent_Contragent_ID",
                table: "p_Division",
                column: "Contragent_ID",
                principalTable: "p_Contragent",
                principalColumn: "Contragent_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Position_p_Division_Division_ID",
                table: "p_Position",
                column: "Division_ID",
                principalTable: "p_Division",
                principalColumn: "Division_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
