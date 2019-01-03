<template>
    <div class="form-container">
        <dx-popup ref="editPopup"
                  :visible="false"
                  :show-title="false"
                  :width="800"
                  :height="600"
                  :toolbar-items="popupToolbarItems"
                  @hiding="onEditPopupHiding">

            <dx-scroll-view>
                <div>
                    <form v-on:submit.prevent="onSubmitButtonClick">
                        <dx-form ref="form"
                                 :form-data="formData"
                                 :items="formItems" />

                    </form>

                    <dx-load-panel :position="{ of: '.form-container' }"
                                   :visible="loading"
                                   :show-indicator="true"
                                   :show-pane="true"
                                   :shading="true"
                                   shading-color="rgba(0,0,0,0.2)"
                                   :close-on-outside-click="false"
                    />
                </div>
            </dx-scroll-view>

        </dx-popup>
    </div>
</template>

<script>
    import {filter, first} from 'rxjs/operators'

    import { DxScrollView, DxPopup } from 'devextreme-vue'
    
    import context from 'api/odata-context'
    
    import BaseEntityEditor from 'components/forms/base-entity-editor'
    import { reftableFormItem } from 'components/forms/reftables'
    import { reftableFormItem2 } from 'components/forms/reftables'
    import { reftableFormItem3 } from 'components/forms/reftables' 
    import { reftableFormItem4 } from 'components/forms/reftables' 

    export default {
        name: 'NaksAttestEdit',
        extends: BaseEntityEditor,
        components: {
            DxPopup,
            DxScrollView,
            BaseEntityEditor            
        },
        props: {
            naksAttestIndex: {
                type: Number,
                default: () => null,
                required: true,
            }
        },
        computed: {
            popupToolbarItems () {
                let titleText = this.naksAttestIndex ?
                    'Область аттестации ' + this.naksAttestIndex :
                    'Новая область аттестации';

                let toolbarTitleHtml = "<div class='dx-item dx-toolbar-item dx-toolbar-label'>" +
                    "<div class='dx-item-content dx-toolbar-item-content'>" + titleText + "</div></div>";
                
                return [
                    {
                        location: 'before',
                        template: toolbarTitleHtml
                    },
                    {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Close",
                            onClick: this.onCloseButton
                        }
                    },
                    {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Save and close",
                            type: "success",
                            onClick: this.onSaveAndCloseButton
                        }
                    }
                ]
            }
        },
        mounted(){
            this.$subscribeTo(
                this.state.pipe(filter(s => s.state === 'initializing')),
                s => this.$refs.editPopup.instance.show()
            )
        },
        data: function () {
            return {
                dataStore: context.DocumentNaksAttest,
                formItems: [
                    reftableFormItem('DetailsType', 'Вид деталей', true),
                    reftableFormItem('SeamsType', 'Типы швов', true),
                    reftableFormItem('JointType', 'Тип соединения',true),
                    reftableFormItem('WeldMaterialGroup', 'Группа свариваемого материала', true),
                    reftableFormItem2('WeldMaterial', 'Сварочные материалы (вид покрытия электродов)', true),
                    {
                        label: { text: 'Сварочные материалы (сварочная проволока)' },
                        dataField: 'WeldingWire',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100,
                            disabled: true
                        }
                    },
                    {
                        label: { text: 'Сварочные материалы (защитный газ / флюс)' },
                        dataField: 'ShieldingGasFlux',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100,
                            disabled: true
                        }
                    },
                    {
                        label: { text: 'Толщина деталей, мм' },
                        dataField: 'DetailWidth',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100,
                        },
                        isRequired: true
                    },
                    {
                        label: { text: 'Наружный диаметр, мм' },
                        dataField: 'OuterDiameter',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100
                        },
                        isRequired: true
                    },
                    reftableFormItem3('WeldPosition', 'Положение при сварке', true),
                    {
                        label: { text: 'Положение при сварке. Пользовательское значение' },
                        dataField: 'WeldPositionCustom',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100,
                            disabled: true
                        }
                    },
                    reftableFormItem('JointKind', 'Вид соединения', true),
                    reftableFormItem('WeldGOST14098', 'Обозначение по ГОСТ 14098', true),
                    reftableFormItem4('WeldingEquipmentAutomationLevel', 'Степень автоматизации сварочного оборудования')
                ]

            }
        },
        methods: {
            onEditPopupHiding() {
                this.$emit('editingDone');
            },
            close() {
                this.$refs.editPopup.instance.hide();
            },
            onCloseButton() {
                this.close();
            },
            onSaveButton() {
                this.submit();
            },
            onSaveAndCloseButton() {
                this.submit();
                this.$subscribeTo(
                    this.state.pipe(first(s => !s.isProgress)),
                    s => { if (s.state === 'success') this.close() }
                );
            }
        }
    };
</script>
