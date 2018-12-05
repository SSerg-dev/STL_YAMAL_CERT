using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddWeldGOST14098FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "WeldGOST14098_ID",
                        principalTable: "p_WeldGOST14098",
                        principalColumn: "WeldGOST14098_ID",
                        onDelete: ReferentialAction.Cascade
                );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
