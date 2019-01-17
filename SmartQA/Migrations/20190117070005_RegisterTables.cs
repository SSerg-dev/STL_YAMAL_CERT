using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class RegisterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_WorkPackage",
                columns: table => new
                {
                    WorkPackage_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    WorkPackage_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true),
                    SiteRussiaYard = table.Column<string>(maxLength: 100, nullable: true),
                    LocationOfWork = table.Column<string>(maxLength: 100, nullable: true),
                    ScopeOfWork = table.Column<string>(maxLength: 1000, nullable: true),
                    AreaOfWork = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_WorkPackage", x => x.WorkPackage_ID);
                    table.ForeignKey(
                        name: "FK_p_WorkPackage_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WorkPackage_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_WorkPackage_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Register",
                columns: table => new
                {
                    Register_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Register_Code = table.Column<string>(maxLength: 255, nullable: false, defaultValueSql: "next value for [Sequence_Register_Number]"),
                    Register_Date = table.Column<DateTime>(type: "date", nullable: true),
                    CurrentIteration = table.Column<int>(nullable: false),
                    Customer_ID = table.Column<Guid>(nullable: true),
                    Contractor_ID = table.Column<Guid>(nullable: true),
                    SubContractor_ID = table.Column<Guid>(nullable: true),
                    Resp_Employee_ID = table.Column<Guid>(nullable: true),
                    WorkPackage_ID = table.Column<Guid>(nullable: true),
                    Comment = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Register", x => x.Register_ID);
                    table.UniqueConstraint("AK_p_Register_Register_Code", x => x.Register_Code);
                    table.ForeignKey(
                        name: "FK_p_Register_p_Contragent_Contractor_ID",
                        column: x => x.Contractor_ID,
                        principalTable: "p_Contragent",
                        principalColumn: "Contragent_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_Contragent_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "p_Contragent",
                        principalColumn: "Contragent_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_Employee_Resp_Employee_ID",
                        column: x => x.Resp_Employee_ID,
                        principalTable: "p_Employee",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_Contragent_SubContractor_ID",
                        column: x => x.SubContractor_ID,
                        principalTable: "p_Contragent",
                        principalColumn: "Contragent_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_p_WorkPackage_WorkPackage_ID",
                        column: x => x.WorkPackage_ID,
                        principalTable: "p_WorkPackage",
                        principalColumn: "WorkPackage_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Register_to_Document",
                columns: table => new
                {
                    Register_to_Document_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Register_ID = table.Column<Guid>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    Iteration = table.Column<int>(nullable: false),
                    NumberInRegister = table.Column<int>(nullable: false),
                    SheetFolderNumber = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Register_to_Document", x => x.Register_to_Document_ID);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Document_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Document_p_Document_Document_ID",
                        column: x => x.Document_ID,
                        principalTable: "p_Document",
                        principalColumn: "Document_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Document_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Document_p_Register_Register_ID",
                        column: x => x.Register_ID,
                        principalTable: "p_Register",
                        principalColumn: "Register_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Document_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Register_to_Marka",
                columns: table => new
                {
                    Register_to_Marka_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Register_ID = table.Column<Guid>(nullable: false),
                    Marka_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Register_to_Marka", x => x.Register_to_Marka_ID);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Marka_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Marka_p_Marka_Marka_ID",
                        column: x => x.Marka_ID,
                        principalTable: "p_Marka",
                        principalColumn: "Marka_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Marka_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Marka_p_Register_Register_ID",
                        column: x => x.Register_ID,
                        principalTable: "p_Register",
                        principalColumn: "Register_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Marka_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Register_to_Status",
                columns: table => new
                {
                    Register_to_Status_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Register_ID = table.Column<Guid>(nullable: false),
                    Status_ID = table.Column<Guid>(nullable: false),
                    DTS_Start = table.Column<DateTimeOffset>(nullable: false),
                    DTS_End = table.Column<DateTimeOffset>(nullable: true),
                    Parent_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Register_to_Status", x => x.Register_to_Status_ID);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Status_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Status_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Status_p_Register_to_Status_Parent_ID",
                        column: x => x.Parent_ID,
                        principalTable: "p_Register_to_Status",
                        principalColumn: "Register_to_Status_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Status_p_Register_Register_ID",
                        column: x => x.Register_ID,
                        principalTable: "p_Register",
                        principalColumn: "Register_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Status_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_Status_p_Status_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "p_Status",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_Register_to_TitleObject",
                columns: table => new
                {
                    Register_to_TitleObject_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Register_ID = table.Column<Guid>(nullable: false),
                    TitleObject_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Register_to_TitleObject", x => x.Register_to_TitleObject_ID);
                    table.ForeignKey(
                        name: "FK_p_Register_to_TitleObject_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_TitleObject_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_TitleObject_p_Register_Register_ID",
                        column: x => x.Register_ID,
                        principalTable: "p_Register",
                        principalColumn: "Register_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_TitleObject_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_Register_to_TitleObject_p_TitleObject_TitleObject_ID",
                        column: x => x.TitleObject_ID,
                        principalTable: "p_TitleObject",
                        principalColumn: "TitleObject_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_Contractor_ID",
                table: "p_Register",
                column: "Contractor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_Created_User_ID",
                table: "p_Register",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_Customer_ID",
                table: "p_Register",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_Modified_User_ID",
                table: "p_Register",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_Resp_Employee_ID",
                table: "p_Register",
                column: "Resp_Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_RowStatus",
                table: "p_Register",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_SubContractor_ID",
                table: "p_Register",
                column: "SubContractor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_WorkPackage_ID",
                table: "p_Register",
                column: "WorkPackage_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Document_Created_User_ID",
                table: "p_Register_to_Document",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Document_Document_ID",
                table: "p_Register_to_Document",
                column: "Document_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Document_Modified_User_ID",
                table: "p_Register_to_Document",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Document_Register_ID",
                table: "p_Register_to_Document",
                column: "Register_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Document_RowStatus",
                table: "p_Register_to_Document",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Marka_Created_User_ID",
                table: "p_Register_to_Marka",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Marka_Marka_ID",
                table: "p_Register_to_Marka",
                column: "Marka_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Marka_Modified_User_ID",
                table: "p_Register_to_Marka",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Marka_RowStatus",
                table: "p_Register_to_Marka",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Marka_Register_ID_Marka_ID",
                table: "p_Register_to_Marka",
                columns: new[] { "Register_ID", "Marka_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Created_User_ID",
                table: "p_Register_to_Status",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Modified_User_ID",
                table: "p_Register_to_Status",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Parent_ID",
                table: "p_Register_to_Status",
                column: "Parent_ID",
                unique: true,
                filter: "[Parent_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Register_ID",
                table: "p_Register_to_Status",
                column: "Register_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_RowStatus",
                table: "p_Register_to_Status",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Status_ID",
                table: "p_Register_to_Status",
                column: "Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_Status_Register_ID_DTS_End",
                table: "p_Register_to_Status",
                columns: new[] { "Register_ID", "DTS_End" },
                unique: true,
                filter: "(DTS_End is null)");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_TitleObject_Created_User_ID",
                table: "p_Register_to_TitleObject",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_TitleObject_Modified_User_ID",
                table: "p_Register_to_TitleObject",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_TitleObject_RowStatus",
                table: "p_Register_to_TitleObject",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_TitleObject_TitleObject_ID",
                table: "p_Register_to_TitleObject",
                column: "TitleObject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Register_to_TitleObject_Register_ID_TitleObject_ID",
                table: "p_Register_to_TitleObject",
                columns: new[] { "Register_ID", "TitleObject_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WorkPackage_Created_User_ID",
                table: "p_WorkPackage",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WorkPackage_Modified_User_ID",
                table: "p_WorkPackage",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_WorkPackage_RowStatus",
                table: "p_WorkPackage",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WorkPackage_WorkPackage_Code",
                table: "p_WorkPackage",
                column: "WorkPackage_Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_Register_to_Document");

            migrationBuilder.DropTable(
                name: "p_Register_to_Marka");

            migrationBuilder.DropTable(
                name: "p_Register_to_Status");

            migrationBuilder.DropTable(
                name: "p_Register_to_TitleObject");

            migrationBuilder.DropTable(
                name: "p_Register");

            migrationBuilder.DropTable(
                name: "p_WorkPackage");
        }
    }
}
