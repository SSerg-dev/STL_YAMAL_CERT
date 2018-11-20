import store from 'store'
import { USER_REQUEST } from 'store/actions/user'
import authHeaders from './headers';


export default {
    onAppInit() {
        const token = store.state.auth.token;
        if (token) {
            authHeaders.setAuthHeaders(token);
            store.dispatch(USER_REQUEST);
        }
    }    
}
