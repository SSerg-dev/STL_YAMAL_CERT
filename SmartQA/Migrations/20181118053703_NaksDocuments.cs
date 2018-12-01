using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class NaksDocuments : Migration
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
                    Number = table.Column<string>(nullable: false),
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
                        name: "FK_p_DocumentNaks_p_Person_Person_ID",
                        column: x => x.Person_ID,
                        principalTable: "p_Person",
                        principalColumn: "Person_ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    WeldingWire = table.Column<string>(nullable: true),
                    ShieldingGasFlux = table.Column<string>(nullable: true),
                    DetailWidth = table.Column<string>(nullable: true),
                    OuterDiameter = table.Column<string>(nullable: true),
                    SDR = table.Column<string>(nullable: true),
                    DocumentNaks_ID = table.Column<Guid>(nullable: false),
                    JointType_ID = table.Column<Guid>(nullable: false),
                    WeldingEquipmentAutomationLevel_ID = table.Column<Guid>(nullable: false),
                    WeldGOST14098_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest", x => x.DocumentNaksAttest_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_DocumentNaks_DocumentNaks_ID",
                        column: x => x.DocumentNaks_ID,
                        principalTable: "p_DocumentNaks",
                        principalColumn: "DocumentNaks_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_JointType_JointType_ID",
                        column: x => x.JointType_ID,
                        principalTable: "p_JointType",
                        principalColumn: "JointType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_WeldGOST14098_WeldGOST14098_ID",
                        column: x => x.WeldGOST14098_ID,
                        principalTable: "p_WeldGOST14098",
                        principalColumn: "WeldGOST14098_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID",
                        column: x => x.WeldingEquipmentAutomationLevel_ID,
                        principalTable: "p_WeldingEquipmentAutomationLevel",
                        principalColumn: "WeldingEquipmentAutomationLevel_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_DetailsType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_DetailsType_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    DetailsType_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_DetailsType", x => x.DocumentNaksAttest_to_DetailsType_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_DetailsType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DetailsType_DetailsType_ID",
                        column: x => x.DetailsType_ID,
                        principalTable: "p_DetailsType",
                        principalColumn: "DetailsType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_DetailsType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_JointKind",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_JointKind_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    JointKind_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_JointKind", x => x.DocumentNaksAttest_to_JointKind_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointKind_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointKind_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointKind_p_JointKind_JointKind_ID",
                        column: x => x.JointKind_ID,
                        principalTable: "p_JointKind",
                        principalColumn: "JointKind_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointKind_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_SeamsType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_SeamsType_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    SeamsType_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_SeamsType", x => x.DocumentNaksAttest_to_SeamsType_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_SeamsType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_SeamsType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID",
                        column: x => x.SeamsType_ID,
                        principalTable: "p_SeamsType",
                        principalColumn: "SeamsType_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_WeldMaterial",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_WeldMaterial_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    WeldMaterial_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_WeldMaterial", x => x.DocumentNaksAttest_to_WeldMaterial_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_WeldMaterial_WeldMaterial_ID",
                        column: x => x.WeldMaterial_ID,
                        principalTable: "p_WeldMaterial",
                        principalColumn: "WeldMaterial_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_WeldMaterialGroup_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    WeldMaterialGroup_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_WeldMaterialGroup", x => x.DocumentNaksAttest_to_WeldMaterialGroup_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_WeldMaterialGroup_WeldMaterialGroup_ID",
                        column: x => x.WeldMaterialGroup_ID,
                        principalTable: "p_WeldMaterialGroup",
                        principalColumn: "WeldMaterialGroup_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_WeldPosition",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_to_WeldPosition_ID = table.Column<Guid>(nullable: false),
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false),
                    WeldPosition_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNaksAttest_to_WeldPosition", x => x.DocumentNaksAttest_to_WeldPosition_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                        column: x => x.DocumentNaksAttest_ID,
                        principalTable: "p_DocumentNaksAttest",
                        principalColumn: "DocumentNaksAttest_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID",
                        column: x => x.WeldPosition_ID,
                        principalTable: "p_WeldPosition",
                        principalColumn: "WeldPosition_ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_p_DocumentNaks_Person_ID",
                table: "p_DocumentNaks",
                column: "Person_ID");

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

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_Created_User_ID",
                table: "p_DocumentNaksAttest",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_DocumentNaks_ID",
                table: "p_DocumentNaksAttest",
                column: "DocumentNaks_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_JointType_ID",
                table: "p_DocumentNaksAttest",
                column: "JointType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_Modified_User_ID",
                table: "p_DocumentNaksAttest",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest",
                column: "WeldGOST14098_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_WeldingEquipmentAutomationLevel_ID",
                table: "p_DocumentNaksAttest",
                column: "WeldingEquipmentAutomationLevel_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_DetailsType_Created_User_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_DetailsType_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "DetailsType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_DetailsType_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_DetailsType_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointKind_Created_User_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointKind_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointKind_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "JointKind_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointKind_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_Created_User_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "SeamsType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_Created_User_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "WeldMaterial_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_Created_User_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "WeldMaterialGroup_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_Created_User_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "DocumentNaksAttest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_Modified_User_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "WeldPosition_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest");

            migrationBuilder.DropTable(
                name: "p_DocumentNaks");
        }
    }
}
