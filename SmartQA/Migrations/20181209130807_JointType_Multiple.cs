using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class JointType_Multiple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_JointType_JointType_ID",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_JointType_ID",
                table: "p_DocumentNaksAttest");

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_JointType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_JointType_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    JointType_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_JointType", x => x.DocumentNaksAttest_to_JointType_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointType_p_JointType_JointType_ID",
                        column: x => x.JointType_ID,
                        principalTable: "p_JointType",
                        principalColumn: "JointType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_Created_User_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "JointType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "Modified_User_ID");

            migrationBuilder.Sql(@"INSERT INTO dbo.p_DocumentNaksAttest_to_JointType
                                               (RowStatus
                                               , Insert_DTS
                                               , Update_DTS
                                               , Created_User_ID
                                               , Modified_User_ID
                                               , DocumentNaksAttest_to_JointType_ID
                                               , DocumentNaksAttest_ID
                                               , JointType_ID)
                                    SELECT
                                             0
                                            , Insert_DTS
                                            , Update_DTS
                                            , Created_User_ID
                                            , Modified_User_ID
                                            , newid()
                                            , DocumentNaksAttest_ID
                                            , JointType_ID
                                    FROM dbo.p_DocumentNaksAttest");

            migrationBuilder.DropColumn(
                name: "JointType_ID",
                table: "p_DocumentNaksAttest");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<Guid>(
                name: "JointType_ID",
                table: "p_DocumentNaksAttest",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_JointType_ID",
                table: "p_DocumentNaksAttest",
                column: "JointType_ID");

            migrationBuilder.Sql(@"UPDATE a
                                   SET a.JointType_ID = a2j.JointType_ID
                                   from dbo.p_DocumentNaksAttest a
                                   join dbo.p_DocumentNaksAttest_to_JointType a2j on a.DocumentNaksAttest_ID = a2j.DocumentNaksAttest_ID");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_p_JointType_JointType_ID",
                table: "p_DocumentNaksAttest",
                column: "JointType_ID",
                principalTable: "p_JointType",
                principalColumn: "JointType_ID",
                onDelete: ReferentialAction.Cascade);

        }
    }
}
