using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddRefTablesForNK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_Level",
                columns: table => new
                {
                    Level_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Level_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Level", x => x.Level_ID);
                    table.UniqueConstraint("AK_p_Level_Level_Code", x => x.Level_Code);
                    table.ForeignKey(
                        name: "FK_p_Level_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Level_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Level_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_StaffFunction",
                columns: table => new
                {
                    StaffFunction_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    StaffFunction_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_StaffFunction", x => x.StaffFunction_ID);
                    table.UniqueConstraint("AK_p_StaffFunction_StaffFunction_Code", x => x.StaffFunction_Code);
                    table.ForeignKey(
                        name: "FK_p_StaffFunction_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_StaffFunction_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_StaffFunction_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_VoltageRange",
                columns: table => new
                {
                    VoltageRange_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    VoltageRange_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_VoltageRange", x => x.VoltageRange_ID);
                    table.UniqueConstraint("AK_p_VoltageRange_VoltageRange_Code", x => x.VoltageRange_Code);
                    table.ForeignKey(
                        name: "FK_p_VoltageRange_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_VoltageRange_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_VoltageRange_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_Level_Created_User_ID",
                table: "p_Level",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Level_Modified_User_ID",
                table: "p_Level",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Level_RowStatus",
                table: "p_Level",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_StaffFunction_Created_User_ID",
                table: "p_StaffFunction",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_StaffFunction_Modified_User_ID",
                table: "p_StaffFunction",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_StaffFunction_RowStatus",
                table: "p_StaffFunction",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_VoltageRange_Created_User_ID",
                table: "p_VoltageRange",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_VoltageRange_Modified_User_ID",
                table: "p_VoltageRange",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_VoltageRange_RowStatus",
                table: "p_VoltageRange",
                column: "RowStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_Level");

            migrationBuilder.DropTable(
                name: "p_StaffFunction");

            migrationBuilder.DropTable(
                name: "p_VoltageRange");
        }
    }
}
