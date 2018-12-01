import DataSource from 'devextreme/data/data_source';
import authHeaders from 'auth/headers.js';

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
            beforeSend: function (e) {
                e.headers = authHeaders.getAuthHeaders();
            },
            version: 4
        }
    },
    documentNaksDetailed: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/DocumentNaks',
            key: 'DocumentNaks_ID',
            keyType: {
                DocumentNaks_ID: "Guid"
            },
            beforeSend: function (e) {
                e.headers = authHeaders.getAuthHeaders();
            },
            version: 4
        },
        expand: [
            'DocumentNaksAttestSet'
        ]
    },
    documentNaksAttest: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/DocumentNaksAttest',
            key: 'ID',
            keyType: {
                ID: "Guid"
            },
            beforeSend: function (e) {
                e.headers = authHeaders.getAuthHeaders();
            },
            version: 4
        }
        
    },

}
