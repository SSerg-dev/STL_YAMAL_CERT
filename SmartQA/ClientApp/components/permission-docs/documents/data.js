import DataSource from 'devextreme/data/data_source';
import context from 'api/odata-context';

export function naksDataSource() {
    return new DataSource(dataSourceConfs.documentNaks);
}

export function ndtDataSource() {
    return new DataSource(dataSourceConfs.documentNDT);
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

export const dataSourceConfsNDT = {
    documentNDT: { store: context.DocumentNDT },
    documentNDTDetailed: {
        store: context.DocumentNDT,
        expand: [
            'DocumentNDTITSet'
        ]
    },
    documentNDTIT: { store: context.DocumentNDTIT },

}
