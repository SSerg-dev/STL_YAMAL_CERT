<template>      
    <div id="page">       
        <main-menu />

        <div class="container-fluid">
            <router-view></router-view>
        </div>

    </div>

</template>

<script>

    import MainMenu from "./components/main-menu";
    import 'bootstrap';
    import 'bootstrap/dist/css/bootstrap.min.css';

    export default {
        components: {
            MainMenu,        
            },

        methods: {
            screenByWidth: function(width) {
                return width < 700 ? "sm" : "lg";
                }            
            },

        name: "app"
    }
</script>


<style scoped>

</style>
