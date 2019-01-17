<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-2">
                <nav class="nav nav-pills">
                    <router-link class="nav-link" :to="{name: 'permission-reports-naks'}">Отчёт по НАКС</router-link>
                    <router-link class="nav-link" :to="{name: 'permission-reports-naks2'}">Ещё отчёт</router-link>
                </nav>
            </div>
            <div class="col-10">
                <router-view></router-view>
            </div>
        </div>
    </div>
</template>

<script>

    export default {
        name: "PermissionReportsIndex"
    }
</script>

<style scoped>

</style>