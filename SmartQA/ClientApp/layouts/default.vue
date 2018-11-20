<template>
    <div id="page">
        <main-menu />

        <div class="container-fluid">
            <router-view></router-view>
        </div>
    </div>
</template>

<script>

    import MainMenu from "components/main-menu";

    export default {
        components: {
            MainMenu,
        },

        methods: {

        }
    }
</script>


<style scoped>
</style>
