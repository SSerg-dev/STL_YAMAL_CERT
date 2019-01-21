<template>
    <div id="page-container">
        <div id="loading-placeholder" v-if="!userProfile">
            <div class="spinner-border" style="width: 10rem; height: 10rem;" role="status">
                <span class="sr-only">Загрузка...</span>
            </div>
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
    import MainMenu from 'components/main-menu'

    export default {
        components: {
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
