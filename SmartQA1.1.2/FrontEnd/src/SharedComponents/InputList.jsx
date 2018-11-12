/*this class is used to create HTML-5 drop-down list with input

For proper using this class requires the same things as his predecesor:

-> array of strings (ArrayOfStrings)
-> id of this drop-down list (MyId)
-> initial value (inValue)
-> callback fuction to call onChange (callBack)

*/
import React from 'react';
import {SuperList} from './SuperList.jsx';

export class InputList extends SuperList{
    render(){   
        let MyId = this.props.MyId;
        this.optionNodes = this.props.ArrayOfStrings.map(function(ThisOption)
            {
                return (<option key={MyId+ThisOption} value={ThisOption}/>);
            }
        );

        return(
            <div>
                <input type="text" 
                    list={this.props.MyId} 
                    value={this.state.value} 
                    className={this.state.class, this.props.className}
                    ref={(input) => { this.textInput = input; }}
                    onFocus={this.onFocus}
                    onKeyDown={this.onKeyDown}
                    onChange={this.onChange}
                />
                <datalist id={this.props.MyId}>
                    {this.optionNodes}
                </datalist>
            </div>
        );
    }
}