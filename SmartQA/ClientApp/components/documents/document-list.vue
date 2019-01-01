<template>
    <div>
        {{ moment().utcOffset() }}
        <dx-data-grid ref="dataGrid"
                      :allow-column-resizing="true"
                      :dataSource="dataSource">

            <dx-column data-field="ID"
                       caption="ID" />

            <dx-column data-field="Issue_Date"
                       data-type="datetime" />
            
            <dx-column data-field="Issue_Date"
                       data-type="datetime"
                       :calculate-display-value="function(rowData) {
                           return moment(rowData['Issue_Date']).format('LLL');                           
                       }"
                       caption="Issue_Date" />

            <dx-column data-field="Document_Date"
                       caption="Document_Date" />
            
            <dx-column data-field="Document_Number"
                       caption="Document_Number" />
            
            <dx-column data-field="Document_Name"
                       caption="Document_Name" />


        </dx-data-grid>
        
    </div>
</template>

<script>
    import { dataSourceConfs } from './data';
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
    import { confirm } from 'devextreme/ui/dialog';
    import { DxDataGrid, DxColumn } from 'devextreme-vue/data-grid';
    import { DxPopup } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import 'devextreme/data/odata/store';
    import { Subject } from 'rxjs';
    import moment from 'moment';
    
    export default {
        name: "DocumentList",
        components: {
            FontAwesomeIcon,
            DxDataGrid,
            DxColumn,
            DxPopup,
            DxToolbar,
            DxButton
        },
        data() {
            return {
                moment: moment,
                dataSource: dataSourceConfs.document,
                
            }
        }
    }
</script>

<style scoped>

</style>