import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

import "devextreme/dist/css/dx.common.css";
import "devextreme/dist/css/dx.light.compact.css";

import "devextreme-intl";

import { FontAwesomeIcon } from './icons'

import Vue from 'vue'
import App from './app.vue'

import router from './router/index'
import store from './store'
import authHelper from 'auth/helper'

import { locale, loadMessages } from "devextreme/localization";
locale(navigator.language || navigator.browserLanguage);

authHelper.onAppInit();

import DefaultLayout from './layouts/default'
import BlankLayout from './layouts/blank'

Vue.component('default-layout', DefaultLayout);
Vue.component('blank-layout', BlankLayout);

new Vue({
    router,
    store,
    el: '#app',
    render: h => h(App)
});
