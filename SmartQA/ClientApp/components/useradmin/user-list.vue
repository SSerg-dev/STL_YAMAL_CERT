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

                
            <entity-form ref="userForm"
                         :formItems="formItems"
                         :formSettings="editRequests"
                         :commandRequests="formCommands"
                         :dataSource="dataSource"
                         v-stream:state="formStateEvents" />
            <div class="float-right mt-3">
                <dx-button
                        text="Cancel" 
                        @click="onCancelButtonClick"
                />

                <dx-button
                        type="success"
                        @click="onSubmitButtonClick"
                        text="Save" 
                />
                
            </div>
                 
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
    
    import EntityForm from 'components/forms/entity-form'
    import { dataSourceConfs } from './data'
    
    
    export default {
        name: "user-list",
        components: {
            FontAwesomeIcon,
            DxToolbar,
            DxDataGrid,
            DxColumn,
            DxButton,
            EntityForm
        },
        subscriptions() {
            this.formStateEvents = new Subject();
            
            this.$subscribeTo(
                this.formStateEvents.pipe(
                    filter(s => s.event.msg.state === 'success')
                ), 
                this.onEditSuccess
            );
            
            return {
                editing: this.editRequests.pipe(
                    map(request => request != null)
                )
            }
        },
        data() {
            return {
                editRequests: new Subject(),
                formCommands: new Subject(),
                dataSource: dataSourceConfs.users,
                formItems: [
                    {
                        label: { text: 'Имя пользователя' },
                        dataField: 'AppUser_Code',
                        isRequired: true
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
                            valueExpr: "Role_ID",
                            searchEnabled: true,
                        },
                        isRequired: false,
                    },
                ],
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
                this.editRequests.next(null);
            },
            onNewButtonClick(event) {
                this.editRequests.next({
                    modelKey: null,
                    formDataInitial: {}
                });
            },           
            onEditRowButtonClick(event, model) {
                this.editRequests.next({
                    modelKey: model.AppUser_ID,
                    formDataInitial: {}
                });
            },
            onDeleteRowButtonClick(event, model) {
                var component = this;
                confirm("Really delete?", "Confirm")
                    .done(function (dialogResult) {
                        if (dialogResult) {
                            let source = new DataSource(component.dataSource);
                            source.store().remove(model.AppUser_ID)
                                .done(function (data) {
                                    component.reloadData()
                                });
                        }
                    });
            },
            onSubmitButtonClick(event){
                this.formCommands.next({ command: 'submit' });
            },
            onCancelButtonClick(event){
                this.editRequests.next(null)
            }

        }
    }
</script>

<style scoped>

</style>