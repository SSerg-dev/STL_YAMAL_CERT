import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

import "devextreme/dist/css/dx.common.css";
import "devextreme/dist/css/dx.light.compact.css";

import "devextreme-intl";

import { FontAwesomeIcon } from './icons'

import Vue from 'vue'
import App from './app.vue'

import router from './router/index'

import { locale, loadMessages } from "devextreme/localization";
locale(navigator.language || navigator.browserLanguage);

import odata from "devextreme/data/odata/utils";
odata.keyConverters["Date"] = function (value) {
    return value + "MT";
};

new Vue({
    router,
    el: '#app',
    render: h => h(App)
})
