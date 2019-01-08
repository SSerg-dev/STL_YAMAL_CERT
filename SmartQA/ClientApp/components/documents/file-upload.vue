<template>
    <div>
        <div class="card"
             v-bind:class="{ dropbox: isInitial }">
            <div class="card-body">
                <form enctype="multipart/form-data" novalidate v-if="isInitial || isSaving">
                    <input type="file"
                           multiple :name="uploadFieldName"
                           :disabled="isSaving"
                           @change="filesChange($event.target.name, $event.target.files); fileCount = $event.target.files.length"
                           accept="*"
                           class="input-file">
                    <div v-if="isInitial" class="upload-prompt">
                        <font-awesome-icon icon="upload"
                                           class="upload-icon"
                        />
                        <p>
                            Перетащите файлы сюда <br/>
                            или нажмите для выбора
                        </p>
                    </div>

                    <div v-if="isSaving">
                        <p>
                            Загрузка файлов ({{ fileCount }})...
                        </p>
                        <div class="progress">
                            <div class="progress-bar" role="progressbar"
                                 :style="`width: ${percentCompleted}%`"
                                 :aria-valuenow="percentCompleted" aria-valuemin="0" aria-valuemax="100"></div>
                        </div>
                    </div>
                </form>

                <div v-if="isSuccess">
                    <div class="alert alert-success" role="alert">
                        Загрузка завершена ({{ uploadedFiles.length }})
                    </div>
                    <button type="button" class="btn btn-info" @click="reset()">Загрузить ешё</button>

                </div>

                <div v-if="isFailed">
                    <div class="alert alert-danger" role="alert">
                        Загрузка не удалась
                    </div>
                    <button type="button" class="btn btn-info" @click="reset()">Загрузить ешё</button>

                    <pre>{{ uploadError }}</pre>
                </div>
            </div>
        </div>
        
    </div>
</template>

<script>
    import axios from 'axios';

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
                    })
                    .catch(err => {
                        this.uploadError = err.response;
                        this.currentStatus = STATUS_FAILED;
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
    .card {
        display: flex;
        //align-items: center;
        position: relative;
    }

    .input-file {
        opacity: 0; /* invisible but it's there! */
        width: 100%;
        height: 100%;
        position: absolute;
        top: 0;
        left: 0;
        cursor: pointer;
    }

    .dropbox {
        cursor: pointer;
    }

    .dropbox:hover {
        background: lightblue; /* when mouse over to the drop zone, change color */
    }

    .card p {
        text-align: center;
    }
    
    .upload-prompt {
        display: flex;
        align-content: center;
    }
    
    .upload-icon {
        width: 40px;
        height: 40px;
        margin-right: 1em;
        opacity: 0.2;
    }
</style>