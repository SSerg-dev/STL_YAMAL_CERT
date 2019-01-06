using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Sequence_CheckList_Number");

            migrationBuilder.CreateSequence(
                name: "Sequence_Document_Number");

            migrationBuilder.CreateSequence(
                name: "Sequence_Register_Number");

            migrationBuilder.CreateTable(
                name: "p_RowStatus",
                columns: table => new
                {
                    RowStatus_ID = table.Column<int>(nullable: false),
                    Status_Name_Eng = table.Column<string>(maxLength: 100, nullable: false),
                    Status_Name_Rus = table.Column<string>(maxLength: 100, nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_RowStatus", x => x.RowStatus_ID);
                });

            migrationBuilder.CreateTable(
                name: "p_AppUser",
                columns: table => new
                {
                    AppUser_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    AppUser_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    User_Password = table.Column<byte[]>(maxLength: 8000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AppUser", x => x.AppUser_ID);
                    table.UniqueConstraint("AK_p_AppUser_AppUser_Code", x => x.AppUser_Code);
                    table.ForeignKey(
                        name: "FK_p_AppUser_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AppUser_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AppUser_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AccessToPIStaffFunction",
                columns: table => new
                {
                    AccessToPIStaffFunction_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    AccessToPIStaffFunction_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AccessToPIStaffFunction", x => x.AccessToPIStaffFunction_ID);
                    table.UniqueConstraint("AK_p_AccessToPIStaffFunction_AccessToPIStaffFunction_Code", x => x.AccessToPIStaffFunction_Code);
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
                    table.ForeignKey(
                        name: "FK_p_AccessToPIStaffFunction_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AccessToPIVoltageRange",
                columns: table => new
                {
                    AccessToPIVoltageRange_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    AccessToPIVoltageRange_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AccessToPIVoltageRange", x => x.AccessToPIVoltageRange_ID);
                    table.UniqueConstraint("AK_p_AccessToPIVoltageRange_AccessToPIVoltageRange_Code", x => x.AccessToPIVoltageRange_Code);
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
                    table.ForeignKey(
                        name: "FK_p_AccessToPIVoltageRange_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AttCenterNaks",
                columns: table => new
                {
                    AttCenterNaks_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    AttCenterNaks_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AttCenterNaks", x => x.AttCenterNaks_ID);
                    table.UniqueConstraint("AK_p_AttCenterNaks_AttCenterNaks_Code", x => x.AttCenterNaks_Code);
                    table.ForeignKey(
                        name: "FK_p_AttCenterNaks_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AttCenterNaks_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AttCenterNaks_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AuthToSignInspActsForWSUN",
                columns: table => new
                {
                    AuthToSignInspActsForWSUN_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    AuthToSignInspActsForWSUN_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AuthToSignInspActsForWSUN", x => x.AuthToSignInspActsForWSUN_ID);
                    table.UniqueConstraint("AK_p_AuthToSignInspActsForWSUN_AuthToSignInspActsForWSUN_Code", x => x.AuthToSignInspActsForWSUN_Code);
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
                    table.ForeignKey(
                        name: "FK_p_AuthToSignInspActsForWSUN_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_ContragentRole",
                columns: table => new
                {
                    ContragentRole_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    ContragentRole_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_ContragentRole", x => x.ContragentRole_ID);
                    table.UniqueConstraint("AK_p_ContragentRole_ContragentRole_Code", x => x.ContragentRole_Code);
                    table.ForeignKey(
                        name: "FK_p_ContragentRole_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_ContragentRole_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_ContragentRole_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DetailsType",
                columns: table => new
                {
                    DetailsType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    DetailsType_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DetailsType", x => x.DetailsType_ID);
                    table.UniqueConstraint("AK_p_DetailsType_DetailsType_Code", x => x.DetailsType_Code);
                    table.ForeignKey(
                        name: "FK_p_DetailsType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DetailsType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DetailsType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentProjectNumber",
                columns: table => new
                {
                    DocumentProjectNumber_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    DocumentProjectNumber_Code = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentProjectNumber", x => x.DocumentProjectNumber_ID);
                    table.UniqueConstraint("AK_p_DocumentProjectNumber_DocumentProjectNumber_Code", x => x.DocumentProjectNumber_Code);
                    table.ForeignKey(
                        name: "FK_p_DocumentProjectNumber_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentProjectNumber_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentProjectNumber_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentType",
                columns: table => new
                {
                    DocumentType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    DocumentType_Code = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentType", x => x.DocumentType_ID);
                    table.UniqueConstraint("AK_p_DocumentType_DocumentType_Code", x => x.DocumentType_Code);
                    table.ForeignKey(
                        name: "FK_p_DocumentType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_ElectricalSafetyAbilitation",
                columns: table => new
                {
                    ElectricalSafetyAbilitation_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    ElectricalSafetyAbilitation_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_ElectricalSafetyAbilitation", x => x.ElectricalSafetyAbilitation_ID);
                    table.UniqueConstraint("AK_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code", x => x.ElectricalSafetyAbilitation_Code);
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
                    table.ForeignKey(
                        name: "FK_p_ElectricalSafetyAbilitation_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_HIFGroup",
                columns: table => new
                {
                    HIFGroup_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    HIFGroup_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_HIFGroup", x => x.HIFGroup_ID);
                    table.UniqueConstraint("AK_p_HIFGroup_HIFGroup_Code", x => x.HIFGroup_Code);
                    table.ForeignKey(
                        name: "FK_p_HIFGroup_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_HIFGroup_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_HIFGroup_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_InspectionSubject",
                columns: table => new
                {
                    InspectionSubject_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Parent_ID = table.Column<Guid>(nullable: true),
                    Structure_Level = table.Column<int>(nullable: false),
                    InspectionSubject_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_InspectionSubject", x => x.InspectionSubject_ID);
                    table.UniqueConstraint("AK_p_InspectionSubject_InspectionSubject_Code", x => x.InspectionSubject_Code);
                    table.ForeignKey(
                        name: "FK_p_InspectionSubject_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_InspectionSubject_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_InspectionSubject_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_InspectionTechnique",
                columns: table => new
                {
                    InspectionTechnique_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    InspectionTechnique_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_InspectionTechnique", x => x.InspectionTechnique_ID);
                    table.UniqueConstraint("AK_p_InspectionTechnique_InspectionTechnique_Code", x => x.InspectionTechnique_Code);
                    table.ForeignKey(
                        name: "FK_p_InspectionTechnique_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_InspectionTechnique_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_InspectionTechnique_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_JointKind",
                columns: table => new
                {
                    JointKind_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    JointKind_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_JointKind", x => x.JointKind_ID);
                    table.UniqueConstraint("AK_p_JointKind_JointKind_Code", x => x.JointKind_Code);
                    table.ForeignKey(
                        name: "FK_p_JointKind_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_JointKind_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_JointKind_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_JointType",
                columns: table => new
                {
                    JointType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    JointType_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_JointType", x => x.JointType_ID);
                    table.UniqueConstraint("AK_p_JointType_JointType_Code", x => x.JointType_Code);
                    table.ForeignKey(
                        name: "FK_p_JointType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_JointType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_JointType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Marka",
                columns: table => new
                {
                    Marka_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Marka_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Marka_Code_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true),
                    Engineering_Drawing_Type_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    Engineering_Drawing_Type_Rus = table.Column<string>(maxLength: 255, nullable: true),
                    IsUsedInMatrix = table.Column<bool>(nullable: true),
                    IsPriority = table.Column<bool>(nullable: true),
                    ReportColor = table.Column<string>(maxLength: 255, nullable: true),
                    ReportOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Marka", x => x.Marka_ID);
                    table.UniqueConstraint("AK_p_Marka_Marka_Code", x => x.Marka_Code);
                    table.ForeignKey(
                        name: "FK_p_Marka_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Marka_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Marka_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Parameter",
                columns: table => new
                {
                    Parameter_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Parameter_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Parameter_Value = table.Column<string>(maxLength: 1000, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Parameter", x => x.Parameter_ID);
                    table.UniqueConstraint("AK_p_Parameter_Parameter_Code", x => x.Parameter_Code);
                    table.ForeignKey(
                        name: "FK_p_Parameter_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Parameter_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Parameter_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Person",
                columns: table => new
                {
                    Person_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Person_Code = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Person", x => x.Person_ID);
                    table.ForeignKey(
                        name: "FK_p_Person_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Person_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Person_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_PID",
                columns: table => new
                {
                    PID_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    PID_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_PID", x => x.PID_ID);
                    table.ForeignKey(
                        name: "FK_p_PID_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_PID_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_PID_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_QualificationField",
                columns: table => new
                {
                    QualificationField_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Parent_ID = table.Column<Guid>(nullable: true),
                    Structure_Level = table.Column<int>(nullable: false),
                    QualificationField_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_QualificationField", x => x.QualificationField_ID);
                    table.UniqueConstraint("AK_p_QualificationField_QualificationField_Code", x => x.QualificationField_Code);
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
                    table.ForeignKey(
                        name: "FK_p_QualificationField_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_QualificationLevel",
                columns: table => new
                {
                    QualificationLevel_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    QualificationLevel_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_QualificationLevel", x => x.QualificationLevel_ID);
                    table.UniqueConstraint("AK_p_QualificationLevel_QualificationLevel_Code", x => x.QualificationLevel_Code);
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
                    table.ForeignKey(
                        name: "FK_p_QualificationLevel_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Responsibility",
                columns: table => new
                {
                    Responsibility_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Responsibility_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Responsibility", x => x.Responsibility_ID);
                    table.UniqueConstraint("AK_p_Responsibility_Responsibility_Code", x => x.Responsibility_Code);
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
                    table.ForeignKey(
                        name: "FK_p_Responsibility_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Role",
                columns: table => new
                {
                    Role_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Role_Code = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Role", x => x.Role_ID);
                    table.ForeignKey(
                        name: "FK_p_Role_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Role_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Role_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_SeamsType",
                columns: table => new
                {
                    SeamsType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    SeamsType_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_SeamsType", x => x.SeamsType_ID);
                    table.UniqueConstraint("AK_p_SeamsType_SeamsType_Code", x => x.SeamsType_Code);
                    table.ForeignKey(
                        name: "FK_p_SeamsType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_SeamsType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_SeamsType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_ShieldingGas",
                columns: table => new
                {
                    ShieldingGas_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    ShieldingGas_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_ShieldingGas", x => x.ShieldingGas_ID);
                    table.UniqueConstraint("AK_p_ShieldingGas_ShieldingGas_Code", x => x.ShieldingGas_Code);
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
                    table.ForeignKey(
                        name: "FK_p_ShieldingGas_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Status",
                columns: table => new
                {
                    Status_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Status_Code = table.Column<string>(maxLength: 255, nullable: false),
                    StatusEntity = table.Column<string>(maxLength: 255, nullable: false),
                    EntityLocked = table.Column<bool>(nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true),
                    ReportColor = table.Column<bool>(maxLength: 255, nullable: false),
                    ReportOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Status", x => x.Status_ID);
                    table.ForeignKey(
                        name: "FK_p_Status_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Status_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Status_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_TestMethod",
                columns: table => new
                {
                    TestMethod_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Parent_ID = table.Column<Guid>(nullable: true),
                    Structure_Level = table.Column<int>(nullable: false),
                    TestMethod_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_TestMethod", x => x.TestMethod_ID);
                    table.UniqueConstraint("AK_p_TestMethod_TestMethod_Code", x => x.TestMethod_Code);
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
                    table.ForeignKey(
                        name: "FK_p_TestMethod_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_TestTypeRef",
                columns: table => new
                {
                    TestTypeRef_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    TestTypeRef_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_TestTypeRef", x => x.TestTypeRef_ID);
                    table.UniqueConstraint("AK_p_TestTypeRef_TestTypeRef_Code", x => x.TestTypeRef_Code);
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
                    table.ForeignKey(
                        name: "FK_p_TestTypeRef_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_TitleObject",
                columns: table => new
                {
                    TitleObject_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    TitleObject_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Parent_ID = table.Column<Guid>(nullable: true),
                    Structure = table.Column<int>(nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 300, nullable: true),
                    Description_Rus = table.Column<string>(maxLength: 400, nullable: true),
                    Phase_Name = table.Column<string>(maxLength: 100, nullable: true),
                    ReportColor = table.Column<string>(maxLength: 50, nullable: true),
                    ReportOrder = table.Column<int>(nullable: true),
                    Book1_Pct = table.Column<float>(nullable: true),
                    Book1_Weight = table.Column<float>(nullable: true),
                    Book2_Pct = table.Column<float>(nullable: true),
                    Book2_Weight = table.Column<float>(nullable: true),
                    Book3_Pct = table.Column<float>(nullable: true),
                    Book3_Weight = table.Column<float>(nullable: true),
                    Book4_Weight = table.Column<float>(nullable: true),
                    TitleObject_for_ABDFinalSet = table.Column<string>(maxLength: 100, nullable: true),
                    StageOfConstr = table.Column<string>(maxLength: 10, nullable: true),
                    Book1_Documents_Total = table.Column<float>(nullable: true),
                    Book1_Documents_received = table.Column<float>(nullable: true),
                    Book1_Progress = table.Column<float>(nullable: true),
                    Book1_Documents_transmitted_to_CPY = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_TitleObject", x => x.TitleObject_ID);
                    table.UniqueConstraint("AK_p_TitleObject_TitleObject_Code", x => x.TitleObject_Code);
                    table.ForeignKey(
                        name: "FK_p_TitleObject_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_TitleObject_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_TitleObject_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldGOST14098",
                columns: table => new
                {
                    WeldGOST14098_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldGOST14098_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldGOST14098", x => x.WeldGOST14098_ID);
                    table.UniqueConstraint("AK_p_WeldGOST14098_WeldGOST14098_Code", x => x.WeldGOST14098_Code);
                    table.ForeignKey(
                        name: "FK_p_WeldGOST14098_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldGOST14098_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldGOST14098_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldingEquipmentAutomationLevel",
                columns: table => new
                {
                    WeldingEquipmentAutomationLevel_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldingEquipmentAutomationLevel_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldingEquipmentAutomationLevel", x => x.WeldingEquipmentAutomationLevel_ID);
                    table.UniqueConstraint("AK_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_Code", x => x.WeldingEquipmentAutomationLevel_Code);
                    table.ForeignKey(
                        name: "FK_p_WeldingEquipmentAutomationLevel_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldingEquipmentAutomationLevel_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldingEquipmentAutomationLevel_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldMaterial",
                columns: table => new
                {
                    WeldMaterial_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldMaterial_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldMaterial", x => x.WeldMaterial_ID);
                    table.UniqueConstraint("AK_p_WeldMaterial_WeldMaterial_Code", x => x.WeldMaterial_Code);
                    table.ForeignKey(
                        name: "FK_p_WeldMaterial_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldMaterial_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldMaterial_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldMaterialGroup",
                columns: table => new
                {
                    WeldMaterialGroup_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldMaterialGroup_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldMaterialGroup", x => x.WeldMaterialGroup_ID);
                    table.UniqueConstraint("AK_p_WeldMaterialGroup_WeldMaterialGroup_Code", x => x.WeldMaterialGroup_Code);
                    table.ForeignKey(
                        name: "FK_p_WeldMaterialGroup_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldMaterialGroup_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldMaterialGroup_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldPasses",
                columns: table => new
                {
                    WeldPasses_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldPasses_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldPasses", x => x.WeldPasses_ID);
                    table.UniqueConstraint("AK_p_WeldPasses_WeldPasses_Code", x => x.WeldPasses_Code);
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
                    table.ForeignKey(
                        name: "FK_p_WeldPasses_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldPosition",
                columns: table => new
                {
                    WeldPosition_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldPosition_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldPosition", x => x.WeldPosition_ID);
                    table.UniqueConstraint("AK_p_WeldPosition_WeldPosition_Code", x => x.WeldPosition_Code);
                    table.ForeignKey(
                        name: "FK_p_WeldPosition_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldPosition_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldPosition_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_WeldType",
                columns: table => new
                {
                    WeldType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WeldType_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldType", x => x.WeldType_ID);
                    table.UniqueConstraint("AK_p_WeldType_WeldType_Code", x => x.WeldType_Code);
                    table.ForeignKey(
                        name: "FK_p_WeldType_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldType_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WeldType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Contragent",
                columns: table => new
                {
                    Contragent_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    ContragentRole_ID = table.Column<Guid>(nullable: true),
                    Contragent_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Contragent", x => x.Contragent_ID);
                    table.UniqueConstraint("AK_p_Contragent_Contragent_Code", x => x.Contragent_Code);
                    table.ForeignKey(
                        name: "FK_p_Contragent_p_ContragentRole_ContragentRole_ID",
                        column: x => x.ContragentRole_ID,
                        principalTable: "p_ContragentRole",
                        principalColumn: "ContragentRole_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Contragent_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Contragent_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Contragent_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_GOST",
                columns: table => new
                {
                    GOST_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    GOST_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true),
                    Marka_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_GOST", x => x.GOST_ID);
                    table.UniqueConstraint("AK_p_GOST_GOST_Code", x => x.GOST_Code);
                    table.ForeignKey(
                        name: "FK_p_GOST_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_p_Marka_Marka_ID",
                        column: x => x.Marka_ID,
                        principalTable: "p_Marka",
                        principalColumn: "Marka_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_AppUser_to_Role",
                columns: table => new
                {
                    AppUser_to_Role_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    AppUser_ID = table.Column<Guid>(nullable: false),
                    Role_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AppUser_to_Role", x => x.AppUser_to_Role_ID);
                    table.UniqueConstraint("AK_p_AppUser_to_Role_AppUser_ID_Role_ID", x => new { x.AppUser_ID, x.Role_ID });
                    table.ForeignKey(
                        name: "FK_p_AppUser_to_Role_p_AppUser_AppUser_ID",
                        column: x => x.AppUser_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_AppUser_to_Role_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AppUser_to_Role_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_AppUser_to_Role_p_Role_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "p_Role",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_AppUser_to_Role_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaks",
                columns: table => new
                {
                    DocumentNaks_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Person_ID = table.Column<Guid>(nullable: false),
                    ParentDocumentNaks_ID = table.Column<Guid>(nullable: true),
                    Number = table.Column<string>(nullable: false),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "Date", nullable: false),
                    Schifr = table.Column<string>(nullable: true),
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
                        name: "FK_p_DocumentNaks_p_DocumentNaks_ParentDocumentNaks_ID",
                        column: x => x.ParentDocumentNaks_ID,
                        principalTable: "p_DocumentNaks",
                        principalColumn: "DocumentNaks_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_p_Person_Person_ID",
                        column: x => x.Person_ID,
                        principalTable: "p_Person",
                        principalColumn: "Person_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_p_WeldType_WeldType_ID",
                        column: x => x.WeldType_ID,
                        principalTable: "p_WeldType",
                        principalColumn: "WeldType_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_Division",
                columns: table => new
                {
                    Division_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Division_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Contragent_ID = table.Column<Guid>(nullable: true),
                    Division_Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Division", x => x.Division_ID);
                    table.UniqueConstraint("AK_p_Division_Division_Code", x => x.Division_Code);
                    table.ForeignKey(
                        name: "FK_p_Division_p_Contragent_Contragent_ID",
                        column: x => x.Contragent_ID,
                        principalTable: "p_Contragent",
                        principalColumn: "Contragent_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Division_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Division_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Division_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_GOST_to_PID",
                columns: table => new
                {
                    GOST_to_PID_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    GOST_ID = table.Column<Guid>(nullable: false),
                    PID_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_GOST_to_PID", x => x.GOST_to_PID_ID);
                    table.UniqueConstraint("AK_p_GOST_to_PID_GOST_ID_PID_ID", x => new { x.GOST_ID, x.PID_ID });
                    table.ForeignKey(
                        name: "FK_p_GOST_to_PID_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_PID_p_GOST_GOST_ID",
                        column: x => x.GOST_ID,
                        principalTable: "p_GOST",
                        principalColumn: "GOST_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_PID_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_PID_p_PID_PID_ID",
                        column: x => x.PID_ID,
                        principalTable: "p_PID",
                        principalColumn: "PID_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_PID_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_GOST_to_TitleObject",
                columns: table => new
                {
                    GOST_to_TitleObject_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    GOST_ID = table.Column<Guid>(nullable: false),
                    TitleObject_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_GOST_to_TitleObject", x => x.GOST_to_TitleObject_ID);
                    table.UniqueConstraint("AK_p_GOST_to_TitleObject_GOST_ID_TitleObject_ID", x => new { x.GOST_ID, x.TitleObject_ID });
                    table.ForeignKey(
                        name: "FK_p_GOST_to_TitleObject_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_TitleObject_p_GOST_GOST_ID",
                        column: x => x.GOST_ID,
                        principalTable: "p_GOST",
                        principalColumn: "GOST_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_TitleObject_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_TitleObject_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_GOST_to_TitleObject_p_TitleObject_TitleObject_ID",
                        column: x => x.TitleObject_ID,
                        principalTable: "p_TitleObject",
                        principalColumn: "TitleObject_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaks_to_HIFGroup",
                columns: table => new
                {
                    DocumentNaks_to_HIFGroup_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_p_DocumentNaks_to_HIFGroup_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest",
                columns: table => new
                {
                    DocumentNaksAttest_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    DetailWidth = table.Column<string>(nullable: true),
                    OuterDiameter = table.Column<string>(nullable: true),
                    WeldingWire = table.Column<string>(nullable: true),
                    ShieldingGasFlux = table.Column<string>(nullable: true),
                    SDR = table.Column<string>(nullable: true),
                    WeldPositionCustom = table.Column<string>(nullable: true),
                    DocumentNaks_ID = table.Column<Guid>(nullable: false),
                    WeldingEquipmentAutomationLevel_ID = table.Column<Guid>(nullable: false)
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
                        name: "FK_p_DocumentNaksAttest_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID",
                        column: x => x.WeldingEquipmentAutomationLevel_ID,
                        principalTable: "p_WeldingEquipmentAutomationLevel",
                        principalColumn: "WeldingEquipmentAutomationLevel_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_Position",
                columns: table => new
                {
                    Position_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Description_Eng = table.Column<string>(maxLength: 255, nullable: true),
                    Division_ID = table.Column<Guid>(nullable: true),
                    Position_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Position", x => x.Position_ID);
                    table.UniqueConstraint("AK_p_Position_Position_Code", x => x.Position_Code);
                    table.ForeignKey(
                        name: "FK_p_Position_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Position_p_Division_Division_ID",
                        column: x => x.Division_ID,
                        principalTable: "p_Division",
                        principalColumn: "Division_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Position_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Position_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_DetailsType",
                columns: table => new
                {
                    DocumentNaksAttest_to_DetailsType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_DetailsType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_JointKind",
                columns: table => new
                {
                    DocumentNaksAttest_to_JointKind_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointKind_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_JointType",
                columns: table => new
                {
                    DocumentNaksAttest_to_JointType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_JointType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_SeamsType",
                columns: table => new
                {
                    DocumentNaksAttest_to_SeamsType_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                        name: "FK_p_DocumentNaksAttest_to_SeamsType_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID",
                        column: x => x.SeamsType_ID,
                        principalTable: "p_SeamsType",
                        principalColumn: "SeamsType_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_WeldGOST14098",
                columns: table => new
                {
                    DocumentNaksAttest_to_WeldGOST14098_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID",
                        column: x => x.WeldGOST14098_ID,
                        principalTable: "p_WeldGOST14098",
                        principalColumn: "WeldGOST14098_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNaksAttest_to_WeldMaterial",
                columns: table => new
                {
                    DocumentNaksAttest_to_WeldMaterial_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
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
                    DocumentNaksAttest_to_WeldMaterialGroup_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                        name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
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
                    DocumentNaksAttest_to_WeldPosition_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
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
                        name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID",
                        column: x => x.WeldPosition_ID,
                        principalTable: "p_WeldPosition",
                        principalColumn: "WeldPosition_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "p_Employee",
                columns: table => new
                {
                    Employee_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Employee_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Person_ID = table.Column<Guid>(nullable: false),
                    Position_ID = table.Column<Guid>(nullable: false),
                    AppUser_ID = table.Column<Guid>(nullable: true),
                    Contragent_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Employee", x => x.Employee_ID);
                    table.UniqueConstraint("AK_p_Employee_Employee_Code", x => x.Employee_Code);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_AppUser_AppUser_ID",
                        column: x => x.AppUser_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_Contragent_Contragent_ID",
                        column: x => x.Contragent_ID,
                        principalTable: "p_Contragent",
                        principalColumn: "Contragent_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_Person_Person_ID",
                        column: x => x.Person_ID,
                        principalTable: "p_Person",
                        principalColumn: "Person_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_Position_Position_ID",
                        column: x => x.Position_ID,
                        principalTable: "p_Position",
                        principalColumn: "Position_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Document",
                columns: table => new
                {
                    Document_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Document_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Issue_Date = table.Column<DateTimeOffset>(nullable: false),
                    Issue_Date_DT = table.Column<DateTime>(nullable: false),
                    Document_Number = table.Column<string>(maxLength: 255, nullable: true),
                    Document_Date = table.Column<DateTime>(type: "date", nullable: true),
                    TotalSheets = table.Column<int>(nullable: true),
                    Document_Name = table.Column<string>(maxLength: 255, nullable: true),
                    VersionNumber = table.Column<int>(nullable: false),
                    IsActual = table.Column<bool>(nullable: false),
                    DocumentType_ID = table.Column<Guid>(nullable: false),
                    Root_ID = table.Column<Guid>(nullable: false),
                    Resp_Employee_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Document", x => x.Document_ID);
                    table.UniqueConstraint("AK_p_Document_Document_Code", x => x.Document_Code);
                    table.ForeignKey(
                        name: "FK_p_Document_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_p_DocumentType_DocumentType_ID",
                        column: x => x.DocumentType_ID,
                        principalTable: "p_DocumentType",
                        principalColumn: "DocumentType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Document_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_p_Employee_Resp_Employee_ID",
                        column: x => x.Resp_Employee_ID,
                        principalTable: "p_Employee",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_p_Document_Root_ID",
                        column: x => x.Root_ID,
                        principalTable: "p_Document",
                        principalColumn: "Document_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Document_to_GOST",
                columns: table => new
                {
                    Document_to_GOST_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    GOST_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Document_to_GOST", x => x.Document_to_GOST_ID);
                    table.UniqueConstraint("AK_p_Document_to_GOST_Document_ID_GOST_ID", x => new { x.Document_ID, x.GOST_ID });
                    table.ForeignKey(
                        name: "FK_p_Document_to_GOST_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_GOST_p_Document_Document_ID",
                        column: x => x.Document_ID,
                        principalTable: "p_Document",
                        principalColumn: "Document_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Document_to_GOST_p_GOST_GOST_ID",
                        column: x => x.GOST_ID,
                        principalTable: "p_GOST",
                        principalColumn: "GOST_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Document_to_GOST_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_GOST_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Document_to_PID",
                columns: table => new
                {
                    Document_to_PID_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    PID_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Document_to_PID", x => x.Document_to_PID_ID);
                    table.UniqueConstraint("AK_p_Document_to_PID_Document_ID_PID_ID", x => new { x.Document_ID, x.PID_ID });
                    table.ForeignKey(
                        name: "FK_p_Document_to_PID_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_PID_p_Document_Document_ID",
                        column: x => x.Document_ID,
                        principalTable: "p_Document",
                        principalColumn: "Document_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Document_to_PID_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_PID_p_PID_PID_ID",
                        column: x => x.PID_ID,
                        principalTable: "p_PID",
                        principalColumn: "PID_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Document_to_PID_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Document_to_Status",
                columns: table => new
                {
                    Document_to_Status_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    Status_ID = table.Column<Guid>(nullable: false),
                    DTS_Start = table.Column<DateTimeOffset>(nullable: false),
                    DTS_End = table.Column<DateTimeOffset>(nullable: true),
                    Parent_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Document_to_Status", x => x.Document_to_Status_ID);
                    table.ForeignKey(
                        name: "FK_p_Document_to_Status_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_Status_p_Document_Document_ID",
                        column: x => x.Document_ID,
                        principalTable: "p_Document",
                        principalColumn: "Document_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Document_to_Status_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_Status_p_Document_to_Status_Parent_ID",
                        column: x => x.Parent_ID,
                        principalTable: "p_Document_to_Status",
                        principalColumn: "Document_to_Status_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_Status_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Document_to_Status_p_Status_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "p_Status",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "p_RowStatus",
                columns: new[] { "RowStatus_ID", "Description_Eng", "Description_Rus", "Status_Name_Eng", "Status_Name_Rus" },
                values: new object[] { 0, "Basic row", "Действующие данные", "Basic_Row", "Базовое состояние строки" });

            migrationBuilder.InsertData(
                table: "p_RowStatus",
                columns: new[] { "RowStatus_ID", "Description_Eng", "Description_Rus", "Status_Name_Eng", "Status_Name_Rus" },
                values: new object[] { 120, "Previous condition of row", "Предыдущие состояния строки", "Historical_Row", "Историческая строка" });

            migrationBuilder.InsertData(
                table: "p_RowStatus",
                columns: new[] { "RowStatus_ID", "Description_Eng", "Description_Rus", "Status_Name_Eng", "Status_Name_Rus" },
                values: new object[] { 200, "Deleted row", "Удалённая строка", "Deleted", "Удалённая строка" });

            migrationBuilder.InsertData(
                table: "p_AppUser",
                columns: new[] { "AppUser_ID", "AppUser_Code", "Comment", "Created_User_ID", "Insert_DTS", "Modified_User_ID", "RowStatus", "Update_DTS", "User_Password" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "root", "superuser", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new byte[] { 154, 188, 48, 112, 67, 142, 69, 201, 80, 125, 104, 193, 197, 212, 204, 212 } });

            migrationBuilder.InsertData(
                table: "p_Parameter",
                columns: new[] { "Parameter_ID", "Created_User_ID", "Description_Rus", "Insert_DTS", "Modified_User_ID", "Parameter_Code", "Parameter_Value", "RowStatus", "Update_DTS" },
                values: new object[] { new Guid("c2a74178-34ae-407d-af20-bcbcf8be649f"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "UTC часовой пояс строительной площадки", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "SiteTimezone", "Ekaterinburg Standard Time", 0, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "p_Role",
                columns: new[] { "Role_ID", "Created_User_ID", "Insert_DTS", "Modified_User_ID", "Role_Code", "RowStatus", "Update_DTS" },
                values: new object[] { new Guid("ccd8c1ee-f6a8-e811-aa0b-005056947b15"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Administrator", 0, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "p_Status",
                columns: new[] { "Status_ID", "Created_User_ID", "Description_Eng", "Description_Rus", "EntityLocked", "Insert_DTS", "Modified_User_ID", "ReportColor", "ReportOrder", "RowStatus", "StatusEntity", "Status_Code", "Update_DTS" },
                values: new object[,]
                {
                    { new Guid("27d94262-2830-1d24-5764-2a90ae9094e7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Fixed", "Исправлено", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIf", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("9ac37fd3-b2c2-c309-5f39-69fb7150a824"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Issued", "Выпущено", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIss", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("6e2d4292-5383-bd3a-24fc-e67857fbf182"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLId", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("60486e51-ef01-2480-9e25-7ae2f56f034d"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Fixed", "Замечания устранены", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wCLf", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("4f24b41a-dac7-3e73-9c0d-b31fb2f19d56"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Completed", "Проверка завершена", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wСLc", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("3dbfcb25-3ec5-f5f6-b619-43a6e0f73926"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Review", "Проверка", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wСLr", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("86cb8686-6b39-13c9-bf28-70cf2d6d62ef"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wСLd", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("c0327b4c-b2eb-32dc-ce07-80f23940350a"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cancelled", "Аннулирован", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCcan", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("95e4f0ea-9378-dc03-cf36-eb9efa314512"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Archived", "Архивирование", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCarh", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("55bc74c0-937a-1691-9c19-4d40d6028c96"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "WaitingSMR", "Ожидание завершения СМР", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCwsmr", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("e10cd869-3878-29b0-1b30-a4a2855c6986"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "NotApproved", "Отказано в утверждении", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCuna", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("2e96ff56-a2c3-7e5f-d06f-28eb06f8106f"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Approvement", "Утверждение", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCua", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("bcfd9a12-a2d8-f81c-c7d5-d43f190ed507"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "SecondReview", "Повторная проверка", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCuAsr", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("28fe952a-5094-3f4e-96cf-f9cddfae5e74"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "CommentsIncorporation", "Устранение замечаний", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wSCci", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("81f3ef08-bfa7-4176-e0c1-54ef6d687b6b"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "ComentsExists", "Выданы замечания", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wSCce", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("e65bd063-4b28-9174-db6d-83319a90ad76"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Review", "Проверка", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCuAr", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("ec3dfdb9-2c7a-9a45-9ced-fde8e9fe7617"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wSCd", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("12c12fe0-2085-5d30-87a5-5d98ba3c6ed8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Accepted", "Действующий", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Document", "wDa", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("5e1a9818-f8a5-481c-20f0-c16d362df87a"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Document", "wDd", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("ce34a401-3dea-c8eb-f304-86c73e9ffd9a"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Approved", "Утверждено", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIa", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { new Guid("2192a6b9-d13b-3e13-597c-cdd6ebed10df"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cancelled", "Отменено", true, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIc", new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "p_AppUser_to_Role",
                columns: new[] { "AppUser_to_Role_ID", "AppUser_ID", "Created_User_ID", "Insert_DTS", "Modified_User_ID", "Role_ID", "RowStatus", "Update_DTS" },
                values: new object[] { new Guid("c2d77d20-d557-4291-8da8-5b6765256a95"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("ccd8c1ee-f6a8-e811-aa0b-005056947b15"), 0, new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_Created_User_ID",
                table: "p_AccessToPIStaffFunction",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_Modified_User_ID",
                table: "p_AccessToPIStaffFunction",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_RowStatus",
                table: "p_AccessToPIStaffFunction",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_Created_User_ID",
                table: "p_AccessToPIVoltageRange",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_Modified_User_ID",
                table: "p_AccessToPIVoltageRange",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_RowStatus",
                table: "p_AccessToPIVoltageRange",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_Created_User_ID",
                table: "p_AppUser",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_Modified_User_ID",
                table: "p_AppUser",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_RowStatus",
                table: "p_AppUser",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_Created_User_ID",
                table: "p_AppUser_to_Role",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_Modified_User_ID",
                table: "p_AppUser_to_Role",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_Role_ID",
                table: "p_AppUser_to_Role",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_RowStatus",
                table: "p_AppUser_to_Role",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AttCenterNaks_Created_User_ID",
                table: "p_AttCenterNaks",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AttCenterNaks_Modified_User_ID",
                table: "p_AttCenterNaks",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AttCenterNaks_RowStatus",
                table: "p_AttCenterNaks",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_Created_User_ID",
                table: "p_AuthToSignInspActsForWSUN",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_Modified_User_ID",
                table: "p_AuthToSignInspActsForWSUN",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_RowStatus",
                table: "p_AuthToSignInspActsForWSUN",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_ContragentRole_ID",
                table: "p_Contragent",
                column: "ContragentRole_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_Created_User_ID",
                table: "p_Contragent",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_Modified_User_ID",
                table: "p_Contragent",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_RowStatus",
                table: "p_Contragent",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_ContragentRole_Created_User_ID",
                table: "p_ContragentRole",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ContragentRole_Modified_User_ID",
                table: "p_ContragentRole",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ContragentRole_RowStatus",
                table: "p_ContragentRole",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_Created_User_ID",
                table: "p_DetailsType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_Modified_User_ID",
                table: "p_DetailsType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_RowStatus",
                table: "p_DetailsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_Contragent_ID",
                table: "p_Division",
                column: "Contragent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_Created_User_ID",
                table: "p_Division",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_Modified_User_ID",
                table: "p_Division",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_RowStatus",
                table: "p_Division",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_Created_User_ID",
                table: "p_Document",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_DocumentType_ID",
                table: "p_Document",
                column: "DocumentType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_Modified_User_ID",
                table: "p_Document",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_Resp_Employee_ID",
                table: "p_Document",
                column: "Resp_Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_Root_ID",
                table: "p_Document",
                column: "Root_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_RowStatus",
                table: "p_Document",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_GOST_Created_User_ID",
                table: "p_Document_to_GOST",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_GOST_GOST_ID",
                table: "p_Document_to_GOST",
                column: "GOST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_GOST_Modified_User_ID",
                table: "p_Document_to_GOST",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_GOST_RowStatus",
                table: "p_Document_to_GOST",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_PID_Created_User_ID",
                table: "p_Document_to_PID",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_PID_Modified_User_ID",
                table: "p_Document_to_PID",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_PID_PID_ID",
                table: "p_Document_to_PID",
                column: "PID_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_PID_RowStatus",
                table: "p_Document_to_PID",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Created_User_ID",
                table: "p_Document_to_Status",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Document_ID",
                table: "p_Document_to_Status",
                column: "Document_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Modified_User_ID",
                table: "p_Document_to_Status",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status",
                column: "Parent_ID",
                unique: true,
                filter: "[Parent_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_RowStatus",
                table: "p_Document_to_Status",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Status_ID",
                table: "p_Document_to_Status",
                column: "Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_Created_User_ID",
                table: "p_DocumentNaks",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_Modified_User_ID",
                table: "p_DocumentNaks",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_ParentDocumentNaks_ID",
                table: "p_DocumentNaks",
                column: "ParentDocumentNaks_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_Person_ID",
                table: "p_DocumentNaks",
                column: "Person_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_RowStatus",
                table: "p_DocumentNaks",
                column: "RowStatus");

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
                name: "IX_p_DocumentNaks_to_HIFGroup_RowStatus",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_Created_User_ID",
                table: "p_DocumentNaksAttest",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_DocumentNaks_ID",
                table: "p_DocumentNaksAttest",
                column: "DocumentNaks_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_Modified_User_ID",
                table: "p_DocumentNaksAttest",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_RowStatus",
                table: "p_DocumentNaksAttest",
                column: "RowStatus");

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
                name: "IX_p_DocumentNaksAttest_to_DetailsType_RowStatus",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "RowStatus");

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
                name: "IX_p_DocumentNaksAttest_to_JointKind_RowStatus",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "RowStatus");

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

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_RowStatus",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "RowStatus");

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
                name: "IX_p_DocumentNaksAttest_to_SeamsType_RowStatus",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "SeamsType_ID");

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
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "WeldGOST14098_ID");

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
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "RowStatus");

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
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "RowStatus");

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
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "WeldPosition_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentProjectNumber_Created_User_ID",
                table: "p_DocumentProjectNumber",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentProjectNumber_Modified_User_ID",
                table: "p_DocumentProjectNumber",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentProjectNumber_RowStatus",
                table: "p_DocumentProjectNumber",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentType_Created_User_ID",
                table: "p_DocumentType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentType_Modified_User_ID",
                table: "p_DocumentType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentType_RowStatus",
                table: "p_DocumentType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_Created_User_ID",
                table: "p_ElectricalSafetyAbilitation",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_Modified_User_ID",
                table: "p_ElectricalSafetyAbilitation",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_RowStatus",
                table: "p_ElectricalSafetyAbilitation",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_AppUser_ID",
                table: "p_Employee",
                column: "AppUser_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_Contragent_ID",
                table: "p_Employee",
                column: "Contragent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_Created_User_ID",
                table: "p_Employee",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_Modified_User_ID",
                table: "p_Employee",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_Person_ID",
                table: "p_Employee",
                column: "Person_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_Position_ID",
                table: "p_Employee",
                column: "Position_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_RowStatus",
                table: "p_Employee",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_Created_User_ID",
                table: "p_GOST",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_Marka_ID",
                table: "p_GOST",
                column: "Marka_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_Modified_User_ID",
                table: "p_GOST",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_RowStatus",
                table: "p_GOST",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_PID_Created_User_ID",
                table: "p_GOST_to_PID",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_PID_Modified_User_ID",
                table: "p_GOST_to_PID",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_PID_PID_ID",
                table: "p_GOST_to_PID",
                column: "PID_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_PID_RowStatus",
                table: "p_GOST_to_PID",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_TitleObject_Created_User_ID",
                table: "p_GOST_to_TitleObject",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_TitleObject_Modified_User_ID",
                table: "p_GOST_to_TitleObject",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_TitleObject_RowStatus",
                table: "p_GOST_to_TitleObject",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_TitleObject_TitleObject_ID",
                table: "p_GOST_to_TitleObject",
                column: "TitleObject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_Created_User_ID",
                table: "p_HIFGroup",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_Modified_User_ID",
                table: "p_HIFGroup",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_RowStatus",
                table: "p_HIFGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_Created_User_ID",
                table: "p_InspectionSubject",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_Modified_User_ID",
                table: "p_InspectionSubject",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_RowStatus",
                table: "p_InspectionSubject",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_Created_User_ID",
                table: "p_InspectionTechnique",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_Modified_User_ID",
                table: "p_InspectionTechnique",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_RowStatus",
                table: "p_InspectionTechnique",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_Created_User_ID",
                table: "p_JointKind",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_Modified_User_ID",
                table: "p_JointKind",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_RowStatus",
                table: "p_JointKind",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_Created_User_ID",
                table: "p_JointType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_Modified_User_ID",
                table: "p_JointType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_RowStatus",
                table: "p_JointType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Marka_Created_User_ID",
                table: "p_Marka",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Marka_Modified_User_ID",
                table: "p_Marka",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Marka_RowStatus",
                table: "p_Marka",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Parameter_Created_User_ID",
                table: "p_Parameter",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Parameter_Modified_User_ID",
                table: "p_Parameter",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Parameter_RowStatus",
                table: "p_Parameter",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Person_Created_User_ID",
                table: "p_Person",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Person_Modified_User_ID",
                table: "p_Person",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Person_RowStatus",
                table: "p_Person",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_PID_Created_User_ID",
                table: "p_PID",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_PID_Modified_User_ID",
                table: "p_PID",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_PID_RowStatus",
                table: "p_PID",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_Created_User_ID",
                table: "p_Position",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_Division_ID",
                table: "p_Position",
                column: "Division_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_Modified_User_ID",
                table: "p_Position",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_RowStatus",
                table: "p_Position",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_Created_User_ID",
                table: "p_QualificationField",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_Modified_User_ID",
                table: "p_QualificationField",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_RowStatus",
                table: "p_QualificationField",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_Created_User_ID",
                table: "p_QualificationLevel",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_Modified_User_ID",
                table: "p_QualificationLevel",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_RowStatus",
                table: "p_QualificationLevel",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_Created_User_ID",
                table: "p_Responsibility",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_Modified_User_ID",
                table: "p_Responsibility",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_RowStatus",
                table: "p_Responsibility",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Role_Created_User_ID",
                table: "p_Role",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Role_Modified_User_ID",
                table: "p_Role",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Role_RowStatus",
                table: "p_Role",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_Created_User_ID",
                table: "p_SeamsType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_Modified_User_ID",
                table: "p_SeamsType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_RowStatus",
                table: "p_SeamsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_Created_User_ID",
                table: "p_ShieldingGas",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_Modified_User_ID",
                table: "p_ShieldingGas",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_RowStatus",
                table: "p_ShieldingGas",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Status_Created_User_ID",
                table: "p_Status",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Status_Modified_User_ID",
                table: "p_Status",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Status_RowStatus",
                table: "p_Status",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_Created_User_ID",
                table: "p_TestMethod",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_Modified_User_ID",
                table: "p_TestMethod",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_RowStatus",
                table: "p_TestMethod",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_Created_User_ID",
                table: "p_TestTypeRef",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_Modified_User_ID",
                table: "p_TestTypeRef",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_RowStatus",
                table: "p_TestTypeRef",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_TitleObject_Created_User_ID",
                table: "p_TitleObject",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TitleObject_Modified_User_ID",
                table: "p_TitleObject",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_TitleObject_RowStatus",
                table: "p_TitleObject",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_Created_User_ID",
                table: "p_WeldGOST14098",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_Modified_User_ID",
                table: "p_WeldGOST14098",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_RowStatus",
                table: "p_WeldGOST14098",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_Created_User_ID",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_Modified_User_ID",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_RowStatus",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_Created_User_ID",
                table: "p_WeldMaterial",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_Modified_User_ID",
                table: "p_WeldMaterial",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_RowStatus",
                table: "p_WeldMaterial",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_Created_User_ID",
                table: "p_WeldMaterialGroup",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_Modified_User_ID",
                table: "p_WeldMaterialGroup",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_RowStatus",
                table: "p_WeldMaterialGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_Created_User_ID",
                table: "p_WeldPasses",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_Modified_User_ID",
                table: "p_WeldPasses",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_RowStatus",
                table: "p_WeldPasses",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_Created_User_ID",
                table: "p_WeldPosition",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_Modified_User_ID",
                table: "p_WeldPosition",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_RowStatus",
                table: "p_WeldPosition",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_Created_User_ID",
                table: "p_WeldType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_Modified_User_ID",
                table: "p_WeldType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_RowStatus",
                table: "p_WeldType",
                column: "RowStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_AccessToPIStaffFunction");

            migrationBuilder.DropTable(
                name: "p_AccessToPIVoltageRange");

            migrationBuilder.DropTable(
                name: "p_AppUser_to_Role");

            migrationBuilder.DropTable(
                name: "p_AttCenterNaks");

            migrationBuilder.DropTable(
                name: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropTable(
                name: "p_Document_to_GOST");

            migrationBuilder.DropTable(
                name: "p_Document_to_PID");

            migrationBuilder.DropTable(
                name: "p_Document_to_Status");

            migrationBuilder.DropTable(
                name: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropTable(
                name: "p_DocumentProjectNumber");

            migrationBuilder.DropTable(
                name: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropTable(
                name: "p_GOST_to_PID");

            migrationBuilder.DropTable(
                name: "p_GOST_to_TitleObject");

            migrationBuilder.DropTable(
                name: "p_InspectionSubject");

            migrationBuilder.DropTable(
                name: "p_InspectionTechnique");

            migrationBuilder.DropTable(
                name: "p_Parameter");

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
                name: "p_TestTypeRef");

            migrationBuilder.DropTable(
                name: "p_WeldPasses");

            migrationBuilder.DropTable(
                name: "p_Role");

            migrationBuilder.DropTable(
                name: "p_Document");

            migrationBuilder.DropTable(
                name: "p_Status");

            migrationBuilder.DropTable(
                name: "p_HIFGroup");

            migrationBuilder.DropTable(
                name: "p_DetailsType");

            migrationBuilder.DropTable(
                name: "p_JointKind");

            migrationBuilder.DropTable(
                name: "p_JointType");

            migrationBuilder.DropTable(
                name: "p_SeamsType");

            migrationBuilder.DropTable(
                name: "p_WeldGOST14098");

            migrationBuilder.DropTable(
                name: "p_WeldMaterial");

            migrationBuilder.DropTable(
                name: "p_WeldMaterialGroup");

            migrationBuilder.DropTable(
                name: "p_DocumentNaksAttest");

            migrationBuilder.DropTable(
                name: "p_WeldPosition");

            migrationBuilder.DropTable(
                name: "p_PID");

            migrationBuilder.DropTable(
                name: "p_GOST");

            migrationBuilder.DropTable(
                name: "p_TitleObject");

            migrationBuilder.DropTable(
                name: "p_DocumentType");

            migrationBuilder.DropTable(
                name: "p_Employee");

            migrationBuilder.DropTable(
                name: "p_DocumentNaks");

            migrationBuilder.DropTable(
                name: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropTable(
                name: "p_Marka");

            migrationBuilder.DropTable(
                name: "p_Position");

            migrationBuilder.DropTable(
                name: "p_Person");

            migrationBuilder.DropTable(
                name: "p_WeldType");

            migrationBuilder.DropTable(
                name: "p_Division");

            migrationBuilder.DropTable(
                name: "p_Contragent");

            migrationBuilder.DropTable(
                name: "p_ContragentRole");

            migrationBuilder.DropTable(
                name: "p_AppUser");

            migrationBuilder.DropTable(
                name: "p_RowStatus");

            migrationBuilder.DropSequence(
                name: "Sequence_CheckList_Number");

            migrationBuilder.DropSequence(
                name: "Sequence_Document_Number");

            migrationBuilder.DropSequence(
                name: "Sequence_Register_Number");
        }
    }
}
