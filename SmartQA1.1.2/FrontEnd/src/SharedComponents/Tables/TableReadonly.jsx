import React from 'react';
import { findDOMNode } from 'react-dom';
import {RightMenu} from '../../SharedComponents/RightMenu.jsx';
import {LangPack} from '../../Service/LangPack.js';
import '../../Styles/TableReadonlyStyle.css';

/*this class creates a simple table that can be ordered by it's columns
this class requires several things to be given to it:
*/
export class  TableReadonly extends React.Component{
    constructor(props){
        super(props);

        this.titleLine = [];
        this.tableBody = [];
        //binding functions:
        this.createTitleLine = this.createTitleLine.bind(this);
        this.createTableBody = this.createTableBody.bind(this);
        this.createStyles = this.createStyles.bind(this);

        this.tableTh = [];
        this.selectedLine=this.props.selectedLine;
        this.createStyles();

        /*CREATING RC MENU - this block can be deleted if you don't use RcMenu
        and block of functions that implement RcMenu can be deleted*/
        this.state={nodes:null};
        this.RcFunctions = [];       
        this.x=null;
        this.y=null;
        //can't loop over functions...
        this.RcFunctions.push(()=>this.props.RcFunctions[0](this.selectedLine));
        this.RcFunctions.push(()=>this.props.RcFunctions[1](this.selectedLine));
        //binding neccessary functions for RcMenu
        this.onRightClick = this.onRightClick.bind(this);
        this.onExitRightMenu = this.onExitRightMenu.bind(this);
        this.onMouseMove = this.onMouseMove.bind(this); //place call of this function inside the component that will register the mouse moving
    }
    createStyles(){
        this.styles = {};
        if(this.props.styles){
            this.styles.readOnlyTable = this.props.styles.readOnlyTable;
        }
        else{
            this.styles.readOnlyTable = 'readOnlyTable'
        }
    }
    componentWillReceiveProps(){
        this.forceUpdate();
    }

    createTitleLine(){
        if(this.props.titleLine){
            for(var i=0; i<this.props.titleLine.length; i++)
            this.titleLine.push(
                <th ref={(input)=>{this.tableTh.push(input)}}>
                    <p>{this.props.titleLine[i]}</p>
                </th>
            );
        }
        else this.titleLine=[];
    }
    createTableBody(){
        this.tableBody=[];
        for(var i=0; i<this.props.bodyInput.length; i++){
            var line = [];
            for(var j=0; j<this.props.bodyInput[i].length; j++)
            {
                line.push(
                    <td key={this.props.bodyInput[i][j]+i+j} id={i}>
                        {this.props.bodyInput[i][j]}
                    </td>
                );
            }
            var styleSelected=null;
            if(this.selectedLine==i) styleSelected ={backgroundColor:'rgb(51, 51, 51', color:'white'};
            this.tableBody.push(
                <tr 
                    key={"tableReadOnlyLine"+i} 
                    name={"tableReadOnlyLine"}
                    style = {styleSelected} 
                    onContextMenu={(event)=>{this.onRightClick(event)}}>{line}
                </tr>);
        }
    }
    render(){
        this.tableBody = [];
        this.createTitleLine();
        this.createTableBody();
        
        return(
            <table 
            onMouseMove = {this.onMouseMove}
            className={this.styles.readOnlyTable}
            cellspacing="0" 
            cellpadding="0"
            >
                <tbody>
                    {this.titleLine}
                    {this.tableBody}
                </tbody>
                {this.state.RcMenuItself}
            </table>
        );
    } 
    //RC MENU COORDS COME FROM LISTENING TO MOUSEMOVE
    onMouseMove(event){
        var scrollTop = Math.max(document.body.scrollTop, window.pageYOffset, document.documentElement.scrollTop);
        this.x= event.clientX;
        this.y= event.clientY+ scrollTop;
    }
    //RIGHT CLICK MENU FUNCTIONS:
    onRightClick(event){
        this.selectedLine=event.target.id;
        event.preventDefault();
        this.setState({RcMenuItself: <RightMenu 
            X={this.x}
            Y={this.y}
            RcNames={this.props.RcNames} 
            RcFunctions={this.RcFunctions}
            onExit={this.onExitRightMenu}/>});
        window.onwheel = (event)=> {event.preventDefault()};
        return false;
    }
    onExitRightMenu(event){
        event.preventDefault();
        this.setState({RcMenuItself: null});
        window.onwheel = null;
        this.selectedLine=null;
        return false;
    }
}
