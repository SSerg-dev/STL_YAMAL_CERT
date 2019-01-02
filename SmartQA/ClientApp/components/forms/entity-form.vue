<template>
    <div class="form-container">
        <h2 v-if="formTitle">{{ formTitle }}</h2>
        
        <form v-on:submit.prevent="onSubmitButtonClick" class="my-5">
            <dx-form ref="form"
                     :form-data="formData"
                     :items="formItems" />
            
        </form>
        
        <dx-load-panel :position="{ of: '.form-container' }"
                       :visible="loading"
                       :show-indicator="true"
                       :show-pane="true"
                       :shading="true"
                       shading-color="rgba(0,0,0,0.2)"
                       :close-on-outside-click="false"
        />
        
        <dx-toolbar :items="toolbarItems" />
        
    </div>
</template>

<script>
    import { DxForm, DxScrollView, DxToolbar } from 'devextreme-vue';
    import notify from 'devextreme/ui/notify';
    import DataSource from 'devextreme/data/data_source';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';           
    import { BehaviorSubject, Subject, empty } from 'rxjs';    
    import { filter, map, distinctUntilChanged, pluck } from 'rxjs/operators';

    export default {
        name: 'EntityForm',
        
        components: {
            DxForm,
            DxLoadPanel,
            DataSource,
            DxScrollView,
            DxToolbar,
        },
        props: {

        },
        data: function () {
            return {
                state: new Subject(),
                formCommands: new Subject(),
                dataStore: {},
                dataStoreLoadOptions: {},
                modelKey: null,
                formTitle: null,
                formData: {},
                formItems: [],
                toolbarItems: [
                    {
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Отмена",
                            onClick: this.onCancelButtonClick
                        }
                    },                
                    {
                        widget: "dxButton",
                        location: "after",
                        options: {
                            text: "Сохранить",
                            type: "success",
                            onClick: this.onSubmitButtonClick
                        }
                    }
                ],
                index: null,
                loading: false
            }
        },
        mounted() {
            this.$subscribeTo(this.formCommands, this.runCommand);

            this.$subscribeTo(this.state.pipe(
                filter(s => s.state !== 'uninitialized'),
                map(s => s.state === 'failure' ? s.formErrors : [])
            ), this.updateFormErrors);

            this.$subscribeTo(this.state, s => {
                console.debug('[entity-form] state ' + s.state, s);
                //this.$emit('state', s);
            });


            this.$subscribeTo(this.formCommands, s => {
                console.debug('[entity-form] formCommands ' + s.command, s);
            });
            
            this.$subscribeTo(
                this.state.pipe(filter(s => s.state === 'success')),
                this.afterSubmitSuccess
            )             
        },
        methods: {
            changeState(state) {
                if(typeof state === "string") {
                    state = { state: state }
                }
                let s = Object.assign({
                    isProgress: ['loading', 'submitting', 'initializing'].includes(state.state),
                    modelKey: this.modelKey,
                    index: this.index,
                    formData: this.formData
                }, state);

                this.state.next(s);
            },
            init(settings) {           
                this.changeState({
                    state: 'initializing'
                });

                let dxForm = this.$refs.form;
                if (dxForm) {
                    dxForm.instance.beginUpdate();
                    dxForm.instance.resetValues();
                    dxForm.instance.endUpdate();
                }

                this.formErrors = {};
                this.modelKey = settings.modelKey;
                this.index = settings.index;
                let formDataInitial = Object.assign({}, settings.formDataInitial || {})

                if (!this.modelKey) {
                    this.formData = this.makeFormData(null, formDataInitial);
                    this.changeState('ready');
                    
                } else {
                    this.loadModel()
                }
                
                this.$subscribeTo(this.state.pipe(
                    pluck('isProgress'),
                    distinctUntilChanged()
                ), (loading) => this.loading = loading);

            },
            loadModel() {
                this.changeState('loading');

                this.dataStore.byKey(this.modelKey, this.dataStoreLoadOptions)
                    .done(this.onLoadModelSuccess)
                    .fail(this.onLoadModelFail);  
            },
            onLoadModelSuccess(data) {
                this.formData = this.makeFormData(data);
                this.changeState('ready');
            },
            onLoadModelFail(error){
                console.debug('onLoadModelFail');
                this.changeState({
                    state: 'error',
                    error: error
                });
            },
            runCommand(cmd) {
                if (!cmd) return;
                if (cmd.command === 'submit') {
                    this.submitForm(null);
                } else if (cmd.command === 'init') {
                    this.init(cmd);
                }
            },
            makeFormData(model = null, initialData = null) {
                let data = {};
                if (initialData) {
                    data = Object.assign(data, initialData)
                }
                if (model) {
                    data = Object.assign(data, model)
                }
                return data;
            },            
            submitForm(event) {
                if (!this.$refs.form.instance.validate().isValid) {
                    notify('Исправьте ошибки на форме и попробуйте ещё раз', 'warning');
                    return;
                }

                this.changeState({
                    state: 'submitting',
                });
                
                var data = this.formData;

                if (this.modelKey) {
                    this.dataStore.update(String(this.modelKey.toString()), data)
                        .done(this.onSubmitFormSuccess)
                        .fail(this.onSubmitFormFail);
                } else {
                    this.dataStore.insert(data)
                        .done(this.onSubmitFormSuccess)
                        .fail(this.onSubmitFormFail);
                }
            },
            onSubmitFormSuccess(data) {
                if (!this.modelKey) {
                    this.modelKey = data[this.dataStore.key()].toString()
                }

                this.changeState({
                    state: 'success',
                    modelKey: this.modelKey
                });

                notify('Сохранение прошло успешно', 'success');
            },
            onSubmitFormFail(error) {
                this.changeState({
                    state: 'failure',
                    formErrors: error.errorDetails.details,
                });                
            },
            updateFormErrors(errors) {
                if (!this.$refs.form) return;

                var form = this.$refs.form.instance;

                Object.keys(this.formData).forEach(function (key, index) {
                    var editor = form.getEditor(key);
                    if (editor) {
                        editor.option('isValid', true);
                        editor.option('validationError', {});
                    }
                });

                for (var i = 0; i < errors.length; i++) {
                    var err = errors[i];
                    var editor = form.getEditor(err.target);
                    if (editor) {
                        editor.option('isValid', false);
                        editor.option('validationError', { message: err.message });
                    }
                }
            },
            onSubmitButtonClick(event) {
                this.submitForm();
            },
            onCancelButtonClick(event) {},
            afterSubmitSuccess(state) {}
        }
    };
</script>
