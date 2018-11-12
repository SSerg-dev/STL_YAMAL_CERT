import React from 'react';
import ReactDOM from 'react-dom';
import {Head} from '../SharedComponents/Head.jsx';
import {RegisterHeadEdit} from './RegisterHeadEdit.jsx';
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

export class RegisterCore extends React.Component{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('eng');
        this.ajaxModuleOutputRef=null;

        this.bodyInput = [[this.LangPack.Loading]];

        this.tableTitle = [this.LangPack.Register_Number, this.LangPack.Phase, this.LangPack.Title,  this.LangPack.Marka, this.LangPack.CNT_Date, this.LangPack.ABDStatusDate, this.LangPack.SCTR_Resp, this.LangPack.CTR_RESP, this.LangPack.Status, this.LangPack.Package]
        this.colNames = ['Register_Number','Phase','TitleObject_Name','Marka_Name','CNT_Date', 'ABDStatusDate','SCTR_RESP','CTR_RESP','Description_Rus','FileLOG'];
        this.lists={
            Register_ID: new Dictionary(),
            Marka: new Dictionary(),
            Title: new Dictionary(),
            Phase: new Dictionary(),
            Status: new Dictionary()
        }
        this.lists.Marka.add(null, this.LangPack.Loading);
        this.lists.Title.add(null, this.LangPack.Loading);

        this.registerHeadEdit=null;
        this.isLoading = true; //this value is used in the handleScroll method so the Ajax call and table update won't launch twice while updating

        //binding functions
        this.getRegisterStatusList = this.getRegisterStatusList.bind(this);
        this.getTitleObjectList = this.getTitleObjectList.bind(this);
        this.createRegister = this.createRegister.bind(this);
        this.closeRegister = this.closeRegister.bind(this);
        this.getMarkaList  = this.getMarkaList.bind(this);
        this.openRegister = this.openRegister.bind(this);
        this.handleScroll = this.handleScroll.bind(this);
        this.sendFilters = this.sendFilters.bind(this);
        this.tableUpdate = this.tableUpdate.bind(this);
        this.tableClear = this.tableClear.bind(this);

        //FILTERS
        //PLACE NECCESSARY FUNCTIONS HERE TO BE CALLBACK FUNCTIONS:
        this.filterDomain = new FilterDomain(this.sendFilters, 40, this.tableClear); //40 - how many rows will be downloaded each time

        this.filterDomain.add(new Filter('Register_Number',this.LangPack.Register_Number,'text'));
        this.filterDomain.add(new Filter('CNT_Date',this.LangPack.CNT_Date, 'date'));
        this.filterDomain.add(new Filter('CTR_RESP',this.LangPack.CTR_RESP,'text'));
        this.filterDomain.add(new Filter('SCTR_RESP',this.LangPack.SCTR_RESP,'text'));
        this.filterDomain.add(new Filter('ABDStatus_ID',this.LangPack.Status, 'checkDrop'));
        this.filterDomain.add(new Filter('TitleObject_ID',this.LangPack.Title, 'checkDrop'));
        this.filterDomain.add(new Filter('Marka_ID',this.LangPack.Marka, 'checkDrop'));

        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        this.RcFunctions=[];
        this.RcFunctions.push(this.openRegister);

        this.RcNames = [];
        this.RcNames.push(this.LangPack.Open);
    }
    componentDidMount(){
        window.addEventListener("scroll", this.handleScroll);
        
        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectList',
        this.ajaxModuleOutputRef,this.getTitleObjectList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getMarkaList',
        this.ajaxModuleOutputRef,this.getMarkaList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getRegisterStatusList',
        this.ajaxModuleOutputRef,this.getRegisterStatusList);

        this.filterDomain.next();
    }
    componentWillUpdate(){
        this.isLoading = true;
    }
    componentDidUpdate(){
        //try to apply table styling:
        var tableCells = document.getElementsByTagName('td');
        for(var i = 0 ; i<tableCells.length; i++) tableCells[i].style.whiteSpace='nowrap';

        this.isLoading = false;
    }
    render(){
        return(
            <div>
                <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.createRegister}>{this.LangPack.CreateRegister}</button>
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
                {this.registerHeadEdit}
            </div>
        );
    }
    tableUpdate(response){
        if(response!=null){
            //showing the amount of the result on the page:
            document.getElementById("bottom_element").style.display="block";
            this.resultsFound = this.LangPack.TotalFound+response.resultsFound+" "+this.LangPack.OfRegisters;

            if(this.bodyInput==[] || this.bodyInput[0]==this.LangPack.Loading) 
            {
                this.tableClear();
            }
            if(response.registerList!=null && response.registerList.length>0){
                for(var i =0; i<response.registerList.length; i++){
                    this.bodyInput.push([]); //adding new line
                    var indexLastLine = this.bodyInput.length-1; //getting the index of the last current line in the bodyInput
                    this.lists.Register_ID.add(this.lists.Register_ID.count(), response.registerList[i].Register_ID);
                    this.bodyInput[indexLastLine].push(response.registerList[i].Register_Number);
                    this.bodyInput[indexLastLine].push(response.registerList[i].Phase);
                    this.bodyInput[indexLastLine].push(response.registerList[i].TitleObject_Name_Concatenated);
                    this.bodyInput[indexLastLine].push(response.registerList[i].Marka_Name_Concatenated);
                    this.bodyInput[indexLastLine].push(response.registerList[i].CNT_Date_UINormalized);
                    this.bodyInput[indexLastLine].push(response.registerList[i].ABDStatusDate_UINormalized);
                    this.bodyInput[indexLastLine].push(response.registerList[i].SCTR_RESP);
                    this.bodyInput[indexLastLine].push(response.registerList[i].CTR_RESP);
                    this.bodyInput[indexLastLine].push(response.registerList[i].Description_Rus);
                    this.bodyInput[indexLastLine].push(response.registerList[i].WorkPackage_Name);
                }
            }
            this.forceUpdate(); 
        }
    }
    tableClear(){
        this.lists.Register_ID.clear();
        this.bodyInput = [];
    }
    //this method is binded to scroll event in component did mount method
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
    openRegister(lineId){
        var width = 1048;
        var height = 800;
        var head = lineId? this.LangPack.EditRegister : this.LangPack.CreateRegister;
        var offsetRight = (window.innerWidth - width)/2;
        var offsetTop  = (window.innerHeight - height)/2;
        var zIndex = 99;

        Head.showBlock();
        this.registerHeadEdit = null;
        this.registerHeadEdit = 
            (
                <PopMovable
                    onExit = {this.closeRegister}
                    head={head}
                    MyId={'openRegister'}
                    offsetStyle={{right:offsetRight, top:offsetTop, width:1048, zIndex:zIndex}}
                >
                    <RegisterHeadEdit 
                        inValue={this.lists.Register_ID.valueByIndex(lineId)} 
                        onExit={this.closeRegister}
                        key={ToolKit.shortId()}
                    />
                </PopMovable>
            );
        this.forceUpdate();
    }
    sendFilters(filters){
        console.log(filters);
        this.ajaxModuleOutputRef.sendJson(filters,'/getRegisterList',
        this.ajaxModuleOutputRef,this.tableUpdate);
    }
    createRegister(){
        this.openRegister(null);
    }
    closeRegister(){
        Head.hideBlock();
        this.registerHeadEdit = null;
        this.forceUpdate();
    }
    getTitleObjectList(response){
        if(response){
            this.lists.Title.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.Title.add(response[i].TitleObject_ID, response[i].TitleObject_Name);
            }
            this.filterDomain.addDictionaryToFilter('TitleObject_ID', this.lists.Title);
        }
    }
    getMarkaList(response){
        if(response) {
            this.lists.Marka.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.Marka.add(response[i].Marka_ID, response[i].Marka_Name);
            }
            this.filterDomain.addDictionaryToFilter('Marka_ID', this.lists.Marka);
        }
    }
    getRegisterStatusList(response){ 
        if(response){
            this.lists.Status.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.Status.add(response[i].ABDStatus_ID, response[i].Description_Rus);
            }
            this.filterDomain.addDictionaryToFilter('ABDStatus_ID', this.lists.Status);
        }
    }
}