using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocumentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_Document_DocumentType_ID",
                table: "p_Document");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_DocumentType_Root_ID",
                table: "p_Document");

            migrationBuilder.AlterColumn<string>(
                name: "Document_Code",
                table: "p_Document",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "next value for [Sequence_Document_Number]",
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "p_DocumentType",
                columns: new[] { "DocumentType_ID", "Created_User_ID", "Insert_DTS", "Modified_User_ID", "RowStatus", "DocumentType_Code", "Update_DTS" },
                values: new object[] { new Guid("724b20fd-df8d-4b4c-8afc-d54fe796f254"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0, "N/A", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_DocumentType_DocumentType_ID",
                table: "p_Document",
                column: "DocumentType_ID",
                principalTable: "p_DocumentType",
                principalColumn: "DocumentType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_Document_Root_ID",
                table: "p_Document",
                column: "Root_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_DocumentType_DocumentType_ID",
                table: "p_Document");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_Document_Root_ID",
                table: "p_Document");

            migrationBuilder.DeleteData(
                table: "p_DocumentType",
                keyColumn: "DocumentType_ID",
                keyValue: new Guid("724b20fd-df8d-4b4c-8afc-d54fe796f254"));

            migrationBuilder.AlterColumn<string>(
                name: "Document_Code",
                table: "p_Document",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldDefaultValueSql: "next value for [Sequence_Document_Number]");

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_Document_DocumentType_ID",
                table: "p_Document",
                column: "DocumentType_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_DocumentType_Root_ID",
                table: "p_Document",
                column: "Root_ID",
                principalTable: "p_DocumentType",
                principalColumn: "DocumentType_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
