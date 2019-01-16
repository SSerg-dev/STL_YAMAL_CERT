import Vue from 'vue'
import VueRouter from 'vue-router'
import {routes} from './routes'

import store from 'store'

Vue.use(VueRouter);

let router = new VueRouter({
    mode: 'history',
    base: baseUrl,    
    linkActiveClass: 'active',
    routes
});

function getUserProfile() {
    return new Promise(resolve => {
        const watcher = store.watch(
            (state) => state.user.status,
            (value) => {
                console.debug('[router] user status === ' + value);
                if (value !== 'loading') {
                    resolve(store.getters.getProfile);
                    watcher();
                }
            }, {
                immediate: true,
            });
    });
}

// check if user is logged in
// if role is specified, also check if user has it
router.beforeEach(async (to, from, next) => {
    console.debug('[router] checking auth');
    
    let userProfile = await getUserProfile();    
        
    if(to.matched.some(record => record.meta.requiresAuth)) {
        let requiredRoles = to.matched.map(record => {
            let r = record.meta.requiresRole;
            if (typeof r === "string") return new Set([r]);
            else if (Array.isArray(r)) return new Set(r);
            else return new Set([]);
        }).reduce((acc, val) => {val.forEach(x => acc.add(x)); return acc}, new Set([]));
        console.debug('userProfile', userProfile)
        console.debug('roles', requiredRoles)
        
        if (userProfile && (requiredRoles.size === 0 || userProfile.Roles.some(r => requiredRoles.has(r)))) {
            next();    
        } else {
            next('/login');
        }
    } else {
        next()
    }
})

export default router
