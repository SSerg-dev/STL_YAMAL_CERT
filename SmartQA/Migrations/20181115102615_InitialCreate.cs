using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_AppUser",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    AppUser_ID = table.Column<Guid>(nullable: false),
                    AppUser_Code = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    User_Password = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AppUser", x => x.AppUser_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_Contragent",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Contragent_ID = table.Column<Guid>(nullable: false),
                    Contragent_Code = table.Column<string>(nullable: false),
                    Description_Eng = table.Column<string>(nullable: true),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Contragent", x => x.Contragent_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_DetailsType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DetailsType_ID = table.Column<Guid>(nullable: false),
                    DetailsType_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DetailsType", x => x.DetailsType_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_HIFGroup",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    HIFGroup_ID = table.Column<Guid>(nullable: false),
                    HIFGroup_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_HIFGroup", x => x.HIFGroup_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_JointKind",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    JointKind_ID = table.Column<Guid>(nullable: false),
                    JointKind_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_JointKind", x => x.JointKind_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_JointType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    JointType_ID = table.Column<Guid>(nullable: false),
                    JointType_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_JointType", x => x.JointType_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_Person",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Person_ID = table.Column<Guid>(nullable: false),
                    Person_Code = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "p_Role",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Role_ID = table.Column<Guid>(nullable: false),
                    Role_Code = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "p_SeamsType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    SeamsType_ID = table.Column<Guid>(nullable: false),
                    SeamsType_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_SeamsType", x => x.SeamsType_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_WeldGOST14098",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldGOST14098_ID = table.Column<Guid>(nullable: false),
                    WeldGOST14098_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldGOST14098", x => x.WeldGOST14098_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_WeldingEquipmentAutomationLevel",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldingEquipmentAutomationLevel_ID = table.Column<Guid>(nullable: false),
                    WeldingEquipmentAutomationLevel_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldingEquipmentAutomationLevel", x => x.WeldingEquipmentAutomationLevel_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_WeldMaterial",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldMaterial_ID = table.Column<Guid>(nullable: false),
                    WeldMaterial_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldMaterial", x => x.WeldMaterial_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_WeldMaterialGroup",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldMaterialGroup_ID = table.Column<Guid>(nullable: false),
                    WeldMaterialGroup_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldMaterialGroup", x => x.WeldMaterialGroup_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_WeldPosition",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldPosition_ID = table.Column<Guid>(nullable: false),
                    WeldPosition_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldPosition", x => x.WeldPosition_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_WeldType",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    WeldType_ID = table.Column<Guid>(nullable: false),
                    WeldType_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WeldType", x => x.WeldType_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_Division",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Division_ID = table.Column<Guid>(nullable: false),
                    Division_Code = table.Column<string>(nullable: false),
                    Contragent_ID = table.Column<Guid>(nullable: true),
                    Division_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Division", x => x.Division_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_AppUser_to_Role",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    AppUser_to_Role_ID = table.Column<Guid>(nullable: false),
                    AppUser_ID = table.Column<Guid>(nullable: false),
                    Role_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_AppUser_to_Role", x => x.AppUser_to_Role_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_Position",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Position_ID = table.Column<Guid>(nullable: false),
                    Position_Code = table.Column<string>(nullable: false),
                    Division_ID = table.Column<Guid>(nullable: false),
                    Description_Eng = table.Column<string>(nullable: true),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Position", x => x.Position_ID);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_p_Position_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Employee",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Employee_ID = table.Column<Guid>(nullable: false),
                    Employee_Code = table.Column<string>(nullable: false),
                    Person_ID = table.Column<Guid>(nullable: false),
                    Position_Id = table.Column<Guid>(nullable: true),
                    AppUser_Id = table.Column<Guid>(nullable: true),
                    Contragent_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Employee", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_p_Employee_p_AppUser_AppUser_Id",
                        column: x => x.AppUser_Id,
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
                        name: "FK_p_Employee_p_Position_Position_Id",
                        column: x => x.Position_Id,
                        principalTable: "p_Position",
                        principalColumn: "Position_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_Created_User_ID",
                table: "p_AppUser",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_Modified_User_ID",
                table: "p_AppUser",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_AppUser_ID",
                table: "p_AppUser_to_Role",
                column: "AppUser_ID");

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
                name: "IX_p_Contragent_Created_User_ID",
                table: "p_Contragent",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_Modified_User_ID",
                table: "p_Contragent",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_Created_User_ID",
                table: "p_DetailsType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_Modified_User_ID",
                table: "p_DetailsType",
                column: "Modified_User_ID");

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
                name: "IX_p_Employee_AppUser_Id",
                table: "p_Employee",
                column: "AppUser_Id");

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
                name: "IX_p_Employee_Position_Id",
                table: "p_Employee",
                column: "Position_Id");

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_Created_User_ID",
                table: "p_HIFGroup",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_Modified_User_ID",
                table: "p_HIFGroup",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_Created_User_ID",
                table: "p_JointKind",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_Modified_User_ID",
                table: "p_JointKind",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_Created_User_ID",
                table: "p_JointType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_Modified_User_ID",
                table: "p_JointType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Person_Created_User_ID",
                table: "p_Person",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Person_Modified_User_ID",
                table: "p_Person",
                column: "Modified_User_ID");

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
                name: "IX_p_Role_Created_User_ID",
                table: "p_Role",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Role_Modified_User_ID",
                table: "p_Role",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_Created_User_ID",
                table: "p_SeamsType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_Modified_User_ID",
                table: "p_SeamsType",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_Created_User_ID",
                table: "p_WeldGOST14098",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_Modified_User_ID",
                table: "p_WeldGOST14098",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_Created_User_ID",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_Modified_User_ID",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_Created_User_ID",
                table: "p_WeldMaterial",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_Modified_User_ID",
                table: "p_WeldMaterial",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_Created_User_ID",
                table: "p_WeldMaterialGroup",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_Modified_User_ID",
                table: "p_WeldMaterialGroup",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_Created_User_ID",
                table: "p_WeldPosition",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_Modified_User_ID",
                table: "p_WeldPosition",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_Created_User_ID",
                table: "p_WeldType",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_Modified_User_ID",
                table: "p_WeldType",
                column: "Modified_User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_AppUser_to_Role");

            migrationBuilder.DropTable(
                name: "p_DetailsType");

            migrationBuilder.DropTable(
                name: "p_Employee");

            migrationBuilder.DropTable(
                name: "p_HIFGroup");

            migrationBuilder.DropTable(
                name: "p_JointKind");

            migrationBuilder.DropTable(
                name: "p_JointType");

            migrationBuilder.DropTable(
                name: "p_SeamsType");

            migrationBuilder.DropTable(
                name: "p_WeldGOST14098");

            migrationBuilder.DropTable(
                name: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropTable(
                name: "p_WeldMaterial");

            migrationBuilder.DropTable(
                name: "p_WeldMaterialGroup");

            migrationBuilder.DropTable(
                name: "p_WeldPosition");

            migrationBuilder.DropTable(
                name: "p_WeldType");

            migrationBuilder.DropTable(
                name: "p_Role");

            migrationBuilder.DropTable(
                name: "p_Person");

            migrationBuilder.DropTable(
                name: "p_Position");

            migrationBuilder.DropTable(
                name: "p_Division");

            migrationBuilder.DropTable(
                name: "p_Contragent");

            migrationBuilder.DropTable(
                name: "p_AppUser");
        }
    }
}
