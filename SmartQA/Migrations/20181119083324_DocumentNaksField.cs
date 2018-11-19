using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocumentNaksField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Schifr",
                table: "p_DocumentNaks",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Schifr",
                table: "p_DocumentNaks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
