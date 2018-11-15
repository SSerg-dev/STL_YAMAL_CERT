using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocumentNaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_DocumentNaks",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaks_ID = table.Column<Guid>(nullable: false),
                    Person_ID = table.Column<Guid>(nullable: false),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "Date", nullable: false),
                    Schifr = table.Column<string>(nullable: false),
                    WeldType_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaks", x => x.DocumentNaks_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_p_WeldType_WeldType_ID",
                        column: x => x.WeldType_ID,
                        principalTable: "p_WeldType",
                        principalColumn: "WeldType_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaks_to_HIFGroup",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaks_to_HIFGroup_ID = table.Column<Guid>(nullable: false),
                    DocumentNaks_ID = table.Column<Guid>(nullable: false),
                    HIFGroup_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaks_to_HIFGroup", x => x.DocumentNaks_to_HIFGroup_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_to_HIFGroup_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_to_HIFGroup_p_DocumentNaks_DocumentNaks_ID",
                        column: x => x.DocumentNaks_ID,
                        principalTable: "p_DocumentNaks",
                        principalColumn: "DocumentNaks_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_to_HIFGroup_p_HIFGroup_HIFGroup_ID",
                        column: x => x.HIFGroup_ID,
                        principalTable: "p_HIFGroup",
                        principalColumn: "HIFGroup_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_to_HIFGroup_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_Created_User_ID",
                table: "p_DocumentNaks",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_Modified_User_ID",
                table: "p_DocumentNaks",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_WeldType_ID",
                table: "p_DocumentNaks",
                column: "WeldType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_to_HIFGroup_Created_User_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_to_HIFGroup_DocumentNaks_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "DocumentNaks_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_to_HIFGroup_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "HIFGroup_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_to_HIFGroup_Modified_User_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "Modified_User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropTable(
                name: "p_DocumentNaks");
        }
    }
}
