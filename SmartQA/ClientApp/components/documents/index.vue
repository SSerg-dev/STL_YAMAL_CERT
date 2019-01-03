<template>
    <div class="mt-5">
       
        <document-list />
    </div>
</template>

<script>

    import DataSource from 'devextreme/data/data_source'
    import DxToolbar from  'devextreme-vue/toolbar'
    import DxButton from 'devextreme-vue/button'
    
    import DxItem from 'devextreme-vue/toolbar'
    import DocumentList from "./document-list";
    import { dataSourceConfs} from "./data";

    export default {
        name: "DocumentsIndex",
        components: { 
            DocumentList,       
            DxToolbar,
            DxButton,
            DxItem
        },
        data: function () { 
            return {

            }
        },
        methods: {
         
        }
    }
</script>

<style scoped>

</style>