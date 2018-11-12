import React from 'react';
import ReactDOM from 'react-dom';
import {ToolKit} from '../Service/ToolKit.js';

/*the main feature of this component is that it's not rendering all the time - it's just
a container with few buttons. And the procedure of updating this component should be
escaped furthermore because of generating id for div elements and manipulating child divs
with this id*/

export class TabWindow extends React.Component{
    constructor(props){
        super(props);

        this.activeTab = null;
        this.tabIdArray = this.props.tabNames.map(()=>{return ToolKit.shortId()});

        //binding functions
        this.changeButton = this.changeButton.bind(this);
        this.createTabButtons = this.createTabButtons.bind(this);
        this.createNodes = this.createNodes.bind(this);
    }
    componentDidMount(){
        this.activeTab = document.getElementById(this.tabIdArray[0]);
        this.activeTab.style.display="block";
    }
    createTabButtons(){
        var tabButtons=[];
        for(var i=0; i<this.props.tabNames.length; i++){
            tabButtons.push(
                <button 
                    name={i} 
                    style={this.props.buttonStyle?this.buttonStyle[i]:null}
                    onClick={this.changeButton}
                >
                    {this.props.tabNames[i]}
                </button>);
        }
        return tabButtons;
    }
    createNodes(){
        var nodes = [];
        for(var i =0; i<this.props.children.length; i++){
            nodes.push(<div id={this.tabIdArray[i]} style={{display:'none'}}>{this.props.children[i]}</div>)
        }
        return nodes;
    }
    render(){
        return(
            <div className={this.props.className.container}>
                <div className={this.props.className.buttonLine}>{this.createTabButtons()}</div>
                <div className={this.props.className.tabs}>{this.createNodes()}</div>
            </div>
        );
    }
    changeButton(event){
        this.activeTab.style.display='none';
        this.activeTab=document.getElementById(this.tabIdArray[event.target.name]);
        this.activeTab.style.display='block';
    }
}