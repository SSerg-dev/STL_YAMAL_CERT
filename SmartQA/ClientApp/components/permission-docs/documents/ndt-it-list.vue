<template>
    <div class="pt-3">

        <table v-if="model != null" class="table table-sm">
            <tr class="table-secondary">
                <th scope="row">
                    Вид контроля
                    <button type="button" class="btn btn-sm btn-light"
                            @click="onNewButtonClick">
                        <font-awesome-icon icon="plus" />
                    </button>
                </th>
                <th scope="col" v-for="(item, index) in model.DocumentNDTITSet">
                    <span>
                        {{ index + 1 }}
                    </span>
                    <div class="float-right">
                        <button type="button" class="btn btn-sm btn-light" @click="onEditButtonClick($event, item.ID.toString(), index + 1)">
                            <font-awesome-icon icon="edit" />
                        </button>
                        <button type="button" class="btn btn-sm btn-light" @click="onDeleteButtonClick($event, item.ID.toString())">
                            <font-awesome-icon icon="trash" />
                        </button>
                    </div>
                </th>
            </tr>
            <tr>
                <th scope="row">Вид контроля:</th>
                <td v-for="item in model.DocumentNDTITSet">
                    <div v-if="item.InspectionTechnique">
                        {{ item.InspectionTechnique.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Уровень:</th>
                <td v-for="item in model.DocumentNDTITSet" style="max-width:100px;word-wrap:break-word;">
                    <div v-if="item.Level">
                        {{ item.Level.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Объекты контроля</th>
                <td v-for="item in model.DocumentNDTITSet">
                    <div v-for="val in item.InspectionSubjectSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Срок действия:</th>
                <td v-for="item in model.DocumentNDTITSet" style="max-width:100px;word-wrap:break-word;">
                    <div>
                        {{ item.ValidUntil }}
                    </div>
                </td>
            </tr>
        </table>
        <ndt-it-edit ref="editor"
                          :editor-settings="editorSettings"
                          :ndt-it-index="editorIndex"
                          @editingDone="onEditingDone" />
    </div>
</template>


<script>
    import {Subject} from 'rxjs';
    import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';
    import {DxButton} from 'devextreme-vue';
    import {confirm} from 'devextreme/ui/dialog';

    import DxToolbar from 'devextreme-vue/toolbar';
    import DataSource from 'devextreme/data/data_source';
    import DxPopup from 'devextreme-vue/popup';
    import {dataSourceConfsNDT} from './data.js';

    import NdtItEdit from './ndt-it-edit';

    export default {
        components: {
            FontAwesomeIcon,
            DxButton,
            DxToolbar,
            DataSource,
            DxPopup,
            NdtItEdit
        },
        props: {
            modelKey: String,
        },
        watch: {
            modelKey: 'loadModel'
        },
        created() {
            this.loadModel();
        },
        data: function () {
            return {
                editRequests: new Subject(),
                loading: false,
                model: null,
                error: null,
                dataSource: dataSourceConfsNDT.documentNDTDetailed,
                editorSettings: {},
                editorIndex: 0,
                toolbarItems: [
                    {
                        location: 'before',
                        widget: 'dxButton',
                        options: {
                            type: 'add',
                            icon: 'add',
                            text: 'Add',
                            onClick: () => {
                                this.editModelKey = null;
                                this.$refs.editPopup.instance.show();
                            }
                        }
                    }
                ]
            }
        },
        methods: {
            loadModel() {
                this.error = this.model = null;

                if (!this.modelKey) {
                    this.loading = false;
                    return;
                }
                this.loading = true;
                let component = this;
                let source = new DataSource(this.dataSource);
                source.filter([source.key(), "=", new String(component.modelKey.toString())]);

                source
                    .load()
                    .done(function (data) {
                        component.loading = false;
                        component.model = data[0];
                    })
                    .fail(function (error) {
                        component.loading = false;
                        component.error = error;
                    });
            },
            onEditingDone() {
                this.loadModel();
            },
            onNewButtonClick(event) {
                this.editorSettings = {
                    modelKey: null,
                    formDataInitial: {
                        DocumentNdt_ID: this.modelKey,
                    }
                };

                this.editorIndex = null
            },
            onEditButtonClick(event, modelId, index) {
                this.editorSettings = {
                    modelKey: modelId,
                    formDataInitial: {}
                };

                this.editorIndex = index;
            },
            onDeleteButtonClick(event, modelId) {
                var component = this;
                confirm("Really delete?", "Confirm")
                    .done(function (dialogResult) {
                        if (dialogResult) {

                            var source = new DataSource(dataSourceConfs.documentNdtIt);
                            source.store().remove(modelId)
                                .done(function (data) {
                                    component.loadModel()
                                });
                        }
                    });
            }

        }
    };

</script>
