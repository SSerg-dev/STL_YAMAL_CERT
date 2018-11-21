using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class AddInspectionTechniqueAndInspectionSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_InspectionSubject",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    InspectionSubject_ID = table.Column<Guid>(nullable: false),
                    Parent_Id = table.Column<Guid>(nullable: false),
                    Structure_Level = table.Column<int>(nullable: false),
                    InspectionSubject_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_InspectionSubject", x => x.InspectionSubject_ID);
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
                });

            migrationBuilder.CreateTable(
                name: "p_InspectionTechnique",
                columns: table => new
                {
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    InspectionTechnique_ID = table.Column<Guid>(nullable: false),
                    InspectionTechnique_Code = table.Column<string>(nullable: false),
                    Description_Rus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_InspectionTechnique", x => x.InspectionTechnique_ID);
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_Created_User_ID",
                table: "p_InspectionSubject",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_Modified_User_ID",
                table: "p_InspectionSubject",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_Created_User_ID",
                table: "p_InspectionTechnique",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_Modified_User_ID",
                table: "p_InspectionTechnique",
                column: "Modified_User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_InspectionSubject");

            migrationBuilder.DropTable(
                name: "p_InspectionTechnique");
        }
    }
}
