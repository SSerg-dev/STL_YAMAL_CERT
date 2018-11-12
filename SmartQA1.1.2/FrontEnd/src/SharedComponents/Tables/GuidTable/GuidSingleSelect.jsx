import React from 'react';
/*this component requires Cell object to be put inside*/

/*TODO: you can implement then this component to make arbitrary number of 
columns to be filled*/
import {ToolKit} from '../../../Service/ToolKit.js';
import {ErrorInput} from '../../InputWithErrors/ErrorInput.jsx';
import {AjaxModule} from '../../../SharedComponents/AjaxModule.jsx';
import {LangPack} from '../../../Service/LangPack.js';
import '../../../Styles/GuidSingleSelect.css'

export class  GuidSingleSelect extends React.Component
{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('rus');
        this.listId = [];
        this.listName = [];
        this.nodes = [];
        this.nodeLines = [];
        this.inputVal=[];

        //counting the amout of items selected
        if(this.props.inValue && this.props.inValue.length>0 && this.props.inValue[0]!=null && this.props.inValue[0]!="00000000-0000-0000-0000-000000000000")
        this.items= this.LangPack.Selected+(this.props.inValue.length);
        else this.items= this.LangPack.Selected+0;

        this.ajaxModuleOutputRef = null; //link used to call ajax module
        this.activeElements = []; //used to show error messages
        this.isStructureListLoaded = false; //used to identify if you can close the window
        this.lists={
            Structure_ID:[],
            Structure_Name:[]
        }
        //binding functions: 
        this.getNodes = this.getNodes.bind(this);
        this.fillLines = this.fillLines.bind(this);
        this.createNodes = this.createNodes.bind(this);
        this.deleteButton = this.deleteButton.bind(this);
        this.tryAddLine = this.tryAddLine.bind(this);
        this.addLine = this.addLine.bind(this);
        this.validateInput = this.validateInput.bind(this);
        this.getStructureList = this.getStructureList.bind(this);
        this.hideNodes = this.hideNodes.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.focusCell = this.focusCell.bind(this); 
    }
    render(){
        return (
            <div>
                <div className = {this.props.className}>{this.items} <button onClick={this.getNodes}>></button></div>
                {this.nodes}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    getNodes(){
        //getting Structure possible options - must be downloaded anyway
        this.ajaxModuleOutputRef.sendRequest('','/getStructureList',
        this.ajaxModuleOutputRef,this.getStructureList);
        this.listName = [];
        this.listId = [];
    }
    fillLines(){
        this.nodeLines=[];
        for(var i=0; i<this.listName.length; i++)
        this.nodeLines.push(
            <div className="gss_listLine">
                <div className="gss_pidText">{this.listName[i]}</div>
                <input className="gss_deleteLineButton" type="submit" value="X" name={i} onClick={(event)=>this.deleteButton(event)}/>
            </div>
        );
        console.log(this.listName.length);
        this.createNodes();
    }
    createNodes(){
        this.nodes=null;
        this.nodes=(
            <div>
                <div className="gss_block" onClick={this.hideNodes}></div>
                <div className="gss_container" >
                    {this.nodeLines}
                    <ErrorInput className="gss_input" ref={(input)=>this.activeElements.push(input)} callBack={(value)=>this.inputVal=value}/>
                    <button className="gss_addLine" onClick={this.tryAddLine}>+</button>
                </div>
            </div>
            );
        this.forceUpdate();
    }
    hideNodes(){
        if(this.isStructureListLoaded)
        {
            this.nodes=[];
            this.props.callBack(this.props.MyId, this.listId);
            this.forceUpdate();
        }
    }
    deleteButton(event){
        this.listName = ToolKit.deleteElement(this.listName, event.target.name);
        this.listId = ToolKit.deleteElement(this.listId, event.target.name);
        this.fillLines();
        this.forceUpdate();
    }
    onFocus(){
        this.props.cellOnFocus(this.props.MyId); //Telling the Line: "I'm focused!": - not pluged yet
    }
    focusCell(){
        //called externally by the line so the cell can change it's style
    }
    tryAddLine(){
        this.activeElements[0].showError("");
        if(this.validateInput()) this.addLine();
    }
    addLine(){
        this.listName.push(this.inputVal.toUpperCase());
        this.listId.push(
            this.lists.Structure_ID[ToolKit.getKeyByValue(this.lists.Structure_Name, this.inputVal)]
        );
        this.fillLines();
        
    }
    validateInput(){
        //check if all input is filled:
        if(this.inputVal=="" || this.inputVal==null || this.inputVal==undefined)
        {
            this.activeElements[0].showError("Fill this field");
            return false;
        }
        //check if there's such values in the dictionary:
        if(!ToolKit.isContaining(this.lists.Structure_Name, this.inputVal)) 
        {
            this.activeElements[0].showError("No such value in dictionary");
            return false;
        }
        //check if the value is already contained in the list
        console.log(this.listName);
        console.log(this.inputVal);
        if(ToolKit.isContaining(this.listName, this.inputVal))
        {
            this.activeElements[0].showError("This value already exist");
            return false;
        }
        return true;
    }
    getStructureList(response){
        console.log("Downloaded Structure dictionary");
        console.log(response);
        
        for(var i=0; i<response.length; i++){
            this.lists.Structure_ID.push(response[i].Structure_ID);
            this.lists.Structure_Name.push(response[i].Name);
        }
        if(this.props.inValue && this.props.inValue[0]!=null)
        for(var i=0; i<this.props.inValue.length; i++)
        {
            this.listId.push(this.props.inValue[i]);
            this.listName.push(this.lists.Structure_Name[ToolKit.getKeyByValue(this.lists.Structure_ID, this.props.inValue[i].toLowerCase())]);
        }
        console.log(this.lists.Structure_Name); //28040
        this.isStructureListLoaded = true;
        this.fillLines();
    }
}