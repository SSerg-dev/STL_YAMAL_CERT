/*this class will be used to create a fixed elements that can be
used to show some information at the bottom of the page*/

import React from 'react';
import '../Styles/SuperStyle.css';

/*it requires only one thing to be created:
-> input value (inValue)*/

export class  BottomElement extends React.Component{
    constructor(props){
        super(props);
        this.changeStyle = this.changeStyle.bind(this);
        this.state={
            showHide:null
        }
    }
    render(){
        return(
            <div className='bottomElementContainer' style={this.state.showHide}>
                {this.props.inValue}
                <bottom onClick={this.changeStyle} className="bottomElementContainerButton">X</bottom>
            </div>
        );
    }
    changeStyle(){
        this.setState({showHide:{display:'none'}});
    }
}