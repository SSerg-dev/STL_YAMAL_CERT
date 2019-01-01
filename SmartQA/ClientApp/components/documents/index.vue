<template>
    <div>
        <button @click="onNewDocumentClick">new</button>
        
        <document-list />
    </div>
</template>

<script>
    import DataSource from 'devextreme/data/data_source'
    import DocumentList from "./document-list";
    import { dataSourceConfs} from "./data";

    export default {
        name: "DocumentsIndex",
        components: { DocumentList },
        data: function () { 
            return {}
        },
        methods: {
            onNewDocumentClick(event) {
                let ds = new DataSource(dataSourceConfs.document);
                
                ds.store().insert({}).then(function(data) {
                    alert(data);
                })
            }
        }
    }
</script>

<style scoped>

</style>