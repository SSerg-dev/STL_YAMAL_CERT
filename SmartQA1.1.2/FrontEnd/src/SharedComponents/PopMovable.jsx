import React from 'react';
import ReactDOM from 'react-dom';
import '../Styles/PopMovable.css';
import {ToolKit} from '../Service/ToolKit.js';

/*this component is just a container - it doensn't have any state, it doensn't update from time to time and 
furthemore any updates or renderings of this element has to be avoided because this component is designed 
to have animation of poping out when being created or initialized*/

export class PopMovable extends React.Component{
    constructor(props){
        super(props);

        //binding functions
        this.move = this.move.bind(this);
        this.onExit = this.onExit.bind(this);
        this.mouseUp = this.mouseUp.bind(this);
        this.mouseDown = this.mouseDown.bind(this);
        this.manageLayout = this.manageLayout.bind(this);

        this.containerId = ToolKit.shortId();
        this.itself = null;
        this.mouseX=null;
        this.mouseY=null;

        this.offsetStyle=this.props.offsetStyle;
        if(this.offsetStyle.zIndex){

        }
        else{
            if(!document.windowId) this.offsetStyle.zIndex=2
            else this.offsetStyle.zIndex=2+document.windowId.length;
        }
    }
    componentDidMount(){
        this.itself = document.getElementById(this.containerId);
        window.onmousemove = this.move;
        window.onmouseup = this.mouseUp;
        if(!document.windowId) document.windowId = [];
        document.windowId.push(this.containerId);
    }
    render(){
        return(
            <div className='popMovableContainer' style={this.offsetStyle} id={this.containerId} onMouseDown={this.manageLayout}>
                <div className='popMovableHead'  onMouseUp={this.mouseUp}>
                    <div className='popMovableHeadTitle' onMouseDown={this.mouseDown}>
                        {this.props.head}
                    </div>
                    <button className='popMovableCloseButton' onClick={this.onExit}>X</button></div>
                <div className='popMovableBody'>
                    {this.props.children}
                </div>
            </div>
        );
    }
    mouseDown(event){
        window.onmousemove = this.move;
        window.onmouseup = this.mouseUp;

        var parent_Id = event.target.parentNode.parentNode.id?event.target.parentNode.parentNode.id:null;
        document.mouseX=event.clientX;
        document.mouseY=event.clientY;
        if(ToolKit.isContaining(document.windowId, parent_Id)) {
            document.movingWindowId = parent_Id;
        }
    }
    mouseUp(){
        window.onmousemove = null;
        window.onmouseup = null;

        document.mouseX=null;
        document.mouseY=null;
        document.movingWindowId = null;
    }
    move(event){
        if(document.mouseX && document.mouseY && document.movingWindowId)
        {
            var it = document.getElementById(document.movingWindowId);
            it.style.top=(it.offsetTop-document.mouseY+event.clientY)+'px';
            it.style.left=(it.offsetLeft-document.mouseX+event.clientX)+'px';
            document.mouseX=event.clientX;
            document.mouseY=event.clientY;
        }
    }
    componentWillUnmount(){
        var elementDeleteIndex;
        for(var i = 0; i<document.windowId.length; i++) 
        if(document.windowId[i] == this.containerId) 
        {
            elementDeleteIndex=i;   
            document.windowId=ToolKit.deleteElement(document.windowId, elementDeleteIndex);
            
        }
    }
    manageLayout(event){
        //console.log(document.windowId);
        //console.log(this.containerId);
        var elementUpIndex;
        for(var i = 0; i<document.windowId.length; i++) if(document.windowId[i] == this.containerId) elementUpIndex=i;   
        if(!isNaN(elementUpIndex))
        {
            document.windowId = ToolKit.moveElement(document.windowId, elementUpIndex, document.windowId.length-1);
            for(var i=0; i<document.windowId.length; i++) 
            
            //don't really know why this error fires:
            if(document.windowId && document.windowId.length>0)
            {
                if(this.props.offsetStyle.zIndex==null)
                document.getElementById(document.windowId[i]).style.zIndex=i+2;
            }
            else console.log("Critical error with document.windowId: "+document.windowId);
        }
    }
    onExit(){
        this.props.onExit(this.props.MyId);
    }
}