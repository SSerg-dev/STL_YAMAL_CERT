import React from 'react';
import ReactDOM from 'react-dom';
import {Head} from '../SharedComponents/Head.jsx';
import {Bottom} from '../SharedComponents/Bottom.jsx';
import {LangPack} from '../Service/LangPack.js';
import {TableReadonly} from '../SharedComponents/Tables/TableReadonly.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {TitleObjectEdit} from './TitleObjectEdit.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import {ButtonPanel} from '../SharedComponents/ButtonPanel.jsx';
import {Tree} from '../Models/Tree.js';
import '../Styles/MarkaDictionaryCore.css';

class TitleObjectdDictionaryCore extends React.Component{
    constructor(props){
        super(props);
        this.ajaxModuleOutputRef=null;
        this.LangPack = new LangPack('eng');
        this.bodyInput = [];
        this.bodyInput.push([this.LangPack.Loading]);
        this.titleObjectEdit =[];

        this.tableTitle = [
            this.LangPack.Title,
            this.LangPack.Description_Eng,
            this.LangPack.Phase,
            this.LangPack.StageOfConstruction
        ];

        this.reportOrderOptions = new Tree(null,null);
        this.reportColorOptions = new Tree(null,null);
        this.colorOptions = [];

        this.lists = {phase:null};
        this.lists.phase = new Dictionary();
        this.lists.phase.add(null, this.LangPack.Loading);
        this.lists.reportOrder = new Dictionary(); //multilayer dictionary - dictionary inside a dictionary inside a dictionary ...
        this.lists.reportColor = new Dictionary(); //multylayer dictionary


        this.rowStyle = [];
        //binding functions:
        this.getTitleObjectDictionaryList = this.getTitleObjectDictionaryList.bind(this);
        this.openTitleObjectForEditCreate = this.openTitleObjectForEditCreate.bind(this);
        this.closeTitleObjectForEdit = this.closeTitleObjectForEdit.bind(this);
        this.getPhaseList = this.getPhaseList.bind(this);
        this.updateTable = this.updateTable.bind(this);

        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        this.RcFunctions=[];
        this.RcFunctions.push(this.openTitleObjectForEditCreate);

        this.RcNames = [];
        this.RcNames.push(this.LangPack.Open);
    }
    componentDidMount(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getPhaseList',
        this.ajaxModuleOutputRef,this.getPhaseList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectDictionaryList',
        this.ajaxModuleOutputRef,this.getTitleObjectDictionaryList);
    }
    componentDidUpdate(){
        if(this.titleObjectList && this.titleObjectList.length>0)
        {
            var table = document.getElementsByTagName('table')[0];
            table.style.tableLayout='fixed';
            table.style.width = (window.innerWidth-200)+'px';

            var header = document.getElementsByTagName('th');
            if(header && header.length>0){
                header[0].colSpan = '3';
                header[0].style=header[0].style+';height:150px; width:200px';
                header[1].style.width="auto";
                header[2].style.width="40px";
                header[3].style.width="100px";
            }       
            var cells = document.getElementsByTagName('td');

            if(cells && cells.length && this.titleObjectList)
            {
                for(var i=0; i<this.titleObjectList.length; i++){
                    
                    var cellIndex = i*6;
                    cells[cellIndex+4].style.textAlign = 'center';
                    cells[cellIndex+5].style.textAlign = 'center';

                    var title = this.titleObjectList[i];
                    for(var j=0; j<3; j++){
                        var cellIndex = i*6+j;
                        cells[cellIndex].style.paddingLeft = '4px';
                        //cells[cellIndex].style.borderLeftStyle = 'none';
                        //cells[cellIndex].style.borderRightStyle = 'none';
                        //cells[cellIndex].style.borderBottomColor = 'white';
                        //cells[cellIndex].style.borderTopColor = 'white';

                        cells[cellIndex].style.backgroundColor = title.ReportColor;
                        cells[cellIndex].style.color = 'black';
                        cells[cellIndex].style.fontWeight = 600;
                        
                        /*if(j==title.Structure-1){
                            if(title.ReportColor){
                                cells[cellIndex].style.backgroundColor = title.ReportColor;
                                cells[cellIndex].style.color = 'black';
                                //if(j==1) cells[cellIndex-1].style.backgroundColor='white';
                                if(j==2) 
                                {
                                    cells[cellIndex-1].style.backgroundColor='white';
                                    cells[cellIndex-2].style.backgroundColor='white';
                                }
                            }
                        }*/
                    }
                    
                }
            }
            //overriding the default TableReadOnly behaviour:
            var rows = document.getElementsByTagName('tr');
            document.colorArray = [];

            for(var i =0 ; i<rows.length; i++) rows[i].onmouseover = 
                function(){
                    //first - check if the previous row exists:
                    if(document.activeRow && document.colorArray && document.colorArray.length>0){
                        var prevRowChildNodes = document.activeRow.childNodes;
                        for(var j = 0; j<prevRowChildNodes.length; j++){
                            prevRowChildNodes[j].style.backgroundColor = document.colorArray[j];
                            prevRowChildNodes[j].style.color = 'black';
                        }
                    }
                    var childNodes = this.childNodes;
                    
                    //if there're no colors in the global color array then add it:
                    for(var j=0; j<childNodes.length; j++){
                        document.colorArray[j] = childNodes[j].style.backgroundColor;
                        childNodes[j].style.backgroundColor = 'rgb(90,90,90)';
                        childNodes[j].style.color = 'white';
                    }
                    document.activeRow = this;
                }
        }
    }
    render(){
        return(
            <div>
                <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.openTitleObjectForEditCreate}>{this.LangPack.Create}</button>
                </ButtonPanel>
                <TableReadonly
                    titleLine={this.tableTitle}
                    bodyInput={this.bodyInput}
                    RcFunctions={this.RcFunctions}
                    RcNames={this.RcNames}
                    key={ToolKit.shortId()}
                />
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                <div style={{height:50}}></div>
                <Bottom/>
                <div>{this.titleObjectEdit}</div>
            </div>
        );
    }
    getTitleObjectDictionaryList(response){
        this.reportOrderOptions.clear();
        this.reportColorOptions.clear();
        this.lists.reportOrder.clear();
        this.lists.reportColor.clear();

        if(response)
        {
            this.bodyInput = [];
            this.titleObjectList = response;
            var line = [];
            for(var i=0; i<response.length; i++)
            {
                var title = response[i];

                //REPORT ORDER options:
                this.reportOrderOptions.addNode(title.TitleObject_PARENTID, title.TitleObject_ID, title.TitleObject_Name);

                //REPORT COLOR options:
                //check if this element has parent - if yes - append parent reportColor to child reportColor
                if(title.TitleObject_PARENTID){
                    var parent = this.reportColorOptions.findNode(title.TitleObject_PARENTID)
                    if(parent) title.ReportColor = parent.value;
                }
                this.reportColorOptions.addNode(title.TitleObject_PARENTID, title.TitleObject_ID, title.ReportColor);
                if(ToolKit.checkHexColor(title.ReportColor)) ToolKit.pushInsideOriginal(this.colorOptions, title.ReportColor);

                line.push(title.Structure==1?title.TitleObject_Name:null);
                line.push(title.Structure==2?title.TitleObject_Name:null);
                line.push(title.Structure==3?title.TitleObject_Name:null);
                //line.push(title.ReportOrder);
                line.push(title.Description_Eng);
                line.push(title.Phase_Name);
                line.push(title.StageOfConstr);
                this.bodyInput.push(line);
                line=[];
            }
        }
        this.forceUpdate();
    }
    updateTable(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectDictionaryList',
        this.ajaxModuleOutputRef,this.getTitleObjectDictionaryList);
    }
    openTitleObjectForEditCreate(lineId){
        var isEdit = !isNaN(lineId) ? true : false;

        var isEdit = !isNaN(lineId) ? true : false;
        var width = 400;
        var height = 500;
        var offsetRight = (window.innerWidth - width)/2; //100+this.titleObjectEdit.length*20
        var offsetTop  = (window.innerHeight - height)/2; //100+this.titleObjectEdit.length*20
        Head.showBlock();

        this.titleObjectEdit.push(
            <PopMovable 
                onExit={this.closeTitleObjectForEdit} 
                head={isEdit ? this.LangPack.EditTitleObject : this.LangPack.CreateNewTitleObject}
                MyId={this.titleObjectEdit.length}
                offsetStyle={{right:offsetRight, top:offsetTop, width:400, zIndex:99}}
            >
                <TitleObjectEdit 
                    key={ToolKit.shortId()}  
                    inValue={isEdit ? this.titleObjectList[lineId] : null}
                    reportOrderOptions={this.reportOrderOptions}
                    colorOptions={this.colorOptions}
                    reportColorOptions={this.reportColorOptions}
                    onExit={this.closeTitleObjectForEdit}
                    MyId={this.titleObjectEdit.length}
                    phaseOptions = {this.lists.phase}
                    onSaved = {this.updateTable}
                    onDeleted = {this.onDeleted}
                />
            </PopMovable>
        );
        this.forceUpdate();
    }
    closeTitleObjectForEdit(MyId){
        Head.hideBlock();
        this.titleObjectEdit[MyId]=null;
        this.forceUpdate();
    }
    updateTable(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectDictionaryList',
        this.ajaxModuleOutputRef,this.getTitleObjectDictionaryList);
    }
    getPhaseList(response){
        if(response) {
            this.lists.phase.clear();
            this.lists.phase.add(null, this.LangPack.NotSelected);
            response.map((phase)=>{
                this.lists.phase.add(phase.Phase_ID, phase.Phase_Name);
            });
        }
    }
}
export function startPage(){
    ReactDOM.render(
        <div>
            <TitleObjectdDictionaryCore/>
        </div>, document.getElementsByTagName("body")[0]);
}