import 'styles/main.scss'
import 'bootstrap'

import "devextreme-intl";

import {FontAwesomeIcon} from './icons'

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

import devExtremeConfig from 'devextreme/core/config'
import {loadMessages, locale} from "devextreme/localization";
import ruMessages from "devextreme/localization/messages/ru.json";

loadMessages(ruMessages);
locale(navigator.language || navigator.browserLanguage);
moment.locale(navigator.language || navigator.browserLanguage);

authHelper.onAppInit();

devExtremeConfig({
    editorStylingMode: 'underlined'
});

Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.component('default-layout', DefaultLayout);
Vue.component('blank-layout', BlankLayout);

Vue.use(VueRx, Rx);

new Vue({
    router,
    store,
    el: '#app',
    render: h => h(App)
});
