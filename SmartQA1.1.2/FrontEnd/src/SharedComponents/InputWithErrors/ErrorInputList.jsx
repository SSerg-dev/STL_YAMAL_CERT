/*this class is used to create input list that can show
Errors underneat when showError is called 
For proper using this class requires the same things as his predecesor:

-> array of strings (ArrayOfStrings)
-> id of this drop-down list (MyId)
-> initial value (inValue)
-> callback fuction to call onChange (callBack)

*/

import React from 'react';
import {SuperList} from '../SuperList.jsx';
import './ErrorStyle.css';

export class ErrorInputList extends SuperList{
    constructor(props){
        super(props);
        this.state = {value: '', class: null, error:null}; //ADDED error in the state
        this.state.value = this.props.inValue;

        this.onChange = this.onChange.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.onKeyDown = this.onKeyDown.bind(this);
        this.verify = this.verify.bind(this);
        this.showError = this.showError.bind(this);
    }
    showError(errorText){
        this.setState({error:errorText});
    }
    render(){   
        let MyId = this.props.MyId;
        this.optionNodes = this.props.ArrayOfStrings.map(function(ThisOption)
            {
                return (<option key={MyId+ThisOption} value={ThisOption}/>);
            }
        );

        return(
            <div className={this.props.className}>
                <input type="text" 
                    list={this.props.MyId} 
                    value={this.props.inValue} 
                    
                    ref={(input) => { this.textInput = input; }}
                    onFocus={this.onFocus}
                    onKeyDown={this.onKeyDown}
                    onChange={this.onChange}
                    readOnly={this.state.readOnly}
                />
                <datalist id={this.props.MyId}>
                    {this.optionNodes}
                </datalist>
                <p className='errorInputText'>{this.state.error}</p>
            </div>
        );
    }
    onChange(event){
        this.setState({value: event.target.value, error:null});
        this.props.callBack(event.target.value);
    }
}