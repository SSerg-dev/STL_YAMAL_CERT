<template>
    <div>        
        <form class="py-3"
              v-on:submit.prevent="processForm"
              id="naksForm">
            <dx-load-panel :visible.sync="loading"
                           :close-on-outside-click="false"
                           :position="{ of: '#naksForm' }"
                           :shading="true"
                           shading-color="rgba(0,0,0,0.2)" />

            <dx-form ref="form"
                     :form-data="formData"
                     :items="formItems" />

            <dx-validation-summary></dx-validation-summary>
        </form>
    </div>
</template>

<script>

    import { DxForm, DxValidationSummary } from 'devextreme-vue';
    import { DxButton } from "devextreme-vue/ui/button";

    import DataSource from 'devextreme/data/data_source';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';
    import { naksDataSource, dataSourceConfs } from './data.js'

    export default {
        components: {
            DxButton,
            DxForm,
            DxValidationSummary,
            DataSource,
            DxLoadPanel
        },
        props: {
            'personId': String,
            'documentNaksId': String
        },
        watch: {
            '$route': 'fetchData',
            'formErrors': 'updateFormErrors',
            'documentNaks': 'makeFormData'
        },
        created() {
            this.fetchData()
        },
        data: function () {
            return {
                loading: false,
                documentNaks: null,
                error: null,
                naksDataSource: naksDataSource,
                dataSourceConfs: dataSourceConfs,
                formItems: [
                    {
                        itemType: 'group',
                        items: [
                            {
                                label: { text: 'Номер' },
                                dataField: 'Number',
                                required: true
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
                                required: true
                            },   
                            
                            {
                                dataField: 'WeldType_ID',
                                label: { text: 'Вид' },
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: dataSourceConfs.weldType,
                                    displayExpr: "Title",
                                    valueExpr: "WeldType_ID",
                                    searchEnabled: true
                                }
                            },
                            {
                                dataField: 'HIFGroup_IDs',
                                label: { text: 'Группы' },
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: dataSourceConfs.HIFGroup,
                                    displayExpr: "Title",
                                    valueExpr: "HIFGroup_ID",
                                    searchEnabled: true
                                }
                            },
                            

                        ]
                    },                    
                    {
                        itemType: "button",
                        horizontalAlignment: "left",
                        buttonOptions: {
                            text: "Submit",
                            type: "success",
                            useSubmitBehavior: true
                        }
                    }

                ],
                formData: {},
                formErrors: {}
            }
        },
        methods: {
            fetchData() {                
                this.error = this.documentNaks = null;
                if (!this.documentNaksId) {
                    this.loading = false;
                    return;
                }
                this.loading = true;
                var component = this;
                var source = this.employeeDataSource();
                source.filter(["DocumentNaks_ID", "=", new String(component.employeeId.toString())]);

                source
                    .load()
                    .done(function (data) {
                        component.loading = false;
                        component.documentNaks = data[0];
                    })
                    .fail(function (error) {
                        component.loading = false;
                        component.error = error;
                    });
            },
            makeFormData(documentNaks) {
                if (documentNaks == null) {
                    this.formData = {}
                } else {
                    this.formData = documentNaks;
                }
            },
            processForm(event) {
                this.loading = true;
                var component = this;
                var source = this.naksDataSource();
                if (this.documentNaksId) {
                    source.store().update(new String(this.documentNaksId.toString()), this.formData)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);

                } else {
                    var data = this.formData;
                    data.DocumentNaks_ID = null;

                    source.store().insert(data)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);
                }
            },
            processFormSuccess(data) {
                this.loading = false;
                var documentNaksId = data.DocumentNaks_ID ? data.DocumentNaks_ID : this.documentNaksId;
            },
            processFormFail(error) {
                this.loading = false;
                this.formErrors = error.errorDetails.details;
            },
            updateFormErrors() {
                var form = this.$refs.form.instance;

                Object.keys(this.formData).forEach(function (key, index) {
                    var editor = form.getEditor(key)
                    if (editor) {
                        editor.option('isValid', true);
                        editor.option('validationError', {});
                    }
                });

                for (var i = 0; i < this.formErrors.length; i++) {
                    var err = this.formErrors[i];
                    var editor = form.getEditor(err.target);
                    editor.option('isValid', false);
                    editor.option('validationError', { message: err.message });
                }

            },
            onEditorValueChanged(e) {
                console.log(e);
            }

        }
    };

</script>
