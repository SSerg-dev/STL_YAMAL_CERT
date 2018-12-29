import 'styles/main.scss'

import "devextreme-intl";

import Vue from 'vue'
import Rx from 'rxjs/Rx';
import VueRx from 'vue-rx';


import App from './app.vue'

import router from './router/index'
import store from './store'
import authHelper from 'auth/helper'

import {locale} from "devextreme/localization";
import DefaultLayout from './layouts/default'
import BlankLayout from './layouts/blank'

locale(navigator.language || navigator.browserLanguage);

authHelper.onAppInit();


Vue.component('default-layout', DefaultLayout);
Vue.component('blank-layout', BlankLayout);

Vue.use(VueRx, Rx)

new Vue({
    router,
    store,
    el: '#app',
    render: h => h(App)
});
