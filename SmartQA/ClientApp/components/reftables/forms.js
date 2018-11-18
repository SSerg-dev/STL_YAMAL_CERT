import { reftableDatasourceConf } from './data';

export function reftableFormItem(modelName, label, multiple = false) {
    var conf = {
        label: { text: label }
    };

    if (!multiple) {
        conf.dataField = modelName + '_ID';
        conf.editorType = 'dxSelectBox';
        conf.editorOptions = {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: modelName + "_ID",
            searchEnabled: true,
        }
    } else {
        conf.dataField = modelName + '_IDs';
        conf.editorType = 'dxTagBox';
        conf.editorOptions = {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: modelName + "_ID",
            searchEnabled: true,
        }
    }

    return conf;
}