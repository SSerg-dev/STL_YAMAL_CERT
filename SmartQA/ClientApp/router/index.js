import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'

Vue.use(VueRouter);

//let baseUrl = '/SmartQACore/';

let router = new VueRouter({
    mode: 'history',
    base: baseUrl,    
    linkActiveClass: 'active',
    routes
});

export default router
