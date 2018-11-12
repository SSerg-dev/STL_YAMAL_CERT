import React from 'react';
import ReactDOM from 'react-dom';
import {Head} from '../SharedComponents/Head.jsx';
import {Bottom} from '../SharedComponents/Bottom.jsx';
import {LangPack} from '../Service/LangPack.js';
import {TableOrderBy} from '../SharedComponents/Tables/TableOrderBy.jsx';
import {Filter} from '../Models/Filter.js';
import {FilterDomain} from '../Models/FilterDomain.js';
import {FilterLine} from '../SharedComponents/Filters/FilterLine.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {ButtonPanel} from '../SharedComponents/ButtonPanel.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {DocumentEdit} from './DocumentEdit.jsx';
import '../Styles/ABDDocumentStyle.css';

class ABDDocumentCore extends React.Component{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('eng');
        this.ajaxModuleOutputRef;

        this.tableTitle = [this.LangPack.ABDDocumentNumber, this.LangPack.ABDDocument_Name, this.LangPack.CreatedBy, this.LangPack.CreationDate];
        this.colNames = ['ABDDocument_Number', 'ABDDocument_Name', 'Created_User', 'Issue_Date'];

        this.lists = {
            document: new Dictionary(),
            gost: [],
            pid: []
        };
        this.lists.document.add(null, this.LangPack.Loading);

        this.documentEditWindow = null;
        this.bodyInput = [[this.LangPack.Loading]];
        this.isLoading = true; //this value is used in the handleScroll method so the Ajax call and table update won't launch twice while updating

        //binding functions
        this.createABDDocument = this.createABDDocument.bind(this);
        this.openForView = this.openForView.bind(this);
        this.openForEdit = this.openForEdit.bind(this);
        this.openABDDocumentWindow = this.openABDDocumentWindow.bind(this);
        this.tableClear = this.tableClear.bind(this);
        this.tableUpdate = this.tableUpdate.bind(this);
        this.handleScroll = this.handleScroll.bind(this);
        this.sendFilters = this.sendFilters.bind(this);
        this.closeDocument = this.closeDocument.bind(this);
        this.onDeleted = this.onDeleted.bind(this);
        this.onSaved = this.onSaved.bind(this);

        //FILTERS
        this.filterDomain = new FilterDomain(this.sendFilters, 40, this.tableClear); //40 - how many rows will be downloaded each time

        this.filterDomain.add(new Filter('ABDDocument_Number', this.LangPack.ABDDocument_Number, 'text'));
        this.filterDomain.add(new Filter('ABDDocument_Name', this.LangPack.ABDDocument_Name, 'text'));
        this.filterDomain.add(new Filter('Created_User', this.LangPack.CreatedBy, 'text'));
        this.filterDomain.add(new Filter('IssueDate', this.LangPack.CreationDate, 'date'));

        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        this.RcFunctions=[];
        this.RcFunctions.push(this.openForView);
        this.RcFunctions.push(this.openForEdit);

        this.RcNames = [];
        this.RcNames.push(this.LangPack.Open);
        this.RcNames.push(this.LangPack.Edit);
    }
    componentDidMount(){
        window.addEventListener("scroll", this.handleScroll);
        this.filterDomain.next();
    }
    componentWillUpdate(){
        this.isLoading = true;
    }
    componentDidUpdate(){
        this.isLoading = false;
        
    }
    render(){
        return (
            <div>
                <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.createABDDocument}>{this.LangPack.CreateABDDocument}</button>
                </ButtonPanel>
                <FilterLine
                    filters={this.filterDomain.filters}
                    hasTitles={true}
                    callBack={this.filterDomain.changeFilters}
                />
                <TableOrderBy
                    orderCallBack = {this.filterDomain.appendOrderByFilter}
                    colNames={this.colNames}
                    titleLine={this.tableTitle}
                    bodyInput={this.bodyInput}
                    RcFunctions={this.RcFunctions}
                    RcNames={this.RcNames}
                    styles={{readOnlyTable:'document_tableStyle'}}
                />
                <Bottom infoMessage = {this.resultsFound}/>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                {this.documentEditWindow}
            </div>
        );
    }
    /*(
        <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.createABDDocument}>{this.LangPack.CreateABDDocument}</button>
                </ButtonPanel>
                <FilterLine
                    filters={this.filterDomain.filters}
                    hasTitles={true}
                    callBack={this.filterDomain.changeFilters}
                />
                <TableOrderBy
                    orderCallBack = {this.filterDomain.appendOrderByFilter}
                    colNames={this.colNames}
                    titleLine={this.tableTitle}
                    bodyInput={this.bodyInput}
                    RcFunctions={this.RcFunctions}
                    RcNames={this.RcNames}
                />
                <Bottom infoMessage = {this.resultsFound}/>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
    )*/
    tableUpdate(response){
        if(response!=null){
            document.getElementById("bottom_element").style.display="block";
            this.resultsFound = this.LangPack.TotalFound+response.resultsFound+" "+this.LangPack.OfDocuments;

            if(this.bodyInput==[] || this.bodyInput[0]==this.LangPack.Loading) 
            {
                this.tableClear();
            }
            if(response.documentList!=null){
                for(var i=0; i<response.documentList.length; i++){
                    this.bodyInput.push([]); //adding new line
                    var indexLastLine = this.bodyInput.length-1; //getting the index of the last current line in the bodyInput
                    this.lists.document.add(response.documentList[i].ABDDocument_ID, response.documentList[i].ABDDocument_Number);
                    this.bodyInput[indexLastLine].push(response.documentList[i].ABDDocument_Number);
                    this.bodyInput[indexLastLine].push(response.documentList[i].ABDDocument_Name);
                    this.bodyInput[indexLastLine].push(response.documentList[i].Modified_User);
                    this.bodyInput[indexLastLine].push(response.documentList[i].Issue_Date_UINormalized);
                }
            }
            this.forceUpdate();
        }
    }
    tableClear(){
        this.lists.document.clear();
        this.bodyInput = [];
    }
    handleScroll() {
        const windowHeight = "innerHeight" in window ? window.innerHeight : document.documentElement.offsetHeight;
        const body = document.body;
        const html = document.documentElement;
        const docHeight = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight,  html.scrollHeight, html.offsetHeight);
        const windowBottom = windowHeight + window.pageYOffset;
        if (windowBottom >= docHeight && !this.isLoading) { //checking if the page is not loading at this moment
            //here we set RowNum filter and send the table loading
            this.filterDomain.next();
            this.isLoading = true;
        }
    }
    sendFilters(filters){
        this.ajaxModuleOutputRef.sendJson(filters,'/GetABDDocumentList',
        this.ajaxModuleOutputRef,this.tableUpdate);
    }
    openForEdit(lineId){
        var id = this.lists.document.keyByIndex(lineId);
        console.log(id);
        this.openABDDocumentWindow(false, id);
    }
    openForView(lineId){
        var id = this.lists.document.keyByIndex(lineId);
        this.openABDDocumentWindow(true, id);
    }
    createABDDocument(){
        this.openABDDocumentWindow(false, null);
    }
    openABDDocumentWindow(isReadonly, ABDDocument_Id){
        var width = 1068;
        var height = 800;
        if(ABDDocument_Id == null) var head = this.LangPack.CreateABDDocument;
        else{
            if(isReadonly) var head = this.LangPack.ViewABDDocument + this.lists.document.valueByKey(ABDDocument_Id);
            else var head = this.LangPack.EditABDDocument + this.lists.document.valueByKey(ABDDocument_Id);
        }
        var offsetRight = (window.innerWidth - width)/2;
        var offsetTop  = 50;
        var zIndex = 99;

        Head.showBlock();
        this.documentEditWindow = null;
        this.documentEditWindow = (
            <PopMovable
                    onExit = {this.closeDocument}
                    head={head}
                    MyId={'openDocument'}
                    offsetStyle={{right:offsetRight, top:offsetTop, width:1048, zIndex:zIndex}}
                >
                    <DocumentEdit
                        isDisabled = {isReadonly}
                        inValue={ABDDocument_Id} 
                        onExit={this.closeDocument}
                        key={ToolKit.shortId()}
                        gostOptions = {this.lists.gost}
                        pidOptions = {this.lists.pid}
                        onDeleted = {this.onDeleted}
                        onSaved = {this.onSaved}
                    />
            </PopMovable> 
        );
        this.forceUpdate();
    }
    onDeleted(){
        this.filterDomain.resetRowNumAndSendFiltersAgain();
        this.closeDocument();
    }
    onSaved(){
        this.filterDomain.resetRowNumAndSendFiltersAgain();
    }
    closeDocument(){
        this.ajaxModuleOutputRef.sendJson(null,'/ABDDocumentDisposeUploadedFiles',
        this.ajaxModuleOutputRef,()=>{});

        this.documentEditWindow = null;
        Head.hideBlock();
        this.forceUpdate();
    }
}

export function startPage(){
    ReactDOM.render(
        <div>
            <ABDDocumentCore/>
        </div>, document.getElementsByTagName("body")[0]);
}