<template>
    <div>

        <dx-popup ref="editPopup"
                  :visible="false"
                  :show-title="true"
                  :width="800"
                  :height="600"
                  :toolbar-items="toolbarItems"
                  @hiding="onEditPopupHiding"
                  title="Область аттестации">

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
        },
        data: function () {
            return {
                formCommands: new Subject(),
                dataSource: dataSourceConfs.documentNaksAttest,
                formItems: [                    
                    reftableFormItem('DetailsType', 'Вид деталей', true),                    
                    reftableFormItem('SeamsType', 'Типы швов', true),
                    reftableFormItem('JointType', 'Тип соединения'),
                    reftableFormItem('WeldMaterialGroup', 'Группа свариваемого материала', true),
                    reftableFormItem('WeldMaterial', 'Сварочные материалы (вид покрытия электродов):', true),
                    {
                        label: { text: 'Сварочные материалы (сварочная проволока):' },
                        dataField: 'WeldingWire',
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        label: { text: 'Сварочные материалы (защитный газ / флюс):' },
                        dataField: 'ShieldingGasFlux',
                        editorOptions: {
                            disabled: false
                        }
                    },
                    {
                        label: { text: 'Толщина деталей, мм' },
                        dataField: 'DetailWidth',
                        isRequired: true
                    },
                    {
                        label: { text: 'Наружный диаметр, мм' },
                        dataField: 'OuterDiameter',
                        isRequired: true
                    },
                    reftableFormItem('WeldPosition', 'Положение при сварке', true),
                    reftableFormItem('JointKind', 'Вид соединения', true),
                    reftableFormItem('WeldGOST14098', 'Обозначение по ГОСТ 14098'),
                    reftableFormItem('WeldingEquipmentAutomationLevel', 'Степень автоматизации сварочного оборудования')
                ],
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
