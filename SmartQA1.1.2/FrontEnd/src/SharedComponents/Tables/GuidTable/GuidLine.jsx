import React from 'react';
import {SuperTable} from '../SuperTable.jsx';
import {ToolKit} from '../../../Service/ToolKit.js';
import {TableLine} from '../TableLine.jsx';
import {TableInput} from '../TableInput.jsx';
import {TableList} from '../TableList.jsx';
import {TableDateInput} from '../TableDateInput.jsx';
import {SuperDropCheck} from '../../SuperDropCheck.jsx';
import {GuidSingleSelect} from './GuidSingleSelect.jsx';
import {GuidDoubleSelect} from './GuidDoubleSelect.jsx';

/* this line get cell objects and then creates line using 
 * complex Shared Components*/

 /*the only things that change is lineInput - now it's array of cells
 and callback - now we are writing to the array of cells*/

 //ALSO THIS TABLE LINE REQUIRES CLASS NAME FROM THE PARENT ELEMENT
 export class GuidLine extends TableLine{
     
    //callBack everywhere stays the same
    createLineNodes(lineMatrix, lineInput){
        var lineNodes=[];
        //console.log("Creating line nodes for: "+this.props.MyId);
        for(var i=0; i<lineMatrix.length; i++){
                        if(lineMatrix[i]=='tableInput') {lineNodes.push(
                <td key={"cell"+this.props.MyId+"."+i}
                    className={this.props.className.td[i]}>
                    <TableInput 
                        callBack={this.callBack} 
                        inValue={lineInput[i].inValue}  //now we are working with cells
                        cellOnFocus={this.cellOnFocus}
                        className={'tableCell'}
                        MyId={i}
                        ref={(inputRef)=>{
                            this.cellArray.push(inputRef)
                        }}
                    />
                </td>
                );
                //console.log("Creating new TableCell with value: ");
                //console.log(lineInput[i].inValue[0]);
                //console.log("Line: rendering TableInput");
            }
            if(lineMatrix[i]=='tableDateInput'){ lineNodes.push(
                <td key={"cell"+this.props.MyId+"."+i}
                    className={this.props.className.td[i]}>
                    <TableDateInput 
                        callBack={this.callBack} 
                        inValue={lineInput[i].inValue[0]} //now we are working with cells
                        cellOnFocus={this.cellOnFocus}
                        
                        MyId={i}
                        ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                    />
                </td>
                );
                //console.log("Line: rendering TableDateInput");
            }
            
            if(lineMatrix[i]=='tableList') {lineNodes.push( //now every component has it's own
                <td key={"cell"+this.props.MyId+"."+i}
                    className={this.props.className.td[i]}>
                    <TableList
                        callBack={this.callBack}
                        inValue={lineInput[i].inValue[0]} //now we are working with cells
                        ArrayOfStrings={lineInput[i].AoS} //now we can pass possible options in cell AoS
                        cellOnFocus={this.cellOnFocus}
                        
                        MyId={i}
                        ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                    />
                </td>);
                
                //console.log("Line: rendering TableList");
            }  
            //tableDropCheck needs to be overriden
            if(lineMatrix[i]=='tableDropCheck') {lineNodes.push( //now every component has it's own
            <td key={"cell"+this.props.MyId+"."+i}
                className={this.props.className.td[i]}>
                <SuperDropCheck
                    onOk={this.callBack}
                    name={"No Name"} //count here the options chosen
                    inValue={lineInput[i].inValue} //now we are working with cells
                    filterOptions={lineInput[i].AoS} //now we can pass possible options in cell AoS
                    cellOnFocus={this.cellOnFocus}
                    
                    hasTitles={false}
                    MyId={i}
                    ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                />
            </td>);
            //console.log("Line: rendering TableDropCheck");
            }  
            if(lineMatrix[i]=='guidSingleCheck') {lineNodes.push(
                <td key={"cell"+this.props.MyId+"."+i}
                    className={this.props.className.td[i]}>
                    <GuidSingleSelect 
                        callBack={this.callBack} 
                        className={this.props.className.input[i]}
                        MyId={i}
                        inValue={lineInput[i].inValue}
                        cellOnFocus={this.cellOnFocus}
                        ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                    />
                </td>);
                //console.log("Line: rendering GuidSingleCheck");
                } 
            if(lineMatrix[i]=='guidDoubleCheck') {lineNodes.push(
            <td key={"cell"+this.props.MyId+"."+i}
                className={this.props.className.td[i]}>
                <GuidDoubleSelect 
                    callBack={this.callBack} 
                    className={this.props.className.input[i]}
                    MyId={i}
                    inValue={lineInput[i].inValue}
                    cellOnFocus={this.cellOnFocus}
                    ref={(inputRef) =>{this.cellArray.push(inputRef);}}
                />
            </td>);
            //console.log("Line: rendering GuidDoubleCheck");
            }
        }
        //console.log("Line nodes length created: "+lineNodes.length);
        return lineNodes;
    }
}

     //constructor
    //render

    //onkeydown
    //focusCell
    //CellonFocus
    //onRightClick
    //onExit
    //onMouseMove