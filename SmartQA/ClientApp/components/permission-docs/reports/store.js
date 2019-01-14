import CustomStore from 'devextreme/data/custom_store'
import axios from 'axios'


function store() {
    let urlGetData = baseUrl + 'api/NaksReport/GetData';
    let urlTotalCount = baseUrl + 'api/NaksReport/TotalCount';

    return new CustomStore({
        key: 'ID',

        load(loadOptions) {
            console.log('load', loadOptions);
            return axios({url: urlGetData, data: loadOptions, method: 'POST'})
                .then(resp => resp.data);

        },
        totalCount(loadOptions) {
            console.log('totalCount', loadOptions);
            return axios({url: urlTotalCount, data: loadOptions, method: 'POST'})
                .then(resp => resp.data);
        }
    });
}


export default store;