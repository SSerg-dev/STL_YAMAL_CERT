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
import '../Styles/LineIso.css';

export class LineEdit extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.line = {
            Line_ID:null,
            Line_Number:null,
            Row_Status:"0",
            Location_From:null,
            Location_To:null,
            Fluid_Name_Eng:null,
            Fluid_Name_Rus:null,
            Fluid_Danger_Code_By_Gost:null,
            Fluid_Fire_Aand_Explosive_Hazard:null,
            Fluid_Group_By_TP_TC_032_2013:null,
            Fluid_Group_By_GOST:null,
            Pipeline_Category_By_GOST:null,
            Piprline_Category_By_TP_TC_032_2013:null
        };

        this.saveLine = this.saveLine.bind(this);
        this.deleteLine = this.deleteLine.bind(this);
        this.validate = this.validate.bind(this);
        this.onExit = this.onExit.bind(this);
        this.getLineById = this.getLineById.bind(this);
        this.showDeleteResult = this.showDeleteResult.bind(this);
        this.showSaveResult = this.showSaveResult.bind(this);
    }
    componentDidMount(){
        var params = 'lineId='+this.props.inValue; //here comes the ISO guid from the core
        this.ajaxModuleOutputRef.sendRequest(params,'/getLineById',
        this.ajaxModuleOutputRef,this.getLineById);
    }
    render(){
        var isDeleteDisabled = this.line.Line_ID?false:true;
        return(
            <div className='lineEdit_Container'>
                <div>
                    <p>{this.LangPack.LineNumber}</p>
                    <SuperInput inValue={this.line.Line_Number} callBack={(value)=>this.line.Line_Number=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Location_From}</p>
                    <SuperInput inValue={this.line.Location_From} callBack={(value)=>this.line.Location_From=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Location_To}</p>
                    <SuperInput inValue={this.line.Location_To} callBack={(value)=>this.line.Location_To=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Fluid_Name_Rus}</p>
                    <SuperInput inValue={this.line.Fluid_Name_Rus} callBack={(value)=>this.line.Fluid_Name_Rus=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Fluid_Name_Eng}</p>
                    <SuperInput inValue={this.line.Fluid_Name_Eng} callBack={(value)=>this.line.Fluid_Name_Eng=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Fluid_Danger_Code_By_Gost}</p>
                    <SuperInput inValue={this.line.Fluid_Danger_Code_By_Gost} callBack={(value)=>this.line.Fluid_Danger_Code_By_Gost=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Fluid_Fire_Aand_Explosive_Hazard}</p>
                    <SuperInput inValue={this.line.Fluid_Fire_Aand_Explosive_Hazard} callBack={(value)=>this.line.Fluid_Fire_Aand_Explosive_Hazard=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Fluid_Group_By_TP_TC_032_2013}</p>
                    <SuperInput inValue={this.line.Fluid_Group_By_TP_TC_032_2013} callBack={(value)=>this.line.Fluid_Group_By_TP_TC_032_2013=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Fluid_Group_By_GOST_32569_2013}</p>
                    <SuperInput inValue={this.line.Fluid_Group_By_GOST} callBack={(value)=>this.line.Fluid_Group_By_GOST=value}/>
                </div>
                <div>
                    <p>{this.LangPack.Pipeline_Category_By_GOST_32569_2013}</p>
                    <SuperInput inValue={this.line.Pipeline_Category_By_GOST} callBack={(value)=>this.line.Pipeline_Category_By_GOST=value}/>
                </div> 
                <div>
                    <p>{this.LangPack.Pipeline_Category_By_TP_TC_032_2013}</p>
                    <SuperInput inValue={this.line.Piprline_Category_By_TP_TC_032_2013} callBack={(value)=>this.line.Piprline_Category_By_TP_TC_032_2013=value}/>
                </div>
                <button className="isoEditSaveButton" onClick={this.saveLine}>{this.LangPack.Save}</button>
                <button className="isoEditSaveButton" disabled={isDeleteDisabled} onClick={this.deleteLine} style={{marginLeft:5}}>{this.LangPack.Delete}</button>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    saveLine(){
        if(this.validate()){
            this.ajaxModuleOutputRef.sendJson(this.line,'/saveLine',
            this.ajaxModuleOutputRef,this.showSaveResult);
        }
    }
    deleteLine(){
        this.ajaxModuleOutputRef.sendJson(this.line,'/deleteLine',
        this.ajaxModuleOutputRef,this.showDeleteResult);
    }
    showSaveResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));
            if(result.isValid) 
            {
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.SavedLine, [this.LangPack.Ok]);
                this.props.onSaved();
                ErrorConsole.writeLine(this.LangPack.SavedLine);
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
                    document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedLine, [this.LangPack.Ok]);
                    this.props.onDeleted();
                    ErrorConsole.WriteLine(this.LangPack.DeletedLine);
                    this.onExit();
                }
            else document.globalPopupRef.showPopup(this.LangPack.ErrorDelete, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
        
            var errors = result.resultSet;
            errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
        }
    }
    onExit(){
        this.props.onExit(this.props.MyId);
    }
    getLineById(response){
        if(response!=null){
            this.line = response;
            this.forceUpdate();
        }
    }
    validate(){
        if(!this.line.Line_Number){
            document.globalPopupRef.showPopup(this.LangPack.Error,this.LangPack.LineNumberCantBeEmpty, [this.LangPack.Ok]);
            return false;
        }
        return true;
    }
}