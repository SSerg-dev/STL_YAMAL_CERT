/*
This class is a superclass for all drop-down lists components. Also an instance of this class
can be used as simple drop-down list - that's why it's not an abstract class
For proper using this class requires only four things from the parent element:

-> array of strings (ArrayOfStrings)
-> id of this drop-down list (MyId)
-> initial value (inValue)
-> callback fuction to call onChange (callBack)

to be shown as options in this component
Maybe then, passing callback function from parent element will be required,
but take into considaration - this change will require modification of other 
descendant classes, and especially, Cores of every View
*/
import React from 'react';
import {ToolKit} from '../Service/ToolKit.js';

export class SuperList extends React.Component{
    constructor(props){
        super(props);
        this.state = {value: '', class: null};
        this.state.value = this.props.inValue;

        this.onChange = this.onChange.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.onKeyDown = this.onKeyDown.bind(this);
        this.verify = this.verify.bind(this);
    }
    componentWillReceiveProps(newProps){
        this.setState({value: newProps.inValue});
    }
    onChange(event){
        //if (event.key==37 || event.key == 39 || event.key ==38) console.log("came from onChange");
        this.setState({value: event.target.value});
        this.props.callBack(event.target.value);
    }
    render(){   
        let MyId = this.props.MyId;
        this.optionNodes = this.props.ArrayOfStrings.map(function(ThisOption)
            {
                return (<option key={MyId+ThisOption}>{ThisOption}</option>);
            }
        );

        return(
            <select 
            key={ToolKit.shortId()}
            value={this.state.value} 
            className={this.state.class, this.props.className}
            ref={(input) => { this.textInput = input; }}
            onFocus={this.onFocus}
            onKeyDown={this.onKeyDown}
            onChange={this.onChange}>
                {this.optionNodes}
            </select>
        );
    }
    onFocus(){ 

    }
    onKeyDown(event){
        
    }
    verify(){

    }

}