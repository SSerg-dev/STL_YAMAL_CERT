<template>
    <div>

        <dx-popup ref="editPopup"
                  :visible="false"
                  :show-title="true"
                  :width="800"
                  :height="600"
                  :toolbar-items="toolbarItems"
                  @hiding="onEditPopupHiding">

            <dx-scroll-view>
                <div>
                    <entity-form ref="form"
                                 :formItems="formItems"
                                 :formSettings="editRequests"
                                 :commandRequests="formCommands"
                                 :dataSource="dataSource"
                                 v-stream:state="formStateEvents$" />

                </div>

            </dx-scroll-view>

        </dx-popup>
    </div>
</template>

<script>
    import { Subject } from 'rxjs';
    import { pluck, map, first } from 'rxjs/operators';

    import { DxScrollView, DxPopup } from 'devextreme-vue';
    import DataSource from 'devextreme/data/data_source';    
    import { dataSourceConfs } from './data.js';

    import EntityForm from 'components/forms/entity-form';
    import { reftableFormItem } from 'components/forms/reftables';
    import { reftableFormItem2 } from 'components/forms/reftables';
    import { reftableFormItem3 } from 'components/forms/reftables'; 
    import { reftableFormItem4 } from 'components/forms/reftables'; 

    export default {
        components: {
            DxPopup,            
            DataSource,
            DxScrollView,
            EntityForm            
        },
        props: {           
            editRequests: Object,
        },
        subscriptions() {
            this.formStateEvents$ = new Subject();

            this.$subscribeTo(this.editRequests, req => {
                var popup = this.$refs.editPopup;
                if (req !== null) {
                    if (popup) popup.instance.show();
                }
            });

            this.formStateObs = this.formStateEvents$.pipe(
                map(e => e.event.msg)
            )
            const indexObs = this.formStateObs.pipe(
                pluck('index')
            );

            return {
                index: indexObs,
                toolbarItems: indexObs.pipe(map(key => [this.title]))
            }
        },
        data: function () {
            return {
                formCommands: new Subject(),
                dataSource: dataSourceConfs.documentNaksAttest,
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
                ],
                title: {
                    location: 'before',
                    template: this.getToolbarTitle
                },
                toolbarItems: [
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
        methods: {
            getToolbarTitle() {
                if (this.index) return "<div class='dx-item dx-toolbar-item dx-toolbar-label'><div class='dx-item-content dx-toolbar-item-content'>Область аттестации " + this.index + "</div></div>";
                return "<div class='dx-item dx-toolbar-item dx-toolbar-label'><div class='dx-item-content dx-toolbar-item-content'>Новая область аттестации</div></div>";
            },
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
                this.formCommands.next({ command: 'submit' });
            },
            onSaveAndCloseButton() {
                this.formCommands.next({ command: 'submit' });
                this.$subscribeTo(
                    this.formStateObs.pipe(first(s => !s.isProgress)),
                    s => { if (s.state === 'success') this.close() }
                );
            }
        }
    };
</script>
