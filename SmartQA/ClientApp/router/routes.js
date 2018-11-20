import PermissionDocsIndex from 'components/permission-docs/index'
import ReftablesIndex from 'components/reftables/index'
import HomePage from 'components/home'
import LoginPage from 'components/account/login-page'

import store from 'store' 

const ifNotAuthenticated = (to, from, next) => {
    console.log(to, store.getters.isAuthenticated);
    if (!store.getters.isAuthenticated) {
        next();
        return;
    }
    next('/');
}

const ifAuthenticated = (to, from, next) => {
    console.log(to, store.getters.isAuthenticated);
    if (store.getters.isAuthenticated) {
        next();
        return;
    }
    next('/login');
}

export const routes = [
    {
        name: 'home',
        path: '/',
        component: HomePage,
        display: 'Home',
        beforeEnter: ifAuthenticated,
    },
    {
        name: 'login',
        path: '/login',
        component: LoginPage,
        meta: { layout: 'blank' },
        beforeEnter: ifNotAuthenticated,
    },
    {
        name: 'permission',
        path: '/permission/:employeeId?',
        component: PermissionDocsIndex,
        props: (route) => ({
            employeeId: route.params.employeeId,
            edit: route.query.edit
        }),
        display: 'Permission',
        beforeEnter: ifAuthenticated,
    },
    {
        name: 'reftables',
        path: '/reftables/:modelName?',
        component: ReftablesIndex,
        props: true,
        display: 'Reftables',
        beforeEnter: ifAuthenticated,
    }
  
]
