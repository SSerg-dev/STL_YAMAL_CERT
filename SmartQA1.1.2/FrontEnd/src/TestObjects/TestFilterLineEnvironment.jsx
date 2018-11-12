import React from 'react';
import {FilterLine} from '../SharedComponents/Filters/FilterLine.jsx';
import {Filter} from '../SharedComponents/Filters/Filter.js';

export class TestFilterLineEnvironment extends React.Component{
    constructor(props){
        super(props);
        this.filters = [];
        //beware - this lines creating new filters are not valid - constructor signature has changed
        this.filters.push(new Filter('Document','title',null));
        this.filters.push(new Filter('Log','text',["None","Contains", "Doesn't contain", "==","!="]));
        this.filters.push(new Filter('Register number','text',["None","Contains", "Doesn't contain", "==","!="]));
        this.filters.push(new Filter('Complect number','drop',['None','Number 1', 'Number 2', 'Number 3', 'Number 4']));
        this.filters.push(new Filter('Phase', 'checkDrop',['1','2','3','4']));
        this.filters.push(new Filter('Title object', 'checkDrop',['Title 1', 'Title 2', 'Title 3', 'Title 4']));
        this.filters.push(new Filter('Marka', 'checkDrop',["None","Contains", "Doesn't contain", "==","!="]));
        this.filters.push(new Filter('Date', 'date',['None','Before','After','=','Between']));
        this.filters.push(new Filter('Contractor', 'drop', ['None','Veless','Nova','ZPGS',"Rega"]));
        this.filters.push(new Filter('Company Resp','text',["None","Contains", "Doesn't contain", "==","!="]));
        this.filters.push(new Filter('Contractor Resp', 'text', ["None","Contains", "Doesn't contain", "==","!="]));
        
        this.changeFilters = this.changeFilters.bind(this);
    }
    render(){
        var outputFilters=[];
        for(var i=0; i<this.filters.length; i++)
        outputFilters[i]=(<p>{JSON.stringify(this.filters[i])}</p>);

        return(
            <div>
            <FilterLine
                filters={this.filters}
                hasTitles={true}
                callBack={this.changeFilters}
            />
            <h3>This will have been send when you press 'Alter filters'</h3>
            {outputFilters}
            </div>
        );
    }
    changeFilters(inputValue){
        this.filters=[];
        this.filters = inputValue;
        this.forceUpdate();
    }
}