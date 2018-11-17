<template>
    <div>
        <form v-on:submit.prevent="processForm">
            <dx-load-panel :visible.sync="loading"
                           :close-on-outside-click="false"                           
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
    import DataSource from 'devextreme/data/data_source';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';    

    import { dataSourceConfs } from './data.js';

    export default {
        components: {            
            DxForm,
            DxValidationSummary,
            DataSource,
            DxLoadPanel
        },
        props: {
            'modelKey': String,
            'personId': String
        },
        watch: {
            'modelKey': 'fetchData',
            'formErrors': 'updateFormErrors',
            'model': 'makeFormData'
        },
        created() {
            this.fetchData();                
        },
        data: function () {
            return {
                loading: false,
                model: null,
                error: null,
                dataSource: dataSourceConfs.documentNaks,
                formItems: [
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
                        editorType: 'dxTagBox',
                        editorOptions: {
                            dataSource: dataSourceConfs.HIFGroup,
                            displayExpr: "Title",
                            valueExpr: "HIFGroup_ID",
                            searchEnabled: true
                        }
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
                console.log(this.modelKey);
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
            makeFormData(model) {
                if (model == null) {
                    this.formData = {}
                } else {
                    this.formData = model
                }                
            },
            processForm(event) {
                this.loading = true;
                var component = this;
                var source = new DataSource(this.dataSource);
                var data = this.formData;
                data.Person_ID = this.personId;

                if (this.modelKey) {
                    source.store().update(new String(this.modelKey.toString()), data)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);
                } else {
                    source.store().insert(data)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);
                }
            },
            processFormSuccess(data) {
                this.loading = false;
                //var employeeId = data.Employee_ID ? data.Employee_ID : this.employeeId;
                this.$emit('editSuccess', {
                    //modelKey: modelKey
                })
            },
            processFormFail(error) {
                this.loading = false;
                this.formErrors = error.errorDetails.details;
            },
            updateFormErrors() {
                var form = this.$refs.form.instance;

                Object.keys(this.formData).forEach(function (key, index) {
                    var editor = form.getEditor(key);
                    if (editor) {
                        editor.option('isValid', true);
                        editor.option('validationError', {});
                    }
                });

                for (var i = 0; i < this.formErrors.length; i++) {
                    var err = this.formErrors[i];
                    var editor = form.getEditor(err.target);
                    if (editor) {
                        editor.option('isValid', false);
                        editor.option('validationError', { message: err.message });
                    }
                }

            },
            onEditorValueChanged(e) {
                console.log(e);
            }

        }
    };

</script>
