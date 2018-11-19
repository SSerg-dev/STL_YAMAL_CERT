using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddTestTypeRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_TestTypeRef",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    TestTypeRef_ID = table.Column<Guid>(nullable: false),
                    TestTypeRef_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_TestTypeRef", x => x.TestTypeRef_ID);
                    table.ForeignKey(
                        name: "FK_p_TestTypeRef_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_TestTypeRef_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_Created_User_ID",
                table: "p_TestTypeRef",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_Modified_User_ID",
                table: "p_TestTypeRef",
                column: "Modified_User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_TestTypeRef");
        }
    }
}
