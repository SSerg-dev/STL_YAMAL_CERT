import React from 'react';
import ReactDOM from 'react-dom';
import {LangPack} from '../Service/LangPack.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import {SuperList} from '../SharedComponents/SuperList.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import {ErrorConsole} from '../Settings/ErrorConsole.jsx';
import '../Styles/MarkaDictionaryCore.css';

export class IsoEdit extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.iso = {
            ISO_ID: null,
            ISO_Number: null,
            Marka_ID: null,
            Marka_Name: null,
            TitleObject_ID: null,
            TitleObject_Name : null,
            DesignAreaType_ID: null,
            DesignAreaType_Name: null,
            Phase_Name: null,
            Phase_ID: null,
            ProcessPhase_ID: null,
            ProcessPhase_Name: null,
            Line_ID: null,
            Line_Number: null,
            Row_status: "0"
        }
        this.lists = {
            markaOptions: new Dictionary(),
            titleObjectOptions: new Dictionary(),
            processPhaseOptions: new Dictionary(),
            designAreaTypeOptions: new Dictionary(),
            phaseOptions: new Dictionary()
        }
        this.lists.markaOptions.add(null, this.LangPack.notSelected);
        this.lists.titleObjectOptions.add(null, this.LangPack.notSelected);
        this.lists.processPhaseOptions.add(null, this.LangPack.notSelected);
        this.lists.designAreaTypeOptions.add(null, this.LangPack.notSelected);
        this.lists.phaseOptions.add(null,this.LangPack.notSelected);

        this.lists.markaOptions = Dictionary.concatenateDictionaries(this.lists.markaOptions, this.props.markaOptions);
        this.lists.titleObjectOptions = Dictionary.concatenateDictionaries(this.lists.titleObjectOptions, this.props.titleObjectOptions);
        this.lists.processPhaseOptions = Dictionary.concatenateDictionaries(this.lists.processPhaseOptions, this.props.processPhaseOptions);
        this.lists.designAreaTypeOptions = Dictionary.concatenateDictionaries(this.lists.designAreaTypeOptions, this.props.designAreaTypeOptions);
        this.lists.phaseOptions = Dictionary.concatenateDictionaries(this.lists.phaseOptions, this.props.phaseOptions);

        this.onExit = this.onExit.bind(this);
        this.getIsoById = this.getIsoById.bind(this);
        this.changeLine = this.changeLine.bind(this);
        this.changeMarka = this.changeMarka.bind(this);
        this.changePhase = this.changePhase.bind(this);
        this.changeTitleObject = this.changeTitleObject.bind(this);
        this.changeProcessPhase = this.changeProcessPhase.bind(this);
        this.changeDesignAreaType = this.changeDesignAreaType.bind(this);
        this.saveIso = this.saveIso.bind(this);
        this.deleteIso = this.deleteIso.bind(this);
        this.showDeleteResult = this.showDeleteResult.bind(this);
        this.showSaveResult = this.showSaveResult.bind(this);
        this.validate = this.validate.bind(this);
    }
    componentDidMount(){
        var params = 'isoId='+this.props.inValue; //here comes the ISO guid from the core
        if(this.props.inValue){
            this.ajaxModuleOutputRef.sendRequest(params,'/getIsoById',
            this.ajaxModuleOutputRef,this.getIsoById);
        }
        else 
        {
            this.iso.Line_Number = this.props.selectedLineNumber;
            this.forceUpdate();
        }
    }
    render(){
        var isDeleteDisabled = this.iso.ISO_ID?false:true;
        return(
            <div className='isoEdit_container'>
                <div>
                    <p>{this.LangPack.Iso}</p>
                    <SuperInput inValue={this.iso.ISO_Number} callBack={(value)=>this.iso.ISO_Number=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Line}</p>
                    <SuperInput inValue={this.iso.Line_Number} callBack={this.changeLine}/>
                </div>
                <div>
                    <p>{this.LangPack.Marka}</p>
                    <SuperList inValue={this.iso.Marka_Name} ArrayOfStrings={this.lists.markaOptions.getAllValues()} callBack={this.changeMarka}/>
                </div>
                <div>
                    <p>{this.LangPack.Title}</p>
                    <SuperList inValue={this.iso.TitleObject_Name} ArrayOfStrings={this.lists.titleObjectOptions.getAllValues()} callBack={this.changeTitleObject}/>
                </div>
                <div>
                    <p>{this.LangPack.Phase}</p>
                    <SuperList inValue={this.iso.Phase_Name} ArrayOfStrings={this.lists.phaseOptions.getAllValues()} callBack={this.changePhase}/>
                </div>
                <div>
                    <p>{this.LangPack.ProcessPhase}</p>
                    <SuperList inValue={this.iso.ProcessPhase_Name} ArrayOfStrings={this.lists.processPhaseOptions.getAllValues()} callBack={this.changeProcessPhase}/>
                </div>
                <div>
                    <p>{this.LangPack.DesignAreaType_Name}</p>
                    <SuperList inValue={this.iso.DesignAreaType_Name} ArrayOfStrings={this.lists.designAreaTypeOptions.getAllValues()} callBack={this.changeDesignAreaType}/>
                </div>
                <button className="isoEditSaveButton" onClick={this.saveIso}>{this.LangPack.Save}</button>
                <button className="isoEditSaveButton" disabled={isDeleteDisabled} onClick={this.deleteIso} style={{marginLeft:5}}>{this.LangPack.Delete}</button>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    onExit(){
        this.props.onExit(this.props.MyId);
    }
    saveIso(){
        if(this.validate()){
            this.ajaxModuleOutputRef.sendJson(this.iso,'/saveIso',
            this.ajaxModuleOutputRef,this.showSaveResult);
        }
    }
    deleteIso(){
        this.ajaxModuleOutputRef.sendJson(this.iso,'/deleteIso',
        this.ajaxModuleOutputRef,this.showDeleteResult);
    }
    showSaveResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));
            if(result.isValid) 
            {
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.SavedIso, [this.LangPack.Ok]);
                this.props.onSaved();
                ErrorConsole.writeLine(this.LangPack.SavedIso);
            }
            else document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
            
            var errors = result.resultSet;
            errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
        }
    }
    showDeleteResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));
            if(result.isValid) 
                {
                    document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedIso, [this.LangPack.Ok]);
                    this.props.onDeleted();
                    ErrorConsole.writeLine(this.LangPack.DeletedIso);
                    this.onExit();
                }
            else document.globalPopupRef.showPopup(this.LangPack.ErrorDelete, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
        
            var errors = result.resultSet;
            errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
        }
    }
    getIsoById(response){
        if(response!=null){
            this.iso = response;
            this.forceUpdate();
        }
    }
    validate(){
        if(!this.iso.Line_Number){
            document.globalPopupRef.showPopup(this.LangPack.Error,this.LangPack.LineNumberCantBeEmpty, [this.LangPack.Ok]);
            return false;
        }
        if(!this.iso.ISO_Number){
            document.globalPopupRef.showPopup(this.LangPack.Error,this.LangPack.IsoNumberCantBeEmpty, [this.LangPack.Ok]);
            return false;
        }
        return true;
    }
    //CHANGE MANAGEMENT BLOCK
    changeLine(value){
        this.iso.Line_ID = null;
        this.iso.Line_Number = value;
        //no need to update after applying this new value
    }
    changeMarka(value){
        this.iso.Marka_ID = this.props.markaOptions.keyByValue(value);
        this.iso.Marka_Name = value;
        this.forceUpdate();
    }
    changeTitleObject(value){
        this.iso.TitleObject_ID = this.props.titleObjectOptions.keyByValue(value);
        this.iso.TitleObject_Name = value;
        this.forceUpdate();
    }
    changeProcessPhase(value){
        this.iso.ProcessPhase_ID = this.props.processPhaseOptions.keyByValue(value);
        this.iso.ProcessPhase_Name = value;
        this.forceUpdate();
    }
    changeDesignAreaType(value){
        this.iso.DesignAreaType_ID = this.props.designAreaTypeOptions.keyByValue(value);
        this.iso.DesignAreaType_Name = value;
        this.forceUpdate();
    }
    changePhase(value){
        this.iso.Phase_ID = this.props.phaseOptions.keyByValue(value);
        this.iso.Phase_Name = value;
        this.forceUpdate();
    }
}