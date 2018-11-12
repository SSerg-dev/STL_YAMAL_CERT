import React from 'react';
import ReactDOM from 'react-dom';
import Switch from "react-switch";

import {LangPack} from '../Service/LangPack.js';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {ToolKit} from '../Service/ToolKit.js';

import '../Styles/SettingsPanel.css';
import '../Styles/PopMovable.css';

export class ErrorConsole extends React.Component{
    constructor(props){
        super(props);
        this.minimizeMaximize = this.minimizeMaximize.bind(this);
        this.onMouseDown = this.onMouseDown.bind(this);
        this.mouseUp = this.mouseUp.bind(this);
        this.resize = this.resize.bind(this);
        this.isMinimized = false;
        this.outputHeight = 100;
        this.clearConsoleOutput = this.clearConsoleOutput.bind(this);
    }
    render(){
        var inputValue = document.errorConsoleOutput;

        var outputWindow = 
                <textarea 
                    key={ToolKit.shortId()}
                    id="errorConsoleOutput"
                    value={inputValue}
                    className='console_output' 
                    style={{height:this.outputHeight}}
                    readOnly={true}
                    onChange={(event)=>{this.marka.Description_Rus=event.target.value; this.forceUpdate()}}>
                </textarea>;
        var minimizeButtonStyleArrow = this.isMinimized ? "popMinimizeDown" : "popMinimizeUp";

        var resizeGrip = <div className="popTopResizeGrip" onMouseDown={this.onMouseDown}></div>;
       
        if(this.isMinimized) {
            outputWindow = null;
            resizeGrip = null;
        }

        return (
            <div className="console_container">
                {resizeGrip}
                <div className="popMovableHead" style={{position:'relative', top:0}}>
                    <div className="popMovableHeadTitle">Error logout</div>
                    <button className="popMovableCloseButton" onClick = {this.props.onExit}>X</button>
                    <button  className="popMinimizeButtonStyle" onClick={this.minimizeMaximize}>
                        <div className={minimizeButtonStyleArrow}></div>
                    </button>
                    <div className = 'popCleanButton_Container' onClick = {this.clearConsoleOutput}>
                        <img 
                            key={ToolKit.shortId()}
                            className = 'popCleanButton_Img' 
                            src={require('../img/trash3.png')}
                        />
                    </div>
                </div>
                {outputWindow}
            </div>
        );
    }
    minimizeMaximize(){
        this.isMinimized = !this.isMinimized;
        this.forceUpdate();
    }
    onMouseDown(event){
        if(!this.isMinimized){
            window.onmousemove = this.resize;
            window.onmouseup = this.mouseUp;
            document.mouseY=event.clientY;
        }
    }
    resize(event){
        //if(document.mouseX && document.mouseY && document.movingWindowId)
        var it = document.getElementById("errorConsoleOutput");

        this.outputHeight = it.offsetHeight+document.mouseY-event.clientY

        it.style.height=this.outputHeight+'px';
        document.mouseY=event.clientY;
    }
    mouseUp(){
        window.onmouseup = null;
        window.onmousemove = null;
        document.mouseY=null;
    }
    clearConsoleOutput(){
        document.errorConsoleOutput = null;
        this.forceUpdate();
    }
    static writeLine(line){
        var errorConsole = document.getElementById("errorConsoleOutput");
        document.errorConsoleOutput = document.errorConsoleOutput==null 
            ? line +"\n" 
            : document.errorConsoleOutput + line + "\n";
        if(errorConsole!=null) errorConsole.value = document.errorConsoleOutput;
    }
}