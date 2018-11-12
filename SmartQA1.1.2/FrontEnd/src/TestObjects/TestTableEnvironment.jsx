import React from 'react';
import {TableInput} from '../SharedComponents/TableInput.jsx';
import {TableDateInput} from '../SharedComponents/TableDateInput.jsx';
import {TableLine} from '../SharedComponents/TableLine.jsx';
import {SuperTable} from '../SharedComponents/SuperTable.jsx';

export class TestTableEnvironment extends React.Component{
    //TABLE TEST
    constructor(props){
        super(props);
        this.dataCameFromTable=this.dataCameFromTable.bind(this);

        this.history=[];
        this.bodyInput = [
            ['Document 1', 'toyota', '23.12.2014', 'Document Type1', 'Construction site'],
            ['New document', 'lexus', '23.02.2013', 'Document Type3', 'Bog flare'],
            ['CS3', 'range rover', '28.12.2013', 'Documet', 'Construction site'],
            ['New document', 'toyota', '23.11.2013', 'NoType', 'Plant site'],
            ['New document', 'bugatti', '23.12.2018', 'Out of newest', 'Construction site'],
            ['New document', 'toyota', '23.12.2019', 'Several', 'Construction site']
        ];
        }
        tableTitle = ['Document Name', 'Choose car', 'Date', 'DocumentType', 'Place'];
        lineMatrix = ['tableInput', ['None','mercedes', 'toyota', 'lexus', 'range rover', 'bugatti'], 'tableDateInput', 'tableInput', 'tableInput'];

    render(){
        //START BLOCK history-recursive function
        var d = new Date();
        var object1 = {a: 1, b: 2, c: 3, titles:['name', 'ownage', 'well','crya']};
        var testObject = [];
        //for(var j=0; j<10000; j++) testObject.push(this.bodyInput);
        object1 = testObject;
        function Xi(obj){return Object.getOwnPropertyNames(obj);}
        var n1 = d.getTime();
        var outArray =[];
        function CallLoop(object){
            if(typeof object != 'object') outArray.push(object);
            else {
                var temp = Xi(object);
                for(var i=0; i<temp.length; i++) if(temp[i]!='length') CallLoop(object[temp[i]]);
            }
        }
        CallLoop(object1);
        var f = new Date();
        var n2 = f.getTime();
        console.log("RESULT "+outArray);
        console.log(n2);
        console.log(n1);
        console.log("TimeRequired: "+(n2-n1)+ " ms");
        //END BLOCK history-recursicve function
        
        var inputValues = this.bodyInput.map(
            (line)=>{
                return(<tr>{line.map((cell)=>{
                    return(<td>{cell}{'___'}</td>)
                })}</tr>)
            }
        );
        
        return(
            <div onKeyDown={this.onKeyDown}>
                <SuperTable 
                    tableTitle={this.tableTitle} 
                    bodyInput={this.bodyInput}
                    lineMatrix={this.lineMatrix}
                    callBack={this.dataCameFromTable}
                />
                {inputValues}
            </div>
        );
    }
    dataCameFromTable(newBody){
        this.bodyInput = newBody;
        /*Remove when implementing table in Core - only table components needs
        to be rendered after data updating*/
        this.forceUpdate();
    }

}
    //TABLE TEST END


