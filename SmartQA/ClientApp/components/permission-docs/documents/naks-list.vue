<template>
    <div>
        <dx-data-grid ref="dataGrid"
                      v-bind:dataSource="dataSource"
                      @editingStart="onEditingStart">

            <dx-editing :allow-updating="true"
                        :allow-deleting="true"
                        :allow-adding="true"
                        :form="editForm"
                        :popup="editPopup"
                        mode="popup" />

            <dx-column data-field="Number"
                       caption="Number" />
            <dx-column data-field="IssueDate"
                       caption="IssueDate" />
        </dx-data-grid>
        
        <dx-popup ref="editPopup"
                  :show-title="true"
                  :width="700"
                  :height="345"                  
                  title="">

            <naks-edit :modelKey="editModelKey" />

        </dx-popup>
    </div>
</template>

<script>
    import {
        DxDataGrid,
        DxColumn,
        DxSearchPanel,
        DxPaging,
        DxEditing,        
        DxLookup,
        DxPosition
    } from "devextreme-vue/data-grid";
    import { DxForm, DxValidationSummary, DxPopup } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";

    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import 'devextreme/data/odata/store';

    import NaksEdit from './naks-edit';

    import { dataSourceConfs } from './data.js'    

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
            NaksEdit,
        },
        props: {
            personId: String
        },
        created() {
            this.setDataSource()
        },
        data: function () {
            return {
                dataSource: {},
                editModelKey: null,
                editForm: {
                    colCount: 1,
                    items: [
                        {
                            label: { text: 'Номер' },
                            dataField: 'Number',
                            required: true
                        },
                        {
                            dataField: 'IssueDate',
                            label: { text: 'Дата выдачи' },
                            editorType: 'dxDateBox',
                            editorOptions: {
                                onValueChanged: 'onEditorValueChanged',
                            }
                        },
                        {
                            dataField: 'ValidUntil',
                            label: { text: 'Срок действия' },
                            editorType: 'dxDateBox',
                            editorOptions: {
                                onValueChanged: 'onEditorValueChanged',
                            }
                        },
                        {
                            label: { text: 'Шифр клейма' },
                            dataField: 'Schifr',
                            required: true
                        },
                    ]
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
            setDataSource() {
                this.dataSource = new DataSource(dataSourceConfs.documentNaks);
                this.dataSource.filter([
                    'Person_ID', '=', new String(this.personId)
                ])
            },
            onEditingStart(event) {
                event.cancel = true;
                this.editModelKey = event.key.toString();
                this.$refs.editPopup.instance.show();
                console.log(event);
                
                
            }
        }

    };
</script>
