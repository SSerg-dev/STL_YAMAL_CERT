<template>
    <div>
        <nav class="nav nav-tabs my-2 px-4">
            <router-link class="nav-link" :to="{name: 'permission-employees'}">Персонал</router-link>
            <router-link class="nav-link" :to="{name: 'permission-reports-dashboard'}">Отчёты</router-link>
        </nav>
        <div class="container-fluid">
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

</style>