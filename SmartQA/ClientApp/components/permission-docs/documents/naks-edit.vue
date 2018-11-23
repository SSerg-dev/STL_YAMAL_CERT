<template>
    <div>
        
        <dx-popup ref="editPopup"
                  :visible="false"
                  :show-title="false"
                  :width="800"
                  :height="600"
                  :toolbar-items="toolbarItems"
                  @hiding="onEditPopupHiding">            

            <dx-scroll-view>
                <div>                    
                    <entity-form ref="naksForm"
                                 :formItems="naksFormItems"
                                 :editRequests="editRequests"
                                 :commandRequests="formCommands"
                                 :dataSource="dataSource"
                                 v-stream:state="formStateEvents$" />

                    <naks-attest-list v-if="modelKey"
                                      :model-key="modelKey" />

                </div>
            </dx-scroll-view>

        </dx-popup>
    </div>
</template>

<script>
    import { Subject } from 'rxjs';
    import { pluck, map, first, filter } from 'rxjs/operators';

    import { DxScrollView, DxPopup } from 'devextreme-vue';   
    import DataSource from 'devextreme/data/data_source';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';    

    import NaksAttestList from './naks-attest-list';
    import { dataSourceConfs } from './data.js';
    
    import EntityForm from 'components/forms/entity-form';
    import { reftableFormItem } from 'components/forms/reftables';
    
    
    export default {
        components: {        
            DxPopup,            
            DataSource,
            DxScrollView,
            EntityForm,
            NaksAttestList
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
                } else {
                    if (popup) popup.instance.hide();
                }
            });

            this.formStateObs = this.formStateEvents$.pipe(
                map(e => e.event.msg)
            );

            var modelKeyObs = this.formStateObs.pipe(
                pluck('modelKey')
            );

            return {
                isChild: this.editRequests.pipe(
                    map(x => x ? x.isChild : false)
                ),
                modelKey: modelKeyObs,                
                toolbarItems: modelKeyObs.pipe(
                    map(key => key == null ? 
                        [ 
                            // toolbar items for new naks
                            this.toolbarItemChoices.toolbarTitle,
                            this.toolbarItemChoices.closeButton,
                            this.toolbarItemChoices.saveButton
                        ] :
                        [
                            // toolbar items for existing naks
                            this.toolbarItemChoices.toolbarTitle,
                            this.toolbarItemChoices.closeButton,
                            this.toolbarItemChoices.saveAndCloseButton
                        ]
                    )
                )
            }
        },
        data: function () {
            

            return {                                
                formCommands: new Subject(),
                dataSource: dataSourceConfs.documentNaks,
                naksFormItems: [
                    {
                        label: { text: 'Номер' },
                        dataField: 'Number',
                        isRequired: true
                    },
                    {
                        dataField: 'IssueDate',
                        label: { text: 'Дата выдачи' },
                        editorType: 'dxDateBox',
                        editorOptions: {
                            onValueChanged: 'onEditorValueChanged',
                        }
                    },
                    {
                        dataField: 'ValidUntil',
                        label: { text: 'Срок действия' },
                        editorType: 'dxDateBox',
                        editorOptions: {
                            onValueChanged: 'onEditorValueChanged',
                        }
                    },
                    {
                        label: { text: 'Шифр клейма' },
                        dataField: 'Schifr',
                        isRequired: false
                    },
                    reftableFormItem('WeldType', 'Вид (способ) сварки (наплавки)', false),
                    reftableFormItem('HIFGroup', 'Группы технических устройств ОПО', true),
                ],                
                toolbarItemChoices: {
                    toolbarTitle: {
                        toolbar: 'top',
                        location: 'before',
                        template: this.getToolbarTitle
                    },
                    closeButton: {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Close",
                            onClick: this.onCloseButton
                        }
                    },
                    saveButton: {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Save",
                            type: "success",
                            onClick: this.onSaveButton
                        }
                    },
                    saveAndCloseButton: {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Save and close",
                            type: "success",
                            onClick: this.onSaveAndCloseButton
                        }
                    }
                }
            }
        },
        methods: {
            getToolbarTitle() {                
                var text;
                if (!this.modelKey && !this.isChild) {
                    text = "Новое свидетельство НАКС";
                } else if (!this.modelKey && this.isChild) {
                    text = "Новый вкладыш";
                } else if (!this.isChild) {
                    text = "Свидетельство НАКС";
                } else {
                    text =  "Вкладыш";
                }
                return '<h5>' + text + '</h5>';
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
