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
                    
                    <naks-attest-list v-if="modelKey"
                                      :model-key="modelKey" />
    
                    <dx-load-panel :position="{ of: '.form-container' }"
                           :visible="loading"
                           :delay="100"
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
    import {filter, first} from 'rxjs/operators';

    import {DxForm, DxPopup, DxScrollView} from 'devextreme-vue';
    import DataSource from 'devextreme/data/data_source';
    import CustomStore from 'devextreme/data/custom_store';
    import {DxLoadPanel} from 'devextreme-vue/load-panel';

    import NaksAttestList from './naks-attest-list';

    import BaseEntityEditor from 'components/forms/base-entity-editor';
    import {reftableFormItem} from 'components/forms/reftables';
    import {reftableDatasourceConf} from 'components/reftables/data';

    import context from 'api/odata-context';

    export default {
        name: 'NaksEdit',
        extends: BaseEntityEditor,
        components: {
            BaseEntityEditor,
            DxPopup,            
            DataSource,
            DxScrollView,
            DxLoadPanel,
            DxForm,
            NaksAttestList
        },
        props: {
            naksIsChild: {
                type: Boolean,
                required: true
            }
        },
        mounted() {
            this.$subscribeTo(
                this.state.pipe(filter(s => s.state === 'initializing')),
                s => this.$refs.editPopup.instance.show()
            )
        },
        computed: {
            popupToolbarItems () {
                let text;
                if (!this.modelKey && !this.naksIsChild) {
                    text = "Новое удостоверение НАКС";
                } else if (!this.modelKey && this.naksIsChild) {
                    text = "Новый вкладыш";
                } else if (!this.naksIsChild) {
                    text = "Удостоверение НАКС";
                } else {
                    text = "Вкладыш";
                }
                
                let toolbarTitle = {
                    toolbar: 'top',
                    location: 'before',
                    template: '<h5>' + text + '</h5>'
                };
                
                return this.modelKey ?
                    [
                        // toolbar items for existing naks
                        toolbarTitle,
                        this.toolbarItemChoices.closeButton,
                        this.toolbarItemChoices.saveAndCloseButton
                    ] :
                    [
                        // toolbar items for new naks
                        toolbarTitle,
                        this.toolbarItemChoices.closeButton,
                        this.toolbarItemChoices.saveButton
                    ]
            }
        },
        watch: {
            modelKey: {
                immediate: true,
                handler(val) {
                  
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
                            
                            onFocusIn(e) {
                                if (!e.component.field().value) e.component.open();
                            },
                            selectionChanged: function(e) {
                                
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
                    closeButton: {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Закрыть",
                            onClick: this.onCloseButton
                        }
                    },
                    saveButton: {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Сохранить",
                            type: "success",
                            onClick: this.onSaveButton
                        }
                    },
                    saveAndCloseButton: {
                        toolbar: 'bottom',
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Сохранить и закрыть",
                            type: "success",
                            onClick: this.onSaveAndCloseButton
                        }
                    }
                }
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
