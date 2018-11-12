import React from 'react';
import {SuperList} from '../SuperList.jsx';
import '../../Styles/FilterStyle.css';

export class FilterList extends SuperList{

    /*TODO - THIS LIST HAS TO RETURN GUID OF THE VALUE*/
    render(){  
        
        let MyId = this.props.MyId;
        this.optionNodes = this.props.ArrayOfStrings.map(function(ThisOption)
            {
                return (<option key={MyId+ThisOption}>{ThisOption}</option>);
            }
        );
        if(this.verify(this.state.value)) var bColor='rgb(24, 139, 24)'; else var bColor='grey';

        return(
            <div className='filterContainer' style={{backgroundColor: bColor}}>
                <button className='filterClose' onClick={()=>this.props.onDelete(this.props.name)}>X</button>
                {this.props.name}
                <select 
                    value={this.state.value} 
                    className={this.state.class}
                    ref={(input) => { this.textInput = input; }}
                    onFocus={this.onFocus}
                    className='filterList'
                    onKeyDown={this.onKeyDown}
                    onChange={this.onChange}>
                        {this.optionNodes}
                </select>
            </div>
        );
    }
    onChange(event){
        //if (event.key==37 || event.key == 39 || event.key ==38) console.log("came from onChange");
        this.setState({value: event.target.value});
        this.props.callBack(this.props.name,0,event.target.value);
    }
    verify(inValue){
        if(!inValue || inValue==this.props.ArrayOfStrings[0]) return false;
        return true;
    }
}
