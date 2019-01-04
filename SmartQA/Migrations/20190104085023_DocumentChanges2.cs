using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocumentChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "p_DocumentType",
                maxLength: 255,
                nullable: true);

            migrationBuilder.RenameTable(
                "p_Document_to_Status",
                newName: "p_DocumentStatus");

            migrationBuilder.RenameColumn(
                "Document_to_Status_ID",
                "p_DocumentStatus",
                "DocumentStatus_ID"
            );
            
            migrationBuilder.RenameIndex(
                "IX_p_Document_to_Status_Created_User_ID",
                "IX_p_DocumentStatus_Created_User_ID",
                table: "p_DocumentStatus"
            );

            migrationBuilder.RenameIndex(
                "IX_p_Document_to_Status_Document_ID",
                "IX_p_DocumentStatus_Document_ID",
                table: "p_DocumentStatus"
            );

            migrationBuilder.RenameIndex(
                "IX_p_Document_to_Status_Modified_User_ID",
                "IX_p_DocumentStatus_Modified_User_ID",
                table: "p_DocumentStatus"
            );

            migrationBuilder.RenameIndex(
                "IX_p_Document_to_Status_Parent_ID",
                "IX_p_DocumentStatus_Parent_ID",
                table: "p_DocumentStatus"
            );

            migrationBuilder.RenameIndex(
                "IX_p_Document_to_Status_RowStatus",
                "IX_p_DocumentStatus_RowStatus",
                table: "p_DocumentStatus"
            );

            migrationBuilder.RenameIndex(
                "IX_p_Document_to_Status_Status_ID",
                "IX_p_DocumentStatus_Status_ID",
                table: "p_DocumentStatus"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "p_DocumentType");

            
            migrationBuilder.RenameTable(
                "p_DocumentStatus",
                newName: "");

            migrationBuilder.RenameColumn(
                "DocumentStatus_ID",
                "p_Document_to_Status",
                "Document_to_Status_ID"
            );
            
            migrationBuilder.RenameIndex(
                "IX_p_DocumentStatus_Created_User_ID",
                "IX_p_Document_to_Status_Created_User_ID",
                table: "p_Document_to_Status"           
            );

            migrationBuilder.RenameIndex(
                "IX_p_DocumentStatus_Document_ID",
                "IX_p_Document_to_Status_Document_ID",
                table: "p_Document_to_Status"                           
            );

            migrationBuilder.RenameIndex(
                "IX_p_DocumentStatus_Modified_User_ID",
                "IX_p_Document_to_Status_Modified_User_ID",
                table: "p_Document_to_Status"                           
            );

            migrationBuilder.RenameIndex(
                "IX_p_DocumentStatus_Parent_ID",
                "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status"                           
            );

            migrationBuilder.RenameIndex(
                "IX_p_DocumentStatus_RowStatus",
                "IX_p_Document_to_Status_RowStatus",
                table: "p_Document_to_Status"                           
            );

            migrationBuilder.RenameIndex(
                "IX_p_DocumentStatus_Status_ID",
                "IX_p_Document_to_Status_Status_ID",
                table: "p_Document_to_Status"                           
            );
        }
    }
}
