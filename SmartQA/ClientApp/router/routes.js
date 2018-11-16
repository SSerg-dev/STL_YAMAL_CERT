import PermissionDocsIndex from '../components/permission-docs/index'
import ReftablesIndex from '../components/reftables/index'
import HomePage from '../components/home'

export const routes = [
    {
        name: 'home', path: '/', component: HomePage, display: 'Home'
    },    
    {
        name: 'permission',
        path: '/permission/:employeeId?',
        component: PermissionDocsIndex,
        props: (route) => ({
            employeeId: route.params.employeeId,
            edit: route.query.edit
        }),
        display: 'Permission'        
    },
    {
        name: 'reftables',
        path: '/reftables/:modelName?',
        component: ReftablesIndex,
        props: true,
        display: 'Reftables'

    }
  
]
