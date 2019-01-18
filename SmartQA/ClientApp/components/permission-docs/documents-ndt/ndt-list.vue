<template>
    <div>
        <dx-toolbar :items="toolbarItems" />

        <dx-tree-list ref="dataGrid"
                      :column-fixing="{ enabled: true }"
                      :remoteOperations="{ filtering: false }"
                      :data-source="dataSource">

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

            </div>

        </dx-tree-list>

        <ndt-edit ref="editor"
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

    import NdtEdit from './ndt-edit';

    import {dataSourceConfs} from './data.js';

    export default {
        name: "ndt-list",
        components: {
            FontAwesomeIcon,
            DxTreeList,
            DxColumn,
            DxToolbar,
            DxButton,
            NdtEdit
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
                var conf = Object.assign({}, dataSourceConfs.documentNDT);
                conf.filter = ['Person_ID', '=', new String(this.personId)];
                this.dataSource = conf;
            },
            reloadData() {
                this.$refs.dataGrid.instance.refresh();
            },
            onEditSuccess() {
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
            onEditRowButtonClick(event, model) {
                this.editorSettings = {
                    modelKey: model.ID.toString(),
                    formDataInitial: {}
                };
            },
            onDeleteRowButtonClick(event, model) {
                var component = this;
                confirm("Действительно удалить?", "Подтверждение")
                    .done(function (dialogResult) {
                        if (dialogResult) {
                            var source = new DataSource(dataSourceConfs.documentNDT);
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