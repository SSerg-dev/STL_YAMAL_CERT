<template>      
    <component :is="layout">
        <router-view></router-view>
    </component>
</template>

<script>
    const defaultLayout = 'default';

    export default {
        computed: {
            layout() {
                return (this.$route.meta.layout || defaultLayout) + '-layout';
            }
        },
        components: {
              
        },

        methods: {
           
        },

        name: "app"
    }
</script>


<style scoped>

</style>
