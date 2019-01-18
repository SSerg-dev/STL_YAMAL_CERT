import PermissionIndex from 'components/permission-docs/index'
import PermissionEmployeesIndex from 'components/permission-docs/employees/index'

import PermissionReportsIndex from 'components/permission-docs/reports/index'
import PermissionReportsDashboard from 'components/permission-docs/reports/dashboard'
import NaksReport from 'components/permission-docs/reports/naks/naks-report'
import NaksReportTwo from 'components/permission-docs/reports/naks/naks-report-two'
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
        name: 'permission', 
        component: PermissionIndex,
        redirect: { name: 'permission-employees' },
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
                name: 'permission-reports',
                path: 'reports',
                component: PermissionReportsIndex,
                children: [
                    {
                        name: 'permission-reports-dashboard',
                        path: '', 
                        component: PermissionReportsDashboard 
                    },
                    {
                        name: 'permission-reports-naks',
                        path: 'naks',
                        component: NaksReport,
                        props: true
                    },
                    {
                        name: 'permission-reports-naks2',
                        path: 'naks2',
                        component: NaksReportTwo,
                    }        
                ]
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
