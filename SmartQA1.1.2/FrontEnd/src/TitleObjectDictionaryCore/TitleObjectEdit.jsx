import React from 'react';
import ReactDOM from 'react-dom';
import {LangPack} from '../Service/LangPack.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {SuperList} from '../SharedComponents/SuperList.jsx';
import {DictionaryColorPicker} from '../SharedComponents/DictionaryColorPicker.jsx';
import {ErrorConsole} from '../Settings/ErrorConsole.jsx';
import {Tree} from '../Models/Tree.js';

import {ToolKit} from '../Service/ToolKit.js';
import '../Styles/TitleObjectDictionaryStyle.css';

export class TitleObjectEdit extends React.Component{
    constructor(props){
        super(props);
        this.state = {nodes:null};
        this.ajaxModuleOutputRef=null;
        this.colorPicker = null;
        this.LangPack = new LangPack('eng');
        this.ajaxModuleOutputRef=null;

        var obj ={};
        if(this.props.inValue) this.title = {...this.props.inValue};
        else this.title = {
            TitleObject_ID:'00000000-0000-0000-0000-000000000000',
            TitleObject_Name:null,
            TitleObject_PARENTID:null,
            TitleObject_for_ABDFinalSet:null,
            newOrder:null,
            Description_Rus:null,
            Description_Eng:null,
            Phase_Name: null,
            ReportColor:null,
            ReportOrder:null,
            Structure:null,
            StageOfConstr:null,
            Row_Status:null
        }

        //binding functions:
        this.saveTitleObject = this.saveTitleObject.bind(this);
        this.deleteTitleObject = this.deleteTitleObject.bind(this);
        this.validate = this.validate.bind(this);
        this.showColorPicker = this.showColorPicker.bind(this);
        this.hideColorPicker = this.hideColorPicker.bind(this);
        this.changeColor = this.changeColor.bind(this);
        this.changePhase = this.changePhase.bind(this);
        this.changeReportOrder = this.changeReportOrder.bind(this);
        this.changeParentObject = this.changeParentObject.bind(this);
        this.clearPopup = this.clearPopup.bind(this);
        this.showSaveResult = this.showSaveResult.bind(this);
        this.showDeleteResult = this.showDeleteResult.bind(this);
        this.onExit = this.onExit.bind(this);
        this.getTitleObjectFromDb = this.getTitleObjectFromDb.bind(this);

        //creating all the necessary dictionaries:
        this.nodeDictionary = this.props.reportOrderOptions.flatten();
        this.nodeDictionary.add('00000000-0000-0000-0000-000000000000'.toLowerCase(), this.LangPack.First);
        
        this._parentOptions = this.props.reportOrderOptions.findAllParents();
        //now we've got to place the root before other nodes:
        this.parentOptions = new Dictionary();
        this.parentOptions.add(null, this.LangPack.NotSelected);
        for(var i = 0; i<this._parentOptions.values.length-1; i++)
        if(this._parentOptions.values[i][1]!='N/A') //escape from N/A titleObject
        this.parentOptions.add(this._parentOptions.values[i][0], this._parentOptions.values[i][1]);
    }
    render(){
        if(!this.title.newOrder){
            //applying new value if nothing is specified
            var prevNode = this.props.reportOrderOptions.prevNode(this.title.TitleObject_ID.toLowerCase());
            if(!prevNode) 
            {
                if(this.title.TitleObject_ID!='00000000-0000-0000-0000-000000000000') this.title.newOrder = '00000000-0000-0000-0000-000000000000'.toLowerCase();
            }
            else this.title.newOrder = prevNode.node_Id;
        }
        var reportOrder = this.nodeDictionary.valueByKey(this.title.newOrder);
        var parentId = this.nodeDictionary.valueByKey(this.title.TitleObject_PARENTID);
        
        var parent = this.title.TitleObject_PARENTID;

        //checking if the parent object was changed and so the color of the Title will change
        if(parent){
            parent = this.props.reportColorOptions.findNode(parent);
            this.title.ReportColor = parent.value;
        }
        var parent = this.props.reportOrderOptions.findNode(this.title.TitleObject_PARENTID);

        //forming up ReportOrder options that will be shown to the user:
        var reportOrderOptions = new Dictionary();
        reportOrderOptions.add(null, this.LangPack.NotSelected);
        reportOrderOptions.add('00000000-0000-0000-0000-000000000000'.toLowerCase(), this.LangPack.First);
        if(parent)
        {
            if(parent.child.length>0) parent.child.forEach((child)=>
                {
                    //escape from N/A titleObject:
                    if(child.value!='N/A') reportOrderOptions.add(child.node_Id, child.value);
                }
            );
        }
        else this.props.reportOrderOptions.root.child.forEach((child)=>
                {
                    //escape from N/A titleObject:
                    if(child.value!='N/A') reportOrderOptions.add(child.node_Id, child.value)
                }
            );
        
        //deleting this element from report order options
        if(this.title.TitleObject_ID!='00000000-0000-0000-0000-000000000000') reportOrderOptions.deleteElementByKey(this.title.TitleObject_ID);

        //checked if this titleObject is brand new:
        var deleteDisabled = (this.title.TitleObject_ID=='00000000-0000-0000-0000-000000000000');

        return (
            <div className='titleEditContainer'>
                <div>
                    <p>{this.LangPack.Title}</p>
                    <SuperInput inValue={this.title.TitleObject_Name} callBack={(value)=>this.title.TitleObject_Name=value}/>
                </div>
                <div>
                    <p>{this.LangPack.ParentObject}</p>
                    <SuperList inValue={parentId} ArrayOfStrings={this.parentOptions.getAllValues()} callBack={this.changeParentObject}/>
                </div> 
                <div>
                    <p>{this.LangPack.ReportOrderAfter}</p>
                    <SuperList inValue={reportOrder} ArrayOfStrings={reportOrderOptions.getAllValues()} callBack={this.changeReportOrder}/>
                </div>
                <div>
                    <p>{this.LangPack.Description}</p>
                    <textarea placeholder='RUS' className='titleEditTextArea' value={this.title.Description_Rus} onChange={(event)=>{this.title.Description_Rus=event.target.value; this.forceUpdate()}}></textarea>
                    <textarea placeholder='ENG' className='titleEditTextArea' value={this.title.Description_Eng} onChange={(event)=>{this.title.Description_Eng=event.target.value; this.forceUpdate()}}></textarea>
                </div>
                <div>
                    <p>{this.LangPack.ReportColor}</p>
                    <button 
                        className= 'titleObjectColorSelector'
                        key={ToolKit.shortId()}
                        style={{backgroundColor:this.title.ReportColor}}
                        onClick={this.showColorPicker}
                    ></button>
                </div>
                <div>
                    <p>{this.LangPack.Phase}</p>
                    <SuperList inValue={this.title.Phase_Name} ArrayOfStrings={this.props.phaseOptions.getAllValues()} callBack={this.changePhase}/>
                </div>
                <div>
                    <p>{this.LangPack.TitleObject_for_ABDFinalSet}</p>
                    <SuperInput inValue={this.title.TitleObject_for_ABDFinalSet} callBack={(value)=>this.title.TitleObject_for_ABDFinalSet=value}/>
                </div>
                <button className='titleEditSave' onClick={this.saveTitleObject}>{this.LangPack.Save}</button>
                <button className='titleEditSave' disabled={deleteDisabled} onClick={this.deleteTitleObject} style={{marginLeft:5}}>{this.LangPack.Delete}</button>
                {this.colorPicker}
                {this.state.nodes}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    showSaveResult(response){
        if(response!=null)
        {
            var result = JSON.parse(String(response));
            if(result.isValid) 
            {
                ErrorConsole.writeLine(this.LangPack.SavedTitleObject);
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.SavedTitleObject, [this.LangPack.Ok]);
                if(response.Entity_ID) this.title.TitleObject_ID = result.parentId;
                this.props.onSaved();
            }
            else 
            {
                var errors = response.resultSet;
                errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
                document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
            }
        }
        this.props.callBack();
    }
    showDeleteResult(response){
        if(response!=null)
        {
            var result = JSON.parse(String(response));
            if(response.isValid)
            {
                ErrorConsole.writeLine(this.LangPack.DeletedTitleObject);
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedTitleObject, [this.LangPack.Ok]);
                this.props.onDeleted();
            }
            else 
            {
                ErrorConsole.writeLine(this.LangPack.ErrorDelete);
                document.globalPopupRef.showPopup(this.LangPack.ErrorDelete, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
            }
        }
    }
    saveTitleObject(){
        if(this.validate())
        {
            ErrorConsole.writeLine(this.LangPack.SavingTitleObject+": "+this.title.TitleObject_Name+"...");
            this.ajaxModuleOutputRef.sendJson(this.title,'/saveTitleObject',
            this.ajaxModuleOutputRef,this.showSaveResult);
        }
    }
    deleteTitleObject(){
        ErrorConsole.writeLine(this.LangPack.DeletingTitleObject+": "+this.title.TitleObject_Name+"...");
        this.ajaxModuleOutputRef.sendJson(this.title,'/deleteTitleObject',
        this.ajaxModuleOutputRef,this.showDeleteResult);
    }
    validate(){
        if(!this.title.TitleObject_Name) 
        {
            document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.EmptyTitleObjecName, [this.LangPack.Ok]);
            return false;            
        }
        var re2 = /^[A-Z0-9.]+$/;
        if(!re2.test(this.title.TitleObject_Name))
        {
            document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.OnlyLatinSymbolsAndNumbersAreAllowedInTitleName, [this.LangPack.Ok]);
            return false;
        }
        if(!this.title.ReportColor)
        {
            document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.ReportColorRequired, [this.LangPack.Ok]);
            return false;
        }
        if(!this.title.Phase_Name)
        {
            document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.PhaseRequired, [this.LangPack.Ok]);
            return false;
        }
        return true;
    }
    changeParentObject(value){
        var newValue = this.nodeDictionary.keyByValue(value);
        if(this.title.TitleObject_PARENTID!=newValue){
            //check if this element has child elements:
            if(this.title.TitleObject_ID!='00000000-0000-0000-0000-000000000000'){
                var node = this.props.reportOrderOptions.findNode(this.title.TitleObject_ID);
                if(node) {
                    if(node.child.length>0) {
                        ErrorConsole.writeLine(this.LangPack.CantChangeParent);
                        document.globalPopupRef.showPopup(this.LangPack.Error, this.LangPack.CantChangeParent, [this.LangPack.Ok]);
                    }
                    else{
                        this.title.TitleObject_PARENTID = newValue;
                        this.title.ReportOrder = null;
                    }
                }
            }
            else this.title.TitleObject_PARENTID = newValue;
        }
        this.forceUpdate();
    }
    changeReportOrder(value){
        this.title.newOrder = this.nodeDictionary.keyByValue(value);
    }
    changePhase(value){
        this.title.Phase_Name = value;

    }
    showColorPicker(){
        //assumed that the right value is already applied in the Core:
        var canChangeColor = !(this.title.TitleObject_PARENTID);
        if(canChangeColor)
        {
            this.colorPicker  = 
                <DictionaryColorPicker 
                    inValue={this.title.ReportColor}
                    callBack={this.changeColor} 
                    onExit={this.hideColorPicker}
                    colorArray = {this.props.colorOptions}
                />;
            this.forceUpdate();
        }
        else {
            ErrorConsole.writeLine(this.LangPack.CantChangeColorParent);
            document.globalPopupRef.showPopup(this.LangPack.Error, this.LangPack.CantChangeColorParent, [this.LangPack.Ok]);
        }
    }
    hideColorPicker(){
        this.colorPicker = null;
        this.forceUpdate();
    }
    changeColor(value){
        console.log(value);
        this.title.ReportColor = value;
        this.hideColorPicker();
    }
    onExit(){
        this.props.onExit(this.props.MyId);
    }
    clearPopup(){
        this.setState({nodes: (<div></div>)});
    }
    getTitleObjectFromDb(response){
        if(response){
            console.log(response);
            this.title = response;
            this.forceUpdate();
        }
    }

}