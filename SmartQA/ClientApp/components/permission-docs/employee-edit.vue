<template>
    <div>
        <h2 v-if="employeeId">Edit employee</h2>
        <h2 v-if="!employeeId">New employee</h2>

        <form class="py-3"
              v-on:submit.prevent="processForm"
              id="employeeForm">
            <dx-load-panel :visible.sync="loading"
                           :close-on-outside-click="false"
                           :position="{ of: '#employeeForm' }"
                           :shading="true"
                           shading-color="rgba(0,0,0,0.2)"
                    />

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
    import { employeeDataSource, contragentDataSource, positionDataSource } from './employee-data.js'

    export default {
        components: {
            DxButton,
            DxForm,
            DxValidationSummary,
            DataSource,
            DxLoadPanel
        },
        props: {
            'employeeId': String
        },
        watch: {
            '$route': 'fetchData',
            'formErrors': 'updateFormErrors',
            'employee': 'makeFormData'
        },
        created() {
            this.fetchData()
        },
        data: function () {
            return {
                loading: false,
                employee: null,
                error: null,
                employeeDataSource: employeeDataSource,
                formItems: [
                    {
                        itemType: 'group',
                        items: [
                            {                  
                                label: { text: 'Фамилия' },
                                dataField: 'LastName',
                                required: true
                            },
                            {
                                dataField: 'FirstName',
                                label: { text: 'Имя' },
                            },
                            {
                                dataField: 'SecondName',
                                label: { text: 'Отчество' },
                            },
                            {
                                dataField: 'BirthDate',
                                label: { text: 'Дата рождения' },
                                editorType: 'dxDateBox',
                                editorOptions: {
                                    onValueChanged: 'onEditorValueChanged',
                                }
                            }
                        ]
                    },
                    {
                        itemType: 'group',
                        items: [
                            {
                                dataField: 'Contragent_ID',
                                label: { text: 'Организация' },
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: contragentDataSource,
                                    displayExpr: "Contragent_Code",
                                    valueExpr: "Contragent_ID",
                                    searchEnabled: true
                                }
                            },
                            {
                                dataField: 'Position_ID',
                                label: { text: 'Должность' },
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: positionDataSource,
                                    displayExpr: "Description_Rus",
                                    valueExpr: "Position_ID",
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
                console.log(this.employeeId);
                this.error = this.employee = null;
                if (!this.employeeId) {
                    this.loading = false;
                    return;
                }
                this.loading = true;
                var component = this;
                var source = this.employeeDataSource();
                source.filter(["Employee_ID", "=", new String(component.employeeId.toString())]);

                source
                    .load()
                    .done(function (data) {
                        component.loading = false;
                        component.employee = data[0];
                    })
                    .fail(function (error) {
                        component.loading = false;
                        component.error = error;
                    });
            },
            makeFormData(employee) {
                if (employee == null) {
                    this.formData = {}
                } else {
                    this.formData = {
                        FirstName: employee.Person.FirstName,
                        LastName: employee.Person.LastName,
                        SecondName: employee.Person.SecondName,
                        BirthDate: employee.Person.BirthDate,
                        Position_ID: employee.Position_ID,
                        Contragent_ID: employee.Contragent_ID
                    }
                }
            },
            processForm(event) {
                this.loading = true;
                var component = this;
                var source =this.employeeDataSource();
                if (this.employeeId) {
                    source.store().update(new String(this.employeeId.toString()), this.formData)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);

                } else {
                    var data = this.formData;
                    data.Employee_ID = null;

                    source.store().insert(data)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);
                }                
            },
            processFormSuccess(data) {
                this.loading = false;
                var employeeId = data.Employee_ID ? data.Employee_ID : this.employeeId;
                this.$emit('employeeChanged', {
                    employeeId: employeeId
                })
                this.$router.push({
                    params: { employeeId: employeeId },
                    query: { edit: false }
                })
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
