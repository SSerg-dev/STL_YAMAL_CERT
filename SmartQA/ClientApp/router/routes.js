import PermissionDocsIndex from 'components/permission-docs/index'
import ReftablesIndex from 'components/reftables/index'
import HomePage from 'components/home'
import LoginPage from 'components/account/login-page'
import UserAdminIndex from 'components/useradmin/index'
import DocumentsIndex from 'components/documents/index'
import DocumentEdit from 'components/documents/document-edit'
import DocumentView from 'components/documents/document-view'

import store from 'store'

const ifNotAuthenticated = (to, from, next) => {

    if (!store.getters.isAuthenticated) {
        next();
        return;
    }
    next('/');
}

// check if user is logged in
// if role is specified, also check if user has it
function ifAuthenticated(role) {
    return (to, from, next) => {
        console.debug('[router] ifAuthenticated');
        var watchStop;

        function proceed() {
            if (watchStop) watchStop();

            let userProfile = store.getters.getProfile;
            if (userProfile && (!role || userProfile.Roles.indexOf(role) !== -1))
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
}


export const routes = [
    {
        name: 'home',
        path: '/',
        component: HomePage,
        display: 'Home',
        beforeEnter: ifAuthenticated(),
    },
    {
        name: 'login',
        path: '/login',
        component: LoginPage,
        meta: { layout: 'blank' },
        beforeEnter: ifNotAuthenticated,
    },
    {
        name: 'useradmin',
        path: '/useradmin',
        component: UserAdminIndex,
        props: (route) => ({
            employeeId: route.params.employeeId,
            edit: route.query.edit
        }),
        display: 'Permission',
        beforeEnter: ifAuthenticated('Administrator'),
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
        beforeEnter: ifAuthenticated(),
    },
    {
        name: 'reftables',
        path: '/reftables/:modelName?',
        component: ReftablesIndex,
        props: true,
        display: 'Reftables',
        beforeEnter: ifAuthenticated(),
    },
    {
        name: 'documents',
        path: '/documents',
        beforeEnter: ifAuthenticated(),
        component: DocumentsIndex,
    },       
    {
        name: 'document-view',
        path: '/documents/:documentId',
        component: DocumentView,
        props: true,
        // props: (route) => ({
        //     editorSettings: {
        //         modelKey: route.params.id
        //     }
        // }),
    },
    {
        name: 'document-edit',
        path: '/documents/edit/:documentId',
        component: DocumentEdit,
        props: true,
        props: (route) => ({
            editorSettings: {
                modelKey: route.params.documentId
            }
        }),
    }

];
