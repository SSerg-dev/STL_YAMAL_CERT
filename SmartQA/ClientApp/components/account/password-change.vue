<template>
    <div>
        <div>
            <div v-if="errors" class="alert alert-danger" role="alert">
                <p v-for="err in errors">{{ err }}</p>
            </div>
            <form class="changePassword" @submit.prevent="submit">
                <dx-form :form-data="formData"
                         :disabled="status === 'loading'"
                         :items="formItems">

                </dx-form>

            </form>

        </div>
        
        <dx-load-panel :delay="100"
                       :visible="status === 'loading'"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="false"
                       :close-on-outside-click="false"
        />
    </div>
</template>

<script>
    import axios from 'axios';
    import {DxForm, DxLoadPanel} from 'devextreme-vue';
    import notify from 'devextreme/ui/notify';

    export default {
        name: 'PasswordChange',
        components: {
            DxForm,
            DxLoadPanel
        },
        data() {
            return {
                status: '',
                errors: null,
                formData: {
                    OldPassword: '',
                    NewPassword: ''
                },
                formItems: [
                    {
                        label: {text: 'Текущий пароль'},
                        dataField: 'OldPassword',
                        isRequired: true,
                        editorOptions: {
                            mode: 'password'
                        }
                    },
                    {
                        label: {text: 'Новый пароль'},
                        dataField: 'NewPassword',
                        isRequired: true,
                        editorOptions: {
                            mode: 'password'
                        }
                    },
                    {
                        itemType: "button",
                        horizontalAlignment: "right",
                        buttonOptions: {
                            text: "Изменить",
                            useSubmitBehavior: true
                        }
                    }
                ]
            }
        },
        methods: {
            submit() {
                this.status = 'loading';
                this.errors = null;

                axios.post(baseUrl + 'api/Account/ChangePassword', this.formData)
                    .then(resp => {
                        notify('Пароль изменён', 'success', 5000);
                        this.status = 'success';
                        this.$emit('success');
                    })
                    .catch(error => {
                        this.status = 'failure';

                        if (error.response && error.response.status === 400) {
                            this.errors = error.response.data.errors.map(x =>
                                x.Code === 'PasswordMismatch' ? 'Неверный пароль' : x.Description
                            );
                        } else if (error.request) {
                            this.errors = ['Не удалось выполнить запрос. Попробуйте ещё раз'];
                        } else {
                            this.errors = [error.message];
                        }
                    });
            }
        }
    }
</script>

<style scoped>

</style>