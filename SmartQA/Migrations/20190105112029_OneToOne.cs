using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class OneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_p_Employee_AppUser_ID",
                table: "p_Employee");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_AppUser_ID",
                table: "p_Employee",
                column: "AppUser_ID",
                unique: true,
                filter: "[AppUser_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status",
                column: "Parent_ID",
                unique: true,
                filter: "[Parent_ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_p_Employee_AppUser_ID",
                table: "p_Employee");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_AppUser_ID",
                table: "p_Employee",
                column: "AppUser_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status",
                column: "Parent_ID");
        }
    }
}
