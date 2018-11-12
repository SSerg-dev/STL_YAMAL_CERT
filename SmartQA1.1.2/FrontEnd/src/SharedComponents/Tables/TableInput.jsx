import React from 'react';
import {SuperInput} from '../SuperInput.jsx';
import '../../Styles/TableCellStyle.css';

export class TableInput extends SuperInput{

    constructor(props){
        super(props);
        this.isOnFocus = 0;
        this.state= {value: '', readOnly: true};
        this.state.value = this.props.inValue;

        this.onChange = this.onChange.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.onBlur = this.onBlur.bind(this);
        this.onClick = this.onClick.bind(this);
        this.onKeyPress = this.onKeyPress.bind(this);
    }
    render(){
        return(
        <input 
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

            />
        );}
    onChange(event){
        //beware - onKeyPress also changes value of the input
        this.isOnFocus = 3;
        this.setState({value: event.target.value});
        this.props.callBack(this.props.MyId, event.target.value);
    }

    onFocus(){
        this.isOnFocus++;
        this.props.cellOnFocus(this.props.MyId); //Telling the Line: "I'm focused!": 
    }
    onClick(){
        if(this.isOnFocus>1) {
            this.setState({readOnly: false});
            this.isOnFocus=3;}
        else {this.isOnFocus=2;}
    }
    onBlur(){
        this.isOnFocus = 0;
        this.setState({readOnly: true, reference: null});
    }
    onKeyPress(){
        if(this.isOnFocus<3){
            this.isOnFocus++;
        this.setState({readOnly: false});
        this.textInput.select();
        }
    }
    focusCell(){
        this.textInput.focus();
    }
}
