import React from 'react';
import {TableOrderBy} from '../SharedComponents/Tables/TableOrderBy.jsx';
import {Filter} from '../Models/Filter.js';
import {FilterLine} from '../SharedComponents/Filters/FilterLine.jsx';
import {FilterDomain} from '../Models/FilterDomain.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Head} from '../SharedComponents/Head.jsx';
import {BottomElement} from '../SharedComponents/BottomElement.jsx';
import {RightMenu} from '../SharedComponents/RightMenu.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {LangPack} from '../Service/LangPack.js';
import {ButtonPanel} from '../SharedComponents/ButtonPanel.jsx';
import {Bottom} from '../SharedComponents/Bottom.jsx';
import '../Styles/FFListCoreStyle.css';

export class  FFListCore extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.ajaxModuleOutputRef=null;

        this.bodyInput = [[this.LangPack.Loading]];

        /*delete this array after testing the table:*/
        this.tableTitle = [this.LangPack.ABDFinalFolder_Name, this.LangPack.CTR_RESP, this.LangPack.StartDate, this.LangPack.TargetDate, this.LangPack.ListCount, this.LangPack.Marka, this.LangPack.Title];
        this.colNames = ['ABDFinalFolder_Name','CTR_RESP','Final_Compilation_Start_Date','Final_Compilation_Target_Date','ListCount', 'Marka_Name','TitleObject_Name'];
        this.lists={
            ABDFinalFolder_ID: new Dictionary(),
            Marka: new Dictionary(),
            Title: new Dictionary()
        }
        this.lists.Marka.add(null, this.LangPack.Loading);
        this.lists.Title.add(null, this.LangPack.Loading);

        var local = '';
        var tpnet = '/SmartPlant';
        this.urlHost = tpnet;

        this.isLoading = true; //this value is used in the handleScroll method so the Ajax call and table update won't launch twice while updating

        //BINDING FUNCTIONS
        this.sendFilters = this.sendFilters.bind(this);
        this.tableClear = this.tableClear.bind(this);
        this.tableUpdate = this.tableUpdate.bind(this);
        this.getMarkaList = this.getMarkaList.bind(this);
        this.getTitleObjectList = this.getTitleObjectList.bind(this);
        this.handleScroll = this.handleScroll.bind(this);
        this.openFolder = this.openFolder.bind(this);
        this.openFolderInNewTab = this.openFolderInNewTab.bind(this);
        this.createFolder = this.createFolder.bind(this);

        //FILTERS
        this.filterDomain = new FilterDomain(this.sendFilters, 40, this.tableClear); //40 - how many rows will be downloaded each time
        this.filterDomain.add(new Filter('ABDFinalFolder_Name',this.LangPack.ABDFinalFolder_Name,'text'));
        this.filterDomain.add(new Filter('Final_Compilation_Start_Date',this.LangPack.StartDate, 'date'));
        this.filterDomain.add(new Filter('Final_Compilation_Target_Date',this.LangPack.TargetDate, 'date'));
        this.filterDomain.add(new Filter('CTR_RESP',this.LangPack.CTR_RESP,'text'));
        this.filterDomain.add(new Filter('TitleObject_ID',this.LangPack.Title, 'checkDrop'));
        this.filterDomain.add(new Filter('Marka_ID',this.LangPack.Marka, 'checkDrop'));

        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        this.RcFunctions=[];
        this.RcFunctions.push(this.openFolder);
        this.RcFunctions.push(this.openFolderInNewTab);

        this.RcNames = [];
        this.RcNames.push(this.LangPack.Open);
        this.RcNames.push(this.LangPack.OpenNewTab);
        }
    componentDidMount(){
        window.addEventListener("scroll", this.handleScroll);

        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectList',
        this.ajaxModuleOutputRef,this.getTitleObjectList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getMarkaList',
        this.ajaxModuleOutputRef,this.getMarkaList);

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
    render(){
        return(
            <div>
                <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.createFolder}>{this.LangPack.Create}</button>
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
            </div>
        );
    }
    tableUpdate(response){
        if(response!=null){
            //showing the amount of the result on the page:
            document.getElementById("bottom_element").style.display="block";
            this.resultsFound = this.LangPack.TotalFound+response.resultsFound+" "+this.LangPack.OfFolders;

            if(this.bodyInput==[] || this.bodyInput[0]==this.LangPack.Loading) 
            {
                this.tableClear();
            }
            if(response.finalFolderList!=null && response.finalFolderList.length>0){
                for(var i =0; i<response.finalFolderList.length; i++){
                    this.bodyInput.push([]); //adding new line
                    var indexLastLine = this.bodyInput.length-1; //getting the index of the last current line in the bodyInput
                    this.lists.ABDFinalFolder_ID.add(indexLastLine, response.finalFolderList[i].ABDFinalFolder_ID);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].ABDFinalFolder_Name);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].CTR_RESP);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].Norm_Final_Compilation_Start_Date);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].Norm_Final_Compilation_Target_Date);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].ListCount);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].Marka_Name);
                    this.bodyInput[indexLastLine].push(response.finalFolderList[i].TitleObject_Name);
                }
            }
            this.forceUpdate();
        }
    }
    tableClear(){
        this.lists.ABDFinalFolder_ID.clear();
        this.bodyInput=[];
    }
    sendFilters(filters){
        this.ajaxModuleOutputRef.sendJson(filters,'/getABDFinalFolderTypedFilteredList',
        this.ajaxModuleOutputRef,this.tableUpdate);
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
    createFolder(){
        document.location = this.urlHost+'/ABDFinalFolder';
    }
    openFolder(lineId){
        document.location = this.urlHost+'/ABDFinalFolder'+'?ABDFinalFolder_ID='+this.lists.ABDFinalFolder_ID.valueByKey(lineId);
    }
    openFolderInNewTab(lineId){
        window.open(this.urlHost+'/ABDFinalFolder'+'?ABDFinalFolder_ID='+this.lists.ABDFinalFolder_ID.valueByKey(lineId));
    }
}