using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class RootUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "p_AppUser",
                keyColumn: "AppUser_ID",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "PasswordHash", "User_Password" },
                values: new object[] { "AQAAAAEAACcQAAAAEM32TERcI2+bweQtjppTckAZD0GyUqWWalim/MrY7rpuVwGFIOJYb39xLcrcR4w5VA==", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "p_AppUser",
                keyColumn: "AppUser_ID",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "PasswordHash", "User_Password" },
                values: new object[] { null, new byte[] { 154, 188, 48, 112, 67, 142, 69, 201, 80, 125, 104, 193, 197, 212, 204, 212 } });
        }
    }
}
