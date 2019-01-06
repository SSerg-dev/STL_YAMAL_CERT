<template>
    <div>
        <dx-toolbar :items="toolbarItems"/>

        <dx-data-grid ref="dataGrid"
                      :allow-column-resizing="true"
                      :dataSource="dataSource">
            
            <dx-paging
                enabled="true"
                page-size="10" />

            <dx-column data-field="Status.Description_Rus"
                       caption="Статус" />

            <dx-column data-field="Document_Code"
                       cell-template="documentCodeCellTemplate"
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

            <dx-column data-field="DocumentType.Title"
                       caption="Тип" />

            <div slot="documentCodeCellTemplate" slot-scope="cellInfo">
                <router-link :to="{ name: 'document-edit', params: { id: cellInfo.data.ID }}">
                    {{ cellInfo.data.Document_Code.toString() }}    
                </router-link>
            </div>
            
        </dx-data-grid>

        <dx-load-panel :visible="loading"
                       :delay="100"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="true"
                       shading-color="rgba(0,0,0,0.2)"
                       :close-on-outside-click="false" />
    </div>
</template>

<script>
    import {dataSourceConfs} from './data';
    import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';
    import {DxColumn, DxDataGrid, DxPaging} from 'devextreme-vue/data-grid';

    import {DxLoadPanel, DxPopup} from 'devextreme-vue';
    import {DxButton} from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import context from 'api/odata-context'

    export default {
        name: "DocumentList",
        components: {
            FontAwesomeIcon,
            DxDataGrid,
            DxColumn,
            DxPopup,
            DxToolbar,
            DxButton,
            DxLoadPanel,
            DxPaging
            
        },
        data() {
            return {
                loading: false,
                dataSource: dataSourceConfs.documentUI,
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
                let ds = new DataSource({ store: context.Document });

                ds.store().insert({})
                    .then(this.onNewDocumentCreated);
            },
            onNewDocumentCreated(data){
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