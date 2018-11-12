import React from 'react';
import Switch from "react-switch";
import {TableOrderBy} from './TableOrderBy.jsx';
import {ActiveHeadCell} from './ActiveHeadCell.jsx';
import {ToolKit} from '../../Service/ToolKit.js';
import {LangPack} from '../../Service/LangPack.js';
import {PopMovable} from '../../SharedComponents/PopMovable.jsx';
import {RightMenu} from '../../SharedComponents/RightMenu.jsx';

import '../../Styles/ScrollTable.css';
import '../../Styles/TableReadonlyStyle.css';

/*this component was made to implement Table, that will have several additional
functions apart from TableOrderBy functionality:

- User is able to choose row with left click
- User is able to select columns that will be displayed
- Title of the table is shown
- The table is situated inside a textarea
- The table may have a button that diselects the selected row (optional)

This component requires these props to be supplied with:

-. orderCallBack()
-. selectCallBack() 
-. scrollCallBack() - function that will be called when the textarea is scrolled to its bottom
-. deselectCallBack() - if no deselect is specified, than no button is created
-. changeColumnsCallBack() - function that will be called when User changes columns (for further UI state saving)
-. colNames - array of name of columns as they are in the DB - to implement Order By
-. titleLine - names of columns
-. defaultColumns - names of columns as they are in the DB to be selected when the component is mounted
-. isDiselectable - specifies if the table has button "diselect" so User can diselect the chosen row
-. bodyInput - data to be filled (columns in the same order as in tableTitle, colNames)
-. RcNames
-. RcFunctions
-. selectedRow
-. tableName
-. key

*/

export class ScrollTable extends TableOrderBy{
    constructor(props){
        super(props);

        this.titleLine = [];
        this.tableBody = null;
        this.columnChoser = null;
        
        this.LangPack = new LangPack('eng');
        this.divScrollPosition = 200;
        this.selectedRow = this.props.selectedRow;

        //applying selected columns
        this.selectedColumns = new Set();
        this.props.defaultColumns.forEach((col)=>this.selectedColumns.add(col));

        this.tableId = ToolKit.shortId(); //used to create key for every <tr>
        this.scrollDivId = ToolKit.shortId(); //see this variable further in render block

        //binding functions
        this.onScroll = this.onScroll.bind(this);
        this.selectRow = this.selectRow.bind(this);
        this.createTitleLine = this.createTitleLine.bind(this);
        this.createTableBody = this.createTableBody.bind(this);
        this.showColumnChoser = this.showColumnChoser.bind(this);
        this.hideColumnChoser = this.hideColumnChoser.bind(this);
        this.deselectRow = this.deselectRow.bind(this);
        this.changeSelectedColumns = this.changeSelectedColumns.bind(this);
        this.onWheel = this.onWheel.bind(this);

        /*CREATING RC MENU - this block can be deleted if you don't use RcMenu
        and block of functions that implement RcMenu can be deleted*/
        this.state={nodes:null};
        this.RcFunctions = [];       
        this.x=null;
        this.y=null;
        //can't loop over functions...
        this.RcFunctions.push(()=>this.props.RcFunctions[0](this.selectedRow));
        this.RcFunctions.push(()=>this.props.RcFunctions[1](this.selectedRow));
        //binding neccessary functions for RcMenu
        this.onRightClick = this.onRightClick.bind(this);
        this.onExitRightMenu = this.onExitRightMenu.bind(this);
        this.onMouseMove = this.onMouseMove.bind(this); //place call of this function inside the component that will register the mouse moving
    }
    componentWillReceiveProps(){
        //if(this.props.selectedRow!=null) this.selectedRow = this.props.selectedRow;
        
    }
    componentDidMount(){
        this.scrollDiv = document.getElementById(this.scrollDivId);
    }
    render(){
        //if(this.props.selectedRow!=null) this.selectedRow = this.props.selectedRow;
        this.createTableBody();
        this.createTitleLine();
        this.containerId = ToolKit.shortId();
        

        var deselectButton = null;
        if(this.props.deselectCallBack) deselectButton = 
            (
                <div className = 'scrollTable_buttonContainer' onClick = {this.deselectRow}>
                    <img 
                        key={ToolKit.shortId()}
                        className = 'scrollTable_deselect' 
                        src={require('../../img/scroll_deselect.png')}
                    />
                </div>
            );
        var createButton = null;
        if(this.props.createCallBack) createButton = 
        (
            <div className = 'scrollTable_buttonContainer' onClick = {this.props.createCallBack}>
                <img
                    className = 'scrollTable_create' 
                    src={require('../../img/scroll_create.png')}
                />
            </div>
        );
        return(
            <div className = 'scrollTable_container' id={this.containerId}>
                <div className = 'scrollTable_titleLine'>
                    <div className = 'scrollTable_title'>{this.props.tableName}</div>
                    <div className = 'scrollTable_buttonContainer' onClick = {this.showColumnChoser}>
                        <img 
                            key={ToolKit.shortId()}
                            className = 'scrollTable_changeColumns' 
                            src={require('../../img/if_Hamburger_Round_657905.png')}
                        />
                    </div>
                    {deselectButton}
                    {createButton}
                </div>
                <div className = 'scrollTable_verticalScrollBarHider'>
                    <div className = 'scrollTable_tableContainer' onScroll={this.onScroll} onWheel={this.onWheel}> 
                        <table
                            onMouseMove = {this.onMouseMove}
                            className="scrollTable"
                            cellspacing="0"
                            cellpadding="0"
                        >
                            <thead>
                                {this.titleLine}
                            </thead>
                            <tbody className = 'scrollTable_tbody' id={this.scrollDivId}>
                                    {this.tableBody}
                            </tbody>
                        </table>
                    </div>
                </div>
                {this.columnChoser}
                {this.state.RcMenuItself}
            </div>
        );
    }
    createTitleLine(){
        if(this.props.titleLine){
            this.titleLine = [];
            for(var i=0; i<this.props.titleLine.length; i++)
            {
                if(this.selectedColumns.has(this.props.colNames[i]))
                this.titleLine.push(
                    <ActiveHeadCell colName={this.props.colNames[i]} orderCallBack = {this.props.orderCallBack}>
                        <p>{this.props.titleLine[i]}</p>
                        <i class="arrow_down"></i>
                        {this.childList}
                    </ActiveHeadCell>
                );
            }
        }
        else this.titleLine=[];
    }
    createTableBody(){

        this.tableBody=[];
        for(var i=0; i<this.props.bodyInput.length; i++){
            var line = [];
            for(var j=0; j<this.props.bodyInput[i].length; j++)
            {
                if(this.selectedColumns.has(this.props.colNames[j]))
                line.push(
                    <td 
                        key={String(this.tableId)+i+j} 
                        id={i}
                    >
                        {this.props.bodyInput[i][j]}
                    </td>
                );
            }
            var styleSelected=null;
            if(this.selectedRow==i) styleSelected = {backgroundColor:'rgb(216, 118, 5)', color:'white'};
            this.tableBody.push(
                <tr 
                    key={String(this.tableId)+i+ToolKit.shortId()} 
                    name={String(this.tableId)}
                    style = {styleSelected} 
                    onClick = {this.selectRow}
                    onContextMenu={(event)=>{this.onRightClick(event)}}
                >
                    {line}
                </tr>
            );
        }
    }
    selectRow(event){
        //how it will work if cells of two tables have equal IDs?
        this.selectedRow = event.target.id; 
        this.props.selectCallBack(this.selectedRow);
        this.forceUpdate();
    }
    deselectRow(){
        this.selectedRow = null;
        this.props.deselectCallBack();
        this.forceUpdate();
    }
    onScroll(event){
        this.scrollDiv.style.overflow = 'scroll';
        var top = this.scrollDiv.scrollHeight;
    }
    onWheel(event){
        this.divScrollPosition += event.deltaY;
        if(this.scrollDiv.scrollHeight <= this.divScrollPosition){
            this.props.scrollCallBack();
            this.divScrollPosition = this.scrollDiv.scrollHeight;
        }
        if(this.divScrollPosition<0) this.divScrollPosition = 200;
    }
    showColumnChoser(){
        //positioning column choser in the center
        var width = 92+ToolKit.maxStringLength(this.props.titleLine)*9;
        var height = 800; //approximate height
        var offsetRight = (window.innerWidth - width)/2;
        var offsetTop  = (window.innerHeight - height)/2;

        var columnSelectors = [];
        for(var i = 0; i<this.props.titleLine.length; i++){
            var isOn = this.selectedColumns.has(this.props.colNames[i]);
            columnSelectors.push(<ColumnSelectorLine 
                name={this.props.titleLine[i]}
                colName={this.props.colNames[i]}
                isOn={isOn}
                callBack = {this.changeSelectedColumns}
            />);
        }
        this.columnChoser = (
            <PopMovable
                offsetStyle = {{right:offsetRight, top:offsetTop, width:width}}
                head = {this.LangPack.ChoseColumns}
                onExit = {this.hideColumnChoser}
                MyId = {String(this.tableId)+"columnSelector"}
            >
                <div className = "scrollTable_columnSelectorsContainer">
                    {columnSelectors}
                </div>
            </PopMovable>
        );
        this.forceUpdate();
    }
    hideColumnChoser(){
        this.columnChoser = null;
        this.forceUpdate();
    }
    changeSelectedColumns(colName){
        if(this.selectedColumns.has(colName)) this.selectedColumns.delete(colName)
        else this.selectedColumns.add(colName);
        this.forceUpdate();
    }
    //RC MENU COORDS COME FROM LISTENING TO MOUSEMOVE
    onMouseMove(event){
        var container = document.getElementById(this.containerId).getBoundingClientRect();
        var scrollTop = Math.max(document.body.scrollTop, window.pageYOffset, document.documentElement.scrollTop);
        
        this.x= event.clientX - container.left;
        this.y= event.clientY+ scrollTop - container.top;
    }
    //RIGHT CLICK MENU FUNCTIONS:
    onRightClick(event){
        this.selectedRow = event.target.id; 
        event.preventDefault();
        this.setState({RcMenuItself: <RightMenu 
            X={this.x}
            Y={this.y}
            RcNames={this.props.RcNames} 
            RcFunctions={this.RcFunctions}
            onExit={this.onExitRightMenu}/>});
        window.onwheel = (event)=> {event.preventDefault()};
        this.forceUpdate();
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
//CLASS
class ColumnSelectorLine extends React.Component{
    constructor(props){
        super(props);
        this.changeSelector = this.changeSelector.bind(this);
        this.isOn = this.props.isOn;
    }
    render(){
        return(
            <div className="scrollTable_columnSelectorLineContainer">
                <div className="scrollTable_columnSelectorLineSwitch">
                    <Switch
                            onChange={this.changeSelector}
                            checked={this.isOn}
                            className="react-switch"
                            id={ToolKit.shortId()}
                            height={20}
                            width={40}
                    />
                </div>
                <div className="scrollTable_columnSelectorLineText">{this.props.name}</div>
            </div>
        );
    }
    changeSelector(){
        this.isOn = !this.isOn;
        this.props.callBack(this.props.colName);
        this.forceUpdate();
    }
}