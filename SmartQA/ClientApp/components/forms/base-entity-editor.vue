<template>
    <div class="form-container">
        <h2 v-if="formTitle">{{ formTitle }}</h2>
        
        <form v-on:submit.prevent="onSubmitButtonClick" class="my-3">
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
        name: 'BaseEntityEditor',
        
        components: {
            DxForm,
            DxLoadPanel,
            DataSource,
            DxScrollView,
            DxToolbar,
        },
        props: {
            items: {
                type: Array,
                default: () => [],
                required: false,
            },
            store: {
                type: Object,
                default: () => {},
                required: false,
            },
            storeLoadOptions: {
                type: Object,
                default: () => {},
                required: false,
            },
            editorSettings: {
                type: Object,
                default: () => {},
                required: true
            }
        },
        watch: {
            editorSettings: {
                immediate: true,
                handler(settings) {
                    if (!settings || Object.keys(settings).length === 0) {
                        return
                    } 
                        
                    this.init(settings)
                }
            }  
        },
        data: function () {
            return {
                state: new Subject(),
                dataStore: this.store,
                dataStoreLoadOptions: this.storeLoadOptions,
                modelKey: null,
                formData: {},
                formTitle: '',
                formItems: this.items,
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
            this.$subscribeTo(this.state.pipe(
                filter(s => s.state !== 'uninitialized'),
                map(s => s.state === 'failure' ? s.formErrors : [])
            ), this.updateFormErrors);
            
            this.$subscribeTo(this.state.pipe(
                filter(s => s.state !== 'uninitialized'),
                pluck('isProgress'),
                distinctUntilChanged()),
              
                (loading) => this.loading = loading
            );
            
            this.$subscribeTo(this.state, s => {
                console.debug('[base-entity-editor] state ' + s.state, s);
                this.$emit('state', s);
            });
            
            this.$subscribeTo(
                this.state.pipe(filter(s => s.state === 'success')),
                this.afterSubmitSuccess
            )             
        },
        methods: {
            init(settings) {
                this.setState({
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
                
                if(settings.hasOwnProperty('formTitle')) {
                    this.formTitle = settings.formTitle;
                }  
                
                let formDataInitial = Object.assign({}, settings.formDataInitial || {})

                if (!this.modelKey) {
                    this.formData = this.makeFormData(null, formDataInitial);
                    this.setState('ready');
                } else {
                    this.loadModel()
                }
            },
            submit() {
                this.onSubmitForm();
            },
            cancel() {
                this.setState('canceled');
            },
            setState(state) {
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
            
            loadModel() {
                this.setState('loading');

                this.dataStore.byKey(this.modelKey, this.dataStoreLoadOptions)
                    .done(this.onLoadModelSuccess)
                    .fail(this.onLoadModelFail);  
            },
            onLoadModelSuccess(data) {
                this.formData = this.makeFormData(data);
                this.setState('ready');
            },
            onLoadModelFail(error){
                console.debug('onLoadModelFail');
                this.setState({
                    state: 'error',
                    error: error
                });
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
            onSubmitForm(event) {
                if (!this.$refs.form.instance.validate().isValid) {
                    notify('Исправьте ошибки на форме и попробуйте ещё раз', 'warning');
                    return;
                }

                this.setState({
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

                this.setState({
                    state: 'success',
                    modelKey: this.modelKey
                });

                notify('Сохранение прошло успешно', 'success');
            },
            onSubmitFormFail(error) {
                this.setState({
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
                this.submit();
            },
            onCancelButtonClick(event) {
                this.cancel();
            },
            afterSubmitSuccess(state) {}
        }
    };
</script>
