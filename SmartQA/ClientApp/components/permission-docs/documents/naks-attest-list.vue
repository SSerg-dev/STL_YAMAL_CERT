<template>
    <div class="pt-3">

        <table v-if="model != null" class="table table-sm">
            <tr class="table-secondary">
                <th scope="row">
                    Области аттестации
                    <dx-button>
                        <font-awesome-icon icon="plus" 
                                           @click="onNewButtonClick"/>
                    </dx-button>
                </th>
                <th scope="col" v-for="(item, index) in model.DocumentNaksAttestSet">
                    <span>
                        {{ index + 1 }}
                    </span>
                    <div class="float-right">
                        <dx-button
                                   :modelId="item.DocumentNaksAttest_ID"
                                   @click="onEditButtonClick($event, item)">
                            <font-awesome-icon icon="edit" />
                        </dx-button>
                        <dx-button
                                   :modelId="item.DocumentNaksAttest_ID"
                                   @click="onDeleteButtonClick($event, item)">
                            <font-awesome-icon icon="trash" />
                        </dx-button>
                    </div>
                </th>
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
                <th scope="row">Сварочные материалы</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    <div v-for="val in item.WeldMaterialSet">
                        {{ val.Title }}
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
                <th scope="row">SDR</th>
                <td v-for="item in model.DocumentNaksAttestSet">
                    {{ item.SDR }}
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


        </table>

        <dx-popup ref="editPopup"
                  :show-title="true"
                  :width="600"
                  :height="600"
                  title="Область аттестации"
                  :toolbarItems="editPopupToolbarItems"
                  @onHiding="onEditPopupHiding">

            <naks-attest-edit ref="editForm"
                              :editModelKey="editModelKey"
                              :parentId="modelKey"
                              @editSuccess="onEditSuccess" />

        </dx-popup>

    </div>
</template>


<script>    
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
            'modelKey': String,            
        },
        watch: {
            'modelKey': 'loadModel'                   
        },
        created() {
            this.loadModel();
        },
        data: function () {
            return {                
                loading: false,
                model: null,
                error: null,
                editModelKey: null,
                dataSource: dataSourceConfs.documentNaks,              
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
            onNewButtonClick(event) {
                this.editModelKey = null;
                this.$refs.editPopup.instance.show();
            },
            onEditButtonClick(event, model) {
                this.editModelKey = model.ID.toString();
                this.$refs.editPopup.instance.show();                
            },            
            onDeleteButtonClick(event, model) {
                var component = this;
                this.editModelKey = model.ID.toString();
                var source = new DataSource(dataSourceConfs.documentNaksAttest);

                source.store().remove(model.ID)
                    .done(function (data) {
                        component.loadModel()
                    });            
            },
            onEditSuccess() {
                this.$refs.editPopup.instance.hide();
                this.loadModel()                
            },
            onEditPopupHiding() {
                this.editModelKey = null;
            }


        }
    };

</script>
