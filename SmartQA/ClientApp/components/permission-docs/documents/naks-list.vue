<template>
    <div>
        <dx-toolbar :items="toolbarItems" />
        
        <dx-tree-list ref="dataGrid"
                      :columnFixing="{ enabled: true }"
                      :dataSource="dataSource"
                      parent-id-expr="ParentDocumentNaks_ID">
            
            <dx-column data-field="Number"
                       caption="Номер" />

            <dx-column data-field="IssueDate"
                       
                       caption="Дата выдачи" />

            <dx-column fixed="true"
                       fixedPosition="right"
                       width="160px"
                       cellTemplate="edit-column-cell"></dx-column>

            <div slot="edit-column-cell" slot-scope="row">
                <dx-button @click="onEditRowButtonClick($event, row.data.DocumentNaks_ID.toString())">
                    <font-awesome-icon icon="edit" />
                </dx-button>

                <dx-button @click="onDeleteRowButtonClick($event, row.data.DocumentNaks_ID.toString())">
                    <font-awesome-icon icon="trash" />
                </dx-button>

                <dx-button v-if="row.data.ParentDocumentNaks_ID == null"                           
                           @click="onNewChildRowButtonClick($event, row.data.DocumentNaks_ID.toString())">
                    <font-awesome-icon icon="plus" /> вкладыш
                </dx-button>

            </div>

        </dx-tree-list>

        <dx-popup ref="editPopup"
                  :show-title="true"
                  :width="800"
                  :height="600"
                  :toolbar-items="editPopupToolbarItems"
                  title="НАКС"
                  @onHiding="onEditPopupHiding">

            <naks-edit ref="editForm"
                       :editModelKey="editModelKey"
                       :editParentModelKey="editParentModelKey"
                       :personId="personId"                       
                       @editSuccess="onEditSuccess" />

        </dx-popup>
    </div>
</template>

<script>
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';    
    import { confirm } from 'devextreme/ui/dialog';
    import { DxTreeList, DxColumn } from 'devextreme-vue/tree-list';
    import { DxPopup } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import 'devextreme/data/odata/store';

    import NaksEdit from './naks-edit';
    import NaksInsertList from './naks-insert-list';

    import { dataSourceConfs } from './data.js'    

    export default {
        name: "naks-list",
        components: {
            FontAwesomeIcon,
            DxTreeList,
            DxColumn,            
            DxPopup,
            DxToolbar,
            DxButton,           
            NaksEdit,
            NaksInsertList
        },
        props: {
            personId: String,
            parentNaksId: {
                type: String,
                default: () => null
            }
        },
        created() {
            this.setDataSource()
        },
        data: function () {
            return {
                dataSource: {},
                editModelKey: null,     
                editParentModelKey: null,
                editPopup: {
                    showTitle: false,
                    width: 400,
                    height: 200,
                    position: {
                        my: "center",
                        at: "center",
                        of: window
                    }
                },
                toolbarItems: [                    
                    {
                        location: 'after',
                        widget: 'dxButton',
                        options: {
                            type: 'add',
                            icon: 'add',
                            text: 'Add',
                            onClick: (event) => this.onNewButtonClick(event)
                        }
                    }
                ],
                editPopupToolbarItems: [
                    {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Submit",
                            type: "success",
                            onClick: () => this.$refs.editForm.submitForm()                                                         
                        }                        
                    }
                ]

            }
        },
        methods: {
            setDataSource() {
                this.dataSource = new DataSource(dataSourceConfs.documentNaks);

                var filter = [[
                    'Person_ID', '=', new String(this.personId)
                ]];
                
                this.dataSource.filter(filter);
            },
            reloadData() {
                this.$refs.dataGrid.instance.refresh();
            },
            onEditSuccess() {                
                this.$refs.editPopup.instance.hide();
                this.reloadData();
            },
            onEditPopupHiding() {
                this.editModelKey = null;
                this.editParentModelKey = null;
            },
            onNewButtonClick(event) {
                this.editModelKey = null;
                this.editParentModelKey = null;
                this.$refs.editPopup.instance.show();
            },
            onNewChildRowButtonClick(event, modelId) {                
                this.editModelKey = null;
                this.editParentModelKey = modelId;
                this.$refs.editPopup.instance.show();
            },
            onEditRowButtonClick(event, modelId) {
                console.log(modelId);
                this.editModelKey = modelId;
                this.editParentModelKey = null;
                this.$refs.editPopup.instance.show();
            },
            onDeleteRowButtonClick(event, modelId) {                
                var component = this;                
                confirm("Really delete?", "Confirm")
                    .done(function (dialogResult) {
                        if (dialogResult) {
                            var source = new DataSource(dataSourceConfs.documentNaks);
                            source.store().remove(modelId)
                                .done(function (data) {
                                    component.reloadData()
                                });
                        }
                    });

            }
        }

    };
</script>
