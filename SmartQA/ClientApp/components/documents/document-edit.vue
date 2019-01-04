
<script>
    import BaseEntityEditor from "../forms/base-entity-editor";
    import { reftableFormItem } from "../forms/reftables";
    
    import context from "api/odata-context";
    
    export default {
        name: "DocumentEdit",
        extends: BaseEntityEditor,
        components: {BaseEntityEditor},
        watch: {
            model(val) {
                this.formTitle = 'Карточка документа № ' + val.Document_Code; 
            } 
        },
        data() {
            return {
                dataStore: context.Document,
                dataStoreLoadOptions: {
                    expand: ['DocumentStatusSet']
                },
                formItems: [
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
                    
                ]
            }
        },
        props: {
            id: String,
        },

        mounted() {
            this.init({                 
                modelKey: this.id,
                formDataInitial: {}
            });
        },
        methods: {
            
        }
    }
</script>

<style scoped>

</style>