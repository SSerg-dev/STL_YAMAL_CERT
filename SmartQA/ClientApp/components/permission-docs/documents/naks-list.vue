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

            <dx-column :fixed="true"
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

        <naks-edit :editRequests="editRequestsNaks"
                   @editingDone="onEditSuccess" />

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

    import { dataSourceConfs } from './data.js';
    import { BehaviorSubject } from 'rxjs';

    export default {
        name: "naks-list",
        components: {
            FontAwesomeIcon,
            DxTreeList,
            DxColumn,            
            DxPopup,
            DxToolbar,
            DxButton,           
            NaksEdit
        },
        subscriptions: {
            
        },
        props: {
            personId: String,
        },
        created() {
            this.setDataSource();
            this.$subscribeTo(this.editRequestsNaks,  (val) => {

            });
        },
        watch: {
            naksEditing(value) {
                console.log("asadfadsf", value);
                if (value) this.$refs.editPopup.instance.show();
                else this.$refs.editPopup.instance.hide();
            }

        },
        data: function () {
            return {
                editRequestsNaks: new BehaviorSubject(),                
                dataSource: {},                
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
                //this.$refs.editPopup.instance.hide();
                this.reloadData();
                
            },
            onNewButtonClick(event) {
                this.editRequestsNaks.next({
                    modelKey: null,
                    formDataInitial: {
                        Person_ID: this.personId,
                    }
                });                
            },
            onNewChildRowButtonClick(event, modelId) {                
                this.editRequestsNaks.next({
                    modelKey: null,
                    formDataInitial: {
                        Person_ID: this.personId,
                        ParentDocumentNaks_ID: modelId
                    }
                });                
            },
            onEditRowButtonClick(event, modelId) {
                this.editRequestsNaks.next({
                    modelKey: modelId,
                    formDataInitial: Object()
                });                 
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
