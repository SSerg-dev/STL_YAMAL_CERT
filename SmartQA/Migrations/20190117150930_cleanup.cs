using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InspectionSubject",
                table: "p_DocumentNDTIT");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationPublishedNDT",
                table: "p_DocumentNDT",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InspectionSubject",
                table: "p_DocumentNDTIT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationPublishedNDT",
                table: "p_DocumentNDT",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
