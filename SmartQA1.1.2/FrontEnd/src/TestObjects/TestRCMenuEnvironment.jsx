/*this object is used for testing right-click menu 
also It can be used with other components, that require
to specify an array of functions and array of their names
*/
import React from 'react';
import {RightMenu} from '../SharedComponents/RightMenu.jsx';

export class TestRCMenuEnvironment extends React.Component{

    constructor(props){
        super(props);
        this.x=0;
        this.y=0;
        this.initialState = (
        <div style={TestRCMenuEnvironment.testStyle} 
            onMouseMove={this.onMouseMove}
            onContextMenu={this.onRightClick}>Right click here to show menu
        </div>);
        this.state = {NodesFree: this.initialState};
    }

    //this style is to implement a div, representing a field, that will invoke right-click menu
    static testStyle = {
        border: '1px solid black',
        width: '300px',
        height: '300px',
        backgroundColor: 'green'
    }
    static InputNames = ['TEST: Create New', 'TEST: Edit this', 'TEST: Escape from this', 'TEST: Exit menu', 'TEST: Delete this'];
    static InputFunctions = [
        function() {alert('TEST: 1-st function');},
        function() {alert('TEST: 2-nd function');},
        function() {alert('TEST: 3-d function');},
        function() {alert('TEST: 4-th function');},
        function() {alert('TEST: 5-th function');}
    ];
    render(){ 
        return(
            this.state.NodesFree
        );
    }

    //TODO - this part have to implemented in the right-click menu itself and without setState
    onRightClick(event){
        event.preventDefault();
        this.setState({NodesFree: <RightMenu 
            X={this.x}
            Y={this.y}
            InputNames={TestRCMenuEnvironment.InputNames} 
            InputFunctions={TestRCMenuEnvironment.InputFunctions}
            onExit={this.onExit}/>});
        return false;
    }
    onExit(event){
        event.preventDefault();
        this.setState({NodesFree: this.initialState});
        return false;
    }
    onMouseMove(event){
        this.x= event.clientX;
        this.y= event.clientY;
    }

    //here all event functions are bound to the instance of this object
    onRightClick = this.onRightClick.bind(this);
    onExit = this.onExit.bind(this);
    onMouseMove = this.onMouseMove.bind(this);

}