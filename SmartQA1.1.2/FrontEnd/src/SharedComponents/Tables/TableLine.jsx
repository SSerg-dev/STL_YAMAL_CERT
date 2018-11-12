import React from 'react';
import {TableInput} from './TableInput.jsx';
import {TableDateInput} from './TableDateInput.jsx';
import {SuperList} from '../SuperList.jsx';
import {ToolKit} from '../../Service/ToolKit.js';
import {TableList} from './TableList.jsx';
import {RightMenu} from '../RightMenu.jsx';

/*this class requires to be supplied with several things while initialization:
-> id of the line (MyId)
-> matrix of the line cells (lineMatrix)
-> input values (lineInput) - an array of initial values
-> callBack function that will be used to alter values in the table (callBack)

*/
export class TableLine extends React.Component{

    constructor(props){
        super(props);

        //binding some functions to the instance of the object
        this.onKeyDown = this.onKeyDown.bind(this);
        this.cellOnFocus = this.cellOnFocus.bind(this);
        this.createLineNodes = this.createLineNodes.bind(this);
        this.callBack = this.callBack.bind(this);
        this.focusCell = this.focusCell.bind(this);
        this.callBack = this.callBack.bind(this);
        this.state = ({RcMenuItself: null});
        
        //navigation between cells:
        this.focusedCell=null;
        this.focusedCellIndex=0;
        this.cellArray = [];
        this.lineNodes = this.createLineNodes(this.props.lineMatrix, this.props.lineInput);
        

        /*CREATING RC MENU - this block can be deleted if you don't use RcMenu
        and block of functions that implement RcMenu can be deleted*/
        this.RcFunctions = [];       
        //can't loop over functions...
        this.RcFunctions.push(()=>this.props.RcFunctions[0](this.props.MyId));
        this.RcFunctions.push(()=>this.props.RcFunctions[1](this.props.MyId));
        this.RcFunctions.push(()=>this.props.RcFunctions[2](this.props.MyId));
        //binding neccessary functions for RcMenu
        this.onRightClick = this.onRightClick.bind(this);
        this.onExit = this.onExit.bind(this);
        this.onMouseMove = this.onMouseMove.bind(this);

    }
    componentDidUpdate(){
        //console.log("The line did updated");
    }
    componentDidMount(){
        //console.log(this.cellArray);
    }
    render(){
        this.lineNodes = [];
        this.lineNodes = this.createLineNodes(this.props.lineMatrix, this.props.lineInput);
        //console.log("Rendering this line: "+this.props.MyId);
        //console.log(this.lineNodes);
        return (
            <tr onKeyDown={this.onKeyDown}
                onMouseMove = {this.onMouseMove}
                onContextMenu = {this.onRightClick}
                key={"lineTr"+this.props.MyId}
                onExit = {this.onExit}>
                {this.lineNodes}
                {this.state.RcMenuItself}
            </tr>
        );
    }

    /*this function creates child nodes of the line
    according to the lineMatrix provided and filling it with values from lineInput
    Here cell refs are put into array to make it possible for the line to navigate between
    cells using focusCell() function
    */

    createLineNodes(lineMatrix, lineInput){
        var lineNodes=[];
        for(var i=0; i<lineMatrix.length; i++){

            if(lineMatrix[i]=='tableInput') lineNodes.push(
                <td>
                    <TableInput 
                    callBack={this.callBack} 
                    inValue={lineInput[i]} 
                    ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                    cellOnFocus={this.cellOnFocus}
                    MyId={i}/>
                </td>
                );

            if(lineMatrix[i]=='tableDateInput') lineNodes.push(
                <td>
                    <TableDateInput 
                    callBack={this.callBack} 
                    inValue={lineInput[i]}
                    ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                    cellOnFocus={this.cellOnFocus}
                    MyId={i}/>
                </td>
                );
            
            if(Array.isArray(lineMatrix[i])) {lineNodes.push(
                <td >
                    <TableList
                    callBack={this.callBack}
                    inValue={lineInput[i]}
                    ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                    ArrayOfStrings={lineMatrix[i]} 
                    cellOnFocus={this.cellOnFocus}
                    MyId={i}/>
                </td>);
            }  
        }
        return lineNodes;
    }
    callBack(j, newValue){
        this.props.callBack(this.props.MyId, j, newValue);
    }
    //KEYEVENT BLOCK
    onKeyDown(event){
        //arrow left
        if(event.which == 37) {
            if(this.focusedCellIndex>0) this.focusCell(this.focusedCellIndex-1);
        }
        //arrow right
        if(event.which == 39) {
            if(this.focusedCellIndex < this.props.lineInput.length-1) this.focusCell(this.focusedCellIndex+1);
        }
    }
    //FOCUS BLOCK
    focusCell(qi){
        this.cellArray[qi].focusCell();
    }
    //this function is passed to cell to be called by cell when 
    cellOnFocus(cellIndex){
        this.focusedCellIndex = cellIndex;
        this.props.cellOnFocus(this.props.MyId, this.focusedCellIndex);
    }
   
    /*this functions implement events from RCmenu, binded in RcMenuCreate to the current context
    and can be deleted if you don't call RcMenuCreate()*/
    //TODO - this part have to implemented in the right-click menu itself and without setState
    onRightClick(event){
        event.preventDefault();
        this.setState({RcMenuItself: <RightMenu 
            X={this.x}
            Y={this.y}
            RcNames={this.props.RcNames} 
            RcFunctions={this.RcFunctions}
            onExit={this.onExit}/>});
        return false;
    }
    onExit(event){
        event.preventDefault();
        this.setState({RcMenuItself: null});
        return false;
    }
    onMouseMove(event){
        this.x= event.clientX;
        this.y= event.clientY;
    }
}
