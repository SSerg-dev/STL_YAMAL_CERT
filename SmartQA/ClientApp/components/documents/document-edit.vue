<template>
    <entity-form ref="form"
                 :formItems="formItems"
                 :formSettings="editRequests"
                 :commandRequests="formCommands"
                 :dataSource="dataSource"
                 v-stream:state="formStateEvents$" />

</template>

<script>
    import EntityForm from "../forms/entity-form";
    import {dataSourceConfs} from "./data";
    import {reftableFormItem} from "../forms/reftables";
    export default {
        name: "DocumentEdit",
        components: {EntityForm},
        data() {
            return {
                dataSource: dataSourceConfs.document,
                formItems: [
                    {
                        label: { text: 'Номер' },
                        dataField: 'Document_Number',
                        required: false
                    },
                    {
                        label: { text: 'Дата' },
                        dataField: 'Document_Date',
                        required: false
                    },
                    reftableFormItem("DocumentType", "Тип"),
                    {
                        label: { text: 'Название' },
                        dataField: 'Document_Name',
                        required: false
                    },
                    
                ],
                editRequests: new Subject(),
                formCommands: new Subject(),
            }
        },
        props: {
            id: String,
        },
        subscriptions() {
            return {}
        },
        activated() {
            this.editRequests.next({
                modelKey: this.id,
                formDataInitial: {}
            })
        },
        methods: {
            
        }
        
    }
    
</script>

<style scoped>

</style>