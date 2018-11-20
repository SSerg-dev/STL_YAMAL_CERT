import { USER_REQUEST, USER_ERROR, USER_SUCCESS } from '../actions/user'
import axios from 'axios';
import Vue from 'vue'
import { AUTH_LOGOUT } from '../actions/auth'

const state = {
    status: '',
    lastUsername: localStorage.getItem('last-username') || '',
    profile: null
}

const getters = {
    getProfile: state => state.profile,
    isProfileLoaded: state => !!state.profile.name,
    getLastUsername: state => state.lastUsername,
}

const actions = {
    [USER_REQUEST]: ({ commit, dispatch }) => {
        commit(USER_REQUEST);
        axios({ url: baseUrl + 'api/Account/UserInfo', })
            .then(resp => {
                commit(USER_SUCCESS, resp.data);
            })
            .catch(resp => {
                commit(USER_ERROR);
                // if resp is unauthorized, logout, to
                dispatch(AUTH_LOGOUT);
            });
    }   
}

const mutations = {
    [USER_REQUEST]: (state) => {
        state.status = 'loading';
    },
    [USER_SUCCESS]: (state, data) => {
        state.status = 'success';
        state.lastUsername = data.UserName,
        Vue.set(state, 'profile', data);
    },
    [USER_ERROR]: (state) => {
        state.profile = null;
        state.status = 'error';
    },
    [AUTH_LOGOUT]: (state) => {
        state.profile = null;
        state.status = '';
    }
}

export default {
    state,
    getters,
    actions,
    mutations,
}
