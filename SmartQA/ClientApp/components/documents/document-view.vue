<template>
    <div class="form-container my-3">
        
        <div class="btn-toolbar justify-content-between" role="toolbar">
            <div class="input-group">
                <h4 v-if="formTitle">{{ formTitle }}</h4>
            </div>
            
            <div class="btn-group" role="group">
                <router-link
                        :to="{ name: 'document-edit', params: { documentId: documentId }}"
                        class="btn btn-outline-primary">
                    Редактировать
                </router-link>
            </div>
        </div>

        <div class="row" v-if="model">
            <div class="col-md-6">
                <h5>Карточка</h5>
                <table class="table">
                    <tr>
                        <th scope="row">Статус</th>
                        <td>{{ model.Status.Description_Rus }}</td>
                    </tr>
                    <tr>
                        <th scope="row">Номер карточки</th>
                        <td>{{ model.Document_Code }}</td>
                    </tr>
                    <tr>
                        <th scope="row">Дата регистрации</th>
                        <td>{{ formatDate(new Date(model.Issue_Date), 'shortDateShortTime') }}</td>
                    </tr>
                    <tr>
                        <th scope="row">Ответственный</th>
                        <td>
                            <div v-if="model.Resp_Employee">
                                {{ model.Resp_Employee.Person.FullName }} <br />
                                {{ model.Resp_Employee.Position.Description }},
                                {{ model.Resp_Employee.Contragent.Description }}
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-md-6">
                <h5>Документ</h5>
                <table class="table">
                    <tr>
                        <th scope="row">Номер</th>
                        <td>{{ model.Document_Number }}</td>
                    </tr>
                    <tr>
                        <th scope="row">Дата</th>
                        <td><div v-if="model.Document_Date">
                            {{ formatDate(new Date(model.Document_Date), 'shortDate') }}
                        </div></td>
                    </tr>
                    <tr>
                        <th scope="row">Тип</th>
                        <td>{{ model.DocumentType.Title }}</td>
                    </tr>                   
                    <tr>
                        <th scope="row">Название</th>
                        <td>{{ model.Document_Name }}</td>
                    </tr>
                    <tr>
                        <th scope="row">Страниц</th>
                        <td>{{ model.TotalSheets }}</td>
                    </tr>
                    <tr>
                        <th scope="row">ГОСТ</th>
                        <td>
                            <ul class="list-unstyled" v-if="model.GOSTSet">
                                <li v-for="gost in model.GOSTSet">
                                    {{ gost.GOST_Code }}
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">PID</th>
                        <td>
                            <ul class="list-unstyled" v-if="model.PIDSet">
                                <li v-for="pid in model.PIDSet">
                                    {{ pid.PID_Code }}
                                </li>
                            </ul>
                        </td>
                    </tr>
                </table>    
            </div>
        </div>

        
        <attachments
                class="mt-3"
                v-if="documentId"
                :editable="false"
                :document-id="documentId"/>
    

        <dx-load-panel :position="{ of: '.form-container' }"
                       :visible="state === 'loading'"
                       :delay="100"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="true"
                       shading-color="rgba(0,0,0,0.2)"
                       :close-on-outside-click="false"/>

    </div>
</template>

<script>
    import DxLoadPanel from 'devextreme-vue/load-panel'
    import {formatDate} from 'devextreme/localization'

    import BaseEntityEditor from "../forms/base-entity-editor"
    import Attachments from './attachments'

    import context from "api/odata-context"

    export default {
        name: "DocumentView",
        components: {BaseEntityEditor, DxLoadPanel, Attachments},

        
        props: {
            documentId: {
                type: String,
                required: true
            }
        },
        watch: {
            documentId: {
                immediate: true,
                handler(val) {
                    this.init(val);
                }
            },
            model: {
                immediate: true,
                handler(val) {
                    this.formTitle = !val ? "" : `Карточка документа № ${val.Document_Code}`;
                }
            }
        },
        computed: {
        },
        data() {
            return {
                state: 'uninitialized',
                model: null,
                dataStore: context.Document,
                dataStoreLoadOptions: {
                    expand: [
                        'DocumentType',
                        'Resp_Employee',
                        'Resp_Employee.Person',
                        'Resp_Employee.Contragent',
                        'Resp_Employee.Position',
                        'GOSTSet',
                        'PIDSet',
                        'DocumentStatusSet',
                        'Status'
                    ]
                },

                formatDate: formatDate,
            }
        },
        mounted() {
            
        },
        methods: {
            init() {
                this.state = 'initializing';
                
                this.loadModel();
            },
            loadModel() {
                this.state = 'loading';
                this.error = null;
                this.dataStore.byKey(this.documentId, this.dataStoreLoadOptions)
                    .done(this.onLoadModelSuccess)
                    .fail(this.onLoadModelFail);
            },
            onLoadModelSuccess(data) {
                this.model = data;
                this.state = 'ready';
            },
            onLoadModelFail(error){
                this.state = 'error';
                this.error = error;
            }
            
        }
    }
</script>

<style scoped>
    th {
        width: 38.2%;
        font-weight: normal;
    }
    td {
        wifth: 61.8%;
    }
    
</style>