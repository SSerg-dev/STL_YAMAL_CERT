<template>    
    <form v-on:submit.prevent="processForm">
        <dx-load-panel :visible="false"
                       :close-on-outside-click="false"
                       :shading="true"
                       shading-color="rgba(0,0,0,0.2)" />

        <dx-form ref="form"
                 :form-data="formData"
                 :items="formItems" />

    </form>            
</template>

<script>
    import { DxForm, DxScrollView } from 'devextreme-vue';
    import DataSource from 'devextreme/data/data_source';
    import { DxLoadPanel } from 'devextreme-vue/load-panel';           
    import { BehaviorSubject, empty } from 'rxjs';    
    import { filter, map, distinctUntilChanged, pluck } from 'rxjs/operators';

    export default {
        components: {
            DxForm,
            DxLoadPanel,
            DataSource,
            DxScrollView,
        },
        props: {
            dataSource: Object, // devetreme datasource settings
            formSettings: { // form settings Observable, e.g. { modelKey: "123", formDataInitial: {} }
                type: Object,
                default: () => empty()
            },
            commandRequests: { // form commands Observable, e.g { command: "submit" }
                type: Object,
                default: () => empty()
            }, 
            formItems: Array,            
        },
       
        subscriptions: function () {                               
            this.$subscribeTo(this.commandRequests, this.runCommand)          
            this.$subscribeTo(this.formSettings, this.init);             

            this.$subscribeTo(this.state.pipe(
                filter(s => s.state !== 'uninitialized'),
                map(s => s.state === 'failure' ? s.formErrors : [])                
            ), this.updateFormErrors);                          

            this.$subscribeTo(this.state, s => {
                console.debug('[entity-form] state ' + s.state, s);
                this.$emit('state', s);
            });

            return {
                loading: this.state.pipe(
                    pluck('isProgress'),
                    distinctUntilChanged()
                )
            }
        },
        data: function () {
            return {                       
                state: new BehaviorSubject({ state: 'uninitialized', modelKey: null }),
                modelKey: null,                                
                formData: {}
            }
        },
        methods: {
            changeState(state) {
                var s = Object.assign({
                    isProgress: state.state === 'loading' || state.state === 'submitting',
                    modelKey: this.modelKey,
                    formData: this.formData
                }, state);

                this.state.next(s);
            },

            init(settings) {                
                this.formErrors = {};
                this.modelKey = settings.modelKey;
                var formDataInitial = Object.assign({}, settings.formDataInitial || {})

                if (!this.modelKey) {                    
                    this.initFormData(formDataInitial);
                    this.changeState({
                        state: 'ready',
                    });
                    return;
                }
                
                var component = this;
                var source = new DataSource(this.dataSource);
                source.filter([source.key(), "=", new String(component.modelKey.toString())]);

                component.changeState({
                    state: 'loading'
                });

                source
                    .load()
                    .done(function (data) {                        
                        component.initFormData(data[0]);
                        component.changeState({
                            state: 'ready'
                        });
                    })
                    .fail(function (error) {
                        component.changeState({
                            state: 'error',
                            error: error
                        });
                    });
            },
            runCommand(cmd) {
                if (!cmd) return;
                if (cmd.command === 'submit') {
                    this.processForm(null);
                }
            },
            initFormData(data) {                
                this.$refs.form.instance.resetValues();
                this.formData = Object.assign({}, data);                
                this.updateFormErrors([]);                
            },            
            processForm(event) {
                this.changeState({
                    state: 'submitting',
                });
                
                var component = this;
                var source = new DataSource(this.dataSource);
                var data = this.formData;

                if (this.modelKey) {
                    source.store().update(new String(this.modelKey.toString()), data)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);
                } else {
                    source.store().insert(data)
                        .done(this.processFormSuccess)
                        .fail(this.processFormFail);
                }
            },
            processFormSuccess(data) {  
                var source = new DataSource(this.dataSource);
                if (!this.modelKey) {
                    this.modelKey = data[source.key()].toString()
                }

                this.changeState({
                    state: 'success',
                    modelKey: this.modelKey
                });
            },
            processFormFail(error) {
                this.changeState({
                    state: 'failure',
                    formErrors: error.errorDetails.details,
                });                
            },
            updateFormErrors: function (errors) {
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
            }
        }
    };
</script>
