import React from 'react';
import '../../Styles/FilterStyle.css';
import '../../Styles/FilterMainDropCheckStyle.css';

import {SuperDropCheck} from '../SuperDropCheck.jsx';
import {FilterLineDropFilters} from './FilterLineDropFilters.jsx';
import {FilterList} from './FilterList.jsx';
import {FilterText} from './FilterText.jsx';
import {FilterSearch} from './FilterSearch.jsx';
import {FilterDropCheck} from './FilterDropCheck.jsx';
import {FilterDate} from './FilterDate.jsx';
import {LangPack} from '../../Service/LangPack.js';
import {ToolKit} from '../../Service/ToolKit.js';

/*this component requires to be supplied with three things :

->array of filters (you need to import filter) (filters)
->specify if the checkbox filter menu has titles (hasTitles)
->specify callback of the function to change filters (callBack)

also there's a helpful thing for debugging at the end of render() method 
beware - this FitlerLine doesn't create node for the last filter, assuming that it's RowNum filter
*/
export class FilterLine extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');

        this.state={nodes:null};
        this.selectedFilters=new Set(); //contains all selected filters in one
        //this.textFilterOptions = ["Not selected","Contains", "Doesn't contain", "==","!="];

        //here will be all values of this lines stored
        this.filters = this.props.filters;
        this.isSearchFilterProvided = false;
        
        //creating names for menu...
        this.filterNames=[];
        var i=0;
        for(var j=0; j<this.filters.length; j++){
            if(this.filters[j].type != 'fileContent'){
                this.filterNames.push(this.filters[j].name);
            }
            else this.isSearchFilterProvided = true;
        }

        //binding functions
        this.changeSelectedFilters = this.changeSelectedFilters.bind(this);
        this.createNodes = this.createNodes.bind(this);
        this.changeFilter = this.changeFilter.bind(this);
        this.clearFilter = this.clearFilter.bind(this);
        this.deleteFilter = this.deleteFilter.bind(this);
        this.createOneNode = this.createOneNode.bind(this);
        this._changeFilter = this._changeFilter.bind(this);
        this.setSearchFilter = this.setSearchFilter.bind(this);
    }
    render(){
        var nodes=[];
        nodes=this.createNodes();
        //if any filters are selected show button "Alter filters";
        if(nodes!=null && nodes.length && nodes.length>0) 
            var isSubmitButtonDisabled = false;
        else {
            var isSubmitButtonDisabled = true;
            //this.props.callBack(this.filters); //also tell parent that no filters are selected so it can rerender the page
        }

        if(this.isSearchFilterProvided){
            this.searchFilter =  <FilterSearch callBack={this.setSearchFilter} />;
        }
        return(
            <div className='filterLine'>
                <FilterLineDropFilters
                    listButtonStyle='flistButtonStyle'
                    name={this.LangPack.ChooseFilters}
                    filterOptions={this.filterNames}
                    callBack={this.changeSelectedFilters}
                />
                <button 
                    className='filterAlterButton' 
                    disabled={isSubmitButtonDisabled} 
                    onClick={()=>this.props.callBack(this.filters)}
                >
                    <img className="filterAlterButtonImg" src={require("../../img/checkmark.png")}/>
                </button>
                {this.searchFilter}
                <div class='filterField'>{nodes}</div>
            </div>
        );//add <br></br> {outputFilters} if you're debuggin filters
    }
    createNodes(){
        var nodes=[];
        for(var i=0; i<this.filterNames.length; i++)
        if(this.selectedFilters.has(this.filterNames[i]))
            nodes.push(this.createOneNode(this.filters[i]));
        return nodes;
    }
    setSearchFilter(value){
        for(var i =0; i<this.filters.length; i++)
        if(this.filters[i].type=='fileContent') this.filters[i].filterParams[0] = value;
        this.props.callBack(this.filters);
        this.forceUpdate();
    }
    changeSelectedFilters(selected){
        //resetting the filter type
        for(var i =0; i<this.filters.length; i++)
        if(this.filters[i].type=='fileContent') this.filters[i].filterParams[0] = null;

        this.selectedFilters = selected;
        for(var i=0; i<this.filters.length; i++)
        if(!this.selectedFilters.has(this.filters[i].name)) 
        {
        this.filters[i].filterParams=[];
        //this.filters[i].guidList=[];
        }
        this.props.callBack(this.filters);
        this.forceUpdate();
    }
    changeFilter(name, paramIndex, value){
        for(var i=0; i<this.filters.length; i++)
        if(this.filters[i].name==name) this.filters[i].filterParams[paramIndex]=value;
        this.forceUpdate();
    }
    _changeFilter(filter){
        for(var i=0; i<this.filters.length; i++)
        if(this.filters[i].name==filter.name) this.filters[i] = filter;
        this.forceUpdate();
    }
    clearFilter(name){
        for(var i=0; i<this.filters.length; i++)
        if(this.filters[i].name==name) this.filters[i].filterParams=[];
        this.forceUpdate();
    }
    deleteFilter(name){
        this.selectedFilters.delete(name);
        this.changeSelectedFilters(this.selectedFilters);
    }
    createOneNode(filter){
        if(filter.type=='text')
        return(
            <FilterText
                name={filter.name} 
                inValue={filter} 
                filterOptions={filter.options}
                callBack={this._changeFilter} //callBack 
                onDelete={this.deleteFilter} //callBack 
            />
        );
        if(filter.type=='drop')
        return(
            <FilterList
                name={filter.name}
                inValue={filter}
                MyId={filter.name}
                ArrayOfStrings={filter.options}
                callBack={this.changeFilter} //callBack
                onDelete={this.deleteFilter} 
            />
        );
        if(filter.type=='checkDrop')
        return(
            <FilterDropCheck
                listButtonStyle='filtersListButtonStyle'
                name={filter.name}
                filter={filter}
                filterOptions={filter.options}
                onOk={this.changeFilter} //callBack
                onRefresh={this.clearFilter} //callBack
                onDelete={this.deleteFilter} 
                key={filter.name}
                callBack = {this._changeFilter}
            />
        );
        if(filter.type =='date')
        return(
            <FilterDate
                name={filter.name}
                inValue={filter}
                options={filter.options}
                callBack={this.changeFilter} //callBack
                onDelete={this.deleteFilter} 
            />
        );
    }
}