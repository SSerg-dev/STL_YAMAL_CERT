using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DeleteWeldGOST14098ColumnProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_WeldGOST14098_WeldGOST14098_ID",
               table: "p_DocumentNaksAttest"
                );
            migrationBuilder.DropColumn(
               name: "WeldGOST14098_ID",
               table: "p_DocumentNaksAttest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
