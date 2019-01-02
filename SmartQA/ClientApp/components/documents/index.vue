<template>
    <div class="mt-5">
        <dx-toolbar>
            <dx-item location="before"
                     widget="dxButton"
                     :options="{
                        type: 'add',
                        icon: 'add',
                        text: 'Создать документ'
                        }" />
            
        </dx-toolbar>
        lkjhlkhj
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