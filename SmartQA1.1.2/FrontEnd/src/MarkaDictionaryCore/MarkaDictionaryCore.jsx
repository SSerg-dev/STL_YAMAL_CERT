import React from 'react';
import ReactDOM from 'react-dom';
import {Head} from '../SharedComponents/Head.jsx';
import {Bottom} from '../SharedComponents/Bottom.jsx';
import {LangPack} from '../Service/LangPack.js';
import {TableReadonly} from '../SharedComponents/Tables/TableReadonly.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {MarkaEdit} from './MarkaEdit.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import {ButtonPanel} from '../SharedComponents/ButtonPanel.jsx';
import '../Styles/MarkaDictionaryCore.css';

class MarkaDictionaryCore extends React.Component{
    constructor(props){
        super(props);
        this.ajaxModuleOutputRef=null;
        this.reportOrderOptions = new Dictionary();
        this.reportColorOptions = [];

        //binding functions
        this.getMarkaDictionaryList = this.getMarkaDictionaryList.bind(this);
        this.closeMarkaForEdit = this.closeMarkaForEdit.bind(this);
        this.openMarkaForEditCreate = this.openMarkaForEditCreate.bind(this);
        this.updateTable = this.updateTable.bind(this);
        this.onDeleted = this.onDeleted.bind(this);

        this.LangPack = new LangPack('eng');
        this.bodyInput = [[this.LangPack.Loading]];
        this.tableTitle = [
            this.LangPack.Marka, 
            this.LangPack.Description_Rus,
            this.LangPack.CodeMark, 
            this.LangPack.isPriority,
            this.LangPack.isUsedInMatrix
        ];
        this.markaList = null;
        this.markaEdit = [];

        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        this.RcFunctions=[];
        this.RcFunctions.push(this.openMarkaForEditCreate);

        this.RcNames = [];
        this.RcNames.push(this.LangPack.Open);
    }
    componentDidMount(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getMarkaDictionaryList',
        this.ajaxModuleOutputRef,this.getMarkaDictionaryList);
    }
    render(){
        return(
            <div>
                <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.openMarkaForEditCreate}>{this.LangPack.Create}</button>
                </ButtonPanel>
                <TableReadonly
                    titleLine={this.tableTitle}
                    bodyInput={this.bodyInput}
                    RcFunctions={this.RcFunctions}
                    RcNames={this.RcNames}
                />
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                <div style={{height:50}}></div>
                <Bottom/>
                <div>{this.markaEdit}</div>
            </div>
        );
        this.applyTableStyling();
    }
    getMarkaDictionaryList(response){
        if(response)
        {   
            //creating report order options
            this.reportOrderOptions.add(null, this.LangPack.NotSelected);
            this.reportOrderOptions.add('00000000-0000-0000-0000-000000000000',this.LangPack.First);

            this.bodyInput=[];
            this.markaList = response;
            var line = [];
            for(var i =0; i<response.length; i++)
            {
                var marka = response[i];
                line.push(marka.Marka_Name);
                line.push(marka.Description_Rus);
                line.push(marka.Code_of_mark);
                line.push(marka.IsPriority===null?null:(marka.IsPriority?this.LangPack.Yes:this.LangPack.No));
                line.push(marka.IsUsedInMatrix===null?null:(marka.IsUsedInMatrix?this.LangPack.Yes:this.LangPack.No));
                this.bodyInput.push(line);
                line=[];

                //escape from N/A marka:
                if(marka.Marka_Name!='N/A') this.reportOrderOptions.add(marka.Marka_ID,marka.Marka_Name);
                
                if(marka.ReportColor && ToolKit.checkHexColor(marka.ReportColor)) ToolKit.pushInsideOriginal(this.reportColorOptions,marka.ReportColor);
            }
            this.forceUpdate();
        }
    }
    openMarkaForEditCreate(lineId){
        var isEdit = !isNaN(lineId) ? true : false;
        var width = 380;
        var height = 700;
        var offsetRight = (window.innerWidth - width)/2; //100+this.markaEdit.length*20
        var offsetTop  = (window.innerHeight - height)/2; //100+this.markaEdit.length*20
        Head.showBlock();
        this.markaEdit.push(
            <PopMovable 
                onExit={this.closeMarkaForEdit} 
                head={isEdit? this.LangPack.EditMarka: this.LangPack.CreateMarka}
                MyId={this.markaEdit.length}
                offsetStyle={{right:offsetRight, top:offsetTop, width:width, zIndex: 99}}
            >
                <MarkaEdit 
                    key={ToolKit.shortId()}  
                    inValue={isEdit? this.markaList[lineId] : null}
                    reportOrderOptions={this.reportOrderOptions}
                    reportColorOptions={this.reportColorOptions}
                    onExit={this.closeMarkaForEdit}
                    MyId={this.markaEdit.length}
                    onSaved = {this.updateTable}
                    onDeleted = {this.onDeleted}
                />
            </PopMovable>
        );
        this.forceUpdate();
    }
    onDeleted(MyId){
        this.updateTable();
        this.closeMarkaForEdit(MyId);
    }
    closeMarkaForEdit(MyId){
        Head.hideBlock();
        this.markaEdit[MyId]=null;
        this.forceUpdate();
    }
    updateTable(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getMarkaDictionaryList',
        this.ajaxModuleOutputRef,this.getMarkaDictionaryList);
    }
}
export function startPage(){
    ReactDOM.render(
        <div>
            <MarkaDictionaryCore/>
        </div>, document.getElementsByTagName("body")[0]);
}