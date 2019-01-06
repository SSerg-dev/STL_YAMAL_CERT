import ODataContext from "devextreme/data/odata/context"
import authHeaders from 'auth/headers.js';
import notify from 'devextreme/ui/notify';

function common_entity_conf(options = Object()) {
    let default_options = {
        key: 'ID',
        keyType: {
            ID: "Guid"
        }
    };
    return Object.assign(default_options, options)
}

let context = new ODataContext({
    url: baseUrl + "odata/",
    errorHandler: function (error) {
        notify(error.message, 'error');
    },
    beforeSend: function (e) {
        e.headers = authHeaders.getAuthHeaders();
    },
    deserializeDates: false,
    version: 4,
    entities: {
        Employee: common_entity_conf(),
        Person: common_entity_conf(),
        Contragent: common_entity_conf(),
        Document: common_entity_conf(),
        DocumentUI: common_entity_conf(),
        AppUser: common_entity_conf(),
        Role: common_entity_conf(),
        DocumentNaks: common_entity_conf(),
        DocumentNaksAttest: common_entity_conf(),
        AccessToPIStaffFunction: common_entity_conf(),
        AccessToPIVoltageRange: common_entity_conf(),
        AttCenterNaks: common_entity_conf(),
        AuthToSignInspActsForWSUN: common_entity_conf(),
        ContragentRole: common_entity_conf(),
        DetailsType: common_entity_conf(),
        Division: common_entity_conf(),
        ElectricalSafetyAbilitation: common_entity_conf(),
        HIFGroup: common_entity_conf(),
        InspectionSubject: common_entity_conf(),
        InspectionTechnique: common_entity_conf(),
        JointKind: common_entity_conf(),
        JointType: common_entity_conf(),
        Level: common_entity_conf(),
        Position: common_entity_conf(),
        QualificationField: common_entity_conf(),
        QualificationLevel: common_entity_conf(),
        Responsibility: common_entity_conf(),
        SeamsType: common_entity_conf(),
        ShieldingGas: common_entity_conf(),
        StaffFunction: common_entity_conf(),
        TestMethod: common_entity_conf(),
        TestTypeRef: common_entity_conf(),
        VoltageRange: common_entity_conf(),
        WeldGOST14098: common_entity_conf(),
        WeldingEquipmentAutomationLevel: common_entity_conf(),
        WeldMaterial: common_entity_conf(),
        WeldMaterialGroup: common_entity_conf(),
        WeldPasses: common_entity_conf(),
        WeldPosition: common_entity_conf(),
        WeldType: common_entity_conf(),
        DocumentProjectNumber: common_entity_conf(),
        DocumentType: common_entity_conf(),
        Marka: common_entity_conf(),
        TitleObject: common_entity_conf(),
        Status: common_entity_conf(),
        GOST: common_entity_conf(),
        PID: common_entity_conf(),
        Reftable : { key: "modelName", keyType: { modelName: "String" }}
    },
});


export default context;