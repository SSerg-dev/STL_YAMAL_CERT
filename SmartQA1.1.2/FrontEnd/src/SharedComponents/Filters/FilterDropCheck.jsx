import React from 'react';
import {SuperDropCheck} from '../SuperDropCheck.jsx';
import '../../Styles/FilterStyle.css';
import Select from 'react-select';
import 'react-select/dist/react-select.css';

export class FilterDropCheck extends React.PureComponent{
    constructor(props){
        super(props);

        this.filter = this.props.filter;

        this.verify = this.verify.bind(this);
        this.changeFilter= this.changeFilter.bind(this);
        this.filterOptions = [];
    }

    showHideNodes(){
        this.props.onRefresh(this.props.name);
        this.showNodes = !this.showNodes;
        var Xi = Array.from(this.selectedCheckBoxes);
        for(var i=0; i<Xi.length; i++) this.props.onOk(this.props.name, i, Xi[i]);
        this.forceUpdate();
    }
    componentWillMount(){
        for(var i =0; i<this.props.filter.options.count(); i++){
            this.filterOptions.push(
                    {   value: this.props.filter.options.keyByIndex(i),
                        label: this.props.filter.options.valueByIndex(i)    }
            )
        }
        this.state={};
    }

    render(){
        console.log(this.filter.filterParams);
        if(this.verify()) var bColor='rgb(194, 230, 193)'; else var bColor='rgb(230, 230, 230)';
        return(
            <div className='filterContainer' style={{backgroundColor: bColor}}>
                <button className='filterCloseCheckDrop' onClick={()=>this.props.onDelete(this.props.name)}>{'\u2A09'}</button>
                <div className='filterNameCheckDrop'><p>{this.props.name}</p></div>
                <div className='filterDropCheckMultiSelect'>
                    <Select
                        closeOnSelect={true}
                        disabled={false}
                        onChange={this.changeFilter}
                        options={this.filterOptions}
                        placeholder="..."
                        removeSelected={true}
                        rtl={false}
                        value={this.filter.filterParams}
                        multi={true}
                    />
                </div>
            </div>
        );
    }
    verify(inValue){
        if(this.filter.filterParams && this.filter.filterParams.length>0) return true;
        return false;
    }
    changeFilter(value){
        this.filter.filterParams = [];
        if(value!=null && value.length>0){
            value.forEach((val)=>this.filter.filterParams.push(val.value));
        }
        this.props.callBack(this.filter);
        this.forceUpdate();
    }
}