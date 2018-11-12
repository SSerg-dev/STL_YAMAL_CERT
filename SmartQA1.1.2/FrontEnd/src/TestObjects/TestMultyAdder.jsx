import React from 'react';
import ReactDOM from 'react-dom';
import {TestDictionary} from './UnitTestDictionary.js';
import {TestSuperMultyAdderModel} from './UnitTestSuperMultyAdderModel.js';
import {SuperMultyAdderModel} from '../Models/SuperMultyAdderModel.js';
import {StructureMultyAdder} from '../SharedComponents/MultyAdder/StructureMultyAdder.jsx';
import { PidGostMultyAdder } from '../SharedComponents/MultyAdder/PidGostMultyAdder';

class TestMultyAdder extends React.Component{
    constructor(props){
        super(props);

        //creating test model for SuperMultyAdderModel

        //binding all functions
        this.callBack = this.callBack.bind(this);

        //tesing models:
        this.structureModel = new SuperMultyAdderModel(1);
        this.structureModel.addLine('B69F1B59-1524-E811-A9C1-0050569403D4',[['0C02C197-849A-49CB-879F-BD5CD6AB3B00','079-FW-00759']]);
        this.pidGostModel = new SuperMultyAdderModel(2);
        this.pidGostModel.addLine('');
    }
    render(){
        return (
            <div>
                <StructureMultyAdder
                    inValue={this.structureModel}
                    callBack={function(childElementId, outModel){console.log(outModel);}}
                />
                <PidGostMultyAdder
                    inValue={this.drawingModel}
                    callBack={function(childElementId, outModel){console.log(outModel);}}
                />
            </div>
        );
    }
    callBack(){
        
    }
}


//rendering the component from itself...
export function start(){
ReactDOM.render(
    <TestMultyAdder/>
    , document.getElementsByTagName("body")[0]);

    //testing new and classes here:
    //TestDictionary();
    //TestSuperMultyAdderModel();
}