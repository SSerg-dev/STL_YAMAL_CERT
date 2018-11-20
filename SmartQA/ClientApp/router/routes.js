import PermissionDocsIndex from 'components/permission-docs/index'
import ReftablesIndex from 'components/reftables/index'
import HomePage from 'components/home'
import LoginPage from 'components/account/login-page'

import store from 'store' 

const ifNotAuthenticated = (to, from, next) => {

    if (!store.getters.isAuthenticated) {
        next();
        return;
    }
    next('/');
}


const ifAuthenticated = (to, from, next) => {
    console.debug('[router] ifAuthenticated');
    var watchStop;
    function proceed() {
        if (watchStop) watchStop();

        if (store.getters.getProfile)
            next();
        else
            next('/login');
    }

    if (store.state.user.status === 'loading') {
        console.debug('[router] user is loading');
        watchStop = store.watch(
            (state) => state.user.status,
            (value) => {
                console.debug('[router] user status === ' + value);
                if (value !== 'loading') 
                    proceed();                
            }
        );
    } else {
        proceed();
    }

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
