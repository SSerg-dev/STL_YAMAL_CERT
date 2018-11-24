import authHeaders from 'auth/headers.js';

export const dataSourceConfs = {
    users: {
        store: {
            type: 'odata',
            url: baseUrl + 'odata/AppUser',
            version: 4,
            key: 'AppUser_ID',
            keyType: {
                AppUser_ID: "Guid"
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
            key: 'Role_ID',
            keyType: {
                Role_ID: "Guid"
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
