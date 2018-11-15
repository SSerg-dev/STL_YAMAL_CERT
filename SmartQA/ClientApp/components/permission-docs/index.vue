<template>
    <div class="row">
        <div class="col-sm-3">                        
            <div class="py-md-3">
                <employee-list ref="employeeList"
                               v-bind:employee-id="employeeId" />
            </div>
        </div>
        <div class="col-sm-9">
            <div class="py-md-3">
                <div v-if="!employeeId" class="alert alert-info" role="alert">
                    Select an employee to proceed
                </div>

                <employee-details v-if="!edit"
                                  @employeeDeleted="onEmployeeDeleted"
                                  v-bind:employee-id="employeeId" />

                <employee-edit v-if="edit"
                               @employeeChanged="onEmployeeChanged"                               
                               v-bind:employee-id="employeeId" />
            </div>
        </div>
    </div>
</template>

<script>
    import EmployeeList from "./employee-list";
    import EmployeeEdit from "./employee-edit";
    import EmployeeDetails from "./employee-details";
    import TestList from "./test-list";

    export default {
        components: {
            EmployeeList,
            EmployeeEdit,
            EmployeeDetails,
            TestList
        },        
        props: {
            employeeId: String,
            edit: false
        },
        data: function () {
            return {
                                
            }
        },
        methods: {            
            onEmployeeChanged() {
                this.$refs.employeeList.reload();
            },
            onEmployeeDeleted(data) {
                if (this.employeeId == data.employeeId) {
                    this.$router.push({
                        params: { employeeId: null },
                        query: { edit: null }
                    })
                }
                this.$refs.employeeList.reload();
                
            }
        }
    }
</script>

<style scoped>

</style>

