import React from 'react';
import {SuperInput} from '../../SharedComponents/SuperInput.jsx';
import {SuperList} from '../../SharedComponents/SuperList.jsx';
import {LangPack} from '../../Service/LangPack.js';
import {Dictionary} from '../../Models/Dictionary.js';
import {ToolKit} from '../../Service/ToolKit.js';
import '../../Styles/FilterStyle.css';

export class FilterText extends React.Component{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('eng');

        //binding functions:
        this.changeFilter0 = this.changeFilter0.bind(this);
        this.changeFilter1 = this.changeFilter1.bind(this);
        this.verify = this.verify.bind(this);

        this.filter = this.props.inValue;
        this.filter.options = new Dictionary();
        this.filter.filterParams[0] = null;
        
        this.filter.options.add(null, this.LangPack.notSelected);
        this.filter.options.add(0, this.LangPack.Contains);
        this.filter.options.add(1, this.LangPack.NotContains);
        this.filter.options.add(2, this.LangPack.Equals);
        this.filter.options.add(3, this.LangPack.NotEquals);

    }
    render(){
        var chosenSelector = this.filter.options.valueByKey(this.filter.filterParams[0]);

        if(this.verify()) var bColor='rgb(194, 230, 193)'; else var bColor='rgb(230, 230, 230)';
        return(
            <div className='filterContainer' style={{backgroundColor: bColor}}>
                <button className='filterClose' onClick={()=>this.props.onDelete(this.props.name)}>{'\u2A09'}</button>
                <div className='filterName'>{this.props.name}</div>
                <SuperList 
                    className='filterList'
                    inValue={chosenSelector}
                    ArrayOfStrings={this.filter.options.getAllValues()}
                    callBack={this.changeFilter0}
                    MyId={this.props.name}
                />
                <SuperInput 
                    className='filterInput'
                    inValue={this.filter.filterParams[1]}
                    callBack={this.changeFilter1}
                />
            </div>
        );
    }
    changeFilter0(key){
        //changing the selector createria
        this.filter.filterParams[0] = this.filter.options.keyByValue(key);
        this.props.callBack(this.filter);
    }
    changeFilter1(value){
        //changin the text itself
        this.filter.filterParams[1] = value;
        this.props.callBack(this.filter);
    }
    verify(){
        if(this.filter.filterParams[0]!=null && this.filter.filterParams[1])
        return true;
        else 
        return false;
    }


}