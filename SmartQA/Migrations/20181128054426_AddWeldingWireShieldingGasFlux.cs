using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddWeldingWireShieldingGasFlux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.AddColumn<string>(
                name: "ShieldingGasFlux",
                table: "p_DocumentNaksAttest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeldingWire",
                table: "p_DocumentNaksAttest",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShieldingGasFlux",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropColumn(
                name: "WeldingWire",
                table: "p_DocumentNaksAttest");
        }
    }
}
