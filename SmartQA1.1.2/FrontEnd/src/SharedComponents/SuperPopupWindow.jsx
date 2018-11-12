import React from 'react';
import ReactDOM from 'react-dom';
import '../Styles/PopupStyle.css';

export class SuperPopupWindow extends React.Component{
    constructor(props){
        super(props);
        this.nodes = null;
        this.showPopup = this.showPopup.bind(this);
        this.onClick = this.onClick.bind(this);
        this.hideNodes = this.hideNodes.bind(this);
        this.buttonFunctions = null;
    }
    render(){
        return( 
            <div>
                {this.nodes}
            </div>
        );
    }
    hideNodes(){
        this.nodes = null;
        this.forceUpdate();
    }
    onClick(event){
        var index = event.target.id.replace("popupWindowButton",""); //replacing the specified prefix
        if(this.buttonFunctions && this.buttonFunctions.length>0 && this.buttonFunctions[index]!=null)
        {
            var func = this.buttonFunctions[index];
            func();
        }
        this.hideNodes();
    }
    showPopup(head, message, buttonNames, buttonFunctions){ //button functions is optional if you have
        var buttonNodes = [];
        for(var i=0; i<buttonNames.length; i++){
            buttonNodes.push(
                <button 
                    id={'popupWindowButton'+i}
                    class='SuperPopupWindow_Button' 
                    onClick={this.onClick}
                >
                    {buttonNames[i]}
                </button>)
        }
        this.nodes = (
            <div>
                <div class='SuperPopupWindow_Block'></div>
                <div class='SuperPopupWindow_Container'>
                    <div class='SuperPopupWindow_Head'>{head}</div>
                    <div class='SuperPopupWindow_Text'>{message}</div>
                    <div class='SuperPopupWindow_ButtonLine'>{buttonNodes}</div>
                </div>
            </div>
        );
        this.buttonFunctions = buttonFunctions;
        this.forceUpdate();
    }
}