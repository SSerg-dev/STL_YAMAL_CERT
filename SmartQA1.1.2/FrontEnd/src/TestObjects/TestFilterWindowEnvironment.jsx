import React from 'react';
import {SuperFilterWindow} from '../SharedComponents/Filters/SuperFilterWindow.jsx';
import {SuperDropCheck} from '../SharedComponents/SuperDropCheck.jsx';
import {FilterList} from '../SharedComponents/Filters/FilterList.jsx';
import {FilterText} from '../SharedComponents/Filters/FilterText.jsx';
import {FilterDropCheck} from '../SharedComponents/Filters/FilterDropCheck.jsx';
import {FilterDate} from '../SharedComponents/Filters/FilterDate.jsx';

export class TestFilterWindowEnvironment extends React.Component{
    constructor(props){
        super(props);
        this.filterOptions=[
            ['Documents','Log', 'Number'],
            ['Analitics','Best in this subsidary', 'Best annually', 'Worst participants'],
            ['Specification','Used elsewhere', 'Used nowhere']
        ];
        this.selectedItems = [];
        this.register = {Register:['Not selected','']}
        this.filters = [];
        this.filters['Register'] = ['',''];
        this.filters['Phase'] = ['',''];
        this.filters['MarkaId'] = ['',''];
        this.filters['DateSgn'] = ['','',''];
        this.changeOutPut = this.changeOutPut.bind(this);
        this.changeFilter = this.changeFilter.bind(this);
        this.clearFilter = this.clearFilter.bind(this);
        console.log(this.filters);
    }
    render(){
        return (
        <div>

            <br></br>
            <SuperDropCheck
                name='Marka'
                filterOptions={this.filterOptions}
                onOk={this.changeOutPut}
                hasTitles={true}
            />
            {this.selectedItems}
            <div>Test text is put here. Not just to warm up fingers</div>
            <br></br>
            <div>Testing filtering text here: </div>
            <br></br>
            <FilterText
                name='Register'
                inputValue={this.filters['Register']}
                callBack={this.changeFilter}
                filterOptions={["Not selected","Contains", "Doesn't contain", "==","!="]}
            />
            <FilterDropCheck
                name='Phase'
                filterOptions={['0','1','2','3']}
                onOk={this.changeFilter}
                onRefresh={this.clearFilter}
            />
            <FilterList
                name='MarkaId'
                inValue={this.filters['MarkaId'][0]}
                MyId='MarkaId'
                ArrayOfStrings={['None','CSW-5','SWP-5','WRD-329']}
                callBack={this.changeFilter}
            />
            <FilterDate
                name='DateSgn'
                inValue={this.filters['DateSgn']}
                options={['None','Before','After','=','Diapasone']}
                callBack={this.changeFilter}
            />
            <br></br>
            
            Text filter:{this.filters['Register'][0]+" "+this.filters['Register'][1]+" "}
            <br></br>
            <br></br>
            Drop-check filter:{this.filters['Phase'][0]+' '+this.filters['Phase'][1]+' '+this.filters['Phase'][2]+' '+this.filters['Phase'][3]+' '}
            <br></br>
            <br></br>
            Drop filter:{this.filters["MarkaId"][0]+' '+this.filters['MarkaId'][1]}
            <br></br>
            <br></br>
            Date filter:{this.filters["DateSgn"][0]+' '+this.filters['DateSgn'][1]+' '+this.filters['DateSgn'][2]}
        </div>);
    }
    changeOutPut(selected){
        var Xi = Array.from(selected);
        this.selectedItems=Xi.map(
            function(item){     
                return(<div>{item}</div>);
            }
        )
        this.forceUpdate();
    }
    changeFilter(name, paramIndex,value){
        this.filters[name][paramIndex] = value;
        this.forceUpdate();
    }
    clearFilter(name){
        for(var i=0; i<this.filters[name].length; i++) 
        this.filters[name][i] = undefined;
        this.forceUpdate();
    }
}