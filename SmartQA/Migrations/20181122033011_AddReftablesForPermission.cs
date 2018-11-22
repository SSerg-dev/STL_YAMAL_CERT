using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddReftablesForPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_AccessToPIStaffFunction",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    AccessToPIStaffFunction_ID = table.Column<Guid>(nullable: false),
                    AccessToPIStaffFunction_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AccessToPIStaffFunction", x => x.AccessToPIStaffFunction_ID);
                    table.ForeignKey(
                        name: "FK_p_AccessToPIStaffFunction_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AccessToPIStaffFunction_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AccessToPIVoltageRange",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    AccessToPIVoltageRange_ID = table.Column<Guid>(nullable: false),
                    AccessToPIVoltageRange_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AccessToPIVoltageRange", x => x.AccessToPIVoltageRange_ID);
                    table.ForeignKey(
                        name: "FK_p_AccessToPIVoltageRange_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AccessToPIVoltageRange_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AuthToSignInspActsForWSUN",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    AuthToSignInspActsForWSUN_ID = table.Column<Guid>(nullable: false),
                    AuthToSignInspActsForWSUN_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AuthToSignInspActsForWSUN", x => x.AuthToSignInspActsForWSUN_ID);
                    table.ForeignKey(
                        name: "FK_p_AuthToSignInspActsForWSUN_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AuthToSignInspActsForWSUN_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_ElectricalSafetyAbilitation",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    ElectricalSafetyAbilitation_ID = table.Column<Guid>(nullable: false),
                    ElectricalSafetyAbilitation_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_ElectricalSafetyAbilitation", x => x.ElectricalSafetyAbilitation_ID);
                    table.ForeignKey(
                        name: "FK_p_ElectricalSafetyAbilitation_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_ElectricalSafetyAbilitation_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_QualificationField",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    QualificationField_ID = table.Column<Guid>(nullable: false),
                    Parent_Id = table.Column<Guid>(nullable: false),
                    Structure_Level = table.Column<int>(nullable: false),
                    QualificationField_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_QualificationField", x => x.QualificationField_ID);
                    table.ForeignKey(
                        name: "FK_p_QualificationField_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_QualificationField_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_QualificationLevel",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    QualificationLevel_ID = table.Column<Guid>(nullable: false),
                    QualificationLevel_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_QualificationLevel", x => x.QualificationLevel_ID);
                    table.ForeignKey(
                        name: "FK_p_QualificationLevel_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_QualificationLevel_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Responsibility",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Responsibility_ID = table.Column<Guid>(nullable: false),
                    Responsibility_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Responsibility", x => x.Responsibility_ID);
                    table.ForeignKey(
                        name: "FK_p_Responsibility_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Responsibility_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_ShieldingGas",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    ShieldingGas_ID = table.Column<Guid>(nullable: false),
                    ShieldingGas_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_ShieldingGas", x => x.ShieldingGas_ID);
                    table.ForeignKey(
                        name: "FK_p_ShieldingGas_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_ShieldingGas_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_TestMethod",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    TestMethod_ID = table.Column<Guid>(nullable: false),
                    Parent_Id = table.Column<Guid>(nullable: false),
                    Structure_Level = table.Column<int>(nullable: false),
                    TestMethod_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_TestMethod", x => x.TestMethod_ID);
                    table.ForeignKey(
                        name: "FK_p_TestMethod_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_TestMethod_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldPasses",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldPasses_ID = table.Column<Guid>(nullable: false),
                    WeldPasses_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldPasses", x => x.WeldPasses_ID);
                    table.ForeignKey(
                        name: "FK_p_WeldPasses_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldPasses_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_Created_User_ID",
                table: "p_AccessToPIStaffFunction",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_Modified_User_ID",
                table: "p_AccessToPIStaffFunction",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_Created_User_ID",
                table: "p_AccessToPIVoltageRange",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_Modified_User_ID",
                table: "p_AccessToPIVoltageRange",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_Created_User_ID",
                table: "p_AuthToSignInspActsForWSUN",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_Modified_User_ID",
                table: "p_AuthToSignInspActsForWSUN",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_Created_User_ID",
                table: "p_ElectricalSafetyAbilitation",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_Modified_User_ID",
                table: "p_ElectricalSafetyAbilitation",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_Created_User_ID",
                table: "p_QualificationField",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_Modified_User_ID",
                table: "p_QualificationField",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_Created_User_ID",
                table: "p_QualificationLevel",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_Modified_User_ID",
                table: "p_QualificationLevel",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_Created_User_ID",
                table: "p_Responsibility",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_Modified_User_ID",
                table: "p_Responsibility",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_Created_User_ID",
                table: "p_ShieldingGas",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_Modified_User_ID",
                table: "p_ShieldingGas",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_Created_User_ID",
                table: "p_TestMethod",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_Modified_User_ID",
                table: "p_TestMethod",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_Created_User_ID",
                table: "p_WeldPasses",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_Modified_User_ID",
                table: "p_WeldPasses",
                column: "Modified_User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_AccessToPIStaffFunction");

            migrationBuilder.DropTable(
                name: "p_AccessToPIVoltageRange");

            migrationBuilder.DropTable(
                name: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropTable(
                name: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropTable(
                name: "p_QualificationField");

            migrationBuilder.DropTable(
                name: "p_QualificationLevel");

            migrationBuilder.DropTable(
                name: "p_Responsibility");

            migrationBuilder.DropTable(
                name: "p_ShieldingGas");

            migrationBuilder.DropTable(
                name: "p_TestMethod");

            migrationBuilder.DropTable(
                name: "p_WeldPasses");
        }
    }
}
