<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <router-link class="navbar-brand" to="/">SmartQA</router-link>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <router-link class="nav-item nav-link active" to="permission">Permission</router-link>

            </div>
        </div>
    </nav>
</template>

<script>
    import { DxMenu } from "devextreme-vue/ui/menu";    

    export default {
        components: {            
            DxMenu
        },
        data: function() {
            return {
                menuItems: [
                    {
                        text: "Home",
                        route: { name: 'home' }
                    },

                    {
                        text: "Permission",
                        route: { name: 'permission' }
                    }                                                          
                ]
           }
        },
        methods: {
            itemClick(e) {
                this.$router.push(e.itemData.route);
            }
        }
    }
</script>
