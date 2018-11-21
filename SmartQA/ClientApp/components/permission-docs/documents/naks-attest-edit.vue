<template>
    <dx-scroll-view>
        <div>
            
            <form v-on:submit.prevent="processForm">
                <dx-load-panel :visible.sync="loading"
                               :close-on-outside-click="false"
                               :shading="true"
                               shading-color="rgba(0,0,0,0.2)" />

                <dx-form ref="form"
                         :form-data="formData"
                         :items="formItems" />

            </form>

        </div>
    </dx-scroll-view>
</template>

<script>
    import { DxForm, DxScrollView } from 'devextreme-vue';
    import DataSource from 'devextreme/data/data_source';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';
    import { reftableFormItem } from 'components/reftables/forms.js';
    import { dataSourceConfs } from './data.js';

    export default {
        components: {
            DxForm,
            DxLoadPanel,
            DataSource,
            DxScrollView,            
        },
        props: {
            'editModelKey': String,
            'parentId': String
        },
        watch: {
            'editModelKey': 'fetchData',
            'formErrors': 'updateFormErrors',
            'model': 'makeFormData'
        },
        created() {
            this.fetchData();
        },
        data: function () {
            return {
                modelKey: null,
                loading: false,
                model: null,
                error: null,
                dataSource: dataSourceConfs.documentNaksAttest,
                formItems: [
                    reftableFormItem('WeldingEquipmentAutomationLevel', 'Степень автоматизации сварочного оборудования'),
                    reftableFormItem('DetailsType', 'Вид деталей', true),
                    reftableFormItem('SeamsType', 'Типы швов', true),
                    reftableFormItem('JointType', 'Тип соединения'),
                    reftableFormItem('WeldMaterialGroup', 'Группа свариваемого материала', true),
                    reftableFormItem('WeldMaterial', 'Сварочные материалы', true),
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
                    reftableFormItem('WeldGOST14098', 'Обозначение по ГОСТ 14098')
                ],
                formData: {},
                formErrors: {}
            }
        },
        methods: {
            fetchData() {
                this.modelKey = this.editModelKey;
                this.error = this.model = null;
                this.formData = {};
                this.formErrors = {};

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
            submitForm() {
                this.processForm(null);
            },
            processForm(event) {
                this.loading = true;
                var component = this;
                var source = new DataSource(this.dataSource);
                var data = this.formData;
                data.DocumentNaks_ID = this.parentId;

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
                var source = new DataSource(this.dataSource);
                if (!this.modelKey) {
                    this.modelKey = data[source.key()]
                }
                //var employeeId = data.Employee_ID ? data.Employee_ID : this.employeeId;
                this.$emit('editSuccess', {
                    //modelKey: modelKeyi
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

            }

        }
    };

</script>
