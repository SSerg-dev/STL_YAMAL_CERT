import DataSource from 'devextreme/data/data_source';
import context from 'api/odata-context';

export function employeeDataSource() {
    return new DataSource(employeeDataSourceSettings);
}

export const employeeDataSourceSettings = {
    store: context.Employee,
    expand: [
        'Person',
        'Contragent',
        'Position'
    ]
}