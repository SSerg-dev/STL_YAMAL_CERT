<template>
    <div class="form-container">
        <dx-popup ref="editPopup"
                  :visible="false"
                  :show-title="false"
                  :width="800"
                  :height="600"
                  :toolbar-items="toolbarItems"
                  @hiding="onEditPopupHiding">

            <dx-scroll-view>
                <div>
                    <form v-on:submit.prevent="onSubmitButtonClick">
                        <dx-form ref="form"
                                 :form-data="formData"
                                 :items="formItems" />
            
                    </form>
                    
                    <naks-attest-list v-if="modelKey"
                                      :model-key="modelKey" />
    
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
    import { Subject } from 'rxjs';
    import { pluck, map, first, filter } from 'rxjs/operators';

    import { DxScrollView, DxPopup, DxForm} from 'devextreme-vue';
    import DataSource from 'devextreme/data/data_source';
    import CustomStore from 'devextreme/data/custom_store';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';    

    import NaksAttestList from './naks-attest-list';
    
    import EntityForm from 'components/forms/entity-form';
    import { reftableFormItem } from 'components/forms/reftables';
    import { reftableDatasourceConf } from 'components/reftables/data'; 
    
    import context from 'api/odata-context';
    
    export default {
        name: 'NaksEdit',
        extends: EntityForm,
        components: {
            EntityForm,
            DxPopup,            
            DataSource,
            DxScrollView,
            DxLoadPanel,
            DxForm,
            NaksAttestList
        },
        props: {            
            editRequests: Object,            
        },
        subscriptions() {
            return {
                isChild: this.editRequests.pipe(
                    map(x => x ? x.isChild : false)
                )
            }
        },
        mounted(){
            this.$subscribeTo(this.editRequests, req => {
                if (req === null) return;
                let popup = this.$refs.editPopup;
                if (popup) popup.instance.show();                     
               
                this.formCommands.next(Object.assign({
                    command: 'init',
                }, req));
                
            });

        },
        watch: {
            modelKey: {
                immediate: true,
                handler(val) {
                    this.toolbarItems = val ?
                        [
                            // toolbar items for existing naks
                            this.toolbarItemChoices.toolbarTitle,
                            this.toolbarItemChoices.closeButton,
                            this.toolbarItemChoices.saveAndCloseButton
                        ] :
                        [
                            // toolbar items for new naks
                            this.toolbarItemChoices.toolbarTitle,
                            this.toolbarItemChoices.closeButton,
                            this.toolbarItemChoices.saveButton
                        ]
                }
            }
        },
        data() {
            
            // custom autocomplete source for Naks Number field
            const attCenterNaksDs = new CustomStore({
                key: "Title",
                load: function (loadOptions) {
                    let attCenterNaksDsConf = reftableDatasourceConf('AttCenterNaks');
                    attCenterNaksDsConf.sort = ['Title'];
                    let ds = new DataSource(attCenterNaksDsConf);
                    ds.paginate(false);
                    if (loadOptions.searchValue) {
                        ds.filter(['Title', 'startswith', loadOptions.searchValue])
                    }

                    return ds.load().then(function (data) {
                        let result = [];
                        for (let i = 0; i < data.length; i++) {
                            let r = data[i];
                            result.push({'Title': r.Title + '-I-'});
                            result.push({'Title': r.Title + '-II-'});
                            result.push({'Title': r.Title + '-III-'});
                            result.push({'Title': r.Title + '-IV-'});
                        }
                        return result;
                    });
                }
            });

            return {
                dataStore: context.DocumentNaks,
                dataStoreLoadOptions: { expand: 'DocumentNaksAttestSet' },
                formItems: [
                    {
                        label: { text: 'Номер' },
                        dataField: 'Number',
                        editorType: 'dxAutocomplete',
                        editorOptions: {
                            dataSource: attCenterNaksDs,
                            searchExpr: 'Title',
                            valueExpr: 'Title',
                            minSearchLength: 0,
                            maxItemCount: 100,
                            
                            onFocusIn: function (e) {
                                if (!e.component.field().value) e.component.open();
                            },
                            selectionChanged: function(e) {
                                console.log(e);
                            }
                        },
                        isRequired: true
                    },
                    {
                        dataField: 'IssueDate',
                        label: { text: 'Дата выдачи' },
                        editorType: 'dxDateBox',
                        editorOptions: {
                            onValueChanged: 'onEditorValueChanged',
                        },
                        isRequired: true
                    },
                    {
                        dataField: 'ValidUntil',
                        label: { text: 'Срок действия' },
                        editorType: 'dxDateBox',
                        editorOptions: {
                            onValueChanged: 'onEditorValueChanged',
                        },
                        isRequired: true
                    },
                    {
                        label: { text: 'Шифр клейма' },
                        dataField: 'Schifr',
                        valueChangeEvent: 'keyup',
                        validationRules: [{
                            type: "pattern",
                            pattern: /^[a-zA-Z0-9]*$/,
                            message: "В поле шифр клейма допускаются только латинские буквы и арабские цифры."
                        }],
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
                let text;
                if (!this.modelKey && !this.isChild) {
                    text = "Новое удостоверение НАКС";
                } else if (!this.modelKey && this.isChild) {
                    text = "Новый вкладыш";
                } else if (!this.isChild) {
                    text = "Удостоверение НАКС";
                } else {
                    text = "Вкладыш";
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
                    this.state.pipe(first(s => !s.isProgress)),
                    s => { if (s.state === 'success') this.close() }
                );
            }
        }
    };
</script>
