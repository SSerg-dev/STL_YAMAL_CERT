<template>

    <div class="container-fluid login-container">
        <div class="card" id="login-form" style="width: 25rem;">
            <div class="card-body">
                <h5 class="card-title">Sign in</h5>
                <div v-if="authError" class="alert alert-danger" role="alert">
                    {{ authError }}
                </div>
                <form class="login" @submit.prevent="login">
                    <dx-form :form-data="formData"
                             :items="formItems">
                        
                    </dx-form>
                    
                </form>
            </div>
        </div>
        <dx-load-panel :position="{ of: '#login-form' }"
                       :delay="100"
                       :visible="authStatus === 'loading'"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="false"
                       :close-on-outside-click="false"
                       />
    </div>
</template>

<script>
    import {DxForm, DxLoadPanel} from 'devextreme-vue';
    import {AUTH_REQUEST} from 'store/actions/auth'

    export default {
        name: 'login',
        components: {
            DxForm,
            DxLoadPanel
        },
        computed: {
            authStatus() {
                return this.$store.getters.authStatus;
            },
            authError() {
                var err = this.$store.getters.authError;
                if (err && err === 'unauthorized') {
                    return 'Wrong username or password';
                } else {
                    return err;
                }
            }
        },
        watch: {
            authStatus(value) {
                if (value === 'success') {
                    this.$router.push({ name: 'home' });
                }
            }
        },
        data() {
            return {
                formData: {
                    username: this.$store.getters.getLastUsername,
                    password: '',
                },
                formItems: [
                    {
                        label: { text: 'Username' },
                        dataField: 'username',
                        isRequired: true
                    },
                    {
                        label: { text: 'Password' },
                        dataField: 'password',
                        isRequired: true,
                        editorOptions: {
                            mode: 'password'
                        }

                    },
                    {
                        itemType: "button",
                        horizontalAlignment: "right",
                        buttonOptions: {
                            text: "Sign in",
                            //type: "success",
                            useSubmitBehavior: true
                        }
                    }
                    ]
            }
        },
        methods: {
            login: function () {
                this.$store.dispatch(AUTH_REQUEST, this.formData);
            }
        },
    }
</script>
