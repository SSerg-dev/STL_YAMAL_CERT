import React from 'react';
/*this component requires Cell object to be put inside*/

/*TODO: you can implement then this component to make arbitrary number of 
columns to be filled*/
import {ToolKit} from '../../Service/ToolKit.js';
import {ErrorInput} from '../InputWithErrors/ErrorInput.jsx';
import {AjaxModule} from '../../SharedComponents/AjaxModule.jsx';
import {LangPack} from '../../Service/LangPack.js';
import '../../Styles/GuidDoubleSelect.css'

export class  GuidDoubleSelect extends React.Component
{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('rus');
        this.list1Id = [];
        this.list2Id = [];
        this.list1Name = [];
        this.list2Name = [];
        this.nodes = [];
        this.nodeLines = [];
        this.inputVal=[];

        //counting the amout of items selected
        if(this.props.inValue && this.props.inValue.length>0 && this.props.inValue[0]!=null && this.props.inValue[0]!="00000000-0000-0000-0000-000000000000")
        this.items= this.LangPack.Selected+(this.props.inValue.length/2);
        else this.items= this.LangPack.Selected+0;

        this.ajaxModuleOutputRef = null; //link used to call ajax module
        this.activeElements = []; //used to show error messages
        this.isGostListLoaded = false;
        this.isPidListLoaded = false;
        this.lists={
            Pid_ID:[],
            Pid_Code:[],
            Gost_ID:[],
            Gost_Code:[]
        }
        //binding functions: 
        this.getNodes = this.getNodes.bind(this);
        this.fillLines = this.fillLines.bind(this);
        this.createNodes = this.createNodes.bind(this);
        this.deleteButton = this.deleteButton.bind(this);
        this.tryAddLine = this.tryAddLine.bind(this);
        this.addLine = this.addLine.bind(this);
        this.validateInput = this.validateInput.bind(this);
        this.getPidList = this.getPidList.bind(this);
        this.getGostList = this.getGostList.bind(this);
        this.hideNodes = this.hideNodes.bind(this);
        this.onFocus = this.onFocus.bind(this);
        this.focusCell = this.focusCell.bind(this); 
    }
    componentDidMount(){

    }
    render(){
        return (
            <div>
                <div className = {this.props.className}>{this.items} <button onClick={this.getNodes}>></button></div>
                {this.nodes}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    getNodes(){
        //getting Pid possible options - must be downloaded anyway
        this.ajaxModuleOutputRef.sendRequest('','/getPidList',
        this.ajaxModuleOutputRef,this.getPidList);

        //getting Gost possible options - must be downloaded anyway
        this.ajaxModuleOutputRef.sendRequest('','/getGostList',
        this.ajaxModuleOutputRef,this.getGostList);
        this.list1Id = []
        this.list1Name = []
        this.list2Id = []
        this.list2Name = [];

    }
    fillLines(){
        this.nodeLines=[];
        for(var i=0; i<Math.min(this.list1Name.length, this.list2Name.length); i++)
        this.nodeLines.push(
            <div className="gds_listLine">
                <div className="gds_pidText">{this.list1Name[i]}</div>|
                <div className="gds_gostText">{this.list2Name[i]}</div>
                <input className="gds_deleteLineButton" type="submit" value="X" name={i} onClick={(event)=>this.deleteButton(event)}/>
            </div>
        );
        this.createNodes();
    }
    createNodes(){
        this.nodes=(
            <div>
                <div className="gds_block" onClick={this.hideNodes}></div>
                <div className="gds_container" >
                    {this.nodeLines}
                    <ErrorInput className="gds_input" ref={(input)=>this.activeElements.push(input)} callBack={(value)=>this.inputVal[0]=value}/>
                    <ErrorInput className="gds_input" ref={(input)=>this.activeElements.push(input)} callBack={(value)=>this.inputVal[1]=value}/>
                    <button className="gds_addLine" onClick={this.tryAddLine}>+</button>
                </div>
            </div>
            );
        this.forceUpdate();
    }
    hideNodes(){
        if(this.isGostListLoaded && this.isPidListLoaded)
        {
            this.nodes=[];
            var outPutValue = [];
            for(var i=0; i<Math.min(this.list1Id.length, this.list2Id.length); i++)
            {
                outPutValue.push(this.list1Id[i]);
                outPutValue.push(this.list2Id[i]);
            }
            this.props.callBack(this.props.MyId, outPutValue);
            this.forceUpdate();
        }
    }
    deleteButton(event){
        this.list1Name = ToolKit.deleteElement(this.list1Name, event.target.name);
        this.list2Name = ToolKit.deleteElement(this.list2Name, event.target.name);
        this.list1Id = ToolKit.deleteElement(this.list1Id, event.target.name);
        this.list2Id = ToolKit.deleteElement(this.list2Id, event.target.name);
        this.forceUpdate();
        console.log(this.list1Name);
        console.log(this.list2Name);
        console.log(this.list1Id);
        console.log(this.list2Id);
        this.fillLines();
    }
    onFocus(){
        this.props.cellOnFocus(this.props.MyId); //Telling the Line: "I'm focused!": - not pluged yet
    }
    focusCell(){
        //called externally by the line so the cell can change it's style
    }
    tryAddLine(){
        this.activeElements[0].showError("");
        this.activeElements[1].showError("");
        if(this.validateInput()) //checking if everything is ok at front-end
        {
            //retrieve guid of the elements to check
            var Pid_ID_toCheck = this.lists.Pid_ID[ToolKit.getKeyByValue(this.lists.Pid_Code, this.inputVal[0])];
            var Gost_ID_toCheck = this.lists.Gost_ID[ToolKit.getKeyByValue(this.lists.Gost_Code, this.inputVal[1])];
            //sending the request to server:
            var params = 'Pid_ID='+Pid_ID_toCheck+"&"+"Gost_ID="+Gost_ID_toCheck;
            this.ajaxModuleOutputRef.sendRequest(params,'/checkPidGost',
            this.ajaxModuleOutputRef,this.addLine);
        }
        
    }
    addLine(response){
       console.log(response);
       if(response==1) {
        this.list1Name.push(this.inputVal[0].toUpperCase());
        this.list2Name.push(this.inputVal[1].toUpperCase());
        this.list1Id.push(
            this.lists.Pid_ID[ToolKit.getKeyByValue(this.lists.Pid_Code, this.inputVal[0])]
        );
        this.list2Id.push(
            this.lists.Gost_ID[ToolKit.getKeyByValue(this.lists.Gost_Code, this.inputVal[1])]
        );
        this.fillLines();
       }
       else this.activeElements[0].showError("No such pair of PID and GOST exists");
    }
    validateInput(){
        //check if all input is filled:
        if(this.inputVal[0]=="" || this.inputVal[0]==null || this.inputVal[0]==undefined){
            this.activeElements[0].showError("Fill this field");
            return false;
        }
        if(this.inputVal[1]=="" || this.inputVal[1]==null || this.inputVal[1]==undefined){
            this.activeElements[1].showError("Fill this field");
            return false;
        }
        //check if there's such values in the dictionary:
        if(!ToolKit.isContaining(this.lists.Pid_Code, this.inputVal[0])) {
            this.activeElements[0].showError("No such value in dictionary");
            return false;
        }
        if(!ToolKit.isContaining(this.lists.Gost_Code, this.inputVal[1])) {
            this.activeElements[1].showError("No such value in dictionary");
            return false;
        }
        if(ToolKit.isContaining(this.list1Name, this.inputVal[0]) && ToolKit.isContaining(this.list2Name, this.inputVal[1]))
        if(ToolKit.getKeyByValue(this.list1Name, this.inputVal[0]) == ToolKit.getKeyByValue(this.list2Name, this.inputVal[1]))
        {
            this.activeElements[0].showError("This pair already exists");
            return false;
        }
        
        return true;
    }
    getPidList(response){
        console.log("Downloaded Pid dictionary");
        for(var i=0; i<response.length; i++){
            this.lists.Pid_ID.push(response[i].PID_ID);
            this.lists.Pid_Code.push(response[i].PID_Code);
        }
        if(this.props.inValue)
        for(var i=0; i<this.props.inValue.length; i++)
            if(i%2==0)
            {
            console.log(ToolKit.getKeyByValue(this.lists.Pid_ID, this.props.inValue[i].toLowerCase()));
            this.list1Id.push(this.props.inValue[i]);
            this.list1Name.push(this.lists.Pid_Code[ToolKit.getKeyByValue(this.lists.Pid_ID, this.props.inValue[i].toLowerCase())]);
            }
            this.isGostListLoaded = true;
            this.fillLines();
    }
    getGostList(response){
        console.log("Downloaded Gost dictionary");
        for(var i=0; i<response.length; i++){
            this.lists.Gost_ID.push(response[i].Gost_ID);
            this.lists.Gost_Code.push(response[i].Gost_Code);
        }
        if(this.props.inValue)
        for(var i=0; i<this.props.inValue.length; i++)
            if(i%2==1)
            {
                console.log(this.lists.Gost_Code[ToolKit.getKeyByValue(this.lists.Gost_ID, this.props.inValue[i])]);
                this.list2Id.push(this.props.inValue[i]);
                this.list2Name.push(this.lists.Gost_Code[ToolKit.getKeyByValue(this.lists.Gost_ID, this.props.inValue[i].toLowerCase())]);
            }
        console.log();
        this.isPidListLoaded = true;
        this.fillLines();
    }
}