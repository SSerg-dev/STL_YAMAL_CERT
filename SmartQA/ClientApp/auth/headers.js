import axios from 'axios';
import store from 'store';

export default {

    setAuthHeaders(token) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + token;
    },
    
    getAuthHeaders() {
        const token = store.state.auth.token;
        if (token) {
            return { 'Authorization': 'Bearer ' + token };
        } else {
            return {};
        }

    }
}