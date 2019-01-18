import DataSource from 'devextreme/data/data_source';
import context from 'api/odata-context';

export function ndtDataSource() {
    return new DataSource(dataSourceConfs.documentNDT);
}

export const dataSourceConfs = {
    documentNDT: { store: context.DocumentNDT },
    documentNDTDetailed: {
        store: context.DocumentNDT,
        expand: [
            'DocumentNDTITSet'
        ]
    },
    documentNDTIT: { store: context.DocumentNDTIT },

}
