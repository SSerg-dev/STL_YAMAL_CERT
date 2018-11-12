/* This class is a superclass for all input fields throughout the application
an instance of this class can be used to create a simple input field
For proper using this class requires two things to be input:

-> initial value (inValue)
-> callback function to call on change (callBack)
      
*/
import React from 'react';
import '../Styles/FilterStyle.css';


export class SuperInput extends React.Component{
    constructor(props){
        super(props);
        this.isOnFocus = 0;
        this.state= {value: '', readOnly: false, class: null, reference: null};
        this.state.value = this.props.inValue;

        this.onChange = this.onChange.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.onBlur = this.onBlur.bind(this);
        this.onClick = this.onClick.bind(this);
        this.onKeyPress = this.onKeyPress.bind(this);
    }
    componentWillReceiveProps(newProps){
        this.setState({value: newProps.inValue});
    }
    render(){
        var isDisabled = this.props.disabled ? true : false;
        return(
        <input 
            style={this.props.style}
            type="text"
            value={this.state.value} 
            onClick={this.onClick} 
            onBlur={this.onBlur} 
            onFocus={this.onFocus} 
            onChange={this.onChange}
            onKeyPress={this.onKeyPress}
            readOnly={this.state.readOnly}
            className={this.props.className}
            ref={(input) => { this.textInput = input; }}
            disabled = {isDisabled}
            />
        );}

    onChange(event){
        this.isOnFocus =3;
        this.setState({value: event.target.value});
        this.props.callBack(event.target.value);
    }
    onClick(){
        
    }
    onFocus(){

    }
    onBlur(){

    }
    onKeyPress(){

    }
}