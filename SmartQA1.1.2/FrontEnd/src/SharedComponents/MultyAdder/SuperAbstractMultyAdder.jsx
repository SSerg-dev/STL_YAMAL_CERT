import React from 'react';
import {AjaxModule} from '../AjaxModule.jsx';
import {LangPack} from '../../Service/LangPack.js';

/*this class is super abstract implementation of the window where you can
input different options (lines) of any input, for example - GOST - PID pairs, structures.
This component itself works with a model SuperMultyAdderModel

This component has it's own Ajax module, with help of which 
it retrieves all the dictionaries from the Server, but the retrieving itself
must be explicitly implemented in the classes that derivate from this abstract one

So, this component requires several things to be supplied with:
-> function on callBack - called when the component is closed (callBack)
-> input values - in SuperMultyAdderModel format (inValue)
-> id of the element so it can be used inside a table (MyId)

*/
export class SuperAbstractMultyAdder extends React.Component{
    constructor(props){
        super(props);

        //variables that used across the component:
        this.nodes = null; //nodes contain lineNodes and lineNodes are child components of the nodes in their turn
        this.lineNodes = null;
        this.LangPack = new LangPack('rus');
        this.ajaxModuleOutputRef = null;
        this.userInputValue = null;

        this.values = this.props.inValue; //binding this SuperMultyAdderModel just for syntaxic convenience
        //binding functions:
        this.showNodes = this.showNodes.bind(this);
        this.hideNodes = this.hideNodes.bind(this);
        this.deleteNode = this.deleteNode.bind(this);
        this.createUserInput = this.createUserInput.bind(this);
    }

    render(){
        this.selected = this.LangPack.Selected+' '+this.values.Count;
        return (
            <div>
                <div>{this.items} 
                    {this.selected}
                    <button onClick={this.showNodes}>></button>
                </div>
                {this.nodes}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    showNodes(){
        //creating lines nodes separetely from input elements and + button:
        this.lineNodes=[];
        this.inputNodes = null;
        this.userInputValue = '';
        this.inputNodes = this.createUserInput();
        
        for(var i=0; i<this.values.Count; i++){ //iterating over lines
            var lineValues = this.values.getLineValues(i);
            var line=[];
            if(lineValues!=null && lineValues.length>0)
            for(var j=0; j<lineValues.length; j++) line.push(<div>{lineValues[j]}</div>)
            line.push(<button name={i} onClick={this.deleteNode}>X</button>);
            this.lineNodes.push(line);
        }
        if(this.lineNodes.length==0) this.lineNodes = (<div>{this.LangPack.nothingSelected}</div>);
        //creating input elements and + button:
        this.nodes=null;
        this.nodes=(
            <div>
                <div className="gss_block" onClick={this.hideNodes}></div>
                <div className="gss_container" >
                    {this.lineNodes}
                    {this.inputNodes}
                </div>
            </div>
            );
        this.forceUpdate();
    }
    hideNodes(){
            this.nodes=[];
            this.props.callBack(this.props.MyId, this.values);
            this.forceUpdate();
    }
    deleteNode(event){
        if(event!=null && event.target!=null && event.target.name!=null)
        this.values.delete(event.target.name);
        this.showNodes();
        this.forceUpdate();
    }
    createUserInput(){
    }
}