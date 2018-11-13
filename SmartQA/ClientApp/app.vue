<template>      
    <div id="page">
        <div class="container-fluid">
            <div class="row">
                <main-menu />
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <employee-list @employee-selected="onEmployeeSelected"/>
                </div>
                <div class="col-sm-9">
                    <test-list />
                </div>

            </div>
        </div>

    </div>

</template>

<script>

    import { DxResponsiveBox, DxRow, DxCol } from "devextreme-vue/ui/responsive-box";
    import MainMenu from "./components/main-menu";
    import EmployeeList from "./components/employee-list";
    import TestList from "./components/test-list";
    import 'bootstrap';
    import 'bootstrap/dist/css/bootstrap.min.css';


export default {
    components: {
        MainMenu,
        EmployeeList,
        TestList,
        DxResponsiveBox,
        DxRow,
        DxCol
        },
    methods: {
        screenByWidth: function(width) {
            return width < 700 ? "sm" : "lg";
        },
        onEmployeeSelected(e) {
            alert(e.Employee_ID);
        }

    },

    name: "app"
}
</script>


    <style scoped>

</style>
