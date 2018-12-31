import DataSource from 'devextreme/data/data_source';
import context from 'api/odata-context';

export function naksDataSource() {
    return new DataSource(dataSourceConfs.documentNaks);
}

export const dataSourceConfs = {
    documentNaks: { store: context.DocumentNaks },
    documentNaksDetailed: {
        store: context.DocumentNaks,
        expand: [
            'DocumentNaksAttestSet'
        ]
    },
    documentNaksAttest: { store: context.DocumentNaksAttest },

}
