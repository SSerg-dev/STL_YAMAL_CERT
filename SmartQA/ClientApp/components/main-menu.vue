<template>
    <div>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <router-link class="navbar-brand" to="/">SmartQA</router-link>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup"
                    aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                <div class="navbar-nav">

                    <router-link class="nav-item nav-link" to="/permission">Разрешительная документация</router-link>
                    <router-link
                            v-if="user && user.Roles.indexOf('Administrator') !== -1"
                            class="nav-item nav-link" to="/documents">
                        Исполнительная документация
                    </router-link>
                    <router-link class="nav-item nav-link" to="/reftables">Справочники</router-link>
                    <router-link
                            v-if="user && user.Roles.indexOf('Administrator') !== -1"
                            class="nav-item nav-link" to="/useradmin">
                        Пользователи
                    </router-link>

                </div>

            </div>

            <ul class="navbar-nav" v-if="user">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" aria-haspopup="true"
                       aria-expanded="false">
                        <font-awesome-icon icon="user"/>&ensp;{{ user.UserName }}
                    </a>

                    <div class="dropdown-menu dropdown-menu-right">
                        <a v-for="role in user.Roles" href="#" class="dropdown-item disabled" @click.prevent="">
                            {{ role }}
                        </a>
                        <div v-if="user.Roles.length > 0" class="dropdown-divider"></div>
                        <a href="#" class="dropdown-item" @click.prevent="changePassword">
                            Изменить пароль
                        </a>
                        <a href="#" class="dropdown-item" @click.prevent="logout">
                            <font-awesome-icon icon="sign-out-alt"/>&ensp;Выйти
                        </a>
                    </div>
                </li>
            </ul>
        </nav>
        <dx-popup ref="passwordChangePopup"
                  title="Изменить пароль"
                  :visible="false"
                  :show-title="true"
                  :width="400"
                  :height="300">
            <password-change @success="passwordChangeSuccess"/>
        </dx-popup>

    </div>
</template>

<script>
    import DxPopup from 'devextreme-vue/popup'
    import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';
    import PasswordChange from 'components/account/password-change';

    import {AUTH_LOGOUT} from 'store/actions/auth';

    export default {
        components: {
            DxPopup,
            FontAwesomeIcon,
            PasswordChange
        },
        computed: {
            user() {
                return this.$store.getters.getProfile;
            }
        },
        data: function () {
            return {
                passwordChangeOpen: false,
            }
        },
        methods: {
            changePassword() {
                this.$refs.passwordChangePopup.instance.show();
            },
            passwordChangeSuccess() {
                this.$refs.passwordChangePopup.instance.hide();
            },
            logout() {
                this.$store.dispatch(AUTH_LOGOUT)
                    .then(() => {
                        this.$router.push('/login');
                    });
            }
        }
    }
</script>
