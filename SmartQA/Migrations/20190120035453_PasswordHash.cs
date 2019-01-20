using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using SmartQA.Util;

namespace SmartQA.Migrations
{
    public partial class PasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "p_AppUser",
                maxLength: 8000,
                nullable: true);            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "p_AppUser");
        }                
    }
}
