import DataSource from 'devextreme/data/data_source';
import authHeaders from 'auth/headers.js';

export function employeeDataSource() {
    return new DataSource(employeeDataSourceSettings);
}

export const employeeDataSourceSettings = {
    store: {
        type: 'odata',
        url: baseUrl + 'odata/Employee',
        key: 'Employee_ID',
        keyType: {
            Employee_ID: "Guid"
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

export const contragentDataSource = {
    store: {
        type: 'odata',
        url: baseUrl + 'odata/Contragent',
        key: 'Contragent_ID',
        keyType: {
            Contragent_ID: "Guid"
        },
        beforeSend: function (e) {
            e.headers = authHeaders.getAuthHeaders();
        },
        version: 4
    }
};

export const positionDataSource = {
    store: {
        type: 'odata',
        url: baseUrl + 'odata/Position',
        key: 'Position_ID',
        keyType: {
            Position_ID: "Guid"
        },
        beforeSend: function (e) {
            e.headers = authHeaders.getAuthHeaders();
        },
        version: 4
    }
};