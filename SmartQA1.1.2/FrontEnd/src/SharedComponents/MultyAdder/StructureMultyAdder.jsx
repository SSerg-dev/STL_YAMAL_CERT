import React from 'react';
import {SuperAbstractMultyAdder} from './SuperAbstractMultyAdder.jsx';
import {ErrorInput} from '../InputWithErrors/ErrorInput.jsx';
import {Dictionary} from '../../Models/Dictionary';

export class StructureMultyAdder extends SuperAbstractMultyAdder{
    constructor(props){
        super(props);

        this.structureDictionary = new Dictionary();
        this.errorInput = null;

        //binding functions:
        this.tryAddLine = this.tryAddLine.bind(this);
    }
    componentDidMount(){
        //start retrieving the structure dictionary from the server
        this.ajaxModuleOutputRef.sendRequest('','/getStructureList',
        this.ajaxModuleOutputRef, response => {response.map( x => this.structureDictionary.add(x.Structure_ID,x.Structure_Name));});
    }
    createUserInput(){
        //input elements (inputNodes) should be specified in each class - for simplicity - not to alter long time ago ErrorInputs
        return (
            <div>
                <ErrorInput 
                    ref={(input)=>this.errorInput=input} 
                    callBack={(value)=>this.userInputValue=value}
                    inValue={this.userInputValue}
                />
                <button onClick={this.tryAddLine}>+</button>
            </div>  
        );
    }
    tryAddLine(){
        //checking for empty input:
        if(this.userInputValue==null || this.userInputValue=='') {
            this.errorInput.showError(this.LangPack.mustBeFilled);
            return;
        }
        
        //checking for the value that is not contained by the dictionary:
        if(!this.structureDictionary.hasValue(this.userInputValue)){
            this.errorInput.showError(this.LangPack.notContainedByDictionary);
            return;
        }

        var newStructureId=this.structureDictionary.keyByValue(this.userInputValue);

        //checking if model values already contain user input
        if(this.values.isContaining([newStructureId])){
            this.errorInput.showError(this.LangPack.valueAlreadyExists);
            return;
        }
        else{
            this.values.addLine(null, [[newStructureId, this.userInputValue]]); //this should be array
            this.showNodes();
        }
    }
}