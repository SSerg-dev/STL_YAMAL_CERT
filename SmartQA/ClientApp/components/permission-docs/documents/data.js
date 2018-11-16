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
            //'Person',
            //'Contragent',
            //'Position'
        ]
    },

    weldType: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/WeldType',
            key: 'WeldType_ID',
            keyType: {
                WeldType_ID: "Guid"
            },
            version: 4
        },
        expand: [
            //'Person',
            //'Contragent',
            //'Position'
        ]
    },
    HIFGroup: {
        store: {
            type: 'odata',
                url:
            baseUrl + 'odata/HIFGroup',
                key:
            'HIFGroup_ID',
                keyType:
            {
                HIFGroup_ID: "Guid"
            },
            version: 4
        },
        expand: [
            //'Person',
            //'Contragent',
            //'Position'
        ]
    }
}
