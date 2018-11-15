import DataSource from 'devextreme/data/data_source';

export function employeeDataSource() {
    return new DataSource(employeeDataSourceSettings);
}

export const employeeDataSourceSettings = {
    store: {
        type: 'odata',
        url: '/odata/Employee',
        key: 'Employee_ID',
        keyType: {
            Employee_ID: "Guid"         
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
        url: '/odata/Contragent',
        version: 4
    }
}

export const positionDataSource = {
    store: {
        type: 'odata',
        url: '/odata/Position',
        version: 4
    }
}