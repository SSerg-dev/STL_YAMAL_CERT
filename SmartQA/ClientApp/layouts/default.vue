<template>
    <div id="page">
        <div v-if="!userProfile">
            <dx-load-panel :visible="true"
                           :show-indicator="true"
                           :show-pane="true"
                           :shading="false"
                           :close-on-outside-click="false" />

        </div>
        <div v-if="userProfile">
            <main-menu />
            
            <router-view></router-view>
            
        </div>
    </div>
</template>

<script>
    import DxLoadPanel from 'devextreme-vue/load-panel'

    import MainMenu from 'components/main-menu'

    export default {
        components: {
            DxLoadPanel,
            MainMenu,
        },
        computed: {
            userProfile() {
                return this.$store.getters.getProfile;
            }
        },
        methods: {

        }
    }
</script>


<style scoped>
    #page {
        display: flex;
        flex-direction: column;
        min-height: 100%;
    }
</style>
