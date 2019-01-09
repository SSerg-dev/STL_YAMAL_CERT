using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class Files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "p_FileDesc",
                columns: table => new
                {
                    FileDesc_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    UploadName = table.Column<string>(maxLength: 1000, nullable: false),
                    FileName = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Length = table.Column<long>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_FileDesc", x => x.FileDesc_ID);
                    table.UniqueConstraint("AK_p_FileDesc_FileName", x => x.FileName);
                    table.ForeignKey(
                        name: "FK_p_FileDesc_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_FileDesc_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_FileDesc_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "p_DocumentAttachment",
                columns: table => new
                {
                    DocumentAttachment_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Insert_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Update_DTS = table.Column<DateTimeOffset>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    FileDesc_ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentAttachment", x => x.DocumentAttachment_ID);
                    table.ForeignKey(
                        name: "FK_p_DocumentAttachment_p_AppUser_Created_User_ID",
                        column: x => x.Created_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentAttachment_p_Document_Document_ID",
                        column: x => x.Document_ID,
                        principalTable: "p_Document",
                        principalColumn: "Document_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentAttachment_p_FileDesc_FileDesc_ID",
                        column: x => x.FileDesc_ID,
                        principalTable: "p_FileDesc",
                        principalColumn: "FileDesc_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentAttachment_p_AppUser_Modified_User_ID",
                        column: x => x.Modified_User_ID,
                        principalTable: "p_AppUser",
                        principalColumn: "AppUser_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_p_DocumentAttachment_p_RowStatus_RowStatus",
                        column: x => x.RowStatus,
                        principalTable: "p_RowStatus",
                        principalColumn: "RowStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentAttachment_Created_User_ID",
                table: "p_DocumentAttachment",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentAttachment_Document_ID",
                table: "p_DocumentAttachment",
                column: "Document_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentAttachment_FileDesc_ID",
                table: "p_DocumentAttachment",
                column: "FileDesc_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentAttachment_Modified_User_ID",
                table: "p_DocumentAttachment",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentAttachment_RowStatus",
                table: "p_DocumentAttachment",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_FileDesc_Created_User_ID",
                table: "p_FileDesc",
                column: "Created_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_FileDesc_Modified_User_ID",
                table: "p_FileDesc",
                column: "Modified_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_FileDesc_RowStatus",
                table: "p_FileDesc",
                column: "RowStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "p_DocumentAttachment");

            migrationBuilder.DropTable(
                name: "p_FileDesc");
        }
    }
}
