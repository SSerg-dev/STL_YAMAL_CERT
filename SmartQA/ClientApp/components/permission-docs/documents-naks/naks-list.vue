<template>
    <div>
        <dx-toolbar :items="toolbarItems" />
        
        <dx-tree-list ref="dataGrid"
                      :column-fixing="{ enabled: true }"
                      :remoteOperations="{ filtering: false }"
                      :data-source="dataSource"                            
                      parent-id-expr="ParentDocumentNaks_ID">
            
            <dx-column data-field="Number"
                       caption="Номер" />

            <dx-column data-field="IssueDate"
                       data-type="date"
                       caption="Дата выдачи" />

            <dx-column :fixed="true"
                       fixedPosition="right"
                       width="160px"
                       cellTemplate="edit-column-cell"></dx-column>

            <div slot="edit-column-cell" slot-scope="row">
                <button type="button" class="btn btn-sm btn-light"
                        @click="onEditRowButtonClick($event, row.data)">
                    <font-awesome-icon icon="edit" />
                </button>

                <button type="button" class="btn btn-sm btn-light"
                        @click="onDeleteRowButtonClick($event, row.data)">
                    <font-awesome-icon icon="trash" />
                </button>

                <button type="button" class="btn btn-sm btn-light"
                        v-if="row.data.ParentDocumentNaks_ID == null"                           
                           @click="onNewChildRowButtonClick($event, row.data)">
                    <font-awesome-icon icon="plus" /> вкладыш
                </button>

            </div>

        </dx-tree-list>

        <naks-edit ref="editor"
                   :editor-settings="editorSettings"
                   :naks-is-child="editorIsChild"
                   @editingDone="onEditSuccess" />

    </div>
</template>

<script>
    import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';
    import {confirm} from 'devextreme/ui/dialog';
    import {DxColumn, DxTreeList} from 'devextreme-vue/tree-list';
    import {DxButton} from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';

    import NaksEdit from './naks-edit';

    import {dataSourceConfs} from './data.js';

    export default {
        name: "naks-list",
        components: {
            FontAwesomeIcon,
            DxTreeList,
            DxColumn,
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
        },
        data: function () {
            return {                 
                dataSource: {},                
                editorSettings: {},
                editorIsChild: false,
                toolbarItems: [                    
                    {
                        location: 'after',
                        widget: 'dxButton',
                        options: {
                            type: 'add',
                            icon: 'add',
                            text: 'Добавить',
                            onClick: (event) => this.onNewButtonClick(event)
                        }
                    }
                ],
                
            }
        },
        methods: {
            setDataSource() {
                var conf = Object.assign({}, dataSourceConfs.documentNaks);
                conf.filter = ['Person_ID', '=', new String(this.personId)];
                this.dataSource = conf;                
            },
            reloadData() {
                this.$refs.dataGrid.instance.refresh();
            },
            onEditSuccess() {                
                //this.$refs.editPopup.instance.hide();
                this.reloadData();
                
            },
            onNewButtonClick(event) {
                this.editorSettings = {
                    modelKey: null,
                    formDataInitial: {
                        Person_ID: this.personId,
                    }
                };
                
                this.editorIsChild = false;
            },
            onNewChildRowButtonClick(event, model) {
                this.editorSettings = {
                    modelKey: null,
                    formDataInitial: {
                        Person_ID: this.personId,
                        ParentDocumentNaks_ID: model.ID.toString(),
                        Number: model.Number + ' В'
                    }
                };

                this.editorIsChild = true;
                
            },
            onEditRowButtonClick(event, model) {
                this.editorSettings = {
                    modelKey: model.ID.toString(),
                    formDataInitial: {}
                };
                
                this.editorIsChild = model.ParentDocumentNaks_ID != null;
                
            },
            onDeleteRowButtonClick(event, model) {                
                var component = this;
                confirm("Действительно удалить?", "Подтверждение")
                    .done(function (dialogResult) {
                        if (dialogResult) {
                            var source = new DataSource(dataSourceConfs.documentNaks);
                            source.store().remove(model.ID)
                                .done(function (data) {
                                    component.reloadData()
                                });
                        }
                    });
            }
        }

    };
</script>
