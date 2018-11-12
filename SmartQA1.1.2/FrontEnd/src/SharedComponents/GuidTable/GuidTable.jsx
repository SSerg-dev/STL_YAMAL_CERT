import React from 'react';
import {SuperTable} from '../SuperTable.jsx';
import {GuidLine} from './GuidLine.jsx';
import {ToolKit} from '../../Service/ToolKit.js';
import {Cell} from '../../Models/Cell.jsx';
import {LangPack} from '../../Service/LangPack.js';


/* this table creates hidden column (probably, column with guid elememts) when being
initialized and doesn't align the values of this column. This makes 
distinguishing the lines that were created at the beginning and lines
that were added by the table itself possible. Also this table places 
the deleted lines to the special table of deleted elements and provides 
this bunch of information to the parent component. The parent component now
can implement this operations: 
- delete lines
- update lines
- create new lines

*/

export class GuidTable extends SuperTable{
    constructor(props){
        super(props);

        this.LangPack=new LangPack('rus');
        this.className = this.props.className; //this is not just a string - it's an object with it's properties see the diagram

        //binding functions first (better do no delete any bindings at all)
        this.createTableBody = this.createTableBody.bind(this);
        this.callBack = this.callBack.bind(this);
        this.cellOnFocus = this.cellOnFocus.bind(this);
        this.onKeyDown = this.onKeyDown.bind(this);
        this.pushLine = this.pushLine.bind(this);
        this.pushLineLast = this.pushLineLast.bind(this);
        this.pushLineAfter = this.pushLineAfter.bind(this);
        this.deleteLine = this.deleteLine.bind(this);
        this.ctrlC = this.ctrlC.bind(this);
        this.ctrlV = this.ctrlV.bind(this);
        this.ctrlX = this.ctrlX.bind(this);
        this.createBufferLine = this.createBufferLine.bind(this);
        this.clearTable = this.clearTable.bind(this);
        //testing resizable function:
        //this.enableResize=this.enableResize.bind(this);

        this.lineArray=[]; //this array is used to store refs that point on line components
        this.buffer = null; //here the table stores and retrieves data when ctrlC and ctrlV events happen
        this.navigateDown = false; //this parameter is used in componentDidMount to navigate down after the last line was added by keydown event or + button
        this.state={bodyInput:this.props.bodyInput};
        this.titleLine = this.createTitleLine(this.props.tableTitle); //creating title line
        this.focusedColumnIndex=0;
        this.focusedLineIndex=0;
        this.tableRef=null;

        //setting the environment for context menu:
        this.RcNames = [this.LangPack.lineBefore, this.LangPack.lineAfter, this.LangPack.lineDelete];
        this.RcFunctions = [this.pushLine, this.pushLineAfter, this.deleteLine];    

        this.guidArray = this.props.guidArray; //ADDED THIS ARRAY TO STORE GUID
        this.deleteArray = []; //ADDED THIS ARRAY TO STORE GUID OF DELETED ELEMENTS
        if(this.guidArray)
        if(this.guidArray.length!=this.state.bodyInput.length) console.log("CRITICAL ERROR: guidArray and bodyInput are of different size");
    }
    componentWillReceiveProps(newProps){
        this.guidArray = newProps.guidArray;
        this.state.bodyInput = newProps.bodyInput;
    }

    createTableBody(Aos){
        var tableBody=[];
        //maybe should the table accept empty aos when been created? or there must be null variable in the parent element?
        for(var i=0; i<Aos.length; i++){
                var newLine = null;
                var newLine = (
                <GuidLine 
                    className = {this.className}
                    lineMatrix={this.props.lineMatrix} 
                    MyId={i} 
                    lineInput={Aos[i]} 
                    callBack={this.callBack}
                    cellOnFocus={this.cellOnFocus}
                    RcNames={this.RcNames}
                    RcFunctions={this.RcFunctions}
                    ref={(inputRef) =>{if(inputRef){this.lineArray[inputRef.props.MyId]=inputRef;}}}
                />);
                tableBody.push(newLine); 
        };
        return tableBody;
    }
    clearTable(){
        this.tableBody=[];
        this.forceUpdate();
    }
    //this function can be called to push line before the element, that provided index points on
    pushLine(index){
        this.state.bodyInput = 
                ToolKit.pushInside(this.state.bodyInput, this.props.createBufferLine(), index);
        this.guidArray = ToolKit.pushInside(this.guidArray, "", index);
        if(!this.state.bodyInput) {
            this.guidArray = [""];
            this.state.bodyInput = this.props.emptyLine;
        }
        this.props.callBack(this.state.bodyInput, this.guidArray, this.deleteArray);   
        this.setState({bodyInput: this.state.bodyInput});
     }
     createBufferLine(){
        var lineForTable = []; //clear it first
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("guidSingleCheck", null));
        lineForTable.push(new Cell("guidDoubleCheck", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableDateInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        //for(var i=0; i<lineForTable.length; i++) lineForTable[i].inValue = ["!"];
        return lineForTable;
        }
    deleteLine(index){
        if(this.guidArray[index]!="") this.deleteArray.push(this.guidArray[index]); //adding the deleted element guid to the guid array
        this.guidArray = ToolKit.deleteElement(this.guidArray, index);
        this.state.bodyInput = ToolKit.deleteElement(this.state.bodyInput, index);
        this.props.callBack(this.state.bodyInput, this.guidArray, this.deleteArray);
        this.setState({bodyInput: this.state.bodyInput});
    }
    callBack(i, j , newValue){
        if(!Array.isArray(newValue)) newValue=[newValue];
        this.state.bodyInput[i][j].inValue = newValue;
        
        this.props.callBack(this.state.bodyInput, this.guidArray, this.deleteArray);
    }
    render(){  
        this.tableBody = [];
        this.tableBody = this.createTableBody(this.state.bodyInput);  
        return(
        <table 
            ref={(input)=>this.tableRef=input}
            onKeyDown={this.onKeyDown} 
            className={this.className.tableStyle} 
            cellspacing="0" cellpadding="0">
                <tbody>
                <tr>{this.titleLine}</tr>
                {this.tableBody}
                <tr><button className={this.className.addLineButton}onClick={this.pushLineLast}>+</button></tr>
                </tbody>
        </table>
    );
}
}