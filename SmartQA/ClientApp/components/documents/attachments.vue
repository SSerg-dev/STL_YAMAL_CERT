<template>
    <div>
        <file-upload
                :upload-url="uploadUrl"
                @uploaded="onUploaded" />
        
        <dx-data-grid ref="dataGrid"
                      :allow-column-resizing="true"
                      :data-source="dataSource">

            <dx-editing
                    :allow-updating="editable"
                    :allow-deleting="editable"
                    :allow-adding="false" />
            
            <dx-column data-field="Description"
                       caption="Описание"
                       :allow-editing="true" />

            <dx-column data-field="FileDesc.UploadName"
                       caption="Файл"
                       :allow-editing="false" />
            
            <dx-column data-field="FileDesc.Length"
                       format="largeNumber"
                       caption="Размер"
                       :allow-editing="false"/>
            
            <dx-column data-field="Insert_DTS"
                       data-type="datetime"
                       caption="Загружено"
                       :allow-editing="false"/>
            
        </dx-data-grid>

    </div>
</template>

<script>
    import DataSource from "devextreme/data/data_source"
    import {DxColumn, DxDataGrid, DxEditing} from 'devextreme-vue/data-grid'

    import context from 'api/odata-context'
    import FileUpload from './file-upload'

    export default {
        name: "Attachments",
        components: {
            DxDataGrid, DxColumn, FileUpload, FileUpload, DxEditing
        },
        props: {
            documentId: {
                type: String,
                required: true
            },
            editable: {
                type: Boolean,
                default: true,
                required: false
            }
        },
        computed: {
            dataSource(){
                return new DataSource({
                    store: context.DocumentAttachment,
                    sort: ['Insert_DTS'],
                    filter: [
                        ['Document_ID', '=', new String(this.documentId)]
                    ]
                })
            },
            uploadUrl() {
                return `${context.Document._url}(${this.documentId})/UploadAttachments?$expand=FileDesc`;
            }
            
        },
        data() {
            return {
          
            }
        },
        methods: {
            onUploaded() {
                this.$refs.dataGrid.instance.refresh();
            }
        }
    }
</script>

<style scoped>

</style>