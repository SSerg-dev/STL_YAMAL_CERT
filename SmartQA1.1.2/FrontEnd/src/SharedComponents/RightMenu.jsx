/* This class is a component, that represents right-click menu
to implement an instance of this component in your UI it has to 
be supplied with three things:
-> Array of strings that represents Name of options (inputNames)
-> Array of functions in the corresponding order (inputFunctions)
-> exit function that will be called when user decided to exit the RCMenu

*/
import React from 'react';
import '../Styles/RCMenuStyle.css';

export class RightMenu extends React.Component{
    constructor(props){
        super(props);
        this.onRightClick = this.onRightClick.bind(this);
    }
    render(){
        let InputNames = this.props.RcNames;
        let InputFunctions = this.props.RcFunctions;
        let RightMenuNodes = [];

        if(InputNames && InputFunctions) {
            //creating components nodes
            for(var i=0; i<Math.min(InputNames.length, InputFunctions.length); i++){
            RightMenuNodes[i] = (<button 
                MyId={i}
                onClick={InputFunctions[i]}
                    >
                    {InputNames[i]}
                    </button>);}

            //this vars change the offset from the right and bottom borders of the window and equal: menuSize+offset
            var menuWidth=200;
            var menuHeight=50;

            //checking if menu is out of bondaris of the view
            var body = document.body;
            var html = document.documentElement;
            var docHeight = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight,  html.scrollHeight, html.offsetHeight);
            var stylePositioning={
                top: this.props.Y>(docHeight-menuHeight) ? (this.props.Y-menuHeight) : this.props.Y,
                left: this.props.X>(window.innerWidth-menuWidth) ? (this.props.X-menuWidth) : this.props.X
            };
            return (
            <div onContextMenu={this.onRightClick}>
            <div class='RCMenuBlock' onClick={this.props.onExit}></div>
                <div class='RCMenuContainer' style={stylePositioning} onClick={this.props.onExit}>
                    {RightMenuNodes}
                </div>
            </div>
            );
        } 
        else {
            alert("You haven't supplied the right-click menu with proper input parameters");
            return(<div>An error occured while rendering right-click menu</div>);
        }
    }
    /*this function was created and binded to the context just to stop propagation of the
    right-click event*/
    onRightClick(event){
        event.stopPropagation();
        this.props.onExit(event);
    }
}