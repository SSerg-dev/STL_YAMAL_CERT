<template>
    <div>
        <dx-toolbar :items="toolbarItems"/>

        <dx-data-grid ref="dataGrid"
                      :allow-column-resizing="true"
                      :dataSource="dataSource">
            
            <dx-column data-field="Document_Code"
                       template="documentCodeCellTemplate"
                       caption="№ карточки" />
            
            <dx-column data-field="Issue_Date"
                       data-type="datetime"
                       caption="Дата карточки" />
            
            <dx-column data-field="Document_Date"
                       caption="Дата" />
                        
            <dx-column data-field="Document_Number"
                       caption="Номер" />
            
            <dx-column data-field="Document_Name"
                       caption="Название" />

            <div slot="documentCodeCellTemplate" slot-scope="cellInfo">
                <router-link :to="{ name: 'document-edit', params: { id: cellInfo.data.ID }}">
                    {{ cellInfo.data.Document_Code.toString() }}    
                </router-link>
            </div>
            
        </dx-data-grid>

        <dx-load-panel :visible="loading"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="true"
                       shading-color="rgba(0,0,0,0.2)"
                       :close-on-outside-click="false" />
    </div>
</template>

<script>
    import { dataSourceConfs } from './data';
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
    import { confirm } from 'devextreme/ui/dialog';
    import { DxDataGrid, DxColumn } from 'devextreme-vue/data-grid';
    
    import { DxPopup, DxLoadPanel } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import 'devextreme/data/odata/store';
    
    export default {
        name: "DocumentList",
        components: {
            FontAwesomeIcon,
            DxDataGrid,
            DxColumn,
            DxPopup,
            DxToolbar,
            DxButton,
            DxLoadPanel
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
                this.loading = true;
                let ds = new DataSource(this.dataSource);

                ds.store().insert({})
                    .then(this.onNewDocumentCreated);
            },
            onNewDocumentCreated(data){
                console.log(data);
                this.loading = false;
                
                this.$router.push({
                    name: 'document-edit',
                    params: { id: data.ID.toString() }
                })
                
            }
            
        }
    }
</script>

<style scoped>

</style>