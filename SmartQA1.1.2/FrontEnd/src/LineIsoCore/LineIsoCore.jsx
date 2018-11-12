import React from 'react';
import ReactDOM from 'react-dom';
import {ScrollTable} from '../SharedComponents/Tables/ScrollTable.jsx';
import {LangPack} from '../Service/LangPack.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Head} from '../SharedComponents/Head.jsx';
import {ButtonPanel} from '../SharedComponents/ButtonPanel.jsx';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {ErrorConsole} from '../Settings/ErrorConsole.jsx';
import {FilterDomain} from '../Models/FilterDomain.js';
import {Filter} from '../Models/Filter.js';
import {FilterLine} from '../SharedComponents/Filters/FilterLine.jsx';
import {LineIsoResultsFoundBar} from './LineIsoResultsFoundBar.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {LineEdit} from './LineEdit.jsx';
import {IsoEdit} from './IsoEdit.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import {IsoDomainModel} from './IsoDomainModel.js';
import {LineDomainModel} from './LineDomainModel.js';

import '../Styles/LineIso.css';

class LineIsoCore extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.lineBodyInput = [];
        this.isoBodyInput = [];
        this.state = {nodes:null};
        this.resizing = false;

        this.lists={
            lineDictionary: new Dictionary(), //fill this dictionary in getLineList
            lineNameDictionary: new Dictionary(), //fill this dictionary in getLineList
            Marka: new Dictionary(),
            TitleObject: new Dictionary(),
            ProcessPhase: new Dictionary(),
            DesignAreaType: new Dictionary(),
            Phase: new Dictionary()
        };
        this.iso = new IsoDomainModel();
        this.line = new LineDomainModel();

        this.isoEditWindows = [];
        this.lineEditWindows = [];
        
        //binding functions:
        this.hidePopUp = this.hidePopUp.bind(this);
        this.onMouseDown = this.onMouseDown.bind(this);
        this.onMouseUp = this.onMouseUp.bind(this);
        this.resizeColumns = this.resizeColumns.bind(this);

        this.getMarkaList = this.getMarkaList.bind(this);
        this.getTitleObjectList = this.getTitleObjectList.bind(this);
        this.getDesignAreaTypeList = this.getDesignAreaTypeList.bind(this);
        this.getProcessPhaseList = this.getProcessPhaseList.bind(this);
        this.getPhaseList = this.getPhaseList.bind(this);

        this.getSingleLine = this.getSingleLine.bind(this);

        this.deselectLine = this.deselectLine.bind(this);
        this.deselectIso = this.deselectIso.bind(this);

        this.clearLineTable = this.clearLineTable.bind(this);
        this.clearIsoTable = this.clearIsoTable.bind(this);

        this.createIsoFilters = this.createIsoFilters.bind(this);
        this.createLineFilters = this.createLineFilters.bind(this);

        this.closeIsoForEdit = this.closeIsoForEdit.bind(this);
        this.closeLineForEdit = this.closeLineForEdit.bind(this);

        this.selectLine = this.selectLine.bind(this);
        this.selectIso = this.selectIso.bind(this);

        this.selectLineRow = this.selectLineRow.bind(this);
        this.selectIsoRow = this.selectIsoRow.bind(this);

        this.openLineForEditCreate = this.openLineForEditCreate.bind(this);
        this.openIsoForEditCreate = this.openIsoForEditCreate.bind(this);

        this.refreshIsoTable = this.refreshIsoTable.bind(this);
        this.refreshLineTable = this.refreshLineTable.bind(this);

        this.deleteLine = this.deleteLine.bind(this);
        this.deleteIso = this.deleteIso.bind(this);

        this.showDeleteLineResult = this.showDeleteLineResult.bind(this);
        this.showDeleteIsoResult = this.showDeleteIsoResult.bind(this);

        this.showDeleteIso = this.showDeleteIso.bind(this);
        this.showDeleteLine  = this.showDeleteLine.bind(this);

        this.blockIsoFilters = this.blockIsoFilters.bind(this);
        this.blockLineFilters = this.blockLineFilters.bind(this);

        this.unblockIsoFilters = this.unblockIsoFilters.bind(this);
        this.unblockLineFilters = this.unblockLineFilters.bind(this);

        this.getLineList = this.getLineList.bind(this);
        this.getIsoList = this.getIsoList.bind(this);

        this.applyIsoFilters=this.applyIsoFilters.bind(this);
        this.applyLineFilters=this.applyLineFilters.bind(this);

        this.createLineTable = this.createLineTable.bind(this);
        this.createIsoTable = this.createIsoTable.bind(this);

        //FILTERS 
        this.lineFilters = null;
        this.isoFilters = null;
        this.filterDomainLine = new FilterDomain(this.applyLineFilters, 40, this.clearLineTable);
        this.filterDomainIso = new FilterDomain(this.applyIsoFilters, 40, this.clearIsoTable);

        this.scrollLineTable = this.filterDomainLine.next;
        this.scrollIsoTable = this.filterDomainIso.next;
        //filters are created in functions

        //creating ScrollTable props for Lines:
        this.lineTable = this.createLineTable();
        this.isoTable = this.createIsoTable();

        this.createIsoFilters(); 
        this.createLineFilters();
    }
    componentDidMount(){
        this.widthCol1 = Math.round((window.innerWidth - 40)/2);
        this.widthCol2 = this.widthCol1;
        this.totalWidth = this.widthCol1 + this.widthCol2;

        this.filterDomainIso.next();
        this.filterDomainLine.next();
        
        this.ajaxModuleOutputRef.sendRequest(null,'/getTitleObjectList',
        this.ajaxModuleOutputRef,this.getTitleObjectList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getMarkaList',
        this.ajaxModuleOutputRef,this.getMarkaList);

        this.ajaxModuleOutputRef.sendRequest(null,'/GetProcessPhaseList',
        this.ajaxModuleOutputRef,this.getProcessPhaseList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getDesignAreaTypeList',
        this.ajaxModuleOutputRef,this.getDesignAreaTypeList);

        this.ajaxModuleOutputRef.sendRequest(null,'/getPhaseList',
        this.ajaxModuleOutputRef,this.getPhaseList);
    }
    componentDidUpdate(){
        var divider = document.getElementsByClassName('lineIso_resizerContainer')[0];
        var body = document.body, html = document.documentElement;
        var heightDocument = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight );
        divider.style.height = heightDocument - 150;
    }
    //THIS FUNCTION CREATES OBJECT FOR LINE TABLE
    createLineTable(){
        var lineTableProps = {};
        lineTableProps.colNames = [
            "Line_Number",
            "Location_From",
            "Location_To",
            "Fluid_Name_Eng",
            "Fluid_Name_Rus",
            "Fluid_Danger_Code_By_Gost",
            "Fluid_Fire_Aand_Explosive_Hazard",
            "Fluid_Group_By_TP_TC_032_2013",
            "Fluid_Group_By_GOST",
            "Piprline_Category_By_TP_TC_032_2013",
            "Pipeline_Category_By_GOST"
        ];
        lineTableProps.tableTitle = [
            this.LangPack.LineNumber,
            this.LangPack.Location_From,
            this.LangPack.Location_To,
            this.LangPack.Fluid_Name_Eng,
            this.LangPack.Fluid_Name_Rus,
            this.LangPack.Fluid_Danger_Code_By_Gost,
            this.LangPack.Fluid_Fire_Aand_Explosive_Hazard,
            this.LangPack.Fluid_Group_By_TP_TC_032_2013,
            this.LangPack.Fluid_Group_By_GOST_32569_2013,
            this.LangPack.Pipeline_Category_By_TP_TC_032_2013,
            this.LangPack.Pipeline_Category_By_GOST_32569_2013
        ];
        lineTableProps.defaultColumns = [
            "Line_Number",
            "Location_From",
            "Location_To",
            "Fluid_Name_Rus"
        ];
        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        lineTableProps.RcFunctions = [];
        lineTableProps.RcFunctions.push(this.openLineForEditCreate);
        lineTableProps.RcFunctions.push(this.showDeleteLine);
        lineTableProps.RcNames = [];
        lineTableProps.RcNames.push(this.LangPack.Open);
        lineTableProps.RcNames.push(this.LangPack.Delete);        
        return lineTableProps;
    }
    createIsoTable(){
        var isoTableProps = {};
        isoTableProps.colNames = [
            "ISO_Number",
            "TitleObject_Name",
            "Marka_Name",
            "Phase_Name",
            "ProcessPhase_Name",
            "DesignAreaType_Name",
        ];
        isoTableProps.tableTitle = [
            this.LangPack.Iso_Number,
            this.LangPack.Title,
            this.LangPack.Marka,
            this.LangPack.Phase,
            this.LangPack.ProcessPhase,
            this.LangPack.DesignAreaType_Name
        ];
        isoTableProps.defaultColumns = [
            "ISO_Number",
            "TitleObject_Name",
            "Marka_Name",
            "Phase_Name"
        ];
        //CREATING FUNCTIONS FOR RC MENU AND NAMES OF BUTTONS
        isoTableProps.RcFunctions = [];
        isoTableProps.RcFunctions.push(this.openIsoForEditCreate);
        isoTableProps.RcFunctions.push(this.showDeleteIso);
        isoTableProps.RcNames = [];
        isoTableProps.RcNames.push(this.LangPack.Open);
        isoTableProps.RcNames.push(this.LangPack.Delete);        
        return isoTableProps;
    }
    createLineFilters(){
        this.filterDomainLine.add(new Filter("Line_Number", this.LangPack.LineNumber, 'text'));
        this.filterDomainLine.add(new Filter("Location_From", this.LangPack.Location_From, 'text'));
        this.filterDomainLine.add(new Filter("Location_To", this.LangPack.Location_To, 'text'));
        this.filterDomainLine.add(new Filter("Fluid_Name_Rus", this.LangPack.Fluid_Name_Rus, 'text'));
        this.filterDomainLine.add(new Filter("Fluid_Name_Eng", this.LangPack.Fluid_Name_Eng, 'text'));
        this.filterDomainLine.add(new Filter('Fluid_Danger_Code_By_Gost', this.LangPack.Fluid_Danger_Code_By_Gost, 'text'));
        this.filterDomainLine.add(new Filter("Fluid_Fire_Aand_Explosive_Hazard", this.LangPack.Fluid_Fire_Aand_Explosive_Hazard, 'text'));
        this.filterDomainLine.add(new Filter("Fluid_Group_By_TP_TC_032_2013", this.LangPack.Fluid_Group_By_TP_TC_032_2013, 'text'));
        this.filterDomainLine.add(new Filter("Fluid_Group_By_GOST", this.LangPack.Fluid_Group_By_GOST_32569_2013, 'text'));
        this.filterDomainLine.add(new Filter("Piprline_Category_By_TP_TC_032_2013", this.LangPack.Pipeline_Category_By_TP_TC_032_2013, 'text'));
        this.filterDomainLine.add(new Filter("Pipeline_Category_By_GOST", this.LangPack.Pipeline_Category_By_GOST_32569_2013, 'text'));
    }
    createIsoFilters(){
        this.filterDomainIso.add(new Filter("ISO_Number", this.LangPack.Iso_Number, 'text'));
        this.filterDomainIso.add(new Filter("Marka_ID", this.LangPack.Marka, 'checkDrop'));
        this.filterDomainIso.add(new Filter("TitleObject_ID", this.LangPack.Title, 'checkDrop'));
        this.filterDomainIso.add(new Filter("DesignAreaType_ID", this.LangPack.DesignAreaType_Name, 'checkDrop'));
        this.filterDomainIso.add(new Filter("Phase_ID", this.LangPack.Phase, 'checkDrop'));
        this.filterDomainIso.add(new Filter("ProcessPhase_ID", this.LangPack.ProcessPhase, 'checkDrop'));
    }

    render(){
        //which Line is selected?
        var selectedLineNumber = 0; // - get from the appropriate dictionary
        var heightTable = (window.innerHeight - 210);
        return(
            <div>
                <Head/>
                <ButtonPanel>
                    <button className='ff_createnew' onClick={this.openLineForEditCreate}>{this.LangPack.CreateLine}</button>
                </ButtonPanel>
                <div id='lineIso_LineContainer' className = 'lineIso_LineContainer' style={{width:this.widthCol1, height:heightTable}}>
                    <div className='lineIso_FilterBlocker' id='filterLineBlocker'>
                        <FilterLine 
                            filters={this.filterDomainLine.filters} 
                            hasTitles={true} 
                            callBack={this.filterDomainLine.changeFilters}
                        />
                    </div>
                    <ScrollTable
                        name='lineTable'
                        orderCallBack = {this.filterDomainLine.appendOrderByFilter}
                        colNames = {this.lineTable.colNames}
                        titleLine = {this.lineTable.tableTitle}
                        scrollCallBack = {this.scrollLineTable}
                        selectCallBack = {this.selectLine}
                        deselectCallBack = {this.line.isDeselectable ? this.deselectLine: null}
                        createCallBack = {this.line.isCreatable ? this.openLineForEditCreate : null}
                        bodyInput = {this.lineBodyInput}
                        defaultColumns = {this.lineTable.defaultColumns}
                        RcNames = {this.lineTable.RcNames}
                        RcFunctions = {this.lineTable.RcFunctions}
                        tableName={this.line.title}
                        selectedRow={this.line.currentRow}
                        ref={(input)=>this.lineTableRef=input}
                    />
                    <LineIsoResultsFoundBar resultsFound = {this.LangPack.LinesFound+this.line.resultsFound}/>
                </div>
                <div className="lineIso_resizerContainer" style={{height:heightTable}}>
                    <div className="lineIso_resizer" onMouseDown={this.onMouseDown}></div>
                </div>
                <div id='lineIso_IsoContainer' className = 'lineIso_IsoContainer' style={{width:this.widthCol2, height:heightTable}}>
                    <div className='lineIso_FilterBlocker' id='filterIsoBlocker'>
                        <FilterLine
                            filters={this.filterDomainIso.filters}
                            hasTitles={true}
                            callBack={this.filterDomainIso.changeFilters}
                        />
                    </div>
                    <ScrollTable
                        name='isoTable'
                        orderCallBack = {this.filterDomainIso.appendOrderByFilter}
                        colNames = {this.isoTable.colNames}
                        titleLine = {this.isoTable.tableTitle}
                        scrollCallBack = {this.scrollIsoTable}
                        selectCallBack= {this.selectIso}
                        deselectCallBack = {this.iso.isDeselectable ? this.deselectIso : null}
                        createCallBack = {this.iso.isCreatable ? this.openIsoForEditCreate : null}
                        bodyInput = {this.isoBodyInput}
                        defaultColumns = {this.isoTable.defaultColumns}
                        RcNames = {this.isoTable.RcNames}
                        RcFunctions = {this.isoTable.RcFunctions}
                        tableName={this.iso.title}
                        selectedRow={this.iso.currentRow}
                        ref={(input)=>this.isoTableRef=input}
                    />
                    <LineIsoResultsFoundBar resultsFound={this.LangPack.IsosFound+this.iso.resultsFound}/>
                </div>
                <div>{this.lineEditWindows}</div>
                <div>{this.isoEditWindows}</div>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                {this.state.nodes}
            </div>
        );
    }
    onMouseDown(event){
        window.onmousemove = this.resizeColumns;
        window.onmouseup = this.onMouseUp;
    }
    onMouseUp(){
        window.onmouseup = null; 
        window.onmousemove = null; 
        document.mouseX = null;
    }
    resizeColumns(event){
        if(document.mouseX != null){
            var delta = document.mouseX - event.clientX;
            var total = this.widthCol1 + this.widthCol2;
            if(this.widthCol1 < 200){
                this.widthCol1 = 200;
                this.widthCol2 = total - this.widthCol1;
            }
            else{
                if(this.widthCol2 < 200){
                    this.widthCol2 = 200;
                    this.widthCol1 = total - this.widthCol2;
                }
                else{
                    this.widthCol1 = this.widthCol1 - delta;
                    this.widthCol2 = this.widthCol2 + delta;
                }
            }
            this.forceUpdate();
        }
        document.mouseX =  event.clientX;
    }
    selectIso(isoNumber){
        //reload line table only when new iso was selected
        if(this.iso.trySelectNewIso(isoNumber)){
            //check if this line exists and contains the selected iso
            if(this.line.checkIfLineHasIso(this.iso.currentId))
            {
                //if contains - doNothing()
                console.log("doNOthing");
                console.log(this.iso.currentRow);
            }
            else
            {
                //controller request 2 on the diagram
                this.blockLineFilters();
                this.ajaxModuleOutputRef.sendRequest('isoGuid='+this.iso.currentId,'/getLineByIso',
                this.ajaxModuleOutputRef,this.getSingleLine);
                //blockLineFilters() - not implemented
            }
        }
    }
    getSingleLine(singleLine){
        this.clearLineTable();
        if(singleLine!=null && singleLine.lineList && singleLine.lineList.length>0)
        {
            this.line.consumeSingleLine(singleLine);
            this.selectedLine = {};
            this.getLineList(singleLine); //drawing the table with single line
            this.selectLine(0); //select the single line
        }
        else
        {
            //ISO that doesn't belong to any Line
            this.line.deselect();
            this.line.setTitleNotSelected();
            this.lineBodyInput.push([this.LangPack.ErrorsInConsole]);
            ErrorConsole.writeLine(this.LangPack.IsoNotBelongs+this.iso.currentName);
            this.forceUpdate();
        }
    }
    selectLine(lineNumber){
        if(this.line.trySelectNewLine(lineNumber)){
            this.clearIsoTable();
            this.blockIsoFilters();
            this.iso.isCreatable = true;
            this.iso.isDeselectable = true;
            this.iso.setTitleByLineName(this.line.currentName);

            this.ajaxModuleOutputRef.sendRequest('lineGuid='+this.line.currentId,'/getIsosByLine',
            this.ajaxModuleOutputRef,this.getIsoList);
        }
    }
    selectLineRow(lineNumber){
        //this is called on the right click and doesn't cause any updates in this core
        this.line.changeRowSelected(lineNumber);
    }
    selectIsoRow(lineNumber){
        //this is called on the right click and doesn't cause any updates in this core
        this.iso.changeRowSelected(lineNumber);
    }
    applyLineFilters(filters){
        this.isLineDeselectable = false;

        this.ajaxModuleOutputRef.sendJson(filters,'/getLineListDictionary',
        this.ajaxModuleOutputRef,this.getLineList);
    }
    applyIsoFilters(filters){
        this.isoFilters = filters;
        
        this.ajaxModuleOutputRef.sendJson(filters,'/getIsoListDictionary',
        this.ajaxModuleOutputRef,this.getIsoList);
    }
    blockLineFilters(){
        var filterLineContainer = document.getElementById('filterLineBlocker')
        filterLineContainer.onclick = (event)=>event.stopPropagation();
        filterLineContainer.style.opacity = '0.3';
        filterLineContainer.style.filter = 'blur(1px) grayscale(100%)';       
        this.scrollLineTable = ()=>{};
    }
    blockIsoFilters(){
        var filterIsoContainer = document.getElementById('filterIsoBlocker');
        filterIsoContainer.onclick = (event)=>event.stopPropagation();
        filterIsoContainer.style.opacity = '0.3';
        filterIsoContainer.style.filter = 'blur(1px) grayscale(100%)';
        this.scrollIsoTable = ()=>{};
    }
    unblockLineFilters(){
        var filterLineContainer = document.getElementById('filterLineBlocker')
        filterLineContainer.onclick = null;
        filterLineContainer.style.opacity = '1';
        filterLineContainer.style.filter = 'none';   
        this.scrollLineTable = this.filterDomainLine.next; //it's not a call of the function
    }
    unblockIsoFilters(){
        var filterIsoContainer = document.getElementById('filterIsoBlocker');
        filterIsoContainer.onclick = null;
        filterIsoContainer.style.opacity = '1';
        filterIsoContainer.style.filter = 'none';
        this.scrollIsoTable = this.filterDomainIso.next; //it's not a call of the function
    }
    openIsoForEditCreate(isoNumber){
        //first - check if it's create of edit
        var isEdit = !isNaN(isoNumber)? true : false;
        var width = 440;
        var height = 300;
        var offsetRight = (window.innerWidth - width)/2; //100+this.isoEditWindows.length*20
        var offsetTop  = (window.innerHeight - height)/2; //100+this.isoEditWindows.length*20
        Head.showBlock();

        this.iso.trySelectNewIso(isoNumber);
        this.isoEditWindows.push(
            <PopMovable 
                onExit={this.closeIsoForEdit} 
                head={isEdit? this.LangPack.IsoEdit: this.LangPack.CreateIso}
                MyId={this.isoEditWindows.length}
                offsetStyle={{right:offsetRight, top:offsetTop, width:width, zIndex:99}}
            >
                <IsoEdit    
                    selectedLineNumber = {this.line.currentName}
                    key={ToolKit.shortId()}
                    inValue={this.iso.getIdByNumber(isoNumber)}
                    markaOptions={this.lists.Marka}
                    titleObjectOptions={this.lists.TitleObject}
                    designAreaTypeOptions={this.lists.DesignAreaType}
                    processPhaseOptions={this.lists.ProcessPhase}
                    phaseOptions = {this.lists.Phase}
                    MyId = {this.isoEditWindows.length}
                    onExit={this.closeIsoForEdit}
                    onDeleted={this.refreshIsoTable}
                    onSaved={this.refreshIsoTable}
                />
            </PopMovable>
        );
        this.forceUpdate(); 
    }
    openLineForEditCreate(lineNumber){
        var isEdit = !isNaN(lineNumber) ? true: false;
        var width = 795;
        var height = 500;
        var offsetRight = (window.innerWidth - width)/2; //100+this.lineEditWindows.length*20
        var offsetTop  = (window.innerHeight - height)/2; //100+this.lineEditWindows.length*20
        Head.showBlock();

        this.lineEditWindows.push(
            <PopMovable 
                onExit={this.closeLineForEdit} 
                head={isEdit? this.LangPack.LineEdit: this.LangPack.CreateLine}
                MyId={this.lineEditWindows.length}
                offsetStyle={{left:offsetRight, top:offsetTop, width:width, zIndex:99}}
            >
                <LineEdit    
                    key={ToolKit.shortId()}
                    inValue={this.line.getIdByNumber(lineNumber)}
                    MyId = {this.lineEditWindows.length}
                    onExit={this.closeLineForEdit}
                    onDeleted={this.refreshLineTable}
                    onSaved = {this.refreshLineTable}
                />
            </PopMovable>
        );
        this.forceUpdate();
    }
    closeLineForEdit(MyId){
        Head.hideBlock();
        this.lineEditWindows[MyId] = null;
        this.forceUpdate();
    }
    closeIsoForEdit(MyId){
        Head.hideBlock();
        this.isoEditWindows[MyId] = null;
        this.forceUpdate();
    }
    deselectLine(){
        this.line.deselect();
        this.iso.deselect();

        this.isoTableRef.selectedRow = null;
        this.lineTableRef.selectedRow = null;

        this.filterDomainIso.resetRowNumAndSendFiltersAgain();
        this.filterDomainLine.resetRowNumAndSendFiltersAgain();

        this.unblockIsoFilters();
        this.unblockLineFilters();
    }
    deselectIso(){
        this.deselectLine();
    }
    refreshLineTable(){
        this.unblockIsoFilters();
        this.unblockLineFilters();
        this.filterDomainIso.resetRowNumAndSendFiltersAgain();
        this.filterDomainLine.resetRowNumAndSendFiltersAgain();
    }
    refreshIsoTable(){
        if(this.line.isSelected()){
            this.selectLine(this.line.currentRow);
        }
        else this.filterDomainIso.resetRowNumAndSendFiltersAgain();
    }
    showDeleteLine(lineNumber){
        this.line.trySelectNewLine(lineNumber);
        this.lineToDelete = {Line_ID: this.line.getIdByNumber(lineNumber)}
        document.globalPopupRef.showPopup(
            this.LangPack.Warning, 
            this.LangPack.DeleteSureLine + this.line.currentName + "?", 
            [this.LangPack.Ok, this.LangPack.Cancel], 
            [this.deleteLine, ()=>{}]
        );
    }
    showDeleteIso(isoNumber){
        this.iso.trySelectNewIso(isoNumber);
        this.isoToDelete = {ISO_ID: this.iso.getIdByNumber(isoNumber)};
        document.globalPopupRef.showPopup(
            this.LangPack.Warning, 
            this.LangPack.DeleteSureIso + this.iso.currentName + "?", 
            [this.LangPack.Ok, this.LangPack.Cancel], 
            [this.deleteIso, ()=>{}]
        );
    }
    deleteLine(lineNumber){
        this.ajaxModuleOutputRef.sendJson(this.lineToDelete,'/deleteLine',
        this.ajaxModuleOutputRef,this.showDeleteLineResult);
    }
    deleteIso(isoNumber){
        this.ajaxModuleOutputRef.sendJson(this.isoToDelete,'/deleteIso',
        this.ajaxModuleOutputRef,this.showDeleteIsoResult);
    }
    showDeleteLineResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));
            if(result.isValid)
            {
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedLine, [this.LangPack.Ok]);
                this.line.deselect();
                ErrorConsole.WriteLine(this.LangPack.DeletedLine);
                this.refreshLineTable();
            }
            else document.globalPopupRef.showPopup(this.LangPack.ErrorDelete, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
        
            var errors = result.resultSet;
            errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
        }
    }
    showDeleteIsoResult(response){
        if(response!=null){
            var result = JSON.parse(String(response));
            if(result.isValid)
            {
                document.globalPopupRef.showPopup(this.LangPack.Success, this.LangPack.DeletedIso, [this.LangPack.Ok]);
                this.iso.deselect();
                ErrorConsole.writeLine(this.LangPack.DeletedIso);
                this.refreshIsoTable();
            }
            else document.globalPopupRef.showPopup(this.LangPack.ErrorDelete, this.LangPack.ErrorsInConsole, [this.LangPack.Ok]);
        
            var errors = result.resultSet;
            errors.forEach((line)=>ErrorConsole.writeLine("Error Id: "+line.Id+", "+line.Msg));
        }
    }
    clearLineTable(){
        this.line.clear();
        this.lineBodyInput = [];
        this.forceUpdate();
    }
    clearIsoTable(){
        this.iso.clear();
        this.isoBodyInput = [];
        this.forceUpdate();
    }
    getLineList(response){
        if(response!=null && response.lineList){
            for(var i =0 ; i<response.lineList.length; i++){
                var line=[];
                line.push(response.lineList[i].Line_Number);
                line.push(response.lineList[i].Location_From);
                line.push(response.lineList[i].Location_To); 
                line.push(response.lineList[i].Fluid_Name_Eng);
                line.push(response.lineList[i].Fluid_Name_Rus);
                line.push(response.lineList[i].Fluid_Danger_Code_By_Gost);
                line.push(response.lineList[i].Fluid_Fire_Aand_Explosive_Hazard);
                line.push(response.lineList[i].Fluid_Group_By_TP_TC_032_2013);
                line.push(response.lineList[i].Fluid_Group_By_GOST);
                line.push(response.lineList[i].Piprline_Category_By_TP_TC_032_2013);
                line.push(response.lineList[i].Pipeline_Category_By_GOST);
                this.line.add(response.lineList[i].Line_ID, response.lineList[i].Line_Number);
                this.lineBodyInput.push(line); 
            }
            this.line.resultsFound = response.resultsFound;
            this.forceUpdate();
        }
    }
    getIsoList(response){
        this.line.isos.clear();
        if(response!=null && response.isoList){
            for(var i=0; i<response.isoList.length; i++){
                var line=[];
                line.push(response.isoList[i].ISO_Number);
                line.push(response.isoList[i].TitleObject_Name);
                line.push(response.isoList[i].Marka_Name);
                line.push(response.isoList[i].Phase_Name);
                line.push(response.isoList[i].ProcessPhase_Name);
                line.push(response.isoList[i].DesignAreaType_Name);
                this.iso.add(response.isoList[i].ISO_ID, response.isoList[i].ISO_Number);
                this.isoBodyInput.push(line);
            }
            
            this.iso.resultsFound = response.resultsFound;
            //if line is selected than we attach this isoList to it:
            
            if(this.line.isSelected()) this.line.isos = this.iso.dictionary.clone();
            this.forceUpdate();
        }
    }
    hidePopUp(){
        this.setState({nodes:null});   
    }
    getMarkaList(response){
        if(response) {
            this.lists.Marka.clear();  
            for(var i=0; i<response.length; i++) {
                this.lists.Marka.add(response[i].Marka_ID, response[i].Marka_Name);
            }
            this.filterDomainIso.addDictionaryToFilter('Marka_ID', this.lists.Marka);
        }
    }
    getTitleObjectList(response){
        if(response){
            this.lists.TitleObject.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.TitleObject.add(response[i].TitleObject_ID, response[i].TitleObject_Name);
            }
            this.filterDomainIso.addDictionaryToFilter('TitleObject_ID', this.lists.TitleObject);
        }
    }
    getProcessPhaseList(response){
        if(response){
            this.lists.ProcessPhase.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.ProcessPhase.add(response[i].ProcessPhase_ID, response[i].ProcessPhase_Name);
            }
            this.filterDomainIso.addDictionaryToFilter('ProcessPhase_ID', this.lists.ProcessPhase);
        }
    }
    getDesignAreaTypeList(response){
        if(response){
            this.lists.DesignAreaType.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.DesignAreaType.add(response[i].DesignAreaType_ID, response[i].DesignAreaType_Name);
            }
            this.filterDomainIso.addDictionaryToFilter('DesignAreaType_ID', this.lists.DesignAreaType);
        }
    }
    getPhaseList(response){
        if(response){
            this.lists.Phase.clear();
            for(var i=0; i<response.length; i++) {
                this.lists.Phase.add(response[i].Phase_ID, response[i].Phase_Name);
            }
            this.filterDomainIso.addDictionaryToFilter('Phase_ID', this.lists.Phase);
        }
    }
}
export function startPage(){
    ReactDOM.render(
        <div>
            <LineIsoCore/>
        </div>, document.getElementsByTagName("body")[0]);
}
