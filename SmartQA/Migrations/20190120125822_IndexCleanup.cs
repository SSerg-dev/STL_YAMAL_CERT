using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class IndexCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_p_Register_to_Status_Register_ID_DTS_End",
                table: "p_Register_to_Status");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_Status_Document_ID_DTS_End",
                table: "p_Document_to_Status");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_Root_ID_IsActual",
                table: "p_Document");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Register_ID_DTS_End",
                table: "p_Register_to_Status",
                columns: new[] { "Register_ID", "DTS_End" },
                unique: true,
                filter: "(DTS_End is null)");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Document_ID_DTS_End",
                table: "p_Document_to_Status",
                columns: new[] { "Document_ID", "DTS_End" },
                unique: true,
                filter: "(DTS_End is null)");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_Root_ID_IsActual",
                table: "p_Document",
                columns: new[] { "Root_ID", "IsActual" },
                unique: true,
                filter: "(IsActual = 1)");
        }
    }
}
