<script>
    import BaseEntityEditor from "../forms/base-entity-editor";
    import {reftableFormItem} from "../forms/reftables";

    import context from "api/odata-context";

    export default {
        name: "DocumentEdit",
        extends: BaseEntityEditor,
        components: {BaseEntityEditor},
        watch: {
            model: {
                immediate: true,
                handler(val) {
                    this.formTitle = !val ? "" : `Карточка документа № ${val.Document_Code}`;
                }
            }
        },
        data() {
            return {
                dataStore: context.Document,
                dataStoreLoadOptions: {
                    expand: [
                        'DocumentStatusSet',
                        'Status'
                    ]
                },
                formItems: [
                    {
                        itemType: 'group',
                        caption: 'Карточка',
                        items: [
                            {
                                dataField: 'Status_ID',
                                label: {text: 'Статус'},
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: {
                                        store: context.Status,
                                        filter: ['StatusEntity', '=', 'Document'],
                                    },
                                    displayExpr: "Description_Rus",
                                    valueExpr: "ID",
                                    searchExpr: ['Description_Rus'],
                                    searchEnabled: true,
                                }
                            },
                            {
                                dataField: 'Document_Code',
                                label: {text: 'Номер карточки'},
                                disabled: true
                            },
                            {
                                dataField: 'Issue_Date',
                                label: {text: 'Дата регистрации'},
                                disabled: true,
                                editorType: 'dxDateBox',
                                editorOptions: {
                                    type: 'datetime'
                                }
                            },
                            {
                                dataField: 'Resp_Employee_ID',
                                label: {text: 'Ответственный'},
                                editorType: 'dxSelectBox',
                                editorOptions: {
                                    dataSource: {
                                        store: context.Employee,
                                        expand: ['Person', 'Contragent', 'Position']
                                    },
                                    displayExpr(itemData) {
                                        return !itemData ? '' :
                                            `${itemData.Person.FullName} (${itemData.Position.Title}, ${itemData.Contragent.Title})`
                                    },
                                    valueExpr: "ID"
                                },
                                disabled: true
                                
                            }
                            
                            
                        ]
                    },
                    {
                        itemType: 'group',
                        caption: 'Документ',
                        items: [
                            {
                                label: { text: 'Номер' },
                                dataField: 'Document_Number',
                                required: false
                            },
                            {
                                label: { text: 'Дата' },
                                dataField: 'Document_Date',
                                editorType: 'dxDateBox',
                                required: false
                            },
                            reftableFormItem("DocumentType", "Тип"),
                            {
                                label: { text: 'Название' },
                                dataField: 'Document_Name',
                                required: false
                            },
                            {
                                dataField: 'GOST_IDs',
                                label: {text: 'ГОСТ'},
                                editorType: 'dxTagBox',
                                editorOptions: {
                                    dataSource: {
                                        store: context.GOST,
                                        paginate: true,
                                        pageSize: 20,
                                        sort: ['GOST_Code']
                                    },
                                    displayExpr: "GOST_Code",
                                    valueExpr: "ID",
                                    searchExpr: ['GOST_Code'],
                                    searchEnabled: true,
                                }
                            },
                            {
                                dataField: 'PID_IDs',
                                label: {text: 'PID'},
                                editorType: 'dxTagBox',
                                editorOptions: {
                                    dataSource: {
                                        store: context.PID,
                                        paginate: true,
                                        pageSize: 20,
                                        sort: ['PID_Code'] 
                                    },
                                    displayExpr: "PID_Code",
                                    valueExpr: "ID",
                                    searchExpr: ['PID_Code'],
                                    searchEnabled: true,
                                }
                            },
                        ]
                    }
                ]
            }
        },
        mounted() {},
        methods: {
            onCancelButtonClick() {
                this.$router.push({
                    name: 'documents'
                });
            },
        }
    }
</script>

<style scoped>

</style>