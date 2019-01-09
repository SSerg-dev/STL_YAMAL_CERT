<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <router-link class="navbar-brand" to="/">SmartQA</router-link>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <router-link class="nav-item nav-link" to="/permission">Permission</router-link>
                <router-link class="nav-item nav-link" to="/documents">Documents</router-link>
                <router-link class="nav-item nav-link" to="/reftables">Reference tables</router-link>
                <router-link
                        v-if="user && user.Roles.indexOf('Administrator') !== -1"
                        class="nav-item nav-link" to="/useradmin">
                    Users
                </router-link>

            </div>           
            
        </div>

        <ul class="navbar-nav" v-if="user">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <font-awesome-icon icon="user" />&ensp;{{ user.UserName }}
                </a>                
                
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
                    <a v-for="role in user.Roles" href="#" class="dropdown-item disabled" @click.prevent="">
                        {{ role }}
                    </a>
                    <div v-if="user.Roles.length > 0" class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item" @click.prevent="logout">
                        <font-awesome-icon icon="sign-out-alt" />&ensp;Log out
                    </a>
                </div>
            </li>
        </ul>
    </nav>
</template>

<script>
    import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';

    import {AUTH_LOGOUT} from 'store/actions/auth';

    export default {
        components: {        
            FontAwesomeIcon
        },
        computed: {            
            user() {
                return this.$store.getters.getProfile;
            }
        },
        data: function() {
            return {
                //user: null
            }
        },
        methods: {
            logout() {
                this.$store.dispatch(AUTH_LOGOUT)
                    .then(() => {
                        this.$router.push('/login');
                    });
            }
        }
    }
</script>
