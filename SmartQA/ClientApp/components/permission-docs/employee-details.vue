<template>
    <div>
        <div class="loading" v-if="loading">
            <dx-load-indicator id="large-indicator"
                               :height="60"
                               :width="60" />
        </div>

        <div v-if="error" class="error">
            {{ error }}
        </div>
        <div v-if="employee">
            <dx-toolbar :items="toolbarItems" 
                        class="pb-3"/>

            <h2>
                {{ employee.Person.LastName }}
                {{ employee.Person.FirstName }}
                {{ employee.Person.SecondName }}
            </h2>

            <div class="row">
                <div class="col-sm-3">Дата рождения</div>
                <div class="col-sm-9">{{ employee.Person.BirthDate }}</div>
            </div>
            <div class="row">
                <div class="col-sm-3">Компания</div>
                <div class="col-sm-9">{{ employee.Contragent.Contragent_Code }}</div>
            </div>
            <div class="row">
                <div class="col-sm-3">Должность</div>
                <div class="col-sm-9">{{ employee.Position.Description_Rus }}</div>
            </div>            
        </div>
        
    </div>
</template>

<script>

    import DataSource from 'devextreme/data/data_source';
    import DxLoadIndicator from 'devextreme-vue/load-indicator';
    import DxButton from "devextreme-vue/ui/button";
    import DxToolbar from 'devextreme-vue/toolbar';

    import { employeeDataSource } from './employee-data.js'    
    import { confirm } from 'devextreme/ui/dialog';


    export default {
        components: {
            DataSource,
            DxLoadIndicator,
            DxButton,
            DxToolbar
        },
        props: {
            'employeeId' : String
        },
        created() {            
            this.fetchData()
        },
        watch: {            
            '$route': 'fetchData'
        },
        data: function () {
            return {
                loading: false,
                employee: null,
                error: null,
                employeeDataSource: employeeDataSource,
                toolbarItems: [
                    {
                        location: 'before',
                        widget: 'dxButton',
                        options: {
                            type: 'edit',
                            icon: 'edit',
                            text: 'Edit employee',
                            onClick: () => {
                                this.$router.push({
                                    params: { employeeId: this.employeeId },
                                    query: { edit: true }
                                })
                            }
                        }
                    },
                    {
                        location: 'before',
                        widget: 'dxButton',
                        options: {
                            type: 'delete',
                            icon: 'trash',
                            text: 'Delete',
                            onClick: () => {
                                var component = this;
                                
                                confirm("Really delete?", "Confirm")
                                    .done(function (dialogResult) {
                                        if (dialogResult) component.deleteEmployee();                                        
                                    });                                                                                            
                                
                            }
                        }
                    }
                ]
            }
        },
        methods: {
            fetchData() {                
                console.log(this.employeeId);
                this.error = this.employee = null;
                if (!this.employeeId) {
                    this.loading = false;                
                    return;
                }
                this.loading = true;                
                var component = this;                                
                var source = this.employeeDataSource();
                source.filter(["Employee_ID", "=", new String(component.employeeId.toString())]);
                
                source
                    .load()
                    .done(function (data) {
                        component.loading = false;
                        component.employee = data[0];
                    })
                    .fail(function (error) {
                        component.loading = false;
                        component.error = error;
                    });                                
            },
            deleteEmployee() {
                var component = this;        
                this.employeeDataSource().store().remove(component.employeeId)
                    .done(function (data) {
                        component.$emit("employeeDeleted", {
                            employeeId: component.employeeId
                        });
                    });
            }
            
        }
    };
</script>
