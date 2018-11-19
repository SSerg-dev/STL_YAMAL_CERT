<template>
    <div>
        <h2 v-if="reftable">{{ reftable.Title }}</h2>
        <dx-data-grid ref="dataGrid"                      
                      v-bind:dataSource="dataSource">

            <dx-editing
                :allow-updating="false"
                :allow-deleting="true"
                :allow-adding="true"                       
                :form="editForm"
                :popup="editPopup"
                mode="popup"
                
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
    import { dataSourceConfs } from "./data";

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
            '$route': 'fetchData',
            
        },
        created() {
            this.fetchData()
        },
        data: function () {
            return {                
                dataSource: null,
                reftable: null,
                editForm: {
                    colCount: 1
                },
                editPopup: {                    
                    showTitle: false,
                    width: 400,
                    height: 200,
                    position: {
                        my: "center",
                        at: "center",
                        of: window
                    }
                }
            }
        },
        methods: {
            fetchData() {
                var component = this;
                var refDs = new DataSource(dataSourceConfs.reftables)
                refDs.filter(["modelName", "=", new String(this.modelName.toString())]);
                refDs.load().done(function (data) {
                    component.reftable = data[0];
                })

                this.dataSource = {
                    store: {
                        type: 'odata',
                            url: baseUrl + 'odata/' + this.modelName,
                                version: 4,
                                    key: 'ID',
                                        keyType: {
                                        'ID': "Guid"
                        }
                    },
                    expand: []
                }
            }
        }
        
    };
</script>
