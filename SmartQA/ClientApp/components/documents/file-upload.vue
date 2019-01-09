<template>
    <div>
        <div class="btn"
             v-bind:class="{ 
                dropbox: isInitial,
                'btn-outline-dark': isInitial,
                'btn-outline-success': isSuccess,
                'btn-outline-danger': isFailed,
                'btn-outline-info': isSaving 
             }"
             @click="function (){ if (isSuccess || isFailed) reset() }">
            
                <form enctype="multipart/form-data" novalidate v-if="isInitial || isSaving">
                    <input type="file"
                           multiple :name="uploadFieldName"
                           :disabled="isSaving"
                           @change="filesChange($event.target.name, $event.target.files); fileCount = $event.target.files.length"
                           accept="*"
                           class="input-file">
                    
                    <div v-if="isInitial" class="upload-prompt">
                        <font-awesome-icon icon="upload"
                                           class="upload-icon" />
                        
                        Загрузить файлы
                        
                    </div>

                    <div v-if="isSaving">
                        <span>
                            Загрузка файлов ({{ fileCount }})...
                        </span>
                        <div class="progress">
                            <div class="progress-bar" role="progressbar"
                                 :style="`width: ${percentCompleted}%`"
                                 :aria-valuenow="percentCompleted" aria-valuemin="0" aria-valuemax="100"></div>
                        </div>
                    </div>
                </form>

                <div v-if="isSuccess">
                    Загружено: {{ uploadedFiles.length }}. Загрузить ещё?
                </div>

                <div v-if="isFailed">
                    Загрузка не удалась. Загрузить ещё?                     
                </div>
            </div>
        
        
    </div>
</template>

<script>
    import axios from 'axios';
    import notify from 'devextreme/ui/notify';

    const STATUS_INITIAL = 0, STATUS_SAVING = 1, STATUS_SUCCESS = 2, STATUS_FAILED = 3;

    export default {
        name: 'app',
        props: {
            uploadUrl: {
                type: String,
                required: true
            }
        },
        data() {
            return {
                uploadedFiles: [],
                uploadError: null,
                currentStatus: null,
                uploadFieldName: 'File',
                percentCompleted: 0
            }
        },
        computed: {
            isInitial() {
                return this.currentStatus === STATUS_INITIAL;
            },
            isSaving() {
                return this.currentStatus === STATUS_SAVING;
            },
            isSuccess() {
                return this.currentStatus === STATUS_SUCCESS;
            },
            isFailed() {
                return this.currentStatus === STATUS_FAILED;
            }
        },
        methods: {
            reset() {
                // reset form to initial state
                this.currentStatus = STATUS_INITIAL;
                this.uploadedFiles = [];
                this.uploadError = null;
            },
            save(formData) {
                // upload data to the server
                this.percentCompleted = 0;
                this.currentStatus = STATUS_SAVING;

                return axios.post(this.uploadUrl, formData, {
                    onUploadProgress: this.onUploadProgress
                })
                    .then(x => x.data)
                    .then(x => {
                        this.uploadedFiles = [].concat(x.value);
                        this.$emit('uploaded', this.uploadedFiles);
                        this.currentStatus = STATUS_SUCCESS;
                        notify('Файлы загружены', 'success', 5000);
                        
                    })
                    .catch(err => {
                        this.uploadError = err.response;
                        this.currentStatus = STATUS_FAILED;
                        notify(`Ошибка при загрузке: ${err.response}`, 'error', 5000);
                        console.error(err.response)
                    });
            },
            filesChange(fieldName, fileList) {
                // handle file changes
                const formData = new FormData();

                if (!fileList.length) return;

                // append the files to FormData
                Array
                    .from(Array(fileList.length).keys())
                    .map(x => {
                        formData.append(fieldName, fileList[x], fileList[x].name);
                    });

                // save it
                this.save(formData);
            },
            onUploadProgress(progressEvent) {
                this.percentCompleted = Math.floor((progressEvent.loaded * 100) / progressEvent.total);
            }
        },
        mounted() {
            this.reset();
        },
    }
</script>

<style scoped lang="scss">
    .input-file {
        opacity: 0; /* invisible but it's there! */
        width: 100%;
        height: 100%;
        position: absolute;
        top: 0;
        left: 0;
        cursor: pointer;
    }
    
</style>