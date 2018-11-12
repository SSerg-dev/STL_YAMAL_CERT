import {Filter} from './Filter.js';
import {ToolKit} from '../Service/ToolKit.js';

/*
    This model was done because since three components need to alter filters state
    it becomes very difficult to maintaing the corresponding code in this Components

    This three components are:
    - Page core itself
    - TableOrderBy
    - FilterLine

    This model requires to be provided with callBack function from the Core
    so it calls this function when sufficient changes have been made to the 
    state of the filters so FE (Core) needs to update its state (update table)
    by sending JSON of filters.

    This model has several functions that are public:
    - addOrderFilter(filter) - provided to the TableOrderBy by the Core
    - changeFilters(filters[]) - provided to the FilterLine by the Core
    - addDictionary(filterVarName, filterDictionary) - the Core uses this function when dictionary of 
        any entities has been downloaded from the BE.
    - next(rows) - is used by the Core to change rowNum filter so it can retrieve new results
*/


export class FilterDomain{
    constructor(filtersHaveChangedCallBack, loadSpeed, clearTable){
        this.filters = [];
        this.callBack = filtersHaveChangedCallBack;
        this.loadSpeed = loadSpeed;
        this.clearOuterTable = clearTable;

        /*these two types of filters are stored separately
        because despite of others they don't have any UI
        representation
        */
        this.rowNumFilter = new Filter(null, null,'rowNum',null);
        this.orderByFilter = null;
        this.searchInFilesFilter = null;

        /*the first call of next() will increment each filter parameter by this.loadSpeed - and is supposed
        to be called when the Core component is mounted for the first time*/
        this.rowNumFilter.filterParams[0] = 0 - this.loadSpeed;
        this.rowNumFilter.filterParams[1] = 0;

        //binding functions:
        this.changeFilters = this.changeFilters.bind(this);
        this.add = this.add.bind(this);
        //this.update = this.update.bind(this);
        this.addDictionaryToFilter = this.addDictionaryToFilter.bind(this);
        this.appendOrderByFilter = this.appendOrderByFilter.bind(this);
        this.appendSearchInFilesFilter = this.appendSearchInFilesFilter.bind(this);
        this.next = this.next.bind(this);
        this.combineFilters = this.combineFilters.bind(this);
        this.resetRowNumFilter = this.resetRowNumFilter.bind(this);
        this.resetRowNumAndSendFiltersAgain = this.resetRowNumAndSendFiltersAgain.bind(this);
    }
    //PUBLIC - is provided to the FilterLine component
    changeFilters(filters){
        this.filters = filters;
        this.resetRowNumFilter();
        this.clearOuterTable();
        this.callBack(this.combineFilters());
    }
    //PUBLIC - used by the Core
    add(filter){
        this.filters.push(filter);
    }
    //PUBLIC - used by the Core
    addDictionaryToFilter(filterVarName, filterDictionary){ 
        for(var i=0; i<this.filters.length; i++){
            if(this.filters[i].varName == filterVarName) this.filters[i].options = filterDictionary;
        }
    }
    //PUBLIC - must be handed to the TableOrderBy component
    appendOrderByFilter(orderByFilter){
        this.orderByFilter = orderByFilter;
        this.resetRowNumFilter();
        this.clearOuterTable();
        this.callBack(this.combineFilters());
    }
    //PUBLIC
    appendSearchInFilesFilter(searchInFilesFilter) {
        this.searchInFilesFilter = searchInFilesFilter;
        this.resetRowNumFilter();
        this.clearOuterTable();
        this.callBack(this.combineFilters());
    }
    //PUBLIC - used by the Core
    next(){ 
        this.rowNumFilter.filterParams[0] = this.rowNumFilter.filterParams[1];
        this.rowNumFilter.filterParams[1] = this.rowNumFilter.filterParams[1]+this.loadSpeed;
        this.callBack(this.combineFilters());
    }
    //PUBLIC
    resetRowNumAndSendFiltersAgain(){
        this.resetRowNumFilter();
        this.clearOuterTable();
        this.callBack(this.combineFilters());
    }
    //PUBLIC - used to retrieve the data again using the same filters:
    /*
    update(){
        this.clearOuterTable();
        this.rowNumFilter.filterParams[0] = 0;
        this.callBack(this.combineFilters());
    }   */
    //PRIVATE
    combineFilters(){
        var resultFilters = ToolKit.copyArray(this.filters);

        //sometimes there's no orderByFilter
        if (this.orderByFilter != null) resultFilters.push(this.orderByFilter);
        if (this.searchInFilesFilter != null) resultFilters.push(this.searchInFilesFilter);

        resultFilters.push(this.rowNumFilter);
        return resultFilters;
    }
    //PRIVATE
    resetRowNumFilter(){
        this.rowNumFilter.filterParams[0]=0;
        this.rowNumFilter.filterParams[1]=this.loadSpeed;
    }
}