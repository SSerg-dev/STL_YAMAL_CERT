<template>
    <div class="form-container">
        <dx-popup ref="editPopup"
                  :visible="false"
                  :show-title="false"
                  :width="800"
                  :height="400"
                  :toolbar-items="popupToolbarItems"
                  @hiding="onEditPopupHiding">

            <dx-scroll-view>
                <div>
                    <form v-on:submit.prevent="onSubmitButtonClick">
                        <dx-form ref="form"
                                 :form-data="formData"
                                 :items="formItems" />

                    </form>

                    <ndt-it-list v-if="modelKey"
                                      :model-key="modelKey" />

                    <dx-load-panel :position="{ of: '.form-container' }"
                                   :visible="loading"
                                   :delay="100"
                                   :show-indicator="true"
                                   :show-pane="true"
                                   :shading="true"
                                   shading-color="rgba(0,0,0,0.2)"
                                   :close-on-outside-click="false" />
                </div>
            </dx-scroll-view>

        </dx-popup>
    </div>
</template>

<script>
    import { filter, first } from 'rxjs/operators';

    import { DxForm, DxPopup, DxScrollView } from 'devextreme-vue';
    import DataSource from 'devextreme/data/data_source';
    import CustomStore from 'devextreme/data/custom_store';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';

    import NdtItList from './ndt-it-list';

    import BaseEntityEditor from 'components/forms/base-entity-editor';
    import { reftableFormItem } from 'components/forms/reftables';
    import { reftableDatasourceConf } from 'components/reftables/data';

    import context from 'api/odata-context';

    export default {
        name: 'NDTEdit',
        extends: BaseEntityEditor,
        components: {
            BaseEntityEditor,
            DxPopup,
            DataSource,
            DxScrollView,
            DxLoadPanel,
            DxForm
            ,
            NdtItList
        },
        
        mounted() {
            this.$subscribeTo(
                this.state.pipe(filter(s => s.state === 'initializing')),
                s => this.$refs.editPopup.instance.show()
            )
        },
        computed: {
            popupToolbarItems() {
                let text;
                if (!this.modelKey) {
                    text = "Новое удостоверение НК";
                } else {
                    text = "Удостоверение НК";
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

            return {
                dataStore: context.DocumentNDT,
                dataStoreLoadOptions: { expand: 'DocumentNDTITSet' },
                formItems: [
                    {
                        label: { text: 'Организация' },
                        dataField: 'OrganizationPublishedNDT',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100
                        },
                        isRequired: true
                    },
                    {
                        label: { text: 'Номер' },
                        dataField: 'Number',
                        editorType: 'dxTextArea',
                        editorOptions: {
                            autoResizeEnabled: true,
                            maxHeight: 100
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
                                        
                ],
                toolbarItemChoices: {
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
