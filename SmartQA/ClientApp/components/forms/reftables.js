import { reftableDatasourceConf } from 'components/reftables/data';

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