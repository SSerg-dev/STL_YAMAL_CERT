import 'styles/main.scss'

import "devextreme-intl";

import { FontAwesomeIcon } from './icons'

import Vue from 'vue'
import Rx from 'rxjs/Rx';
import VueRx from 'vue-rx';
import moment from 'moment';


import App from './app.vue'

import router from './router/index'
import store from './store'
import authHelper from 'auth/helper'

import DefaultLayout from './layouts/default'
import BlankLayout from './layouts/blank'

import config from 'devextreme/core/config'
import {loadMessages, locale} from "devextreme/localization";
import ruMessages from "devextreme/localization/messages/ru.json";

loadMessages(ruMessages);
locale(navigator.language || navigator.browserLanguage);
moment.locale(navigator.language || navigator.browserLanguage);

authHelper.onAppInit();

config({
    //forceIsoDateParsing: false,
    editorStylingMode: 'underlined'
});

Vue.component('default-layout', DefaultLayout);
Vue.component('blank-layout', BlankLayout);

Vue.use(VueRx, Rx);

new Vue({
    router,
    store,
    el: '#app',
    render: h => h(App)
});
