<template>
    <div>
        <div class="btn-toolbar justify-content-between mb-2" role="toolbar">
            <div class="btn-group mr-2" role="group">
                <h5>
                    Файлы
                    <span class="text-muted" v-if="totalCount">
                        ({{ totalCount }})
                    </span>                     
                </h5>
            </div>

            <div class="btn-group" role="group" v-if="editable">
                <file-upload
                    class="mt-lg-0 mt-2"
                    :upload-url="uploadUrl"
                    @uploaded="onUploaded" />
            </div>
        </div>

        <dx-data-grid ref="dataGrid"
                      :show-borders="true"
                      :allow-column-resizing="true"
                      :data-source="dataSource"
                      @content-ready="onDataGridContentReady">

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
                required: false,
            }
        },
        computed: {
            dataSource(){
                return new DataSource({
                    store: context.DocumentAttachment,
                    sort: ['Insert_DTS'],
                    requireTotalCount: true,
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
                totalCount: null
            }
        },
        methods: {
            onUploaded() {
                this.$refs.dataGrid.instance.refresh();
            },
            onDataGridContentReady(e) {
                this.totalCount = e.component.totalCount();
            }
        }
    }
</script>

<style scoped>

</style>