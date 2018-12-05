using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddM2MWeldGOST14098 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_WeldGOST14098",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_WeldGOST14098_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    WeldGOST14098_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_WeldGOST14098", x => x.DocumentNaksAttest_to_WeldGOST14098_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                  
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_Created_User_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "WeldGOST14098_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldGOST14098");

        }
    }
}
