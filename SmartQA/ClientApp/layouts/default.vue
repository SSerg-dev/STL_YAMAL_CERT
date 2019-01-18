<template>
    <div id="page-container">
        <div id="loading-placeholder" v-if="!userProfile">
            <dx-load-panel :visible="true"
                           :show-indicator="true"
                           :show-pane="true"
                           :shading="false"
                           :close-on-outside-click="false"/>
        </div>
        
        <div id="page" v-if="userProfile">
            <main-menu />
            <div class="page-body">
                <router-view></router-view>
            </div>
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
        methods: {}
    }
</script>


<style scoped>
    #page-container {
        min-height: 100%;
        display: flex;
        flex-direction: column;
    }
    
    #page, #loading-placeholder {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
        min-height: 100%;
    }

    .page-body {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
    }
    
    #loading-placeholder {
        justify-content: center;
        align-items: center;
    }
</style>
