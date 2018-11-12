import React from 'react';
import ReactDOM from 'react-dom';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {SuperList} from '../SharedComponents/SuperList.jsx';
import {DateInput} from '../SharedComponents/DateInput.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {LangPack} from '../Service/LangPack.js';
import '../Styles/RegisterHead.css';
import {ToolKit} from '../Service/ToolKit.js';
import {StatusBar} from './StatusBar.jsx';
import {MileStoneModel} from '../Models/MileStoneModel.js';
import createClass from 'create-react-class';
import PropTypes from 'prop-types';
import Select from 'react-select';
import 'react-select/dist/react-select.css';

/* this component requires:

-> Register_ID (inValue)
-> Function onExit

*/

export class RegisterHeadEdit extends React.Component{
    constructor(props){
        super(props);
        this.state = {nodes:null};
        this.register = {};
        this.isCreateNew = false;
        if(this.props.inValue!=null)
        this.register.Register_ID = this.props.inValue; 
        else
        {
            this.isCreateNew = true;
            this.register.Register_ID = null;
        }
        
            
        this.LangPack = new LangPack('eng');

        this.registerNumberInput = null;
        this.phaseInput = null;
        this.processPhaseInput = null;
        this.workPackageInput = null;
        this.ajaxModuleOutputRef = null;

        this.lists = {
            markaList: new Dictionary(),
            titleList: new Dictionary(),
            phaseList: new Dictionary(),
            workPackageList: new Dictionary(),
            processPhaseList: new Dictionary()
        }
        this.titleOptions = [];
        this.markaOptions = [];
        this.phaseOptions = [];
        this.workPackageOptions = [];
        this.processPhaseOptions = [];
        this.lists.markaList.add(null, this.LangPack.Loading);
        this.lists.titleList.add(null, this.LangPack.Loading);
        this.lists.phaseList.add(null, this.LangPack.Loading);
        this.lists.workPackageList.add(null, this.LangPack.Loading);
        this.lists.processPhaseList.add(null, this.LangPack.Loading);


        this.titleCheckDrop = null;
        
        //binding functions
        this.getRegister = this.getRegister.bind(this);
        this.editMarka = this.editMarka.bind(this);
        this.editTitle = this.editTitle.bind(this);
        this.editPhase = this.editPhase.bind(this);
        this.editProcessPhase = this.editProcessPhase.bind(this);
        this.editStatus = this.editStatus.bind(this);
        this.editRegisterNumber = this.editRegisterNumber.bind(this);
        this.editCntDate = this.editCntDate.bind(this);
        this.getMarkaList = this.getMarkaList.bind(this);
        this.getTitleList = this.getTitleList.bind(this);
        this.getPhaseList = this.getPhaseList.bind(this);
        this.getProcessPhaseList = this.getProcessPhaseList.bind(this);
        this.getWorkPackageList = this.getWorkPackageList.bind(this);
        this.editWorkPackage = this.editWorkPackage.bind(this);
        this.deleteRegister = this.deleteRegister.bind(this);
        this.saveRegister = this.saveRegister.bind(this);
        this.showDeleteResult = this.showDeleteResult.bind(this);
        this.showSaveResult = this.showSaveResult.bind(this);
        this.showCUDResult = this.showCUDResult.bind(this);
        this.clearPopup = this.clearPopup.bind(this);
        this.getNewRegisterNumber = this.getNewRegisterNumber.bind(this);
    }
    componentDidMount(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getMarkaList',
        this.ajaxModuleOutputRef,this.getMarkaList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectList',
        this.ajaxModuleOutputRef,this.getTitleList);

        if(this.register.Register_ID!=null)
        {
            var param = 'Register_ID='+this.register.Register_ID;
            this.ajaxModuleOutputRef.sendRequest(param,'/getRegisterByRegisterId',
            this.ajaxModuleOutputRef,this.getRegister);
        }
        if (this.isCreateNew)
        this.ajaxModuleOutputRef.sendRequest(null,'/GetNewRegisterNumber',
        this.ajaxModuleOutputRef,this.getNewRegisterNumber);
            
        this.ajaxModuleOutputRef.sendRequest(null,'/getPhaseList',
        this.ajaxModuleOutputRef,this.getPhaseList);

        this.ajaxModuleOutputRef.sendRequest(null,'/GetProcessPhaseList',
        this.ajaxModuleOutputRef,this.getProcessPhaseList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getWorkPackageList',
        this.ajaxModuleOutputRef,this.getWorkPackageList);
    }
    componentWillReceiveProps(){
        /*
        console.log("Received props: "+this.props.inValue);
        this.register.Register_ID = this.props.inValue;   
        var param = 'Register_ID='+this.register.Register_ID;
        this.ajaxModuleOutputRef.sendRequest(param,'/getRegisterByRegisterId',
        this.ajaxModuleOutputRef,this.getRegister);  
        */
    }
    /*<StatusBar inValue={this.register.Register_ID} callBack={this.editStatus}/>*/
    render(){
        return(
            <div className='registerHead'>
                <div className='registerHeadContainer'>
                
                    <div className="rh_title">
                        <div>
                            <div className='rhc_titles' style={{marginBottom:10}}><p>{this.LangPack.WorkPackage}</p><SuperList MyId={'workpackageID'} ArrayOfStrings={this.lists.workPackageList.getAllValues()} inValue={this.register.WorkPackage_Name} callBack={this.editWorkPackage}/></div>
                            <div className='rhc_titles'><p>{this.LangPack.Register_Number}</p><SuperInput ref={(input)=>{this.registerNumberInput=input}} inValue={this.register.Register_Number} callBack={this.editRegisterNumber}/></div>
                            <div className='rhc_titles'><p>{this.LangPack.Title}</p>
                                <div className='rhc_titleobject'>
                                    <Select
                                        closeOnSelect={true}
                                        disabled={false}
                                        onChange={this.editTitle}
                                        options={this.titleOptions}
                                        placeholder="Выбрать Титул"
                                        removeSelected={true}
                                        rtl={false}
                                        value={this.register.TitleObject_ID}
                                        multi={true}
                                    />
                                </div>
                            </div>
                            <div className='rhc_titles' style={{marginBottom:10}}><p style={{position:'relative',top:12}}>{this.LangPack.ProcessPhase}</p>
                                <SuperList MyId={'processPhaseID'} ArrayOfStrings={this.lists.processPhaseList.getAllValues()} inValue={this.register.ProcessPhase_Name} callBack={this.editProcessPhase}/>
                            </div>
                            <div className='rhc_titles' style={{marginBottom:5}}><p>{this.LangPack.Phase}</p>
                                <div className='rhc_phase'>
                                    <Select
                                        closeOnSelect={true}
                                        disabled={false}
                                        onChange={this.editPhase}
                                        options={this.phaseOptions}
                                        placeholder="авто"
                                        removeSelected={true}
                                        rtl={false}
                                        value={this.register.Phase_ID}
                                        multi={true}
                                        disabled={false}
                                    />
                                </div>
                            </div>
                            <div className='rhc_titles'><p>{this.LangPack.Marka}</p>
                                <div className='rhc_marka'>
                                    <Select
                                        closeOnSelect={true}
                                        disabled={false}
                                        onChange={this.editMarka}
                                        options={this.markaOptions}
                                        placeholder="Выбрать Марку"
                                        removeSelected={true}
                                        rtl={false}
                                        value={this.register.Marka_ID}
                                        multi={true}
                                    />
                                </div>
                            </div>
                            <div className='rhc_titles' style={{display:'block', marginTop:20}}><p>{this.LangPack.CNT_Date}</p><DateInput inValue={this.register.CNT_Date_UINormalized} callBack={(value)=>this.register.CNT_Date_UINormalized=value}/></div>
                            <div className='rhc_titles' style={{marginBottom:20}}><p>{this.LangPack.CTR_RESP}</p><SuperInput inValue={this.register.CTR_RESP} callBack={(value)=>this.register.CTR_RESP=value}/></div>
                            <div className='rhc_titles'><p className='rhc_sctr_Resp'>{this.LangPack.SCTR_RESP}</p><SuperInput inValue={this.register.SCTR_RESP} callBack={(value)=>this.register.SCTR_RESP=value}/></div>
                            <div className='rhc_titles' style={{width:'100%'}}><p>{this.LangPack.WorkDesc}</p><SuperInput className='rhc_workdesc_input' inValue={this.register.Work_Desc} callBack={(value)=>this.register.Work_Desc=value}/></div>
                        </div>  
                    </div>
                    <button className='rhc_button_delete' onClick={this.deleteRegister}>{this.LangPack.Delete}</button>
                    <button className='rhc_button_save' onClick={this.saveRegister}>{this.LangPack.Save}</button>
                </div>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>     
                {this.state.nodes}           
            </div>
        );
    }
    deleteRegister(){
        /*
        this.ajaxModuleOutputRef.sendJson(this.register,'/DeleteRegister',
        this.ajaxModuleOutputRef,this.showDeleteResult);
        */
    }
    showDeleteResult(response){

    }
    showCUDResult(input){
    }
    clearPopup(){
        this.setState({nodes: (<div></div>)});
    }
    saveRegister(){
        if (this.register.TitleObject_ID)
        this.register.TitleObject_ID_Concatenated = this.register.TitleObject_ID.join('/');
        
        if (this.register.Marka_ID)
        this.register.Marka_ID_Concatenated = this.register.Marka_ID.join('/');

        if (this.register.Phase_ID)
        this.register.Phase_ID_Concatenated = this.register.Phase_ID.join('/');

        /*
        this.ajaxModuleOutputRef.sendJson(this.register,'/SaveRegister',
        this.ajaxModuleOutputRef,this.showSaveResult);
        */
    }
    showSaveResult(response){
        if(response!=null){
            if(response.Error_ID=="0") 
            {
                this.showCUDResult({head: this.LangPack.Success, message: this.LangPack.SavedRegister});
                var param = 'Register_ID='+response.Entity_ID;
                this.ajaxModuleOutputRef.sendRequest(param,'/getRegisterByRegisterId',
                this.ajaxModuleOutputRef,this.getRegister);
            }
            else this.showCUDResult({head: this.LangPack.ErrorSaved, message: response.Error_Message});
        }
    }
    editRegisterNumber(value){
        this.registerNumberInput.setState({value:this.register.Register_Number});
    }
    editMarka(value){
        this.register.Marka_ID = value.map((val)=>{return val.value});
        this.forceUpdate();
    }
    editStatus(value){
        this.register.ABDStatus_ID=value;
    }
    editTitle(value){
        this.register.TitleObject_ID = value.map((val)=>{return val.value});
        
        this.register.Phase_ID = [];
        this.register.Phase_Name = [];
        if(value && value.length>0){
            value.map(
                (val)=>
                {
                    ToolKit.pushInsideOriginal(this.register.Phase_ID,this.lists.phaseList.keyByIndex(this.lists.titleList.indexByKey(val.value)));
                    ToolKit.pushInsideOriginal(this.register.Phase_Name,this.lists.phaseList.valueByIndex(this.lists.titleList.indexByKey(val.value)));
                }
            );
        }
        else{
            this.register.Phase_ID = [];
            this.register.Phase_Name = [];
        }
        this.forceUpdate();
    }
    editCntDate(value){
        this.register.CNT_Date = value;
    }
    editPhase(value){
        
    }
    editProcessPhase(value){
        this.register.ProcessPhase_Name=value;
        this.register.ProcessPhase_ID = this.lists.processPhaseList.keyByValue(value);
    }
    editWorkPackage(value){
        this.register.WorkPackage_Name=value;
        this.register.WorkPackage_ID = this.lists.workPackageList.keyByValue(value);
    }
    getMarkaList(response){
        if(response!=null && response.length>0){
            this.lists.markaList.clear();
            response.map((marka)=>{this.lists.markaList.add(marka.Marka_ID, marka.Marka_Name)});
        }
        for(var i=0; i<response.length; i++){
            this.markaOptions.push({label: response[i].Marka_Name, value: response[i].Marka_ID});
        }
        this.forceUpdate();
    }
    getTitleList(response){
        if(response!=null && response.length>0){

            this.lists.titleList.clear();

            this.lists.phaseList.clear();

            response.map((ent)=>{
                this.lists.titleList.add(ent.TitleObject_ID, ent.TitleObject_Name);
                this.lists.phaseList.add(ent.Phase_ID, ent.Phase_Name);
            });
        }
        for(var i=0; i<response.length; i++) {
            this.titleOptions.push({label: response[i].TitleObject_Name, value: response[i].TitleObject_ID});
        }
        this.forceUpdate();
    }
    getRegister(response){
        if(response!=null)
        {
            this.register = response;
            this.register.Marka_ID= this.register.Marka_ID_Concatenated.split("/");
            this.register.TitleObject_ID=this.register.TitleObject_ID_Concatenated.split("/");
        }
        this.forceUpdate();
    }
    getNewRegisterNumber(response){
        if (response)
        {
            this.register.Register_Number = response;
        }
        else
        {
            this.showCUDResult("Не удалось сгенерировать номер реестра!");
        }
        this.forceUpdate();
    }
    getPhaseList(response){
        if(response!=null && response.length>0){
        }
        for(var i=0; i<response.length; i++) {
            this.phaseOptions.push({label: response[i].Phase_Name, value: response[i].Phase_ID});
        }
        this.forceUpdate();
    }
    getProcessPhaseList(response){
        if(response!=null && response.length>0)
        {
            this.lists.processPhaseList.clear();
            this.lists.processPhaseList.add(null, this.LangPack.NotSelected);
            for(var i=0; i<response.length; i++) {
                this.lists.processPhaseList.add(response[i].ProcessPhase_ID, response[i].ProcessPhase_Name);
            }
            this.forceUpdate();
        }
    }
    getWorkPackageList(response){
        if(response!=null && response.length>0)
        {
            this.lists.workPackageList.clear();
            this.lists.workPackageList.add(null, this.LangPack.NotSelected);
            for(var i=0; i<response.length; i++) {
                this.lists.workPackageList.add(response[i].WorkPackage_ID, response[i].WorkPackage_Name);
            }
            this.forceUpdate();
        }
    }
}