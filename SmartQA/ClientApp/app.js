import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

import "devextreme/dist/css/dx.common.css";
import "devextreme/dist/css/dx.light.compact.css";

import "devextreme-intl";

import Vue from 'vue'
import App from './app.vue'

import router from './router/index'

import { locale, loadMessages } from "devextreme/localization";
locale(navigator.language || navigator.browserLanguage);

new Vue({
    router,
    el: '#app',
    render: h => h(App)
})
