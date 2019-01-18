<template>
    <div class="content">
        <nav class="nav nav-tabs mt-2 px-4">
            <router-link class="nav-link" :to="{name: 'permission-employees'}">Персонал</router-link>
            <router-link class="nav-link" :to="{name: 'permission-reports-dashboard'}">Отчёты</router-link>
        </nav>
        <div class="content-body container-fluid">
            <router-view></router-view>    
        </div>
    </div>
</template>

<script>
    export default {
        name: "PermissionIndex"
    }
</script>

<style scoped>
    .content {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
    }

    .content-body {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
    }
</style>