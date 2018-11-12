import React from 'react';
import ReactDOM from 'react-dom';
import {LangPack} from '../Service/LangPack.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {SuperList} from '../SharedComponents/SuperList.jsx';
import {DictionaryColorPicker} from '../SharedComponents/DictionaryColorPicker.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import {ErrorConsole} from '../Settings/ErrorConsole.jsx';
import '../Styles/MarkaDictionaryCore.css';

export class MarkaEdit extends React.Component{
    constructor(props){
        super(props);
        this.ajaxModuleOutputRef=null;
        this.colorPicker = null;

        if(this.props.inValue) this.marka = {...this.props.inValue};
        else this.marka = {
            Marka_ID:null,
            Marka_Name:null,
            Code_of_mark:null,
            Description_Eng:null,
            Description_Rus:null,
            Engineering_Drawing_Type_Eng:null,
            Engineering_Drawing_Type_Rus:null,
            IsUsedInMatrix:null,
            IsPriority:null,
            ReportColor:null,
            ReportOrder:null,
            Row_Status:0,
            newOrder:null
        };
        this.marka.newOrder = null;
        this.LangPack = new LangPack('eng');
        this.reportOrderOptions={...this.props.reportOrderOptions};

        this.showDeleteResult =  this.showDeleteResult.bind(this);
        this.changeReportOrder = this.changeReportOrder.bind(this);
        this.hideColorPicker = this.hideColorPicker.bind(this);
        this.showColorPicker = this.showColorPicker.bind(this);
        this.changePriority = this.changePriority.bind(this);
        this.checkBoolValue = this.checkBoolValue.bind(this);
        this.showSaveResult = this.showSaveResult.bind(this);
        this.changeMatrix = this.changeMatrix.bind(this);
        this.changeColor = this.changeColor.bind(this);
        this.deleteMarka = this.deleteMarka.bind(this);
        this.saveMarka = this.saveMarka.bind(this);
        this.validate = this.validate.bind(this);
        this.onExit = this.onExit.bind(this);
    }
    render(){
        var isPriority = this.marka.IsPriority===null?this.LangPack.NotSelected:(this.marka.IsPriority?this.LangPack.Yes:this.LangPack.No);
        var isUsedInMatrix = this.marka.IsUsedInMatrix===null?this.LangPack.NotSelected:(this.marka.IsUsedInMatrix?this.LangPack.Yes:this.LangPack.No);
        const boolSelectOptions = [this.LangPack.NotSelected, this.LangPack.Yes, this.LangPack.No];
        
        var reportOrderValue = null;
        if(!this.marka.newOrder){
            var reportOrderKey = this.reportOrderOptions.prevKeyByKey(this.marka.Marka_ID);
            if(reportOrderKey) reportOrderValue = this.reportOrderOptions.valueByKey(reportOrderKey);
        }
        else{
            reportOrderValue = this.reportOrderOptions.valueByKey(this.marka.newOrder);
        }
        
        
        if(this.marka.Marka_ID) this.reportOrderOptions.deleteElementByKey(this.marka.Marka_ID);
        var deleteDisabled = this.marka.Marka_ID ? false : true;

        return (
            <div className='markaEditContainer'>
                <div>
                    <p style={{marginTop:0}}>{this.LangPack.Marka}</p>
                    <SuperInput inValue={this.marka.Marka_Name} callBack={(value)=>this.marka.Marka_Name=value}/>
                </div>
                <div>
                    <p>{this.LangPack.CodeMark}</p>
                    <SuperInput inValue={this.marka.Code_of_mark} callBack={(value)=>this.marka.Code_of_mark=value}/>
                </div>
                <div>
                    <p>{this.LangPack.ReportOrderAfter}</p>
                    <SuperList inValue={reportOrderValue} ArrayOfStrings={this.reportOrderOptions.getAllValues()} callBack={this.changeReportOrder}/>
                </div>
                <div>
                    <p>{this.LangPack.Description}</p>
                    <textarea placeholder='RUS' className='markaEditTextArea' value={this.marka.Description_Rus} onChange={(event)=>{this.marka.Description_Rus=event.target.value; this.forceUpdate()}}></textarea>
                    <textarea placeholder='ENG' className='markaEditTextArea' value={this.marka.Description_Eng} onChange={(event)=>{this.marka.Description_Eng=event.target.value; this.forceUpdate()}}></textarea>
                </div>
                <div>
                    <p>{this.LangPack.DrawingType}</p>
                    <textarea placeholder='RUS' className='markaEditTextArea' value={this.marka.Engineering_Drawing_Type_Rus} onChange={(event)=>{this.marka.Engineering_Drawing_Type_Rus=event.target.value; this.forceUpdate()}}></textarea>
                    <textarea placeholder='ENG' className='markaEditTextArea' value={this.marka.Engineering_Drawing_Type_Eng} onChange={(event)=>{this.marka.Engineering_Drawing_Type_Eng=event.target.value; this.forceUpdate()}}></textarea>
                </div>
                <div>
                    <p>{this.LangPack.isPriority}</p>
                    <SuperList inValue={isPriority} ArrayOfStrings={boolSelectOptions} callBack={this.changePriority}/>
                </div>
                <div>
                    <p>{this.LangPack.isUsedInMatrix}</p>
                    <SuperList inValue={isUsedInMatrix} ArrayOfStrings={boolSelectOptions} callBack={this.changeMatrix}/>
                </div>
                <div>
                    <p>{this.LangPack.ReportColor}</p>
                    <button 
                        className= 'markaEditColorSelector'
                        key={ToolKit.shortId()}
                        style={{backgroundColor:this.marka.ReportColor}}
                        onClick={this.showColorPicker}
                    >
                    </button>
                </div>
                <button className='markaEditSaveMarka' onClick={this.saveMarka}>{this.LangPack.Save}</button>
                <button className='markaEditSaveMarka' disabled={deleteDisabled} onClick={this.deleteMarka} style={{marginLeft:5}}>{this.LangPack.Delete}</button>
                {this.colorPicker}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    validate(){
        if(!this.marka.Marka_Name) 
        {
            document.globalPopupRef.showPopup(this.LangPack.ErrorSaved, this.LangPack.EmptyMarkaName, [this.LangPack.Ok]);
            return false;            
        }
        return true;
    }
    saveMarka(){
        if(this.validate())
        {
            ErrorConsole.writeLine(this.LangPack.SavingMarka+": "+this.marka.Marka_Name+"...");
            this.ajaxModuleOutputRef.sendJson(this.marka,'/saveMarka',
            this.ajaxModuleOutputRef,this.showSaveResult);
        }
    }
    deleteMarka(){
        ErrorConsole.writeLine(this.LangPack.DeletingMarka+": "+this.marka.Marka_Name+"...");
        this.ajaxModuleOutputRef.sendJson(this.marka,'/deleteMarka',
        this.ajaxModuleOutputRef,this.showDeleteResult);
    }
    showSaveResult(response){
        console.log(response);
        if(response!=null)
        {

            var result = JSON.parse(String(response));
            
            if(result.isValid) 
            {
                ErrorConsole.writeLine(this.LangPack.SavedMarka);
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.SavedMarka, [this.LangPack.Ok]);
                this.props.onSaved();
                this.marka.Marka_ID = result.parentId;
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
                ErrorConsole.writeLine(this.LangPack.DeletedMarka);
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedMarka, [this.LangPack.Ok]);
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
    showColorPicker(){
        this.colorPicker  = 
                <DictionaryColorPicker 
                    inValue={this.marka.ReportColor}
                    callBack={this.changeColor} 
                    onExit={this.hideColorPicker}
                    colorArray = {this.props.reportColorOptions}
                />;
        this.forceUpdate();
    }
    hideColorPicker(){
        this.colorPicker = null;
        this.forceUpdate();
    }
    changeReportOrder(value){
        this.marka.newOrder = this.reportOrderOptions.keyByValue(value);
        this.forceUpdate();
    }   
    changeColor(value){
        this.marka.ReportColor = value;
        this.hideColorPicker();
    }
    changeMatrix(value){
        this.marka.IsUsedInMatrix = this.checkBoolValue(value);
    }
    changePriority(value){
        this.marka.IsPriority = this.checkBoolValue(value);
    }
    checkBoolValue(value){
        if(!value) return null;
        if(value == this.LangPack.NotSelected) return null;
        if(value == this.LangPack.Yes) return true;
        if(value == this.LangPack.No) return false;
        return null;
    }
    onExit(){
        this.props.onExit(this.props.MyId);
    }
}