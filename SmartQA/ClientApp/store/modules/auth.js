/* eslint-disable promise/param-names */
import { AUTH_REQUEST, AUTH_ERROR, AUTH_SUCCESS, AUTH_LOGOUT } from '../actions/auth'
import { USER_REQUEST, USER_SUCCESS } from '../actions/user'
import authHeaders from 'auth/headers.js';

import axios from 'axios';

const state = {
    token: localStorage.getItem('user-token') || '',    
    status: '',
    error: null,
    hasLoadedOnce: false
}

const getters = {
    isAuthenticated: state => !!state.token,
    authStatus: state => state.status,
    authError: state => state.error
}

const actions = {
    [AUTH_REQUEST]: ({ commit, dispatch }, loginForm) => {
        return new Promise((resolve, reject) => {
            commit(AUTH_REQUEST);
            axios({ url: baseUrl + 'api/Account/Login', data: loginForm, method: 'POST' })
                .then(resp => {
                    var data = resp.data;

                    localStorage.setItem('last-username', data.UserInfo.UserName);
                    localStorage.setItem('user-token', data.Token);

                    authHeaders.setAuthHeaders(data.Token);
                    
                    commit(AUTH_SUCCESS, data.Token);
                    commit(USER_SUCCESS, data.UserInfo);                    
                    
                    resolve(data);
                })
                .catch(err => {
                    commit(AUTH_ERROR, err);
                    localStorage.removeItem('user-token');
                    
                    reject(err);
                });
        });
    },
    [AUTH_LOGOUT]: ({ commit, dispatch }) => {
        return new Promise((resolve, reject) => {
            commit(AUTH_LOGOUT);

            localStorage.removeItem('user-token');
            
            resolve();
        });
    }
}

const mutations = {
    [AUTH_REQUEST]: (state) => {
        state.status = 'loading';
        state.token = '';
        state.error = null;
    },
    [AUTH_SUCCESS]: (state, data) => {
        state.token = data;
        state.status = 'success';
        state.error = null;
        state.hasLoadedOnce = true;    
    },
    [AUTH_ERROR]: (state, err) => {
        state.status = 'error';
        if (err.response.status === 401) {
            state.error = 'unauthorized';
        } else {
            state.error = 'Error when processing request: '+ err.response.status.toString();
        }
        state.hasLoadedOnce = true;
    },
    [AUTH_LOGOUT]: (state) => {        
        state.token = '';
        state.status = '';
    }
}

export default {
    state,
    getters,
    actions,
    mutations,
}
