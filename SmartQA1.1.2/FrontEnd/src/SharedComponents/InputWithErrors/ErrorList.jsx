/*this class is used to create input field that can show Errors underneath when calling
the proper function showError()

For proper usage this class requires the same things as his predecesor:

-> array of strings (ArrayOfStrings)
-> id of this drop-down list (MyId)
-> initial value (inValue)
-> callback fuction to call onChange (callBack)

*/
import React from 'react';
import {SuperList} from '../SuperList.jsx';
import './ErrorStyle.css';

export class ErrorList extends SuperList{
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
                return (<option key={MyId+ThisOption}>{ThisOption}</option>);
            }
        );
        return(
            <div className={this.props.className}>
                <select
                    value={this.state.value} 
                    className={this.state.class}
                    ref={(input) => { this.textInput = input; }}
                    onFocus={this.onFocus}
                    onKeyDown={this.onKeyDown}
                    onChange={this.onChange}>
                    {this.optionNodes}
                </select>
                <p className='errorInputText'>{this.state.error}</p>
            </div>
        );
    }

    //also override onChange method - to get rid of the error message when user bagan his input
    onChange(event){
        this.setState({value: event.target.value, error:null});
        this.props.callBack(event.target.value);
    }

}

