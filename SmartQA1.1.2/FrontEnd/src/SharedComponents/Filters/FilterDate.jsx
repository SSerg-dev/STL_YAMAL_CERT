import React from 'react';
import {DateInput} from '../../SharedComponents/DateInput.jsx';
import {SuperList} from '../../SharedComponents/SuperList.jsx';
import {ToolKit} from '../../Service/ToolKit.js';
import {Dictionary} from '../../Models/Dictionary.js';
import {LangPack} from '../../Service/LangPack.js';
import '../../Styles/FilterStyle.css';

export class FilterDate extends React.Component{
    constructor(props){
        super(props);
        this.additionalDateInput = null;
        this.LangPack = new LangPack('eng');

        this.filter = this.props.inValue;
        this.filter.options = new Dictionary();
        this.filter.filterParams[0] = null;

        this.filter.options.add(null, this.LangPack.notSelected);
        this.filter.options.add(0, this.LangPack.Before);
        this.filter.options.add(1, this.LangPack.After);
        this.filter.options.add(2, this.LangPack.Equals);
        this.filter.options.add(3, this.LangPack.Between);

        //binding functions:
        this.changeFilter0 = this.changeFilter0.bind(this);
        this.changeFilter1 = this.changeFilter1.bind(this);
        this.changeFilter2 = this.changeFilter2.bind(this);
    }
    render(){
        var selected = this.filter.options.valueByKey(this.filter.filterParams[0]);

        if(this.verify()) var bColor='rgb(194, 230, 193)'; else var bColor='rgb(230, 230, 230)';
        return (
            <div className='filterContainer' style={{backgroundColor: bColor}}>
                <button className='filterClose' onClick={()=>this.props.onDelete(this.props.name)}>{'\u2A09'}</button>
                <div className='filterName'>{this.props.name}</div>
                <SuperList
                    className ='filterList'
                    MyId={this.props.name}
                    ArrayOfStrings={this.filter.options.getAllValues()}
                    inValue={selected}
                    callBack={this.changeFilter0}
                />
                <DateInput 
                    inValue={this.filter.filterParams[1]} 
                    callBack={this.changeFilter1} 
                    className='filterInput'
                />
                {this.additionalDateInput}
            </div>
        );
    }
    changeFilter0(value){
        var key = this.filter.options.keyByValue(value);
        if(key==3) 
            this.additionalDateInput=(
                <DateInput 
                    inValue={this.filter.filterParams[2]} 
                    callBack={this.changeFilter2} 
                    className='filterInput'
                />
            );
        else{
            this.additionalDateInput=null;
            this.filter.filterParams[2] = null;
        }
        this.filter.filterParams[0] = key;
        this.props.callBack(this.filter);
        this.forceUpdate();
    }
    changeFilter1(value){
        this.filter.filterParams[1] = value;
        this.forceUpdate();
    }
    changeFilter2(value){
        this.filter.filterParams[2] = value;
        this.forceUpdate();
    }
    verify(){
        if(this.filter.filterParams[0]==null) return false;
        if(this.filter.filterParams[1]==null || this.filter.filterParams[1].length<10) return false;
        if(this.filter.filterParams[0]==3 &&(this.filter.filterParams[2]==null || this.filter.filterParams[2].length<10)) return false;
        return true;
    }
}