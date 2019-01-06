import context from 'api/odata-context';

export const dataSourceConfs = {
    users: {
        store: context.AppUser,
        sort: [
            'AppUser_Code'
        ],
        expand: [
            'RoleSet',
            'Employee',
            'Employee.Person',
            'Employee.Position',
            'Employee.Contragent'
        ]
    },
    roles: {
        store: context.Role,
        sort: [
            'Role_Code'
        ]
    }
}