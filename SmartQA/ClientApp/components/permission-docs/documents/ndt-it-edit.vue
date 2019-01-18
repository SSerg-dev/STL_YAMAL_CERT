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

                    <dx-load-panel :position="{ of: '.form-container' }"
                                   :delay="100"
                                   :visible="loading"
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
    import {filter, first} from 'rxjs/operators'

    import {DxPopup, DxScrollView} from 'devextreme-vue'

    import context from 'api/odata-context'

    import BaseEntityEditor from 'components/forms/base-entity-editor'
    import {reftableFormItem, reftableFormItem2, reftableFormItem3, reftableFormItem4} from 'components/forms/reftables'

    export default {
        name: 'NdtItEdit',
        extends: BaseEntityEditor,
        components: {
            DxPopup,
            DxScrollView,
            BaseEntityEditor
        },
        props: {
            ndtItIndex: {
                type: Number,
                default: () => null,
                required: false,
            }
        },
        computed: {
            popupToolbarItems () {
                let titleText = this.ndtItIndex ?
                    'Вид контроля ' + this.ndtItIndex :
                    'Новый вид контроля';

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
                dataStore: context.DocumentNdtIt,
                formItems: [
                    reftableFormItem('InspectionTechnique', 'Вид контроля', false),
                    reftableFormItem('Level', 'Уровень', false),  
                    reftableFormItem('InspectionSubject', 'Объекты контроля', true),
                    {
                        label: { text: 'Срок действия' },
                        dataField: 'ValidUntil',
                        editorType: 'dxDateBox',                        
                        isRequired: true
                        
                    },                   
                    
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
