using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class UniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldType_WeldType_Code",
                table: "p_WeldType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldPosition_WeldPosition_Code",
                table: "p_WeldPosition");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldPasses_WeldPasses_Code",
                table: "p_WeldPasses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldMaterialGroup_WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldMaterial_WeldMaterial_Code",
                table: "p_WeldMaterial");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_WeldGOST14098_WeldGOST14098_Code",
                table: "p_WeldGOST14098");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_VoltageRange_VoltageRange_Code",
                table: "p_VoltageRange");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_TitleObject_TitleObject_Code",
                table: "p_TitleObject");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_TestTypeRef_TestTypeRef_Code",
                table: "p_TestTypeRef");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_TestMethod_TestMethod_Code",
                table: "p_TestMethod");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_StaffFunction_StaffFunction_Code",
                table: "p_StaffFunction");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_ShieldingGas_ShieldingGas_Code",
                table: "p_ShieldingGas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_SeamsType_SeamsType_Code",
                table: "p_SeamsType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Responsibility_Responsibility_Code",
                table: "p_Responsibility");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_QualificationLevel_QualificationLevel_Code",
                table: "p_QualificationLevel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_QualificationField_QualificationField_Code",
                table: "p_QualificationField");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Position_Position_Code",
                table: "p_Position");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Parameter_Parameter_Code",
                table: "p_Parameter");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Marka_Marka_Code",
                table: "p_Marka");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Level_Level_Code",
                table: "p_Level");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_JointType_JointType_Code",
                table: "p_JointType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_JointKind_JointKind_Code",
                table: "p_JointKind");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_InspectionTechnique_InspectionTechnique_Code",
                table: "p_InspectionTechnique");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_InspectionSubject_InspectionSubject_Code",
                table: "p_InspectionSubject");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_HIFGroup_HIFGroup_Code",
                table: "p_HIFGroup");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_GOST_to_TitleObject_GOST_ID_TitleObject_ID",
                table: "p_GOST_to_TitleObject");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_GOST_to_PID_GOST_ID_PID_ID",
                table: "p_GOST_to_PID");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_GOST_GOST_Code",
                table: "p_GOST");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Employee_Employee_Code",
                table: "p_Employee");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_DocumentType_DocumentType_Code",
                table: "p_DocumentType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_DocumentProjectNumber_DocumentProjectNumber_Code",
                table: "p_DocumentProjectNumber");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Document_to_PID_Document_ID_PID_ID",
                table: "p_Document_to_PID");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Document_to_GOST_Document_ID_GOST_ID",
                table: "p_Document_to_GOST");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Division_Division_Code",
                table: "p_Division");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_DetailsType_DetailsType_Code",
                table: "p_DetailsType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_ContragentRole_ContragentRole_Code",
                table: "p_ContragentRole");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_Contragent_Contragent_Code",
                table: "p_Contragent");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AuthToSignInspActsForWSUN_AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AttCenterNaks_AttCenterNaks_Code",
                table: "p_AttCenterNaks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AppUser_to_Role_AppUser_ID_Role_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AppUser_AppUser_Code",
                table: "p_AppUser");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AccessToPIVoltageRange_AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_p_AccessToPIStaffFunction_AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction");

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldType_WeldType_Code",
                table: "p_WeldType",
                column: "WeldType_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPosition_WeldPosition_Code",
                table: "p_WeldPosition",
                column: "WeldPosition_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldPasses_WeldPasses_Code",
                table: "p_WeldPasses",
                column: "WeldPasses_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterialGroup_WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup",
                column: "WeldMaterialGroup_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldMaterial_WeldMaterial_Code",
                table: "p_WeldMaterial",
                column: "WeldMaterial_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel",
                column: "WeldingEquipmentAutomationLevel_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_WeldGOST14098_WeldGOST14098_Code",
                table: "p_WeldGOST14098",
                column: "WeldGOST14098_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_VoltageRange_VoltageRange_Code",
                table: "p_VoltageRange",
                column: "VoltageRange_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_TitleObject_TitleObject_Code",
                table: "p_TitleObject",
                column: "TitleObject_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_TestTypeRef_TestTypeRef_Code",
                table: "p_TestTypeRef",
                column: "TestTypeRef_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_TestMethod_TestMethod_Code",
                table: "p_TestMethod",
                column: "TestMethod_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_StaffFunction_StaffFunction_Code",
                table: "p_StaffFunction",
                column: "StaffFunction_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_ShieldingGas_ShieldingGas_Code",
                table: "p_ShieldingGas",
                column: "ShieldingGas_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_SeamsType_SeamsType_Code",
                table: "p_SeamsType",
                column: "SeamsType_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Responsibility_Responsibility_Code",
                table: "p_Responsibility",
                column: "Responsibility_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationLevel_QualificationLevel_Code",
                table: "p_QualificationLevel",
                column: "QualificationLevel_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_QualificationField_QualificationField_Code",
                table: "p_QualificationField",
                column: "QualificationField_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Position_Position_Code",
                table: "p_Position",
                column: "Position_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Parameter_Parameter_Code",
                table: "p_Parameter",
                column: "Parameter_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Marka_Marka_Code",
                table: "p_Marka",
                column: "Marka_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Level_Level_Code",
                table: "p_Level",
                column: "Level_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_JointType_JointType_Code",
                table: "p_JointType",
                column: "JointType_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_JointKind_JointKind_Code",
                table: "p_JointKind",
                column: "JointKind_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionTechnique_InspectionTechnique_Code",
                table: "p_InspectionTechnique",
                column: "InspectionTechnique_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_InspectionSubject_InspectionSubject_Code",
                table: "p_InspectionSubject",
                column: "InspectionSubject_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_HIFGroup_HIFGroup_Code",
                table: "p_HIFGroup",
                column: "HIFGroup_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_TitleObject_GOST_ID_TitleObject_ID",
                table: "p_GOST_to_TitleObject",
                columns: new[] { "GOST_ID", "TitleObject_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_to_PID_GOST_ID_PID_ID",
                table: "p_GOST_to_PID",
                columns: new[] { "GOST_ID", "PID_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_GOST_GOST_Code",
                table: "p_GOST",
                column: "GOST_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Employee_Employee_Code",
                table: "p_Employee",
                column: "Employee_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation",
                column: "ElectricalSafetyAbilitation_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentType_DocumentType_Code",
                table: "p_DocumentType",
                column: "DocumentType_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_DocumentProjectNumber_DocumentProjectNumber_Code",
                table: "p_DocumentProjectNumber",
                column: "DocumentProjectNumber_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_PID_Document_ID_PID_ID",
                table: "p_Document_to_PID",
                columns: new[] { "Document_ID", "PID_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Document_to_GOST_Document_ID_GOST_ID",
                table: "p_Document_to_GOST",
                columns: new[] { "Document_ID", "GOST_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Division_Division_Code",
                table: "p_Division",
                column: "Division_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_DetailsType_DetailsType_Code",
                table: "p_DetailsType",
                column: "DetailsType_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_ContragentRole_ContragentRole_Code",
                table: "p_ContragentRole",
                column: "ContragentRole_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_Contragent_Contragent_Code",
                table: "p_Contragent",
                column: "Contragent_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN",
                column: "AuthToSignInspActsForWSUN_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_AttCenterNaks_AttCenterNaks_Code",
                table: "p_AttCenterNaks",
                column: "AttCenterNaks_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_to_Role_AppUser_ID_Role_ID",
                table: "p_AppUser_to_Role",
                columns: new[] { "AppUser_ID", "Role_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_AppUser_AppUser_Code",
                table: "p_AppUser",
                column: "AppUser_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIVoltageRange_AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange",
                column: "AccessToPIVoltageRange_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_p_AccessToPIStaffFunction_AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction",
                column: "AccessToPIStaffFunction_Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_p_WeldType_WeldType_Code",
                table: "p_WeldType");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldPosition_WeldPosition_Code",
                table: "p_WeldPosition");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldPasses_WeldPasses_Code",
                table: "p_WeldPasses");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldMaterialGroup_WeldMaterialGroup_Code",
                table: "p_WeldMaterialGroup");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldMaterial_WeldMaterial_Code",
                table: "p_WeldMaterial");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_Code",
                table: "p_WeldingEquipmentAutomationLevel");

            migrationBuilder.DropIndex(
                name: "IX_p_WeldGOST14098_WeldGOST14098_Code",
                table: "p_WeldGOST14098");

            migrationBuilder.DropIndex(
                name: "IX_p_VoltageRange_VoltageRange_Code",
                table: "p_VoltageRange");

            migrationBuilder.DropIndex(
                name: "IX_p_TitleObject_TitleObject_Code",
                table: "p_TitleObject");

            migrationBuilder.DropIndex(
                name: "IX_p_TestTypeRef_TestTypeRef_Code",
                table: "p_TestTypeRef");

            migrationBuilder.DropIndex(
                name: "IX_p_TestMethod_TestMethod_Code",
                table: "p_TestMethod");

            migrationBuilder.DropIndex(
                name: "IX_p_StaffFunction_StaffFunction_Code",
                table: "p_StaffFunction");

            migrationBuilder.DropIndex(
                name: "IX_p_ShieldingGas_ShieldingGas_Code",
                table: "p_ShieldingGas");

            migrationBuilder.DropIndex(
                name: "IX_p_SeamsType_SeamsType_Code",
                table: "p_SeamsType");

            migrationBuilder.DropIndex(
                name: "IX_p_Responsibility_Responsibility_Code",
                table: "p_Responsibility");

            migrationBuilder.DropIndex(
                name: "IX_p_QualificationLevel_QualificationLevel_Code",
                table: "p_QualificationLevel");

            migrationBuilder.DropIndex(
                name: "IX_p_QualificationField_QualificationField_Code",
                table: "p_QualificationField");

            migrationBuilder.DropIndex(
                name: "IX_p_Position_Position_Code",
                table: "p_Position");

            migrationBuilder.DropIndex(
                name: "IX_p_Parameter_Parameter_Code",
                table: "p_Parameter");

            migrationBuilder.DropIndex(
                name: "IX_p_Marka_Marka_Code",
                table: "p_Marka");

            migrationBuilder.DropIndex(
                name: "IX_p_Level_Level_Code",
                table: "p_Level");

            migrationBuilder.DropIndex(
                name: "IX_p_JointType_JointType_Code",
                table: "p_JointType");

            migrationBuilder.DropIndex(
                name: "IX_p_JointKind_JointKind_Code",
                table: "p_JointKind");

            migrationBuilder.DropIndex(
                name: "IX_p_InspectionTechnique_InspectionTechnique_Code",
                table: "p_InspectionTechnique");

            migrationBuilder.DropIndex(
                name: "IX_p_InspectionSubject_InspectionSubject_Code",
                table: "p_InspectionSubject");

            migrationBuilder.DropIndex(
                name: "IX_p_HIFGroup_HIFGroup_Code",
                table: "p_HIFGroup");

            migrationBuilder.DropIndex(
                name: "IX_p_GOST_to_TitleObject_GOST_ID_TitleObject_ID",
                table: "p_GOST_to_TitleObject");

            migrationBuilder.DropIndex(
                name: "IX_p_GOST_to_PID_GOST_ID_PID_ID",
                table: "p_GOST_to_PID");

            migrationBuilder.DropIndex(
                name: "IX_p_GOST_GOST_Code",
                table: "p_GOST");

            migrationBuilder.DropIndex(
                name: "IX_p_Employee_Employee_Code",
                table: "p_Employee");

            migrationBuilder.DropIndex(
                name: "IX_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentType_DocumentType_Code",
                table: "p_DocumentType");

            migrationBuilder.DropIndex(
                name: "IX_p_DocumentProjectNumber_DocumentProjectNumber_Code",
                table: "p_DocumentProjectNumber");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_PID_Document_ID_PID_ID",
                table: "p_Document_to_PID");

            migrationBuilder.DropIndex(
                name: "IX_p_Document_to_GOST_Document_ID_GOST_ID",
                table: "p_Document_to_GOST");

            migrationBuilder.DropIndex(
                name: "IX_p_Division_Division_Code",
                table: "p_Division");

            migrationBuilder.DropIndex(
                name: "IX_p_DetailsType_DetailsType_Code",
                table: "p_DetailsType");

            migrationBuilder.DropIndex(
                name: "IX_p_ContragentRole_ContragentRole_Code",
                table: "p_ContragentRole");

            migrationBuilder.DropIndex(
                name: "IX_p_Contragent_Contragent_Code",
                table: "p_Contragent");

            migrationBuilder.DropIndex(
                name: "IX_p_AuthToSignInspActsForWSUN_AuthToSignInspActsForWSUN_Code",
                table: "p_AuthToSignInspActsForWSUN");

            migrationBuilder.DropIndex(
                name: "IX_p_AttCenterNaks_AttCenterNaks_Code",
                table: "p_AttCenterNaks");

            migrationBuilder.DropIndex(
                name: "IX_p_AppUser_to_Role_AppUser_ID_Role_ID",
                table: "p_AppUser_to_Role");

            migrationBuilder.DropIndex(
                name: "IX_p_AppUser_AppUser_Code",
                table: "p_AppUser");

            migrationBuilder.DropIndex(
                name: "IX_p_AccessToPIVoltageRange_AccessToPIVoltageRange_Code",
                table: "p_AccessToPIVoltageRange");

            migrationBuilder.DropIndex(
                name: "IX_p_AccessToPIStaffFunction_AccessToPIStaffFunction_Code",
                table: "p_AccessToPIStaffFunction");

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
                name: "AK_p_VoltageRange_VoltageRange_Code",
                table: "p_VoltageRange",
                column: "VoltageRange_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_TitleObject_TitleObject_Code",
                table: "p_TitleObject",
                column: "TitleObject_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_TestTypeRef_TestTypeRef_Code",
                table: "p_TestTypeRef",
                column: "TestTypeRef_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_TestMethod_TestMethod_Code",
                table: "p_TestMethod",
                column: "TestMethod_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_StaffFunction_StaffFunction_Code",
                table: "p_StaffFunction",
                column: "StaffFunction_Code");

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
                name: "AK_p_Parameter_Parameter_Code",
                table: "p_Parameter",
                column: "Parameter_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Marka_Marka_Code",
                table: "p_Marka",
                column: "Marka_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Level_Level_Code",
                table: "p_Level",
                column: "Level_Code");

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
                name: "AK_p_GOST_to_TitleObject_GOST_ID_TitleObject_ID",
                table: "p_GOST_to_TitleObject",
                columns: new[] { "GOST_ID", "TitleObject_ID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_GOST_to_PID_GOST_ID_PID_ID",
                table: "p_GOST_to_PID",
                columns: new[] { "GOST_ID", "PID_ID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_GOST_GOST_Code",
                table: "p_GOST",
                column: "GOST_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Employee_Employee_Code",
                table: "p_Employee",
                column: "Employee_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_ElectricalSafetyAbilitation_ElectricalSafetyAbilitation_Code",
                table: "p_ElectricalSafetyAbilitation",
                column: "ElectricalSafetyAbilitation_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_DocumentType_DocumentType_Code",
                table: "p_DocumentType",
                column: "DocumentType_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_DocumentProjectNumber_DocumentProjectNumber_Code",
                table: "p_DocumentProjectNumber",
                column: "DocumentProjectNumber_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Document_to_PID_Document_ID_PID_ID",
                table: "p_Document_to_PID",
                columns: new[] { "Document_ID", "PID_ID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Document_to_GOST_Document_ID_GOST_ID",
                table: "p_Document_to_GOST",
                columns: new[] { "Document_ID", "GOST_ID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Division_Division_Code",
                table: "p_Division",
                column: "Division_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_DetailsType_DetailsType_Code",
                table: "p_DetailsType",
                column: "DetailsType_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_ContragentRole_ContragentRole_Code",
                table: "p_ContragentRole",
                column: "ContragentRole_Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_Contragent_Contragent_Code",
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
                name: "AK_p_AppUser_to_Role_AppUser_ID_Role_ID",
                table: "p_AppUser_to_Role",
                columns: new[] { "AppUser_ID", "Role_ID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_p_AppUser_AppUser_Code",
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
        }
    }
}
