<template>
    <div>
        <h2>{{ modelName }}</h2>
        <dx-data-grid ref="dataGrid"                      
                      v-bind:dataSource="dataSource">

            <dx-editing
                :allow-updating="true"
                :allow-deleting="true"
                :allow-adding="true"
                mode="row"
            />

            <dx-column data-field="Title"
                       caption="Title" />

            <dx-column data-field="Description"
                       caption="Description" />
        </dx-data-grid>
        
      
    </div>
</template>

<script>
    import {
        DxDataGrid,
        DxColumn,
        DxSearchPanel,
        DxPaging,
        DxEditing,
        DxPopup,
        DxLookup,
        DxPosition
    } from "devextreme-vue/data-grid";
    import { DxForm, DxValidationSummary } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";

    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';

    import 'devextreme/data/odata/store';

    export default {
        components: {
            DxDataGrid,
            DxColumn,
            DxSearchPanel,
            DxPaging,
            DxEditing,
            DxPopup,
            DxLookup,
            DxPosition,
            DxToolbar,
            DxButton,
            DxForm,
        },
        props: {
            modelName: String
        },
        watch: {
            '$route': 'setDataSource',
            
        },
        created() {
            this.setDataSource()
        },
        data: function () {
            return {
                dataSource: {}           
            }
        },
        methods: {                   
            setDataSource() {
                this.dataSource = {
                    store: {
                        type: 'odata',
                            url: baseUrl + 'odata/' + this.modelName,
                                version: 4,
                                    key: this.modelName + '_ID',
                                        keyType: {
                            [this.modelName + '_ID']: "Guid"
                        }
                    },
                    expand: []
                }
            }
        }
        
    };
</script>
