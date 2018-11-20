import authHeaders from 'auth/headers.js';

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
            beforeSend: function (e) {                
                e.headers = authHeaders.getAuthHeaders();
            }
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
            key: 'ID',
            keyType: {
                ID: "Guid"
            },
            version: 4,
            beforeSend: function (e) {
                e.headers = authHeaders.getAuthHeaders();
            }

        }
    }
}
