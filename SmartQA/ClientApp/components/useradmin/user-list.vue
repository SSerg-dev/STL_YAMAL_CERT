<template>
    <div class="row">
        <div class="col py-5">
            <dx-toolbar :items="toolbarItems" />
            
            <dx-data-grid ref="dataGrid"
                          :show-row-lines="true"
                          :filterRow="{ visible: true }"
                          :dataSource="dataSource">
    
                <dx-column
                        caption="User name"
                        :allow-filtering="true"
                        :allow-search="true"
                        data-field="AppUser_Code" />
                
                <dx-column caption="Roles"
                        cell-template="roles-cell" />
    
                <dx-column :fixed="true"
                           fixedPosition="right"
                           width="160px"
                           cellTemplate="edit-column-cell"></dx-column>
    
                <div slot="roles-cell" slot-scope="row">
                    <span v-for="role in row.data.RoleSet"
                          class="badge badge-info badge-pill mr-1">
                        {{ role.Role_Code }}
                    </span>
                </div>
                
                <div slot="edit-column-cell" slot-scope="row">
                    <button type="button" class="btn btn-sm btn-light"
                            @click="onEditRowButtonClick($event, row.data)">
                        <font-awesome-icon icon="edit" />
                    </button>
    
                    <button type="button" class="btn btn-sm btn-light"
                            @click="onDeleteRowButtonClick($event, row.data)">
                        <font-awesome-icon icon="trash" />
                    </button>
    
                </div>
                
            </dx-data-grid>
        </div>
        <div class="col py-5" v-show="editing">
             
            <base-entity-editor 
                    ref="editor"
                    :store="dataSource.store"
                    :storeLoadOptions="{ expand: ['RoleSet'] }"
                    v-stream:state="formStateEvents" 
            />
                 
        </div>
        
    </div>
</template>
<script>
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
    import { DxToolbar, DxButton } from 'devextreme-vue'
    import { DxDataGrid, DxColumn } from 'devextreme-vue/data-grid'
    import { confirm } from 'devextreme/ui/dialog';
    import DataSource from 'devextreme/data/data_source';
    
    import { Subject } from 'rxjs';
    import { map, filter } from 'rxjs/operators';
    
    import BaseEntityEditor from 'components/forms/base-entity-editor'
    import { dataSourceConfs } from './data'
    
    
    export default {
        name: "user-list",
        components: {
            FontAwesomeIcon,
            DxToolbar,
            DxDataGrid,
            DxColumn,
            DxButton,
            BaseEntityEditor
        },
        subscriptions () {
            this.formStateEvents = new Subject();
            let formStateObs = this.formStateEvents.pipe(
                map(e => e.event.msg)
            );
            
            this.$subscribeTo(
                formStateObs.pipe(
                    filter(s => s.state === 'success')
                ), 
                this.onEditSuccess
            );  
            
            return {
                editing: formStateObs.pipe(
                    map(s => !(['uninitialized', 'success', 'canceled'].includes(s.state)))
                )
            }
        },
        data() {
            return {
                dataSource: dataSourceConfs.users,
                toolbarItems: [
                    {
                        location: 'after',
                        widget: 'dxButton',
                        options: {
                            type: 'add',
                            icon: 'add',
                            text: 'Add',
                            onClick: (event) => this.onNewButtonClick(event)
                        }
                    }
                ],
            }
        },
        methods: {
            reloadData() {
                this.$refs.dataGrid.instance.refresh();
            },
            onEditSuccess() {
                this.reloadData();
            },
            onNewButtonClick(event) {
                this.$refs.editor.init({
                    modelKey: null,
                    formDataInitial: {}
                }, {
                    formItems: this.getFormItems(null),
                    formTitle: 'Новый пользователь'
                });
            },           
            onEditRowButtonClick(event, model) {
                this.$refs.editor.init({
                    modelKey: model.ID,
                    formDataInitial: {}
                }, {
                    formItems: this.getFormItems(model.ID),
                    formTitle: model.AppUser_Code
                });
            },
            onDeleteRowButtonClick(event, model) {
                var component = this;
                confirm("Really delete?", "Confirm")
                    .done(function (dialogResult) {
                        if (dialogResult) {
                            let source = new DataSource(component.dataSource);
                            source.store().remove(model.ID)
                                .done(function (data) {
                                    component.reloadData()
                                });
                        }
                    });
            },
            getFormItems(modelKey) {
                return [
                    {
                        label: { text: 'Имя пользователя' },
                        dataField: 'AppUser_Code',
                        isRequired: true,
                        editorOptions: {
                            disabled: !!modelKey,
                        }
                    },
                    {
                        label: { text: 'Пароль' },
                        dataField: 'User_Password',
                        helpText: 'Если оставить поле пустым, то пароль не будет изменён',
                        isRequired: false,
                        editorOptions: {
                            mode: 'password'
                        }
                    },
                    {
                        label: { text: 'Роли' },
                        dataField: 'Role_IDs',
                        editorType: 'dxTagBox',
                        editorOptions: {
                            dataSource: dataSourceConfs.roles,
                            displayExpr: "Role_Code",
                            valueExpr: "ID",
                            searchEnabled: true,
                        },
                        isRequired: false,
                    }
                ]
            } 

        }
    }
</script>

<style scoped>

</style>