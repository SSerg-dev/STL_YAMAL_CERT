<template>
    <div class="row component-container">
        <dx-drawer
                class="drawer"
                ref="drawer"
                position="left"
                opened-state-mode="shrink"
                :opened.sync="drawerOpen"
                template="drawer-sidebar">

            <div slot="drawer-sidebar"
                 slot-scope="data"
                 class="drawer-sidebar">
                <nav class="nav flex-column nav-pills">
                    <router-link class="nav-link" :to="{name: 'permission-reports-naks'}">Отчёт по НАКС</router-link>
                    <router-link class="nav-link" :to="{name: 'permission-reports-naks2'}">Ещё отчёт</router-link>
                </nav>
            </div>

            <div class="drawer-content">
                <div class="drawer-toggle" @click="drawerToggleClick">
                    <font-awesome-icon :icon="drawerOpen ? 'chevron-left' : 'chevron-right'"
                                       class="drawer-toggle-icon"/>
                </div>
                
                <router-view></router-view>
            </div>
        </dx-drawer>


    </div>
</template>

<script>
    import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';
    import DxDrawer from 'devextreme-vue/drawer'

    export default {
        name: "PermissionReportsIndex",
        components: {
            DxDrawer,
            FontAwesomeIcon,
        },
        data() {
            return {
                drawerOpen: true,
            }
        },
        methods: {
            drawerToggleClick(event) {
                this.$refs.drawer.instance.toggle();
            }
        }
    }
</script>

<style scoped lang="scss">
    @import "~bootstrap/scss/bootstrap";

    .component-container {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
    }
    
    .drawer {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
    }
    
    .drawer-sidebar {
        @extend .px-2;
    }

    .drawer-content {
        
        min-height: 100%;
        display: flex;
        flex-direction: row;
        align-items: stretch;
        
        .drawer-toggle {
            @extend .bg-light, .text-secondary, .px-2, .pt-3;
            
            display: flex;
            justify-content: center;
            
            min-width: 25px;
            cursor: pointer;
        }
        
        .drawer-toggle:hover {
            @extend .bg-secondary, .text-light;
        }
    }

    .component-container /deep/ .dx-drawer-content {
        height: auto;
    }
</style>