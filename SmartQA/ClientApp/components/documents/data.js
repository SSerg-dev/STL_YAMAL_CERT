import context from 'api/odata-context'

export const dataSourceConfs = {
    document: {
        store: context.Document,
        //expand: ['DocumentType'],
        //expand: ['DocumentStatus', 'DocumentType', "DocumentStatus.Status"]
    },
    documentUI: {
        store: context.DocumentUI,
        
    }
};
