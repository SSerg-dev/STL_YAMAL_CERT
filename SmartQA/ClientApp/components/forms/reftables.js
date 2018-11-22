import { reftableDatasourceConf } from 'components/reftables/data';

export function reftableFormItem(modelName, label, multiple = false, required = true) {
    var conf = {
        label: { text: label },
        editorOptions: {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: "ID",
            searchEnabled: true,
        },
        isRequired: required

    };

    if (!multiple) {
        conf.dataField = modelName + '_ID';
        conf.editorType = 'dxSelectBox';
    } else {
        conf.dataField = modelName + '_IDs';
        conf.editorType = 'dxTagBox';       
    }

    return conf;
}