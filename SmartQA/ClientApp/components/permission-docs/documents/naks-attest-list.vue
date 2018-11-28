<template>
    <div class="pt-3">

        <table v-if="model != null" class="table table-sm">
            <tr class="table-secondary">
                <th scope="row">
                    Области аттестации
                    <button type="button" class="btn btn-sm btn-light">
                        <font-awesome-icon icon="plus"
                                           @click="onNewButtonClick" />
                    </button>
                </th>
                <th scope="col" v-for="(item, index) in model.DocumentNaksAttestSet">
                    <span>
                        {{ index + 1 }}
                    </span>
                    <div class="float-right">
                        <button type="button" class="btn btn-sm btn-light" @click="onEditButtonClick($event, item.ID.toString())">
                            <font-awesome-icon icon="edit" />
                        </button>
                        <button type="button" class="btn btn-sm btn-light" @click="onDeleteButtonClick($event, item.ID.toString())">
                            <font-awesome-icon icon="trash" />
                        </button>
                    </div>
                </th>
            </tr>
            <tr>
                <th scope="row">Вид деталей</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.DetailsTypeSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Типы швов</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.SeamsTypeSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Тип соединения</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-if="item.JointType">
                        {{ item.JointType.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Группа свариваемого материала</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.WeldMaterialGroupSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Сварочные материалы (вид покрытия электродов):</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.WeldMaterialSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Сварочные материалы (сварочная проволока):</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div>
                        {{ item.WeldingWire }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Сварочные материалы (защитный газ / флюс):</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div>
                        {{ item.ShieldingGasFlux }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Толщина деталей, мм</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div>
                        {{ item.DetailWidth }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Наружный диаметр, мм</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    {{ item.OuterDiameter }}
                </td>
            </tr>
            <tr>
                <th scope="row">Положение при сварке</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.WeldPositionSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>

            <tr>
                <th scope="row">Вид соединения</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.JointKindSet">
                        {{ val.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Обозначение по ГОСТ 14098</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-if="item.WeldGOST14098">
                        {{ item.WeldGOST14098.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">Степень автоматизации сварочного оборудования</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-if="item.WeldingEquipmentAutomationLevel">
                        {{ item.WeldingEquipmentAutomationLevel.Title }}
                    </div>
                </td>
            </tr>
            <tr>
                <th scope="row">SDR</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    {{ item.SDR }}
                </td>
            </tr>

        </table>

        <naks-attest-edit :editRequests="editRequests"
                          @editingDone="onEditingDone"/>
    </div>
</template>


<script>    
    import { Subject } from 'rxjs';
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
    import { DxButton } from 'devextreme-vue';
    import DxToolbar from 'devextreme-vue/toolbar'; 
    import DataSource from 'devextreme/data/data_source';
    import DxPopup from 'devextreme-vue/popup';
    import { dataSourceConfs } from './data.js';

    import NaksAttestEdit from './naks-attest-edit';

    export default {
        components: {
            FontAwesomeIcon,
            DxButton,
            DxToolbar,
            DataSource,
            DxPopup,
            NaksAttestEdit
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
                dataSource: dataSourceConfs.documentNaksDetailed,              
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
                ],
                editPopupToolbarItems: [
                    {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Submit",
                            type: "success",
                            onClick: () => {
                                this.$refs.editForm.submitForm();
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
                var component = this;
                var source = new DataSource(this.dataSource);
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
                this.editRequests.next({
                    modelKey: null,
                    formDataInitial: {
                        DocumentNaks_ID: this.modelKey,
                    }
                });
            },
            onEditButtonClick(event, modelId) {
                this.editRequests.next({
                    modelKey: modelId,
                    formDataInitial: Object()
                });
            },
            onDeleteButtonClick(event, modelId) {
                var component = this;
                confirm("Really delete?", "Confirm")
                    .done(function (dialogResult) {
                        if (dialogResult) {
                            var source = new DataSource(component.dataSource);
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
