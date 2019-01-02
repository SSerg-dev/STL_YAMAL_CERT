<template>
    <div>
        <dx-toolbar :items="toolbarItems"/>

        <dx-data-grid ref="dataGrid"
                      
                      :allow-column-resizing="true"
                      :dataSource="dataSource">

            <dx-column data-field="ID"
                       cell-template="idCellTemplate"
                       caption="ID" />

            <dx-column data-field="Issue_Date"
                       data-type="datetime" />
            
            <dx-column data-field="Document_Date"
                       data-type="date"
                       caption="Document_Date" />
            
            <dx-column data-field="Document_Number"
                       caption="Document_Number" />
            
            <dx-column data-field="Document_Name"
                       caption="Document_Name" />

            <div slot="idCellTemplate" slot-scope="cellInfo">
                <router-link :to="{ name: 'document-edit', params: { id: cellInfo.data.ID }}">
                    {{ cellInfo.data.Document_Code.toString() }}    
                </router-link>
            </div>
            
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
                loading: false,
                dataSource: dataSourceConfs.document,
                toolbarItems: [{
                    location: 'before',
                    widget: 'dxButton',
                    options: {
                        type: 'add',
                        icon: 'add',
                        text: 'Создать документ',
                        onClick: this.onNewDocumentClick
                    }
                }]
            }
        },
        methods: {
            onNewDocumentClick(event) {
                let ds = new DataSource(this.dataSource);

                ds.store().insert({})
                    .then(function (data) {
                        
                    });
            }
        }
    }
</script>

<style scoped>

</style>