import { findDOMNode } from 'react-dom';
import React from 'react';
import ReactDOM from 'react-dom';
import {TableLine} from './TableLine.jsx';
import {ToolKit} from '../../Service/ToolKit.js';
import {DateInput} from '../DateInput.jsx';
import {LangPack} from '../../Service/LangPack.js';

/*import $ from 'jquery';
import store from 'store';
import './jquery.resizableColumns.js';
import ColumnResizer from 'column-resizer';*/
/*
This superclass will be soon used to create different types of the tables in future
This table can do several basic things:
- right-click context menu on every line
- add, edit, delete lines
- navigation between cells using arrows, enter, tab
- ctrl+C and ctrl+V functionality, buffering values
- all functionality coming from cell components involved

This class requires several things to be supplied with to create an instance of
the table:
-> matrix that will determine type of columns (lineMatrix)
-> table title - header of the table (tabletitle)
-> initial table value (bodyInput)
-> callBack function to update table value outside the Supertable itself

*/

export class SuperTable extends React.Component{

    constructor(props){
        super(props);

        this.LangPack=new LangPack('rus');

        //binding functions first:
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
        this.specifyColWidth = this.specifyColWidth.bind(this);
        //testing resizable function:
        //this.enableResize=this.enableResize.bind(this);

        this.lineArray=[]; //this array is used to store refs that point on line components
        this.buffer = null; //here the table stores and retrieves data when ctrlC and ctrlV events happen
        this.navigateDown = false; //this parameter is used in componentDidMount to navigate down after the last line was added by keydown event or + button
        this.state={bodyInput:this.props.bodyInput};
        this.titleLine = this.createTitleLine(this.props.tableTitle); //creating title line
        this.focusedColumnIndex=0;
        this.focusedLineIndex=0;
        this.colNodes = []; //used for resizing
        this.tableRef=null;

        //setting the environment for context menu:
        this.RcNames = [this.LangPack.lineBefore, this.LangPack.lineAfter, this.LangPack.lineDelete];
        this.RcFunctions = [this.pushLine, this.pushLineAfter, this.deleteLine];    
    }
    /*this native method is called when the component has updated - implemented just for navigating down
    when the last line is added by keydown or + button */
    componentDidUpdate(){
        if(this.navigateDown) this.lineArray[this.focusedLineIndex+1].focusCell(this.focusedColumnIndex);
        this.navigateDown=false;
    }
    componentDidMount(){
        /*
        var tableTurnResizable = findDOMNode(this.tableRef);
        $(tableTurnResizable).resizableColumns({
            store: window.store
          });
          this.enableResize();*/
          
    }
    /*
    enableResize() {
        const normalRemote = ReactDOM.findDOMNode(this).querySelector(`#${this.bodyId}`);
        const options = this.props.resizerOptions;
        //options.remoteTable = normalRemote;
        if (!this.resizer) {
            this.resizer = new ColumnResizer(
                ReactDOM.findDOMNode(this).querySelector(`#${this.headerId}`), options);
        } else {
            this.resizer.reset(options);
        }
    }*/

    createTableBody(Aos){
        var tableBody=[];
        
        //maybe should the table accept empty aos when been created? or there must be null variable in the parent element?
        for(var i=0; i<Aos.length; i++){
            
            tableBody.push(
                <TableLine lineMatrix={this.props.lineMatrix} 
                    key={"line"+i}
                    MyId={i} 
                    lineInput={Aos[i]} 
                    colSize={this.props.colSize}
                    callBack={this.callBack}
                    cellOnFocus={this.cellOnFocus}
                    RcNames={this.RcNames}
                    RcFunctions={this.RcFunctions}
                    ref={(inputRef) =>{if(inputRef){this.lineArray[inputRef.props.MyId]=inputRef;}}}
                />
            ); 
        };
        return tableBody;
    }

    //this function creates title line from input values
    createTitleLine(Aos){
        var newTitleLine = null;
        var i=0;
        newTitleLine = Aos.map((node) =>{
            return (<th>{node}</th>);
        }    
        );
        return newTitleLine;
    }
    specifyColWidth(){
        this.colNodes=[];
        for(var i=0; i<this.props.colSize.length; i++)
        this.colNodes.push((<col width={this.props.colSize[i]}/>));
    }

    render(){  
        this.specifyColWidth();
        this.tableBody = [];
        this.tableBody = this.createTableBody(this.state.bodyInput);  
        return(
        <table 
            ref={(input)=>this.tableRef=input}
            onKeyDown={this.onKeyDown} 
            className={this.props.className} 
            data-resizable-columns-id="demo-table"
            cellspacing="0" cellpadding="0">
            {this.colNodes}
            <tbody>
                <tr>{this.titleLine}</tr>
                {this.tableBody}
                <tr><button onClick={this.pushLineLast}>+</button></tr>
            </tbody>
        </table>
    );}
    //this function updated table date by adding a line
    pushLineLast(){
        //before creating new line the program have to find out if the last existing line is empty      
        if(this.state.bodyInput.length==0 || !ToolKit.isEmpty(this.state.bodyInput[this.state.bodyInput.length-1])){
            if(this.state.bodyInput.length!=0) this.navigateDown=true;
            this.pushLine(this.state.bodyInput.length);
        }
    }
    //this function can be called to push line before the element, that provided index points on
    pushLine(index){
        this.state.bodyInput = 
                ToolKit.pushInside(this.state.bodyInput, ToolKit.empty(this.props.lineMatrix), index);
        if(!this.state.bodyInput) this.state.bodyInput = ToolKit.empty(this.props.lineMatrix);
        this.setState({bodyInput: this.state.bodyInput});
        this.props.callBack(this.state.bodyInput);
    }
    /*this function was created to avoid modifying arguments during
    calling callBack functions.*/
    pushLineAfter(index){
        this.pushLine(index+1);
    }
    deleteLine(index){
        this.state.bodyInput = ToolKit.deleteElement(this.state.bodyInput, index);
        this.setState({bodyInput: this.state.bodyInput});
        this.props.callBack(this.state.bodyInput);
    }
    callBack(i, j, newValue){
        this.state.bodyInput[i][j] = newValue;
        //this line can be unneccessary at all but delete statement doesn't work:
        //this.setState({bodyInput: this.state.bodyInput});
        this.props.callBack(this.state.bodyInput);
    }
    cellOnFocus(i, j){
        this.focusedLineIndex=i;
        this.focusedColumnIndex=j;
    }
    onKeyDown(event){
        //navigation
        if(event.which==38)
        if(this.focusedLineIndex>0)
            this.lineArray[this.focusedLineIndex-1].focusCell(this.focusedColumnIndex);

        if(event.which==13 || event.which==40) {
            //checking if it's the last line of the table
            if(this.focusedLineIndex==(this.state.bodyInput.length-1)) {
                //checking if user is pressing Enter on the SuperList component
                if(!(event.which==13 && this.props.lineMatrix[this.focusedColumnIndex]!='tableInput' && this.props.lineMatrix[this.focusedColumnIndex]!='tableDateInput'))
                    this.pushLineLast();
            }        
            //if it's not the last line of the table then jump to the next line
            else if(this.focusedLineIndex<(this.state.bodyInput.length-1))
                    this.lineArray[this.focusedLineIndex+1].focusCell(this.focusedColumnIndex);
        } 

        if(event.ctrlKey && event.which == 67) {
            this.ctrlC();}
        if(event.ctrlKey && event.which == 86) {
            this.ctrlV();}
        if(event.ctrlKey && event.which == 88){
            this.ctrlX();}
        if(event.which == 46) this.callBack(this.focusedLineIndex, this.focusedColumnIndex, '');
    }
    ctrlC(){
        this.buffer = this.state.bodyInput[this.focusedLineIndex][this.focusedColumnIndex];
    }
    ctrlV(){
        var columnType = this.props.lineMatrix[this.focusedColumnIndex];
        
        //you can't copy invalid values into date input
        if(!(columnType=='tableDateInput' && this.buffer!=DateInput.DateMask(this.buffer)))
        //you can't copy invalid values into drop-down list
        if(!(Array.isArray(columnType) && !ToolKit.isContaining(columnType, this.buffer)))
        this.callBack(this.focusedLineIndex, this.focusedColumnIndex, this.buffer);
    }
    ctrlX(){
        this.buffer = this.state.bodyInput[this.focusedLineIndex][this.focusedColumnIndex];
        this.callBack(this.focusedLineIndex, this.focusedColumnIndex, '');
    }
}