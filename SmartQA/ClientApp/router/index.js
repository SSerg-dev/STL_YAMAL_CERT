import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'

Vue.use(VueRouter);

//let baseUrl = '/SmartQACore/';

let router = new VueRouter({
    mode: 'history',
    base: baseUrl,    
    routes
});

export default router
