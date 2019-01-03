
<script>
    import BaseEntityEditor from "../forms/base-entity-editor";
    import { reftableFormItem } from "../forms/reftables";
    
    import context from "api/odata-context";
    
    export default {
        name: "DocumentEdit",
        extends: BaseEntityEditor,
        components: {BaseEntityEditor},
        data() {
            return {
                dataStore: context.Document,
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