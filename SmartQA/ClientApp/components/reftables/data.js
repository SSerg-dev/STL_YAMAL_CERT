
export const dataSourceConfs = {
    reftables: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/Reftable',
            version: 4,
            key: 'modelName',
            keyType: {
                modelName: "String"
            }
        },
        expand: []
    }
}
