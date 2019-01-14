<template>
    <div class="employee-container">
        <dx-load-panel :visible="loading"
                       :position="{ of: '.employee-container' }"
                       :delay="100"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="true"
                       shading-color="rgba(0,0,0,0.2)"
                       :close-on-outside-click="false" />

        <div v-if="error" class="error">
            {{ error }}
        </div>
        <div v-if="employee">
            <dx-toolbar :items="toolbarItems"
                        class="pb-3" />

            <h2>
                {{ employee.Person.LastName }}
                {{ employee.Person.FirstName }}
                {{ employee.Person.SecondName }}
            </h2>

            <div class="row">
                <div class="col-sm-3">Дата рождения</div>
                <div class="col-sm-9">
                    {{ formatDate(new Date(employee.Person.BirthDate), 'shortDate') }}
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">Организация</div>
                <div class="col-sm-9">{{ employee.Contragent.Title }}</div>
            </div>
            <div class="row">
                <div class="col-sm-3">Должность</div>
                <div class="col-sm-9">{{ employee.Position.Description }}</div>
            </div>
            <div class="pt-5">
                <h3>Удостоверения НАКС</h3>
                <naks-list :person-id="employee.Person_ID.toString()" />
            </div>
            <div class="pt-5">
                <h3>Удостоверения НК</h3>
                <ndt-list :person-id="employee.Person_ID.toString()" />
            </div>
        </div>

    </div>
</template>

<script>

    import DataSource from 'devextreme/data/data_source'
    import DxLoadPanel from 'devextreme-vue/load-panel'
    import DxButton from "devextreme-vue/ui/button"
    import DxToolbar from 'devextreme-vue/toolbar'
    import {confirm} from 'devextreme/ui/dialog'
    import {formatDate} from "devextreme/localization"

    import {employeeDataSource} from './employee-data.js'

    import NaksList from './documents/naks-list';
    import NdtList from './documents/ndt-list';

    export default {
        components: {
            DataSource,
            DxLoadPanel,
            DxButton,
            DxToolbar,
            NaksList,
            NdtList
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
                                    params: { employeeId: this.employeeId.toString() },
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
            formatDate: formatDate,
            fetchData() {                                
                this.error = this.employee = null;
                if (!this.employeeId) {
                    this.loading = false;                
                    return;
                }
                this.loading = true;                
                var component = this;                                
                var source = this.employeeDataSource();
                source.filter(["ID", "=", new String(component.employeeId.toString())]);
                
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
