import context from 'api/odata-context';

export const dataSourceConfs = {
    users: {
        store: context.AppUser,
        sort: [
            'AppUser_Code'
        ],
        expand: [
            'RoleSet'
        ]
    },
    roles: {
        store: context.Role,
        sort: [
            'Role_Code'
        ]
    }
}