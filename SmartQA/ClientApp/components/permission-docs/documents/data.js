import DataSource from 'devextreme/data/data_source';

export function naksDataSource() {
    return new DataSource(dataSourceConfs.documentNaks);
}


export const dataSourceConfs = {
    documentNaks: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/DocumentNaks',
            key: 'DocumentNaks_ID',
            keyType: {
                DocumentNaks_ID: "Guid"
            },
            version: 4
        },
        expand: [
            'DocumentNaksAttestSet',
            'DocumentNaksAttestSet.WeldingEquipmentAutomationLevel',
            'DocumentNaksAttestSet.DetailsTypeSet'
        ]
    },

}
