import PermissionIndex from 'components/permission-docs/index'
import PermissionEmployeesIndex from 'components/permission-docs/employees/index'

import NaksReport from 'components/permission-docs/reports/naks-report'
import ReftablesIndex from 'components/reftables/index'
import HomePage from 'components/home'
import LoginPage from 'components/account/login-page'
import UserAdminIndex from 'components/useradmin/index'
import DocumentsIndex from 'components/documents/index'
import DocumentEdit from 'components/documents/document-edit'
import DocumentView from 'components/documents/document-view'

export const routes = [
    {
        name: 'home',
        path: '/',
        component: HomePage,
        display: 'Home',
    },
    {
        name: 'login',
        path: '/login',
        component: LoginPage,
        meta: {
            layout: 'blank',
        }
    },
    {
        name: 'useradmin',
        path: '/useradmin',
        component: UserAdminIndex,
        props: (route) => ({
            employeeId: route.params.employeeId,
            edit: route.query.edit
        }),
        meta: {
            requiresAuth: true,
            requiresRole: ['Administrator']
        }
    },
    {
        name: 'permission', component: PermissionIndex,
        path: '/permission',
        children: [
            {
                name: 'permission-employees',
                path: 'employees/:employeeId?',
                component: PermissionEmployeesIndex,
                props: (route) => ({
                    employeeId: route.params.employeeId,
                    edit: route.query.edit
                }),
            },
            {
                name: 'permission-naks-report',
                path: 'naks-report',
                component: NaksReport,
            }
        ],
        meta: {
            requiresAuth: true,
        }
    },
    {
        name: 'reftables',
        path: '/reftables/:modelName?',
        component: ReftablesIndex,
        props: true,
        meta: {
            requiresAuth: true,
        }
    },
    {
        name: 'documents',
        path: '/documents',
        component: DocumentsIndex,
        meta: {
            requiresAuth: true,
        }
    },
    {
        name: 'document-view',
        path: '/documents/:documentId',
        component: DocumentView,
        props: true,
        meta: {
            requiresAuth: true,
            requiresRole: ['Administrator']
        }
    },
    {
        name: 'document-edit',
        path: '/documents/edit/:documentId',
        component: DocumentEdit,
        props: (route) => ({
            editorSettings: {
                modelKey: route.params.documentId
            }
        }),
        meta: {
            requiresAuth: true,
            requiresRole: ['Administrator']
        }
    }
];
