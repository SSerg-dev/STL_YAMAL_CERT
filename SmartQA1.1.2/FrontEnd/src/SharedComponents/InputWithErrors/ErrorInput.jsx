/*this class is used to create input field that can show Errors underneath when calling
the proper function showError()

For proper using this class requires the same things as his predecesor:

-> initial value (inValue)
-> callback function to call on change

*/

//BEWARE - styling of this class are not completed!
//TODO - styling 
import React from 'react';
import {SuperInput} from '../SuperInput.jsx';
import './ErrorStyle.css';

export class ErrorInput extends SuperInput{
    constructor(props){
        super(props);
        this.isOnFocus = 0;
        this.state= {value: 'new', readOnly: false, class: null, reference: null, error:null}; //ADDED error in the state
        this.state.value = this.props.inValue;

        this.onChange = this.onChange.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.onBlur = this.onBlur.bind(this);
        this.onClick = this.onClick.bind(this);
        this.onKeyPress = this.onKeyPress.bind(this);
    }

    render(){
        return(
        <div className={this.props.className}>
        <input 
            type="text"
            value={this.state.value} 
            onClick={this.onClick} 
            onBlur={this.onBlur} 
            onFocus={this.onFocus} 
            onChange={this.onChange}
            onKeyPress={this.onKeyPress}
            readOnly={this.state.readOnly}
            ref={(input) => { this.textInput = input; }}
        />
            <p className='errorStyleText'>{this.state.error}</p>
            </div>
        );
    }
    showError(errorText){
        this.setState({error:errorText});
    }
    //also override onChange method - to get rid of the error message when user bagan his input
    onChange(event){
        this.isOnFocus =3;
        this.setState({value: event.target.value, error:null});
        this.props.callBack(event.target.value);
    }
}

