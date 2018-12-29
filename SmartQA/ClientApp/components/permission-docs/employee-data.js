import DataSource from 'devextreme/data/data_source';
import authHeaders from 'auth/headers.js';

export function employeeDataSource() {
    return new DataSource(employeeDataSourceSettings);
}

export const employeeDataSourceSettings = {
    store: {
        type: 'odata',
        url: baseUrl + 'odata/Employee',
        key: 'ID',
        keyType: {
            ID: "Guid"
        },
        beforeSend: function (e) {
            e.headers = authHeaders.getAuthHeaders();
        },
        version: 4
    },
    expand: [
        'Person',
        'Contragent',
        'Position'
    ]
}