import authHeaders from 'auth/headers.js';

export const dataSourceConfs = {
    users: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/AppUser',
            version: 4,
            key: 'ID',
            keyType: {
                ID: "Guid"
            },
            beforeSend: function (e) {
                e.headers = authHeaders.getAuthHeaders();
            }
        },
        sort: [
            'AppUser_Code'
        ],
        expand: [
            'RoleSet'
        ]
    },
    roles: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/Role',
            version: 4,
            key: 'ID',
            keyType: {
                ID: "Guid"
            },
            beforeSend: function (e) {
                e.headers = authHeaders.getAuthHeaders();
            }
        },
        sort: [
            'Role_Code'
        ]
    }
}
