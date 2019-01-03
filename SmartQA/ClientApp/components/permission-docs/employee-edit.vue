<script>
    import {reftableDatasourceConf} from "components/reftables/data"
    import context from 'api/odata-context'
    import BaseEntityEditor from 'components/forms/base-entity-editor'
    
    export default {
        extends: BaseEntityEditor,
        props: {
            employeeId: {
                type: String,
                required: true
            }             
        },
        watch: {
            employeeId: {
                immediate: true,
                handler(val) {
                    this.init({
                        modelKey: val
                    });
                }
            },
            modelKey: {
                immediate: true,
                handler(val) {
                    this.formTitle = val ? 'Карточка сотрудника' : 'Новый сотрудник';
                }
            }
        },
        data: function () {
            return {
                dataStore: context.Employee,
                dataStoreLoadOptions: { expand: 'Person' },
                formTitle: null,
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
                            }
                        ]
                    },
                    {
                        itemType: 'group',
                        items: [
                            {
                                label: { text: 'Организация' },
                                editorOptions: {
                                    dataSource: reftableDatasourceConf("Contragent"),
                                    displayExpr: "Description",
                                    valueExpr: "ID",
                                    searchExpr: ['Description'],
                                    searchEnabled: true,
                                },
                                dataField: 'Contragent_ID',
                                editorType:'dxSelectBox',
                                isRequired: true
                            },                            
                            {
                                label: { text: 'Должность' },
                                editorOptions: {
                                    dataSource: reftableDatasourceConf("Position"),
                                    displayExpr: "Description",
                                    valueExpr: "ID",
                                    searchExpr: ['Description'],
                                    searchEnabled: true,
                                },
                                dataField: 'Position_ID',
                                editorType:'dxSelectBox',
                                isRequired: true
                            }
                        ]
                    }
                ]
            }
        },
        methods: {
            makeFormData(model = null, initialData = null) {
                let data = {};
                if (initialData) {
                    data = Object.assign(data, initialData)
                }
                if (model) {
                    data = Object.assign(data, {
                        FirstName: model.Person.FirstName,
                        LastName: model.Person.LastName,
                        SecondName: model.Person.SecondName,
                        BirthDate: model.Person.BirthDate,
                        Position_ID: model.Position_ID,
                        Contragent_ID: model.Contragent_ID
                    });
                }
                return data;
            },
            onCancelButtonClick() {
                this.$router.push({
                    params: { employeeId: this.employeeId }
                })
            },
            afterSubmitSuccess(state) {
                this.$emit('employeeChanged', {
                    employeeId: this.modelKey
                });
                this.$router.push({
                    params: { employeeId: this.modelKey.toString() },
                    query: { edit: false }
                })
            }
        }
    };

</script>
