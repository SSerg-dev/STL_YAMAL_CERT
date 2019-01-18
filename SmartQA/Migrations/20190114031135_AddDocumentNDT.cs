using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddDocumentNDT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_DocumentNDT",
                columns: table => new
                {
                    DocumentNDT_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Person_ID = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    OrganizationPublishedNDT = table.Column<string>(nullable: true),
                    DocumentNDTID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNDT", x => x.DocumentNDT_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDT_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDT_p_DocumentNDT_DocumentNDTID",
                        column: x => x.DocumentNDTID,
                        principalTable: "p_DocumentNDT",
                        principalColumn: "DocumentNDT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDT_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDT_p_Person_Person_ID",
                        column: x => x.Person_ID,
                        principalTable: "p_Person",
                        principalColumn: "Person_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDT_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNDTIT",
                columns: table => new
                {
                    DocumentNDTIT_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    InspectionSubject = table.Column<string>(nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "Date", nullable: false),
                    DocumentNDT_ID = table.Column<Guid>(nullable: false),
                    InspectionTechnique_ID = table.Column<Guid>(nullable: false),
                    Level_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNDTIT", x => x.DocumentNDTIT_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_p_DocumentNDT_DocumentNDT_ID",
                        column: x => x.DocumentNDT_ID,
                        principalTable: "p_DocumentNDT",
                        principalColumn: "DocumentNDT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_p_InspectionTechnique_InspectionTechnique_ID",
                        column: x => x.InspectionTechnique_ID,
                        principalTable: "p_InspectionTechnique",
                        principalColumn: "InspectionTechnique_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_p_Level_Level_ID",
                        column: x => x.Level_ID,
                        principalTable: "p_Level",
                        principalColumn: "Level_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentNDTIT_to_InspectionSubject",
                columns: table => new
                {
                    DocumentNDTIT_to_InspectionSubject_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    DocumentNDTIT_ID = table.Column<Guid>(nullable: false),
                    InspectionSubject_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentNDTIT_to_InspectionSubject", x => x.DocumentNDTIT_to_InspectionSubject_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_to_InspectionSubject_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_to_InspectionSubject_p_DocumentNDTIT_DocumentNDTIT_ID",
                        column: x => x.DocumentNDTIT_ID,
                        principalTable: "p_DocumentNDTIT",
                        principalColumn: "DocumentNDTIT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_to_InspectionSubject_p_InspectionSubject_InspectionSubject_ID",
                        column: x => x.InspectionSubject_ID,
                        principalTable: "p_InspectionSubject",
                        principalColumn: "InspectionSubject_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_to_InspectionSubject_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentNDTIT_to_InspectionSubject_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDT_Created_User_ID",
                table: "p_DocumentNDT",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDT_DocumentNDTID",
                table: "p_DocumentNDT",
                column: "DocumentNDTID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDT_Modified_User_ID",
                table: "p_DocumentNDT",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDT_Person_ID",
                table: "p_DocumentNDT",
                column: "Person_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDT_RowStatus",
                table: "p_DocumentNDT",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_Created_User_ID",
                table: "p_DocumentNDTIT",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_DocumentNDT_ID",
                table: "p_DocumentNDTIT",
                column: "DocumentNDT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_InspectionTechnique_ID",
                table: "p_DocumentNDTIT",
                column: "InspectionTechnique_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_Level_ID",
                table: "p_DocumentNDTIT",
                column: "Level_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_Modified_User_ID",
                table: "p_DocumentNDTIT",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_RowStatus",
                table: "p_DocumentNDTIT",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_to_InspectionSubject_Created_User_ID",
                table: "p_DocumentNDTIT_to_InspectionSubject",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_to_InspectionSubject_DocumentNDTIT_ID",
                table: "p_DocumentNDTIT_to_InspectionSubject",
                column: "DocumentNDTIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_to_InspectionSubject_InspectionSubject_ID",
                table: "p_DocumentNDTIT_to_InspectionSubject",
                column: "InspectionSubject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_to_InspectionSubject_Modified_User_ID",
                table: "p_DocumentNDTIT_to_InspectionSubject",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNDTIT_to_InspectionSubject_RowStatus",
                table: "p_DocumentNDTIT_to_InspectionSubject",
                column: "RowStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_DocumentNDTIT_to_InspectionSubject");

            migrationBuilder.DropTable(
                name: "p_DocumentNDTIT");

            migrationBuilder.DropTable(
                name: "p_DocumentNDT");
        }
    }
}
