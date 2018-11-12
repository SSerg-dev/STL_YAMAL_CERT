import React from 'react';
import ReactDOM from 'react-dom';
import {FileLoader} from './FileLoader.jsx';
import {FileBar} from './FileBar.jsx';
import {LangPack} from '../Service/LangPack.js';
import Select from 'react-select';
import { SuperInput } from '../SharedComponents/SuperInput.jsx';
//import { DateInput } from '../SharedComponents/DateInput.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {ToolKit} from '../Service/ToolKit.js';
import {ErrorConsole} from '../Settings/ErrorConsole.jsx';
import {AsyncSelect} from '../SharedComponents/AsyncSelect.jsx';
import 'react-select/dist/react-select.css';
import '../Styles/ABDDocumentStyle.css';

export class DocumentEdit extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.ajaxModuleOutputRef

        this.document = {
            ABDDocument_ID:this.props.inValue,
            ABDDocument_Number:null,
            ABDDocument_Name:null,
            Total_Sheets:null,
            PID_ID_concatenated:null,
            PID_Code_concatenated:null,
            GOST_ID_concatenated:null,
            GOST_Code_concatenated:null,
            files: []
        };
        this.isFileBarUpdatedId = ToolKit.shortId();
        this.fileLoaderKey = ToolKit.shortId();
        //binding functions
        this.getDocument = this.getDocument.bind(this);
        this.changeFiles = this.changeFiles.bind(this);
        this.showSaveResult  = this.showSaveResult.bind(this);
        this.save = this.save.bind(this);
        this.onSaved = this.onSaved.bind(this);
        this.delete = this.delete.bind(this);
        this.cancel = this.cancel.bind(this);
        this.changeName = this.changeName.bind(this);
        this.sendRequestForDocument = this.sendRequestForDocument.bind(this);
        this.changePid = this.changePid.bind(this);
        this.changeGost = this.changeGost.bind(this);
    }
    componentDidMount(){
        this.sendRequestForDocument();
    }
    render(){
        var isDisabled = this.props.isDisabled;
        var isDeleteDisabled = (isDisabled || this.document.ABDDocument_ID==null) ? true : false;

        return  (
            <div className='document_editContainer'>
                <div className='document_leftColumn'>
                    <div className='document_editHead'>
                        <div>
                            <p>{this.LangPack.DocumentNumber}</p>
                            <SuperInput style={{width:257}} disabled={isDisabled} inValue={this.document.ABDDocument_Number} callBack={(value)=>this.document.ABDDocument_Number=value}/>
                        </div>
                        <div>
                            <p>{this.LangPack.ABDDocumentName}</p>
                            <textarea className='document_editTextArea' disabled={isDisabled} value={this.document.ABDDocument_Name} onChange={this.changeName} />
                        </div>
                        <div>
                            <p>{this.LangPack.PagesNumber}</p>
                            <SuperInput style={{width:105}} disabled={isDisabled} inValue={this.document.Total_Sheets} callBack={(value)=>this.document.Total_Sheets=value}/>
                        </div>
                        <div>
                            <p className='document_editHeadGostLabel'>{this.LangPack.GOST}</p>
                            <AsyncSelect
                                inValue = {[this.document.GOST_ID_concatenated, this.document.GOST_Code_concatenated]}
                                idCol={'GOST_ID'}
                                nameCol={'GOST_Code'}
                                url = {'/SearchGost'}
                                callBack = {this.changeGost}
                                disabled = {isDisabled}
                                style={{width:300, marginLeft:10, marginTop:14}}
                            />
                        </div>
                        <div>
                            <p className='document_editHeadPidLabel'>{this.LangPack.PID}</p>
                            <AsyncSelect
                                inValue = {[this.document.PID_ID_concatenated, this.document.PID_Code_concatenated]}
                                idCol={'PID_ID'}
                                nameCol={'PID_Code'}
                                url = {'/SearchPid'}
                                callBack = {this.changePid}
                                disabled = {isDisabled}
                                style={{width:300, marginLeft:10, marginTop:14}}
                            />
                        </div>
                    </div>
                    <div className='document_editButtons'>
                        <button className='document_editSave' onClick = {this.save} disabled={isDisabled}>{this.LangPack.Save}</button>
                        <button className='document_editDelete' onClick={this.delete} disabled={isDeleteDisabled}>{this.LangPack.Delete}</button>
                        <button className='document_editCancel' onClick = {this.cancel} >{this.LangPack.Cancel}</button>
                    </div>
                </div>
                <div className='document_rightColumn'>
                    <FileBar inValue = {this.document.files} isDisabled={isDisabled} key={this.isFileBarUpdatedId} callBack={this.changeFiles}/>
                    <FileLoader isDisabled = {isDisabled} key={this.fileLoaderKey}/>
                </div>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    changePid(value){
        this.document.PID_ID_concatenated = value;
    }
    changeGost(value){
        this.document.GOST_ID_concatenated = value;
    }
    changeName(x){
        this.document.ABDDocument_Name = x.target.value;
        this.forceUpdate();
    }
    sendRequestForDocument(){
        if(this.document.ABDDocument_ID!=null)
        this.ajaxModuleOutputRef.sendRequest("documentId="+this.document.ABDDocument_ID,'/GetABDDocumentById',
        this.ajaxModuleOutputRef,this.getDocument);
    }
    save() {
        //isDisabled = true;
        //this.forceUpdate();
        this.ajaxModuleOutputRef.sendJson(this.document,'/SaveABDDocument',
        this.ajaxModuleOutputRef,this.showSaveResult);
    }
    delete(){
        this.ajaxModuleOutputRef.sendJson(this.document,'/DeleteABDDocument',
        this.ajaxModuleOutputRef,this.showSaveResult);
    }
    onSaved(){
        this.sendRequestForDocument();
        this.props.onSaved();
    }
    cancel(){
        if(!this.props.isDisabled){
            document.globalPopupRef.showPopup(
                this.LangPack.Warning, 
                this.LangPack.SureQuitDocument, 
                [this.LangPack.Ok, this.LangPack.Cancel],
                [this.props.onExit, ()=>{}]
            );
        }
        else this.props.onExit();
    }
    showSaveResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));
            
            if(result.isValid) 
            {
                ErrorConsole.writeLine(this.LangPack.SavedABDDocument);
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.SavedABDDocument, [this.LangPack.Ok]);
                this.onSaved();
                this.document.ABDDocument_ID = result.parentId;
            }
            else 
            {
                var errors = result.resultSet;
                errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
                document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
            }
        }
    }
    showDeleteResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));

            if(result.isValid)
            {
                ErrorConsole.writeLine(this.LangPack.DeletedABDDocument);
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedABDDocument, [this.LangPack.Ok]);
                this.props.onDeleted(this.props.MyId);
            }
            else 
            {
                document.globalPopupRef.showPopup(this.LangPack.ErrorDelete, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
                var errors = result.resultSet;
                errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
            }
        }

    }
    changeFiles(files){
        this.document.files = files;
    }
    getDocument(response){
        console.log(response);
        if(response!=null) {
            this.document = response;
        }
        this.isFileBarUpdatedId = ToolKit.shortId();
        this.fileLoaderKey = ToolKit.shortId();
        this.forceUpdate();
    }
}