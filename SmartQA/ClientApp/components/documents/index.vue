<template>
    <div class="container-fluid py-4">
        <h2>Документы</h2>
        <document-list />
    </div>
</template>

<script>

    import DxToolbar from 'devextreme-vue/toolbar'
    import DxItem from 'devextreme-vue/toolbar'
    import DxButton from 'devextreme-vue/button'
    import DocumentList from "./document-list";

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