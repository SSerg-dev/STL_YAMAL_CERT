export const dataSourceConfs = {
    reftables: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/Reftable',
            version: 4,
            key: 'modelName',
            keyType: {
                modelName: "String"
            },            
        },
        sort: [
            'Title'
        ]
    }
}

export function reftableDatasourceConf(modelName) {
    return {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/' + modelName,
            key: modelName + '_ID',
            keyType: {
                WeldType_ID: "Guid"
            },
            version: 4
        }
    }
}
