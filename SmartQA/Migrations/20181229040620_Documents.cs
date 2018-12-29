using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_AppUser_AppUser_Id",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_Position_Position_Id",
                table: "p_Employee");

            migrationBuilder.DropIndex(
                name: "IX_p_AppUser_to_Role_AppUser_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.RenameColumn(
                name: "Parent_Id",
                table: "p_TestMethod",
                newName: "Parent_ID");

            migrationBuilder.RenameColumn(
                name: "Parent_Id",
                table: "p_QualificationField",
                newName: "Parent_ID");

            migrationBuilder.RenameColumn(
                name: "Parent_Id",
                table: "p_InspectionSubject",
                newName: "Parent_ID");

            migrationBuilder.RenameColumn(
                name: "Position_Id",
                table: "p_Employee",
                newName: "Position_ID");

            migrationBuilder.RenameColumn(
                name: "AppUser_Id",
                table: "p_Employee",
                newName: "AppUser_ID");

            migrationBuilder.RenameIndex(
                name: "IX_p_Employee_Position_Id",
                table: "p_Employee",
                newName: "IX_p_Employee_Position_ID");

            migrationBuilder.RenameIndex(
                name: "IX_p_Employee_AppUser_Id",
                table: "p_Employee",
                newName: "IX_p_Employee_AppUser_ID");

            migrationBuilder.CreateSequence(
                name: "Sequence_CheckList_Number");

            migrationBuilder.CreateSequence(
                name: "Sequence_Document_Number");

            migrationBuilder.CreateSequence(
                name: "Sequence_Register_Number");

            migrationBuilder.AlterColumn<string>(
                name: "WeldType_Code",
                table: "p_WeldType",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldType",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldType_ID",
                table: "p_WeldType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "WeldPosition_Code",
                table: "p_WeldPosition",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldPosition",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldPosition_ID",
                table: "p_WeldPosition",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "WeldPasses_Code",
                table: "p_WeldPasses",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldPasses",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldPasses_ID",
                table: "p_WeldPasses",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldMaterialGroup",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldMaterialGroup_ID",
                table: "p_WeldMaterialGroup",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "WeldMaterial_Code",
                table: "p_WeldMaterial",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldMaterial",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldMaterial_ID",
                table: "p_WeldMaterial",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldingEquipmentAutomationLevel",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldingEquipmentAutomationLevel_ID",
                table: "p_WeldingEquipmentAutomationLevel",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "WeldGOST14098_Code",
                table: "p_WeldGOST14098",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldGOST14098",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldGOST14098_ID",
                table: "p_WeldGOST14098",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "TestTypeRef_Code",
                table: "p_TestTypeRef",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_TestTypeRef",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TestTypeRef_ID",
                table: "p_TestTypeRef",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Description_Eng",
                table: "p_TestTypeRef",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestMethod_Code",
                table: "p_TestMethod",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent_ID",
                table: "p_TestMethod",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_TestMethod",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TestMethod_ID",
                table: "p_TestMethod",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ShieldingGas_Code",
                table: "p_ShieldingGas",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_ShieldingGas",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShieldingGas_ID",
                table: "p_ShieldingGas",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "SeamsType_Code",
                table: "p_SeamsType",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_SeamsType",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SeamsType_ID",
                table: "p_SeamsType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Role_Code",
                table: "p_Role",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Role_ID",
                table: "p_Role",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Responsibility_Code",
                table: "p_Responsibility",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_Responsibility",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Responsibility_ID",
                table: "p_Responsibility",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "QualificationLevel_Code",
                table: "p_QualificationLevel",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_QualificationLevel",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationLevel_ID",
                table: "p_QualificationLevel",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "QualificationField_Code",
                table: "p_QualificationField",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent_ID",
                table: "p_QualificationField",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_QualificationField",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationField_ID",
                table: "p_QualificationField",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Position_Code",
                table: "p_Position",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_Position",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Eng",
                table: "p_Position",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Position_ID",
                table: "p_Position",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Person_ID",
                table: "p_Person",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "JointType_Code",
                table: "p_JointType",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_JointType",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JointType_ID",
                table: "p_JointType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "JointKind_Code",
                table: "p_JointKind",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_JointKind",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JointKind_ID",
                table: "p_JointKind",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "InspectionTechnique_Code",
                table: "p_InspectionTechnique",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_InspectionTechnique",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionTechnique_ID",
                table: "p_InspectionTechnique",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "InspectionSubject_Code",
                table: "p_InspectionSubject",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent_ID",
                table: "p_InspectionSubject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_InspectionSubject",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionSubject_ID",
                table: "p_InspectionSubject",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "HIFGroup_Code",
                table: "p_HIFGroup",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_HIFGroup",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HIFGroup_ID",
                table: "p_HIFGroup",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Position_ID",
                table: "p_Employee",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Employee_Code",
                table: "p_Employee",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Employee_ID",
                table: "p_Employee",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_ElectricalSafetyAbilitation",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ElectricalSafetyAbilitation_ID",
                table: "p_ElectricalSafetyAbilitation",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaks_to_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaks_ID",
                table: "p_DocumentNaks",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Division_Name",
                table: "p_Division",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Division_Code",
                table: "p_Division",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Division_ID",
                table: "p_Division",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "DetailsType_Code",
                table: "p_DetailsType",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_DetailsType",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DetailsType_ID",
                table: "p_DetailsType",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_Contragent",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Eng",
                table: "p_Contragent",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contragent_Code",
                table: "p_Contragent",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "Contragent_ID",
                table: "p_Contragent",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ContragentRole_ID",
                table: "p_Contragent",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AuthToSignInspActsForWSUN",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthToSignInspActsForWSUN_ID",
                table: "p_AuthToSignInspActsForWSUN",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "AttCenterNaks_Code",
                table: "p_AttCenterNaks",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AttCenterNaks",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AttCenterNaks_ID",
                table: "p_AttCenterNaks",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUser_to_Role_ID",
                table: "p_AppUser_to_Role",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "User_Password",
                table: "p_AppUser",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "p_AppUser",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUser_Code",
                table: "p_AppUser",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUser_ID",
                table: "p_AppUser",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AccessToPIVoltageRange",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccessToPIVoltageRange_ID",
                table: "p_AccessToPIVoltageRange",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AccessToPIStaffFunction",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccessToPIStaffFunction_ID",
                table: "p_AccessToPIStaffFunction",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldType_WeldType_Code",
                table: "p_WeldType",
                column: "WeldType_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldPosition_WeldPosition_Code",
                table: "p_WeldPosition",
                column: "WeldPosition_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldPasses_WeldPasses_Code",
                table: "p_WeldPasses",
                column: "WeldPasses_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldMaterialGroup_WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup",
                column: "WeldMaterialGroup_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldMaterial_WeldMaterial_Code",
                table: "p_WeldMaterial",
                column: "WeldMaterial_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "WeldingEquipmentAutomationLevel_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_WeldGOST14098_WeldGOST14098_Code",
                table: "p_WeldGOST14098",
                column: "WeldGOST14098_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_TestTypeRef_TestTypeRef_Code",
                table: "p_TestTypeRef",
                column: "TestTypeRef_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_TestMethod_TestMethod_Code",
                table: "p_TestMethod",
                column: "TestMethod_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_ShieldingGas_ShieldingGas_Code",
                table: "p_ShieldingGas",
                column: "ShieldingGas_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_SeamsType_SeamsType_Code",
                table: "p_SeamsType",
                column: "SeamsType_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Responsibility_Responsibility_Code",
                table: "p_Responsibility",
                column: "Responsibility_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_QualificationLevel_QualificationLevel_Code",
                table: "p_QualificationLevel",
                column: "QualificationLevel_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_QualificationField_QualificationField_Code",
                table: "p_QualificationField",
                column: "QualificationField_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Position_Position_Code",
                table: "p_Position",
                column: "Position_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_JointType_JointType_Code",
                table: "p_JointType",
                column: "JointType_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_JointKind_JointKind_Code",
                table: "p_JointKind",
                column: "JointKind_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_InspectionTechnique_InspectionTechnique_Code",
                table: "p_InspectionTechnique",
                column: "InspectionTechnique_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_InspectionSubject_InspectionSubject_Code",
                table: "p_InspectionSubject",
                column: "InspectionSubject_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_HIFGroup_HIFGroup_Code",
                table: "p_HIFGroup",
                column: "HIFGroup_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_p_Employee",
                table: "p_Employee",
                column: "Employee_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation",
                column: "ElectricalSafetyAbilitation_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_p_Division",
                table: "p_Division",
                column: "Division_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_DetailsType_DetailsType_Code",
                table: "p_DetailsType",
                column: "DetailsType_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_p_Contragent",
                table: "p_Contragent",
                column: "Contragent_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_AuthToSignInspActsForWSUN_AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN",
                column: "AuthToSignInspActsForWSUN_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_AttCenterNaks_AttCenterNaks_Code",
                table: "p_AttCenterNaks",
                column: "AttCenterNaks_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_p_AppUser_to_Role",
                table: "p_AppUser_to_Role",
                columns: new[] { "AppUser_ID", "Role_ID" });

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_p_AppUser",
                table: "p_AppUser",
                column: "AppUser_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_AccessToPIVoltageRange_AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange",
                column: "AccessToPIVoltageRange_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_AccessToPIStaffFunction_AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction",
                column: "AccessToPIStaffFunction_Code");

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
                name: "p_ContragentRole",
                columns: table => new
                {
                    ContragentRole_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
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
                name: "p_DocumentProjectNumber",
                columns: table => new
                {
                    DocumentProjectNumber_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
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
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    DocumentType_Code = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_DocumentType", x => x.DocumentType_ID);
                    table.UniqueConstraint("UQ_p_DocumentType", x => x.DocumentType_Code);
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
                name: "p_Marka",
                columns: table => new
                {
                    Marka_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
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
                name: "p_PID",
                columns: table => new
                {
                    PID_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
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
                name: "p_Status",
                columns: table => new
                {
                    Status_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
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
                name: "p_TitleObject",
                columns: table => new
                {
                    TitleObject_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
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
                name: "p_Document",
                columns: table => new
                {
                    Document_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Document_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Issue_Date = table.Column<DateTime>(nullable: false),
                    Document_Number = table.Column<string>(maxLength: 255, nullable: true),
                    Document_Date = table.Column<DateTime>(nullable: true),
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
                    table.UniqueConstraint("UQ_p_Document", x => x.Document_Code);
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
                name: "p_GOST",
                columns: table => new
                {
                    GOST_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    GOST_Code = table.Column<string>(maxLength: 255, nullable: false),
                    Description_Rus = table.Column<string>(maxLength: 255, nullable: true),
                    Marka_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_GOST", x => x.GOST_ID);
                    table.UniqueConstraint("UQ_p_GOST", x => x.GOST_Code);
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
                name: "p_Document_to_PID",
                columns: table => new
                {
                    Document_to_PID_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    PID_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Document_to_PID", x => x.Document_to_PID_ID);
                    table.UniqueConstraint("UQ_p_Document_to_PID", x => new { x.Document_ID, x.PID_ID });
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
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    Status_ID = table.Column<Guid>(nullable: false),
                    DTS_Start = table.Column<DateTime>(nullable: false),
                    DTS_End = table.Column<DateTime>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "p_Document_to_GOST",
                columns: table => new
                {
                    Document_to_GOST_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    Document_ID = table.Column<Guid>(nullable: false),
                    GOST_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_Document_to_GOST", x => x.Document_to_GOST_ID);
                    table.UniqueConstraint("UQ_p_Document_to_GOST", x => new { x.Document_ID, x.GOST_ID });
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
                name: "p_GOST_to_PID",
                columns: table => new
                {
                    GOST_to_PID_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    GOST_ID = table.Column<Guid>(nullable: false),
                    PID_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_GOST_to_PID", x => x.GOST_to_PID_ID);
                    table.UniqueConstraint("UQ_p_GOST_to_PID", x => new { x.GOST_ID, x.PID_ID });
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
                    RowStatus = table.Column<int>(nullable: false),
                    Insert_DTS = table.Column<DateTime>(nullable: false),
                    Update_DTS = table.Column<DateTime>(nullable: false),
                    Created_User_ID = table.Column<Guid>(nullable: false),
                    Modified_User_ID = table.Column<Guid>(nullable: false),
                    GOST_ID = table.Column<Guid>(nullable: false),
                    TitleObject_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_p_GOST_to_TitleObject", x => x.GOST_to_TitleObject_ID);
                    table.UniqueConstraint("UQ_p_GOST_to_TitleObject", x => new { x.GOST_ID, x.TitleObject_ID });
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
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "root", "superuser", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2018, 12, 29, 4, 6, 19, 607, DateTimeKind.Utc).AddTicks(751), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0, new DateTime(2018, 12, 29, 4, 6, 19, 607, DateTimeKind.Utc).AddTicks(1138), new byte[] { 195, 146, 201, 42, 72, 160, 70, 204, 48, 231, 104, 185, 151, 82, 178, 138 } });

            migrationBuilder.InsertData(
                table: "p_Status",
                columns: new[] { "Status_ID", "Created_User_ID", "Description_Eng", "Description_Rus", "EntityLocked", "Insert_DTS", "Modified_User_ID", "ReportColor", "ReportOrder", "RowStatus", "StatusEntity", "Status_Code", "Update_DTS" },
                values: new object[,]
                {
                    { new Guid("5e1a9818-f8a5-481c-20f0-c16d362df87a"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7894), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Document", "wDd", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7897) },
                    { new Guid("27d94262-2830-1d24-5764-2a90ae9094e7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Fixed", "Исправлено", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIf", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915) },
                    { new Guid("9ac37fd3-b2c2-c309-5f39-69fb7150a824"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Issued", "Выпущено", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIss", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915) },
                    { new Guid("6e2d4292-5383-bd3a-24fc-e67857fbf182"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLId", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912) },
                    { new Guid("60486e51-ef01-2480-9e25-7ae2f56f034d"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Fixed", "Замечания устранены", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wCLf", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912) },
                    { new Guid("4f24b41a-dac7-3e73-9c0d-b31fb2f19d56"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Completed", "Проверка завершена", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wСLc", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912) },
                    { new Guid("3dbfcb25-3ec5-f5f6-b619-43a6e0f73926"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Review", "Проверка", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wСLr", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7912) },
                    { new Guid("86cb8686-6b39-13c9-bf28-70cf2d6d62ef"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckList", "wСLd", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909) },
                    { new Guid("c0327b4c-b2eb-32dc-ce07-80f23940350a"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cancelled", "Аннулирован", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCcan", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909) },
                    { new Guid("ce34a401-3dea-c8eb-f304-86c73e9ffd9a"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Approved", "Утверждено", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIa", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915) },
                    { new Guid("95e4f0ea-9378-dc03-cf36-eb9efa314512"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Archived", "Архивирование", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCarh", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909) },
                    { new Guid("e10cd869-3878-29b0-1b30-a4a2855c6986"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "NotApproved", "Отказано в утверждении", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCuna", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906) },
                    { new Guid("2e96ff56-a2c3-7e5f-d06f-28eb06f8106f"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Approvement", "Утверждение", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCua", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906) },
                    { new Guid("bcfd9a12-a2d8-f81c-c7d5-d43f190ed507"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "SecondReview", "Повторная проверка", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCuAsr", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906) },
                    { new Guid("28fe952a-5094-3f4e-96cf-f9cddfae5e74"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "CommentsIncorporation", "Устранение замечаний", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wSCci", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906) },
                    { new Guid("81f3ef08-bfa7-4176-e0c1-54ef6d687b6b"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "ComentsExists", "Выданы замечания", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wSCce", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903) },
                    { new Guid("e65bd063-4b28-9174-db6d-83319a90ad76"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Review", "Проверка", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCCuAr", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903) },
                    { new Guid("ec3dfdb9-2c7a-9a45-9ced-fde8e9fe7617"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Draft", "Черновик", false, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wSCd", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903) },
                    { new Guid("12c12fe0-2085-5d30-87a5-5d98ba3c6ed8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Accepted", "Действующий", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7900), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Document", "wDa", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7903) },
                    { new Guid("55bc74c0-937a-1691-9c19-4d40d6028c96"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "WaitingSMR", "Ожидание завершения СМР", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7906), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "Register", "wCwsmr", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7909) },
                    { new Guid("2192a6b9-d13b-3e13-597c-cdd6ebed10df"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cancelled", "Отменено", true, new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, 0, 0, "CheckItem", "wCLIc", new DateTime(2018, 12, 29, 4, 6, 19, 611, DateTimeKind.Utc).AddTicks(7915) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_RowStatus",
                table: "p_WeldType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_RowStatus",
                table: "p_WeldPosition",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_RowStatus",
                table: "p_WeldPasses",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_RowStatus",
                table: "p_WeldMaterialGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_RowStatus",
                table: "p_WeldMaterial",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_RowStatus",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_RowStatus",
                table: "p_WeldGOST14098",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_RowStatus",
                table: "p_TestTypeRef",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_RowStatus",
                table: "p_TestMethod",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_RowStatus",
                table: "p_ShieldingGas",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_RowStatus",
                table: "p_SeamsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Role_RowStatus",
                table: "p_Role",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_RowStatus",
                table: "p_Responsibility",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_RowStatus",
                table: "p_QualificationLevel",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_RowStatus",
                table: "p_QualificationField",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_RowStatus",
                table: "p_Position",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Person_RowStatus",
                table: "p_Person",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_RowStatus",
                table: "p_JointType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_RowStatus",
                table: "p_JointKind",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_RowStatus",
                table: "p_InspectionTechnique",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_RowStatus",
                table: "p_InspectionSubject",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_RowStatus",
                table: "p_HIFGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_RowStatus",
                table: "p_Employee",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_RowStatus",
                table: "p_ElectricalSafetyAbilitation",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_RowStatus",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_RowStatus",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_JointKind_RowStatus",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_to_DetailsType_RowStatus",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaksAttest_RowStatus",
                table: "p_DocumentNaksAttest",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_to_HIFGroup_RowStatus",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentNaks_RowStatus",
                table: "p_DocumentNaks",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_RowStatus",
                table: "p_Division",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_RowStatus",
                table: "p_DetailsType",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_ContragentRole_ID",
                table: "p_Contragent",
                column: "ContragentRole_ID");

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_RowStatus",
                table: "p_Contragent",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_RowStatus",
                table: "p_AuthToSignInspActsForWSUN",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AttCenterNaks_RowStatus",
                table: "p_AttCenterNaks",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_RowStatus",
                table: "p_AppUser_to_Role",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_RowStatus",
                table: "p_AppUser",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_RowStatus",
                table: "p_AccessToPIVoltageRange",
                column: "RowStatus");

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_RowStatus",
                table: "p_AccessToPIStaffFunction",
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

            migrationBuilder.AddForeignKey(
                name: "FK_p_AccessToPIStaffFunction_p_RowStatus_RowStatus",
                table: "p_AccessToPIStaffFunction",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AccessToPIVoltageRange_p_RowStatus_RowStatus",
                table: "p_AccessToPIVoltageRange",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AppUser_p_RowStatus_RowStatus",
                table: "p_AppUser",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AppUser_to_Role_p_RowStatus_RowStatus",
                table: "p_AppUser_to_Role",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AttCenterNaks_p_RowStatus_RowStatus",
                table: "p_AttCenterNaks",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_AuthToSignInspActsForWSUN_p_RowStatus_RowStatus",
                table: "p_AuthToSignInspActsForWSUN",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Contragent_p_ContragentRole_ContragentRole_ID",
                table: "p_Contragent",
                column: "ContragentRole_ID",
                principalTable: "p_ContragentRole",
                principalColumn: "ContragentRole_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Contragent_p_RowStatus_RowStatus",
                table: "p_Contragent",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DetailsType_p_RowStatus_RowStatus",
                table: "p_DetailsType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Division_p_RowStatus_RowStatus",
                table: "p_Division",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_p_RowStatus_RowStatus",
                table: "p_DocumentNaks",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_RowStatus_RowStatus",
                table: "p_DocumentNaks_to_HIFGroup",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_DetailsType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_JointKind",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_JointType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_SeamsType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_ElectricalSafetyAbilitation_p_RowStatus_RowStatus",
                table: "p_ElectricalSafetyAbilitation",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_AppUser_AppUser_ID",
                table: "p_Employee",
                column: "AppUser_ID",
                principalTable: "p_AppUser",
                principalColumn: "AppUser_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_Position_Position_ID",
                table: "p_Employee",
                column: "Position_ID",
                principalTable: "p_Position",
                principalColumn: "Position_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_RowStatus_RowStatus",
                table: "p_Employee",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_HIFGroup_p_RowStatus_RowStatus",
                table: "p_HIFGroup",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_InspectionSubject_p_RowStatus_RowStatus",
                table: "p_InspectionSubject",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_InspectionTechnique_p_RowStatus_RowStatus",
                table: "p_InspectionTechnique",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_JointKind_p_RowStatus_RowStatus",
                table: "p_JointKind",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_JointType_p_RowStatus_RowStatus",
                table: "p_JointType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Person_p_RowStatus_RowStatus",
                table: "p_Person",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Position_p_RowStatus_RowStatus",
                table: "p_Position",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_QualificationField_p_RowStatus_RowStatus",
                table: "p_QualificationField",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_QualificationLevel_p_RowStatus_RowStatus",
                table: "p_QualificationLevel",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Responsibility_p_RowStatus_RowStatus",
                table: "p_Responsibility",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Role_p_RowStatus_RowStatus",
                table: "p_Role",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_SeamsType_p_RowStatus_RowStatus",
                table: "p_SeamsType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_ShieldingGas_p_RowStatus_RowStatus",
                table: "p_ShieldingGas",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_TestMethod_p_RowStatus_RowStatus",
                table: "p_TestMethod",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_TestTypeRef_p_RowStatus_RowStatus",
                table: "p_TestTypeRef",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldGOST14098_p_RowStatus_RowStatus",
                table: "p_WeldGOST14098",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldingEquipmentAutomationLevel_p_RowStatus_RowStatus",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldMaterial_p_RowStatus_RowStatus",
                table: "p_WeldMaterial",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldMaterialGroup_p_RowStatus_RowStatus",
                table: "p_WeldMaterialGroup",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldPasses_p_RowStatus_RowStatus",
                table: "p_WeldPasses",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldPosition_p_RowStatus_RowStatus",
                table: "p_WeldPosition",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_WeldType_p_RowStatus_RowStatus",
                table: "p_WeldType",
                column: "RowStatus",
                principalTable: "p_RowStatus",
                principalColumn: "RowStatus_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_p_AccessToPIStaffFunction_p_RowStatus_RowStatus",
                table: "p_AccessToPIStaffFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AccessToPIVoltageRange_p_RowStatus_RowStatus",
                table: "p_AccessToPIVoltageRange");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AppUser_p_RowStatus_RowStatus",
                table: "p_AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AppUser_to_Role_p_RowStatus_RowStatus",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AttCenterNaks_p_RowStatus_RowStatus",
                table: "p_AttCenterNaks");

            migrationBuilder.DropForeignKey(
                name: "FK_p_AuthToSignInspActsForWSUN_p_RowStatus_RowStatus",
                table: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Contragent_p_ContragentRole_ContragentRole_ID",
                table: "p_Contragent");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Contragent_p_RowStatus_RowStatus",
                table: "p_Contragent");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DetailsType_p_RowStatus_RowStatus",
                table: "p_DetailsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Division_p_RowStatus_RowStatus",
                table: "p_Division");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_p_RowStatus_RowStatus",
                table: "p_DocumentNaks");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaks_to_HIFGroup_p_RowStatus_RowStatus",
                table: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_DetailsType_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointKind_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_JointType_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_SeamsType_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldGOST14098_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterial_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_DocumentNaksAttest_to_WeldPosition_p_RowStatus_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_p_ElectricalSafetyAbilitation_p_RowStatus_RowStatus",
                table: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_AppUser_AppUser_ID",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_Position_Position_ID",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Employee_p_RowStatus_RowStatus",
                table: "p_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_p_HIFGroup_p_RowStatus_RowStatus",
                table: "p_HIFGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_InspectionSubject_p_RowStatus_RowStatus",
                table: "p_InspectionSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_p_InspectionTechnique_p_RowStatus_RowStatus",
                table: "p_InspectionTechnique");

            migrationBuilder.DropForeignKey(
                name: "FK_p_JointKind_p_RowStatus_RowStatus",
                table: "p_JointKind");

            migrationBuilder.DropForeignKey(
                name: "FK_p_JointType_p_RowStatus_RowStatus",
                table: "p_JointType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Person_p_RowStatus_RowStatus",
                table: "p_Person");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Position_p_RowStatus_RowStatus",
                table: "p_Position");

            migrationBuilder.DropForeignKey(
                name: "FK_p_QualificationField_p_RowStatus_RowStatus",
                table: "p_QualificationField");

            migrationBuilder.DropForeignKey(
                name: "FK_p_QualificationLevel_p_RowStatus_RowStatus",
                table: "p_QualificationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Responsibility_p_RowStatus_RowStatus",
                table: "p_Responsibility");

            migrationBuilder.DropForeignKey(
                name: "FK_p_Role_p_RowStatus_RowStatus",
                table: "p_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_p_SeamsType_p_RowStatus_RowStatus",
                table: "p_SeamsType");

            migrationBuilder.DropForeignKey(
                name: "FK_p_ShieldingGas_p_RowStatus_RowStatus",
                table: "p_ShieldingGas");

            migrationBuilder.DropForeignKey(
                name: "FK_p_TestMethod_p_RowStatus_RowStatus",
                table: "p_TestMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_p_TestTypeRef_p_RowStatus_RowStatus",
                table: "p_TestTypeRef");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldGOST14098_p_RowStatus_RowStatus",
                table: "p_WeldGOST14098");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldingEquipmentAutomationLevel_p_RowStatus_RowStatus",
                table: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldMaterial_p_RowStatus_RowStatus",
                table: "p_WeldMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldMaterialGroup_p_RowStatus_RowStatus",
                table: "p_WeldMaterialGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldPasses_p_RowStatus_RowStatus",
                table: "p_WeldPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldPosition_p_RowStatus_RowStatus",
                table: "p_WeldPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_p_WeldType_p_RowStatus_RowStatus",
                table: "p_WeldType");

            migrationBuilder.DropTable(
                name: "p_ContragentRole");

            migrationBuilder.DropTable(
                name: "p_Document_to_GOST");

            migrationBuilder.DropTable(
                name: "p_Document_to_PID");

            migrationBuilder.DropTable(
                name: "p_Document_to_Status");

            migrationBuilder.DropTable(
                name: "p_DocumentProjectNumber");

            migrationBuilder.DropTable(
                name: "p_GOST_to_PID");

            migrationBuilder.DropTable(
                name: "p_GOST_to_TitleObject");

            migrationBuilder.DropTable(
                name: "p_Document");

            migrationBuilder.DropTable(
                name: "p_Status");

            migrationBuilder.DropTable(
                name: "p_PID");

            migrationBuilder.DropTable(
                name: "p_GOST");

            migrationBuilder.DropTable(
                name: "p_TitleObject");

            migrationBuilder.DropTable(
                name: "p_DocumentType");

            migrationBuilder.DropTable(
                name: "p_Marka");

            migrationBuilder.DropTable(
                name: "p_RowStatus");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldType_WeldType_Code",
                table: "p_WeldType");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldType_RowStatus",
                table: "p_WeldType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldPosition_WeldPosition_Code",
                table: "p_WeldPosition");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldPosition_RowStatus",
                table: "p_WeldPosition");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldPasses_WeldPasses_Code",
                table: "p_WeldPasses");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldPasses_RowStatus",
                table: "p_WeldPasses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldMaterialGroup_WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldMaterialGroup_RowStatus",
                table: "p_WeldMaterialGroup");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldMaterial_WeldMaterial_Code",
                table: "p_WeldMaterial");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldMaterial_RowStatus",
                table: "p_WeldMaterial");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_RowStatus",
                table: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldGOST14098_WeldGOST14098_Code",
                table: "p_WeldGOST14098");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldGOST14098_RowStatus",
                table: "p_WeldGOST14098");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_TestTypeRef_TestTypeRef_Code",
                table: "p_TestTypeRef");

            migrationBuilder.DropIndex(
                name: "IX_p_TestTypeRef_RowStatus",
                table: "p_TestTypeRef");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_TestMethod_TestMethod_Code",
                table: "p_TestMethod");

            migrationBuilder.DropIndex(
                name: "IX_p_TestMethod_RowStatus",
                table: "p_TestMethod");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_ShieldingGas_ShieldingGas_Code",
                table: "p_ShieldingGas");

            migrationBuilder.DropIndex(
                name: "IX_p_ShieldingGas_RowStatus",
                table: "p_ShieldingGas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_SeamsType_SeamsType_Code",
                table: "p_SeamsType");

            migrationBuilder.DropIndex(
                name: "IX_p_SeamsType_RowStatus",
                table: "p_SeamsType");

            migrationBuilder.DropIndex(
                name: "IX_p_Role_RowStatus",
                table: "p_Role");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Responsibility_Responsibility_Code",
                table: "p_Responsibility");

            migrationBuilder.DropIndex(
                name: "IX_p_Responsibility_RowStatus",
                table: "p_Responsibility");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_QualificationLevel_QualificationLevel_Code",
                table: "p_QualificationLevel");

            migrationBuilder.DropIndex(
                name: "IX_p_QualificationLevel_RowStatus",
                table: "p_QualificationLevel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_QualificationField_QualificationField_Code",
                table: "p_QualificationField");

            migrationBuilder.DropIndex(
                name: "IX_p_QualificationField_RowStatus",
                table: "p_QualificationField");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Position_Position_Code",
                table: "p_Position");

            migrationBuilder.DropIndex(
                name: "IX_p_Position_RowStatus",
                table: "p_Position");

            migrationBuilder.DropIndex(
                name: "IX_p_Person_RowStatus",
                table: "p_Person");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_JointType_JointType_Code",
                table: "p_JointType");

            migrationBuilder.DropIndex(
                name: "IX_p_JointType_RowStatus",
                table: "p_JointType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_JointKind_JointKind_Code",
                table: "p_JointKind");

            migrationBuilder.DropIndex(
                name: "IX_p_JointKind_RowStatus",
                table: "p_JointKind");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_InspectionTechnique_InspectionTechnique_Code",
                table: "p_InspectionTechnique");

            migrationBuilder.DropIndex(
                name: "IX_p_InspectionTechnique_RowStatus",
                table: "p_InspectionTechnique");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_InspectionSubject_InspectionSubject_Code",
                table: "p_InspectionSubject");

            migrationBuilder.DropIndex(
                name: "IX_p_InspectionSubject_RowStatus",
                table: "p_InspectionSubject");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_HIFGroup_HIFGroup_Code",
                table: "p_HIFGroup");

            migrationBuilder.DropIndex(
                name: "IX_p_HIFGroup_RowStatus",
                table: "p_HIFGroup");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_p_Employee",
                table: "p_Employee");

            migrationBuilder.DropIndex(
                name: "IX_p_Employee_RowStatus",
                table: "p_Employee");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropIndex(
                name: "IX_p_ElectricalSafetyAbilitation_RowStatus",
                table: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldPosition_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldPosition");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterialGroup_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldMaterial_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldMaterial");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_WeldGOST14098_RowStatus",
                table: "p_DocumentNaksAttest_to_WeldGOST14098");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_SeamsType_RowStatus",
                table: "p_DocumentNaksAttest_to_SeamsType");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_JointType_RowStatus",
                table: "p_DocumentNaksAttest_to_JointType");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_JointKind_RowStatus",
                table: "p_DocumentNaksAttest_to_JointKind");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_to_DetailsType_RowStatus",
                table: "p_DocumentNaksAttest_to_DetailsType");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaksAttest_RowStatus",
                table: "p_DocumentNaksAttest");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaks_to_HIFGroup_RowStatus",
                table: "p_DocumentNaks_to_HIFGroup");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentNaks_RowStatus",
                table: "p_DocumentNaks");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_p_Division",
                table: "p_Division");

            migrationBuilder.DropIndex(
                name: "IX_p_Division_RowStatus",
                table: "p_Division");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_DetailsType_DetailsType_Code",
                table: "p_DetailsType");

            migrationBuilder.DropIndex(
                name: "IX_p_DetailsType_RowStatus",
                table: "p_DetailsType");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_p_Contragent",
                table: "p_Contragent");

            migrationBuilder.DropIndex(
                name: "IX_p_Contragent_ContragentRole_ID",
                table: "p_Contragent");

            migrationBuilder.DropIndex(
                name: "IX_p_Contragent_RowStatus",
                table: "p_Contragent");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AuthToSignInspActsForWSUN_AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_RowStatus",
                table: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AttCenterNaks_AttCenterNaks_Code",
                table: "p_AttCenterNaks");

            migrationBuilder.DropIndex(
                name: "IX_p_AttCenterNaks_RowStatus",
                table: "p_AttCenterNaks");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_p_AppUser_to_Role",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropIndex(
                name: "IX_p_AppUser_to_Role_RowStatus",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_p_AppUser",
                table: "p_AppUser");

            migrationBuilder.DropIndex(
                name: "IX_p_AppUser_RowStatus",
                table: "p_AppUser");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AccessToPIVoltageRange_AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange");

            migrationBuilder.DropIndex(
                name: "IX_p_AccessToPIVoltageRange_RowStatus",
                table: "p_AccessToPIVoltageRange");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AccessToPIStaffFunction_AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction");

            migrationBuilder.DropIndex(
                name: "IX_p_AccessToPIStaffFunction_RowStatus",
                table: "p_AccessToPIStaffFunction");

            migrationBuilder.DropSequence(
                name: "Sequence_CheckList_Number");

            migrationBuilder.DropSequence(
                name: "Sequence_Document_Number");

            migrationBuilder.DropSequence(
                name: "Sequence_Register_Number");

            migrationBuilder.DeleteData(
                table: "p_AppUser",
                keyColumn: "AppUser_ID",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DropColumn(
                name: "Description_Eng",
                table: "p_TestTypeRef");

            migrationBuilder.DropColumn(
                name: "ContragentRole_ID",
                table: "p_Contragent");

            migrationBuilder.RenameColumn(
                name: "Parent_ID",
                table: "p_TestMethod",
                newName: "Parent_Id");

            migrationBuilder.RenameColumn(
                name: "Parent_ID",
                table: "p_QualificationField",
                newName: "Parent_Id");

            migrationBuilder.RenameColumn(
                name: "Parent_ID",
                table: "p_InspectionSubject",
                newName: "Parent_Id");

            migrationBuilder.RenameColumn(
                name: "Position_ID",
                table: "p_Employee",
                newName: "Position_Id");

            migrationBuilder.RenameColumn(
                name: "AppUser_ID",
                table: "p_Employee",
                newName: "AppUser_Id");

            migrationBuilder.RenameIndex(
                name: "IX_p_Employee_Position_ID",
                table: "p_Employee",
                newName: "IX_p_Employee_Position_Id");

            migrationBuilder.RenameIndex(
                name: "IX_p_Employee_AppUser_ID",
                table: "p_Employee",
                newName: "IX_p_Employee_AppUser_Id");

            migrationBuilder.AlterColumn<string>(
                name: "WeldType_Code",
                table: "p_WeldType",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldType_ID",
                table: "p_WeldType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "WeldPosition_Code",
                table: "p_WeldPosition",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldPosition",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldPosition_ID",
                table: "p_WeldPosition",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "WeldPasses_Code",
                table: "p_WeldPasses",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldPasses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldPasses_ID",
                table: "p_WeldPasses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldMaterialGroup",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldMaterialGroup_ID",
                table: "p_WeldMaterialGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "WeldMaterial_Code",
                table: "p_WeldMaterial",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldMaterial",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldMaterial_ID",
                table: "p_WeldMaterial",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldingEquipmentAutomationLevel",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldingEquipmentAutomationLevel_ID",
                table: "p_WeldingEquipmentAutomationLevel",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "WeldGOST14098_Code",
                table: "p_WeldGOST14098",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_WeldGOST14098",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WeldGOST14098_ID",
                table: "p_WeldGOST14098",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "TestTypeRef_Code",
                table: "p_TestTypeRef",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_TestTypeRef",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TestTypeRef_ID",
                table: "p_TestTypeRef",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "TestMethod_Code",
                table: "p_TestMethod",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent_Id",
                table: "p_TestMethod",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_TestMethod",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TestMethod_ID",
                table: "p_TestMethod",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "ShieldingGas_Code",
                table: "p_ShieldingGas",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_ShieldingGas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShieldingGas_ID",
                table: "p_ShieldingGas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "SeamsType_Code",
                table: "p_SeamsType",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_SeamsType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SeamsType_ID",
                table: "p_SeamsType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Role_Code",
                table: "p_Role",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Role_ID",
                table: "p_Role",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Responsibility_Code",
                table: "p_Responsibility",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_Responsibility",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Responsibility_ID",
                table: "p_Responsibility",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "QualificationLevel_Code",
                table: "p_QualificationLevel",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_QualificationLevel",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationLevel_ID",
                table: "p_QualificationLevel",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "QualificationField_Code",
                table: "p_QualificationField",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent_Id",
                table: "p_QualificationField",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_QualificationField",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QualificationField_ID",
                table: "p_QualificationField",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Position_Code",
                table: "p_Position",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Eng",
                table: "p_Position",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_Position",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Position_ID",
                table: "p_Position",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Person_ID",
                table: "p_Person",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "JointType_Code",
                table: "p_JointType",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_JointType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JointType_ID",
                table: "p_JointType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "JointKind_Code",
                table: "p_JointKind",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_JointKind",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JointKind_ID",
                table: "p_JointKind",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "InspectionTechnique_Code",
                table: "p_InspectionTechnique",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_InspectionTechnique",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionTechnique_ID",
                table: "p_InspectionTechnique",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "InspectionSubject_Code",
                table: "p_InspectionSubject",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent_Id",
                table: "p_InspectionSubject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_InspectionSubject",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionSubject_ID",
                table: "p_InspectionSubject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "HIFGroup_Code",
                table: "p_HIFGroup",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_HIFGroup",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HIFGroup_ID",
                table: "p_HIFGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Position_Id",
                table: "p_Employee",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Employee_Code",
                table: "p_Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Employee_ID",
                table: "p_Employee",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_ElectricalSafetyAbilitation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ElectricalSafetyAbilitation_ID",
                table: "p_ElectricalSafetyAbilitation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldPosition_ID",
                table: "p_DocumentNaksAttest_to_WeldPosition",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldMaterialGroup_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterialGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldMaterial_ID",
                table: "p_DocumentNaksAttest_to_WeldMaterial",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_WeldGOST14098_ID",
                table: "p_DocumentNaksAttest_to_WeldGOST14098",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_SeamsType_ID",
                table: "p_DocumentNaksAttest_to_SeamsType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_JointType_ID",
                table: "p_DocumentNaksAttest_to_JointType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_JointKind_ID",
                table: "p_DocumentNaksAttest_to_JointKind",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_to_DetailsType_ID",
                table: "p_DocumentNaksAttest_to_DetailsType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaksAttest_ID",
                table: "p_DocumentNaksAttest",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaks_to_HIFGroup_ID",
                table: "p_DocumentNaks_to_HIFGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentNaks_ID",
                table: "p_DocumentNaks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Division_Name",
                table: "p_Division",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Division_Code",
                table: "p_Division",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Division_ID",
                table: "p_Division",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "DetailsType_Code",
                table: "p_DetailsType",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_DetailsType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DetailsType_ID",
                table: "p_DetailsType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Contragent_Code",
                table: "p_Contragent",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Eng",
                table: "p_Contragent",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_Contragent",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Contragent_ID",
                table: "p_Contragent",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AuthToSignInspActsForWSUN",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthToSignInspActsForWSUN_ID",
                table: "p_AuthToSignInspActsForWSUN",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "AttCenterNaks_Code",
                table: "p_AttCenterNaks",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AttCenterNaks",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AttCenterNaks_ID",
                table: "p_AttCenterNaks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUser_to_Role_ID",
                table: "p_AppUser_to_Role",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<byte[]>(
                name: "User_Password",
                table: "p_AppUser",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "p_AppUser",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUser_Code",
                table: "p_AppUser",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUser_ID",
                table: "p_AppUser",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AccessToPIVoltageRange",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccessToPIVoltageRange_ID",
                table: "p_AccessToPIVoltageRange",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description_Rus",
                table: "p_AccessToPIStaffFunction",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccessToPIStaffFunction_ID",
                table: "p_AccessToPIStaffFunction",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_AppUser_ID",
                table: "p_AppUser_to_Role",
                column: "AppUser_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_AppUser_AppUser_Id",
                table: "p_Employee",
                column: "AppUser_Id",
                principalTable: "p_AppUser",
                principalColumn: "AppUser_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_p_Employee_p_Position_Position_Id",
                table: "p_Employee",
                column: "Position_Id",
                principalTable: "p_Position",
                principalColumn: "Position_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
