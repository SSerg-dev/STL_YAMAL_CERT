<template>
    <div class="container-fluid py-4">
        <h2>Пользователи</h2>
        <user-list />
    </div>
</template>

<script>
    import UserList from './user-list'

    export default {
        name: "user-index",
        components: {
            UserList
        }
    }
</script>

<style scoped>

</style>