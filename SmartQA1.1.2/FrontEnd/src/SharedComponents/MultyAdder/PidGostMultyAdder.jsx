import React from 'react';
import {SuperAbstractMultyAdder} from './SuperAbstractMultyAdder.jsx';
import {ErrorInput} from '../InputWithErrors/ErrorInput.jsx';
import {Dictionary} from '../../Models/Dictionary';

export class PidGostMultyAdder extends SuperAbstractMultyAdder{
    constructor(props){
        super(props);

        this.pidInputValue = null;
        this.gostInputValue = null;
    
        this.pidDictionary = new Dictionary();
        this.gostDictionary = new Dictionary();
    }
    componentDidMount(){
        this.ajaxModuleOutputRef.sendRequest('','/getPidList',
        this.ajaxModuleOutputRef, response => {response.map( x => this.pidDictionary.add(x.PID_ID,x.PID_Code));});

        this.ajaxModuleOutputRef.sendRequest('','/getGostList',
        this.ajaxModuleOutputRef, response => {response.map( x => this.gostDictionary.add(x.Gost_ID,x.Gost_Code));});
    }
    createUserInput(){
        //input elements (inputNodes) should be specified in each class - for simplicity - not to alter long time ago ErrorInputs
        return (
            <div>
                <ErrorInput 
                    ref={(input)=>this.errorInputPid=input} 
                    callBack={(value)=>this.pidInputValue=value}
                    inValue={this.userInputValue}
                />
                <ErrorInput 
                    ref={(input)=>this.errorInputGost=input} 
                    callBack={(value)=>this.gostInputValue=value}
                    inValue={this.userInputValue}
                />
                <button onClick={this.tryAddLine}>+</button>
            </div>  
        );
    }
    tryAddLine(){
        //checking for empty user input:
        if(this.pidInputValue==null || this.pidInputValue==''){
            this.errorInputPid.showError(this.LangPack.mustBeFilled);
            return;
        }
        if(this.gostInputValue==null || this.gostInputValue==''){
            this.errorInputGost.showError(this.LangPack.mustBeFilled);
            return;
        }
        //checking if dictionaries contain input values:
        if(!this.pidDictionary.hasValue(this.pidInputValue)){
            this.errorInputPid.showError(this.LangPack.notContainedByDictionary);
            return;
        }
        if(!this.gostDictionary.hasValue(this.gostInputValue)){
            this.errorInputGost.showError(this.LangPack.notContainedByDictionary);
            return;
        }
        var newPidId = this.pidDictionary.keyByValue(this.pidInputValue);
        var newGostId = this.gostDictionary.keyByValue(this.gostInputValue);
        


        //checking if model already contains such user input
        if(this.values.isContaining([newPidId, newGostId])){
            this.errorInput.showError(this.LangPack.valueAlreadyExists);
            return;
        }
        else{ //the server will help us to check if such pair of pid and gost exists with the developed microservice
            
            var params = 'Pid_ID='+newPidId+"&"+"Gost_ID="+newGostId;
            this.ajaxModuleOutputRef.sendRequest(params,'/checkPidGost',
            this.ajaxModuleOutputRef,
            response=>{
                if(response==1) this.values.addLine(null,[[newPidId, this.pidInputValue],[newGostId, this.gostInputValue]]); // null - for null guid element to guidArray of the model
                else this.errorInputPid.showError(this.LangPack.noSuchPair);
            });
        }
    }
}