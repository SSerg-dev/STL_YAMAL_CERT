import { reftableDatasourceConf } from 'components/reftables/data';
import $ from 'jquery';


export function reftableFormItem(modelName, label, multiple = false, required = true) {
    var conf = {
        label: { text: label },
        editorOptions: {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: "ID",
            searchExpr: ['Title', 'Description'],
            searchEnabled: true,
            itemTemplate (itemData, itemIndex, itemElement) {
                var result = '<div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">'
                    + itemData.Title;
                if (itemData.Description) {
                    result += '&emsp;&emsp;<span class="text-muted">'
                        + itemData.Description.toString()
                        + '</span>';
                }
                result += '</div>';
                return result;
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
                    dxForm.getEditor("WeldingWire").option("value", null);
                    dxForm.getEditor("ShieldingGasFlux").option("value", null);

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
export function reftableFormItem3(modelName, label, multiple = false, required = true) {
    var conf = {
        label: { text: label },
        editorOptions: {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: "ID",
            searchEnabled: true,
            onValueChanged: function (e) {                
                let dxForm = $(e.element).closest('.dx-form').get()[0].__vue__.instance;
                //TODO переделать на отслеживание не GUID, а текста Ручной ввод
                let isCustom = e.value.map(function (x) { return x._value; }).indexOf("be4b2aa8-7e0a-49bb-7e28-08d65671be0b");
                let isDisabled = true;
                if (isCustom < 0) {                    
                    dxForm.getEditor("WeldPositionCustom").option("value", null);
                    isDisabled = true;
                } else {
                    isDisabled = false;
                }                
                dxForm.getEditor("WeldPositionCustom").option("disabled", isDisabled);

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
export function reftableFormItem4(modelName, label, multiple = false, required = true) {
    var conf = {
        label: { text: label },
        editorOptions: {
            dataSource: reftableDatasourceConf(modelName),
            displayExpr: "Title",
            valueExpr: "ID",
            searchExpr: ['Title', 'Description'],
            searchEnabled: true,
            itemTemplate(itemData, itemIndex, itemElement) {
                var result = '<div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">'
                    + itemData.Title;
                if (itemData.Description) {
                    result += '&emsp;&emsp;<span class="text-muted">'
                        + itemData.Description.toString()
                        + '</span>';
                }
                result += '</div>';
                return result;
            }
        },
        isRequired: required,
        value:"N/A"

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