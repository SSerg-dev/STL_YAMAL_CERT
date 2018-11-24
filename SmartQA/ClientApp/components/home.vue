<template>
    <div class="px-1 py-3">        
        <div class="card">            
            <div class="card-body">
                <h2 class="card-title">Navigation</h2>
                <nav>
                    <router-link class="nav-item nav-link" to="/permission">Permission</router-link>
                    <router-link class="nav-item nav-link" to="/reftables">Reference tables</router-link>
                    <router-link
                            v-if="user.Roles.indexOf('Administrator') !== -1"
                            class="nav-item nav-link" to="/useradmin">
                        Users
                    </router-link>
                </nav>
            </div>
        </div>
        
    </div>
</template>

<script>
    export default {
        data () {
            return {}
        },
        computed: {
            user() {
                return this.$store.getters.getProfile;
            }
        },
    }
</script>

<style>

</style>
