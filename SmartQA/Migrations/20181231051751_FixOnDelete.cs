using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class FixOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_AppUser_to_Role_p_AppUser_AppUser_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AppUser_to_Role_p_Role_Role_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_DocumentType_DocumentType_ID",
                table: "p_Document");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_Document_Root_ID",
                table: "p_Document");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_GOST_p_Document_Document_ID",
                table: "p_Document_to_GOST");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_GOST_p_GOST_GOST_ID",
                table: "p_Document_to_GOST");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_PID_p_Document_Document_ID",
                table: "p_Document_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_PID_p_PID_PID_ID",
                table: "p_Document_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_Status_p_Document_Document_ID",
                table: "p_Document_to_Status");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_Status_p_Status_Status_ID",
                table: "p_Document_to_Status");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_Person_Person_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_WeldType_WeldType_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_HIFGroup_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DetailsType_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_JointKind_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_JointType_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_WeldMaterial_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_WeldMaterialGroup_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_Person_Person_ID",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_Position_Position_ID",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_PID_p_GOST_GOST_ID",
                table: "p_GOST_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_PID_p_PID_PID_ID",
                table: "p_GOST_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_GOST_GOST_ID",
                table: "p_GOST_to_TitleObject");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_TitleObject_TitleObject_ID",
                table: "p_GOST_to_TitleObject");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status",
                column: "Parent_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_p_AppUser_to_Role_p_AppUser_AppUser_ID",
                table: "p_AppUser_to_Role",
                column: "AppUser_ID",
                principalTable: "p_AppUser",
                principalColumn: "AppUser_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AppUser_to_Role_p_Role_Role_ID",
                table: "p_AppUser_to_Role",
                column: "Role_ID",
                principalTable: "p_Role",
                principalColumn: "Role_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_Document_DocumentType_ID",
                table: "p_Document",
                column: "DocumentType_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_DocumentType_Root_ID",
                table: "p_Document",
                column: "Root_ID",
                principalTable: "p_DocumentType",
                principalColumn: "DocumentType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_GOST_p_Document_Document_ID",
                table: "p_Document_to_GOST",
                column: "Document_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_GOST_p_GOST_GOST_ID",
                table: "p_Document_to_GOST",
                column: "GOST_ID",
                principalTable: "p_GOST",
                principalColumn: "GOST_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_PID_p_Document_Document_ID",
                table: "p_Document_to_PID",
                column: "Document_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_PID_p_PID_PID_ID",
                table: "p_Document_to_PID",
                column: "PID_ID",
                principalTable: "p_PID",
                principalColumn: "PID_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_Status_p_Document_Document_ID",
                table: "p_Document_to_Status",
                column: "Document_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_Status_p_Status_Status_ID",
                table: "p_Document_to_Status",
                column: "Status_ID",
                principalTable: "p_Status",
                principalColumn: "Status_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_Person_Person_ID",
                table: "p_DocumentNaks",
                column: "Person_ID",
                principalTable: "p_Person",
                principalColumn: "Person_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_WeldType_WeldType_ID",
                table: "p_DocumentNaks",
                column: "WeldType_ID",
                principalTable: "p_WeldType",
                principalColumn: "WeldType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "DocumentNaks_ID",
                principalTable: "p_DocumentNaks",
                principalColumn: "DocumentNaks_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_HIFGroup_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "HIFGroup_ID",
                principalTable: "p_HIFGroup",
                principalColumn: "HIFGroup_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaksAttest",
                column: "DocumentNaks_ID",
                principalTable: "p_DocumentNaks",
                principalColumn: "DocumentNaks_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID",
                table: "p_DocumentNaksAttest",
                column: "WeldingEquipmentAutomationLevel_ID",
                principalTable: "p_WeldingEquipmentAutomationLevel",
                principalColumn: "WeldingEquipmentAutomationLevel_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DetailsType_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "DetailsType_ID",
                principalTable: "p_DetailsType",
                principalColumn: "DetailsType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_JointKind_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "JointKind_ID",
                principalTable: "p_JointKind",
                principalColumn: "JointKind_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_JointType_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "JointType_ID",
                principalTable: "p_JointType",
                principalColumn: "JointType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "SeamsType_ID",
                principalTable: "p_SeamsType",
                principalColumn: "SeamsType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "WeldGOST14098_ID",
                principalTable: "p_WeldGOST14098",
                principalColumn: "WeldGOST14098_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_WeldMaterial_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "WeldMaterial_ID",
                principalTable: "p_WeldMaterial",
                principalColumn: "WeldMaterial_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_WeldMaterialGroup_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "WeldMaterialGroup_ID",
                principalTable: "p_WeldMaterialGroup",
                principalColumn: "WeldMaterialGroup_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "WeldPosition_ID",
                principalTable: "p_WeldPosition",
                principalColumn: "WeldPosition_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_Person_Person_ID",
                table: "p_Employee",
                column: "Person_ID",
                principalTable: "p_Person",
                principalColumn: "Person_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_Position_Position_ID",
                table: "p_Employee",
                column: "Position_ID",
                principalTable: "p_Position",
                principalColumn: "Position_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_PID_p_GOST_GOST_ID",
                table: "p_GOST_to_PID",
                column: "GOST_ID",
                principalTable: "p_GOST",
                principalColumn: "GOST_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_PID_p_PID_PID_ID",
                table: "p_GOST_to_PID",
                column: "PID_ID",
                principalTable: "p_PID",
                principalColumn: "PID_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_GOST_GOST_ID",
                table: "p_GOST_to_TitleObject",
                column: "GOST_ID",
                principalTable: "p_GOST",
                principalColumn: "GOST_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_TitleObject_TitleObject_ID",
                table: "p_GOST_to_TitleObject",
                column: "TitleObject_ID",
                principalTable: "p_TitleObject",
                principalColumn: "TitleObject_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_AppUser_to_Role_p_AppUser_AppUser_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AppUser_to_Role_p_Role_Role_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_Document_DocumentType_ID",
                table: "p_Document");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_p_DocumentType_Root_ID",
                table: "p_Document");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_GOST_p_Document_Document_ID",
                table: "p_Document_to_GOST");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_GOST_p_GOST_GOST_ID",
                table: "p_Document_to_GOST");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_PID_p_Document_Document_ID",
                table: "p_Document_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_PID_p_PID_PID_ID",
                table: "p_Document_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_Status_p_Document_Document_ID",
                table: "p_Document_to_Status");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Document_to_Status_p_Status_Status_ID",
                table: "p_Document_to_Status");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_Person_Person_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_WeldType_WeldType_ID",
                table: "p_DocumentNaks");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_HIFGroup_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DetailsType_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_JointKind_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_JointType_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_WeldMaterial_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_WeldMaterialGroup_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_Person_Person_ID",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_Position_Position_ID",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_PID_p_GOST_GOST_ID",
                table: "p_GOST_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_PID_p_PID_PID_ID",
                table: "p_GOST_to_PID");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_GOST_GOST_ID",
                table: "p_GOST_to_TitleObject");

            migrationBuilder.DropForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_TitleObject_TitleObject_ID",
                table: "p_GOST_to_TitleObject");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status");

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_Status_Parent_ID",
                table: "p_Document_to_Status",
                column: "Parent_ID",
                unique: true,
                filter: "[Parent_ID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_p_AppUser_to_Role_p_AppUser_AppUser_ID",
                table: "p_AppUser_to_Role",
                column: "AppUser_ID",
                principalTable: "p_AppUser",
                principalColumn: "AppUser_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AppUser_to_Role_p_Role_Role_ID",
                table: "p_AppUser_to_Role",
                column: "Role_ID",
                principalTable: "p_Role",
                principalColumn: "Role_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_DocumentType_DocumentType_ID",
                table: "p_Document",
                column: "DocumentType_ID",
                principalTable: "p_DocumentType",
                principalColumn: "DocumentType_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_p_Document_Root_ID",
                table: "p_Document",
                column: "Root_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_GOST_p_Document_Document_ID",
                table: "p_Document_to_GOST",
                column: "Document_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_GOST_p_GOST_GOST_ID",
                table: "p_Document_to_GOST",
                column: "GOST_ID",
                principalTable: "p_GOST",
                principalColumn: "GOST_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_PID_p_Document_Document_ID",
                table: "p_Document_to_PID",
                column: "Document_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_PID_p_PID_PID_ID",
                table: "p_Document_to_PID",
                column: "PID_ID",
                principalTable: "p_PID",
                principalColumn: "PID_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_Status_p_Document_Document_ID",
                table: "p_Document_to_Status",
                column: "Document_ID",
                principalTable: "p_Document",
                principalColumn: "Document_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Document_to_Status_p_Status_Status_ID",
                table: "p_Document_to_Status",
                column: "Status_ID",
                principalTable: "p_Status",
                principalColumn: "Status_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_Person_Person_ID",
                table: "p_DocumentNaks",
                column: "Person_ID",
                principalTable: "p_Person",
                principalColumn: "Person_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_WeldType_WeldType_ID",
                table: "p_DocumentNaks",
                column: "WeldType_ID",
                principalTable: "p_WeldType",
                principalColumn: "WeldType_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "DocumentNaks_ID",
                principalTable: "p_DocumentNaks",
                principalColumn: "DocumentNaks_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_HIFGroup_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "HIFGroup_ID",
                principalTable: "p_HIFGroup",
                principalColumn: "HIFGroup_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_p_DocumentNaks_DocumentNaks_ID",
                table: "p_DocumentNaksAttest",
                column: "DocumentNaks_ID",
                principalTable: "p_DocumentNaks",
                principalColumn: "DocumentNaks_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID",
                table: "p_DocumentNaksAttest",
                column: "WeldingEquipmentAutomationLevel_ID",
                principalTable: "p_WeldingEquipmentAutomationLevel",
                principalColumn: "WeldingEquipmentAutomationLevel_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DetailsType_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "DetailsType_ID",
                principalTable: "p_DetailsType",
                principalColumn: "DetailsType_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_JointKind_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "JointKind_ID",
                principalTable: "p_JointKind",
                principalColumn: "JointKind_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_JointType_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "JointType_ID",
                principalTable: "p_JointType",
                principalColumn: "JointType_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "SeamsType_ID",
                principalTable: "p_SeamsType",
                principalColumn: "SeamsType_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "WeldGOST14098_ID",
                principalTable: "p_WeldGOST14098",
                principalColumn: "WeldGOST14098_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_WeldMaterial_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "WeldMaterial_ID",
                principalTable: "p_WeldMaterial",
                principalColumn: "WeldMaterial_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_WeldMaterialGroup_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "WeldMaterialGroup_ID",
                principalTable: "p_WeldMaterialGroup",
                principalColumn: "WeldMaterialGroup_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_DocumentNaksAttest_DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "DocumentNaksAttest_ID",
                principalTable: "p_DocumentNaksAttest",
                principalColumn: "DocumentNaksAttest_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "WeldPosition_ID",
                principalTable: "p_WeldPosition",
                principalColumn: "WeldPosition_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_Person_Person_ID",
                table: "p_Employee",
                column: "Person_ID",
                principalTable: "p_Person",
                principalColumn: "Person_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_Position_Position_ID",
                table: "p_Employee",
                column: "Position_ID",
                principalTable: "p_Position",
                principalColumn: "Position_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_PID_p_GOST_GOST_ID",
                table: "p_GOST_to_PID",
                column: "GOST_ID",
                principalTable: "p_GOST",
                principalColumn: "GOST_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_PID_p_PID_PID_ID",
                table: "p_GOST_to_PID",
                column: "PID_ID",
                principalTable: "p_PID",
                principalColumn: "PID_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_GOST_GOST_ID",
                table: "p_GOST_to_TitleObject",
                column: "GOST_ID",
                principalTable: "p_GOST",
                principalColumn: "GOST_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_GOST_to_TitleObject_p_TitleObject_TitleObject_ID",
                table: "p_GOST_to_TitleObject",
                column: "TitleObject_ID",
                principalTable: "p_TitleObject",
                principalColumn: "TitleObject_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
