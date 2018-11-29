import { reftableDatasourceConf } from 'components/reftables/data';
import $ from 'jquery';


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
export function reftableFormItem2(modelName, label, multiple = false, required = true) {
    var conf = {
        label: { text: label },
        editorOptions: {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: "ID",
            searchEnabled: true,
            onValueChanged: function (e) {
                console.log(e);
                let dxForm = $(e.element).closest('.dx-form').get()[0].__vue__.instance;
                //TODO переделать на отслеживание не GUID, а текста Ручной ввод
                let isCustom = e.value.map(function (x) { return x._value; }).indexOf("6100a1f1-1716-4956-4904-08d654edd27a"); 
                let isDisabled = true;
                if (isCustom < 0) {
                    isDisabled = true;
                } else {
                    isDisabled = false;
                }               
                dxForm.getEditor("WeldingWire").option("disabled", isDisabled); 
                dxForm.getEditor("ShieldingGasFlux").option("disabled", isDisabled);   

            }
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