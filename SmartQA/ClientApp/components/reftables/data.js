import context from 'api/odata-context';


export const dataSourceConfs = {
    reftables: {
        store: context.Reftable,
        sort: [
            'Title'
        ]
    }
}

export function reftableDatasourceConf(modelName) {
    return {
        store: context[modelName]
    }
}
