import React from 'react';
import ReactDOM from 'react-dom';
import {Cell} from '../Models/Cell.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {ToolKit} from '../Service/ToolKit.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {SuperList} from '../SharedComponents/SuperList.jsx';
import {SuperTable} from '../SharedComponents/Tables/SuperTable.jsx';
import {InputList} from '../SharedComponents/InputList.jsx';
import {ErrorList} from '../SharedComponents/InputWithErrors/ErrorList.jsx';
import {ErrorInputList} from '../SharedComponents/InputWithErrors/ErrorInputList.jsx';
import {BottomElement} from '../SharedComponents/BottomElement.jsx';
import {GuidTable} from '../SharedComponents/Tables/GuidTable/GuidTable.jsx';
import {Head} from '../SharedComponents/Head.jsx';
import {Bottom} from '../SharedComponents/Bottom.jsx';
import {GuidDoubleSelect} from '../SharedComponents/Tables/GuidTable/GuidDoubleSelect.jsx';
import {LangPack} from '../Service/LangPack.js';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import '../Styles/FinalFolderStyle.css';

export class  FinalFolderCore extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('rus');

        //core object:
        this.finalFolder= {
                ABDFinalSet_ID: null,
                ABDFinalSet_Number: null,
                ABDFinalFolder_ID: this.props.ABDFinalFolder_ID, 
                ABDFinalFolder_Name: null,
                TitleObject_Name: null,
                TitleDescriptionRus: null,
                Contragent_ID:null,
                Contragent_Name:null,
                Contragent_DescriptionRus:null,
                MarkaDescriptionRus:null,
                guidArray: [], //used to store guids of documents
                deleteArray: [], //used to store guid of deleted elements
                documentsInFolder:[] //will be used to make up a table
        }

        //models that are send to the server and then are processed by the transaction blocks:
        this.newModel = null;
        this.oldModel = null;

        this.state={popup:null}; //used just to show/hide popup window

        //declaring all dictionaries that will be used by the Core - other components declare their own dictionaries and fill them with Ajax module
        this.lists={
            ABDFinalSet: new Dictionary(),
            ABDFinalFolder: new Dictionary(),
            Contragent: new Dictionary()
        }
        this.lists.ABDFinalSet.add(null, this.LangPack.Loading);
        this.lists.ABDFinalFolder.add(null, this.LangPack.Loading);
        this.lists.Contragent.add(null, this.LangPack.Loading);

        //These are React refs:
        this.ajaxModuleOutputRef=null; 
        this.activeElement=[];

        this.tableComponent=null;

        //why are they here:
        this.tableTitle = [];
        this.lineMatrix = [];
        this.colSize = [];

        //creating object className that will be passed by the component tree: GuidTable -> Lines -> Td -> Input fields
        this.tableClassName={
            tableStyle:['finalFolderTable'],
            td:['finalFolderTdRowNum',
                'finalFolderTdNumInFolder',
                'finalFolderTdStructure',
                'finalFolderTdStructure',
                'finalFolderTdDocumentNumber',
                'finalFolderTdDocumentName',
                'finalFolderTdIssueDate',
                'finalFolderTdNumberInFolder',
                'finalFolderTdTotalSheet'
            ],
            addLineButton: 'finalFolderAddLineButton',
            input:[null, null, 'finalFolderGostPidSelect', 'finalFolderGostPidSelect', null, null, null, null, null, null]
        }

        //binding functions:
        this.getABDFinalSetList=this.getABDFinalSetList.bind(this);
        this.getABDFinalSetByFolder = this.getABDFinalSetByFolder.bind(this); //only for case when ABDFinalFolder_ID!=null
        this.getABDFinalSetProperties=this.getABDFinalSetProperties.bind(this);
        this.getABDFinalFolderList=this.getABDFinalFolderList.bind(this);
        this.getContragentByFolder = this.getContragentByFolder.bind(this); //only for case when ABDFinalFolder_ID!=null
        this.getContragentsList = this.getContragentsList.bind(this);
        this.selectABDFinalSet = this.selectABDFinalSet.bind(this);
        this.selectABDFinalFolder = this.selectABDFinalFolder.bind(this);
        this.createTable = this.createTable.bind(this);
        this.createBufferLine = this.createBufferLine.bind(this);
        this.callBackTable = this.callBackTable.bind(this);
        this.saveABDFinalFolder = this.saveABDFinalFolder.bind(this);
        this.deleteABDFinalFolder = this.deleteABDFinalFolder.bind(this);
        this.updateTable = this.updateTable.bind(this);
        this.createTransactionModel = this.createTransactionModel.bind(this);
        this.hidePopup = this.hidePopup.bind(this);
        this.showResult = this.showResult.bind(this);

    }
    componentDidMount(){
        this.finalFolder.ABDFinalFolder_ID = this.props.ABDFinalFolder_ID;
        console.log(this.finalFolder);
        
        //this dictionary must be downloaded anyway
        this.ajaxModuleOutputRef.sendRequest('','/getABDFinalSetList',
        this.ajaxModuleOutputRef,this.getABDFinalSetList);
        
        //this dictionary must be downloaded anyway
        this.ajaxModuleOutputRef.sendRequest('','/getContragentsList',
        this.ajaxModuleOutputRef,this.getContragentsList);
        
        //here comes the fork: whether ABDFinalFolder_ID is selected or not depends the process of rendering of the window
        if(this.finalFolder.ABDFinalFolder_ID==null) 
        {
            //CREATE FINAL FOLDER
            this.activeElement['ABDFinalSet_Number'].showError(this.LangPack.SelectSet);
            this.activeElement['ABDFinalFolder_Name'].showError(this.LangPack.SelectSet);
            //table have to be shown when editing the existing ABDFinalFolder
            this.createTable();
        }
        else
        {
            //UPDATE FINAL FOLDER
            this.ajaxModuleOutputRef.sendRequest('ABDFinalFolder_ID='+this.finalFolder.ABDFinalFolder_ID,'/getABDFinalSetByFolder',
            this.ajaxModuleOutputRef,this.getABDFinalSetByFolder);

            this.selectABDFinalFolder();

            //this.activeElement['ABDFinalFolder_Name'].setState({readOnly:true}); //setting fields readonly
        }

        this.oldModel = Object.assign({},this.createTransactionModel()); //creating old transaction model in case nothing will be returned

        this.forceUpdate();
    }

    render(){
        //this.updateTable();
        return (
            <div className="finalFolder">
                <Head/>
                <div className='finalFolderTitleLine'>
                    <div>
                        <p>Номер комплекта</p>
                        <ErrorList
                            MyId="ABDFinalSet_Number" 
                            inValue={this.finalFolder.ABDFinalSet_Number} 
                            ArrayOfStrings={this.lists.ABDFinalSet.getAllValues()}
                            callBack={this.selectABDFinalSet}
                            className={'finalFolderInput'}
                            ref={(input)=>{this.activeElement['ABDFinalSet_Number']=input}}
                        />
                        <p>Номер папки</p>
                        <ErrorInputList
                            MyId="ABDFinalFolder_Name" 
                            inValue={this.finalFolder.ABDFinalFolder_Name} 
                            ArrayOfStrings={this.lists.ABDFinalFolder.getAllValues()}
                            callBack={(outValue)=>{this.selectABDFinalFolder(outValue)}}
                            className={'finalFolderInput'}
                            ref={(input)=>this.activeElement['ABDFinalFolder_Name']=input}
                        />
                        <p>Субподрядчик</p>
                        <ErrorList
                            MyId="Contragent" 
                            inValue={this.finalFolder.Contragent_DescriptionRus} 
                            ArrayOfStrings={this.lists.Contragent.getAllValues()}
                            callBack={function(){}}
                            className={'finalFolderInput'}
                            ref={(input)=>this.activeElement['Contragent']=input}
                        />
                    </div>
                    <div>
                        <p>Титульный Объект</p>
                        <div className='finalFolderFalseInput'>{this.finalFolder.TitleDescriptionRus}</div>
                        <p>Тит. номер Объекта</p>
                        <div className='finalFolderFalseInput'>{this.finalFolder.TitleObject_Name}</div>
                        <p>Раздел (дисциплина)</p>
                        <div className='finalFolderFalseInput'>{this.finalFolder.MarkaDescriptionRus}</div>
                    </div>
                    <div className='finalFolderButtonLine'>
                        <button className='finalFolderSaveButton' onClick={this.saveABDFinalFolder}>{this.LangPack.Save}</button>
                        <button className='finalFolderDeleteButton' onClick={this.deleteABDFinalFolder}>{this.LangPack.Delete}</button>
                    </div>
                </div>
                <div>{this.tableComponent}</div>
                <Bottom/>
                {this.state.popup}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div> 
        );
    }
    createBufferLine(lineForTable){
        lineForTable = []; //clear it first
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("guidSingleCheck", null));
        lineForTable.push(new Cell("guidDoubleCheck", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableDateInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        lineForTable.push(new Cell("tableInput", null));
        return lineForTable;
        }
    createTable(response){
        console.log(response);
        if(this.activeElement['Table'])this.activeElement['Table'].clearTable(); //also the table have to be cleared
        this.tableTitle = [this.LangPack.RowNum, this.LangPack.NumberInFolder, this.LangPack.Structure,this.LangPack.Drawing,this.LangPack.ABDDocument_Number,
        this.LangPack.ABDDocument_Name, this.LangPack.ABDDocument_IssueDate, this.LangPack.SheetFolderNumber, this.LangPack.TotalSheets, this.LangPack.Remark];
        this.lineMatrix = ['tableInput', 'tableInput', 'guidSingleCheck', 'guidDoubleCheck', 'tableInput', 'tableInput', 'tableInput', 
        'tableInput', 'tableInput', 'tableInput'];
        this.colSize=['10px','10px','10px','190px','auto','10px','auto',
        '10px','10px','10px','10px','10px','10px','20px'];

        //here this block combines the document items into cells

        this.finalFolder.documentsInFolder = [];
        var lineForTable = []; //this array is used as a buffer for writing the value of the documents
        //stuffing it with the right type of the cell:

        lineForTable = this.createBufferLine(lineForTable);
        
        this.emptyLine = this.createBufferLine(this.emptyLine);
        
        if(response!=null && response.length>0){
            for(var i =0; i<response.length; i++){
                var qa = 0;
                var qb = 0;
                this.finalFolder.guidArray = ToolKit.pushInsideOriginal(this.finalFolder.guidArray, response[i].ABDDocument_ID);
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, this.finalFolder.documentsInFolder.length+1); //0
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].Number_in_Folder); //1
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].Structure_ID); //2
                lineForTable[qa].inValue = ToolKit.pushInsideOriginal(lineForTable[qb].inValue, response[i].PID_ID); //3
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].GOST_ID); //3
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].ABDDocument_Number);//4
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].ABDDocument_Name); //5
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].Issue_Date_Normalized); //6
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].Sheet_Folder_Number); //7
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, response[i].Total_Sheets); //8
                lineForTable[qa++].inValue = ToolKit.pushInsideOriginal(lineForTable[qb++].inValue, ""); //9
                if(!response[i+1] || response[i].ABDDocument_ID!=response[i+1].ABDDocument_ID) {
                    this.finalFolder.documentsInFolder.push(lineForTable);
                    lineForTable = this.createBufferLine(lineForTable);
                }
            }
        } else this.finalFolder.documentsInFolder.push(lineForTable);
        this.oldModel = Object.assign({},this.createTransactionModel());
        this.updateTable();
        
        
        this.forceUpdate();
    }
    
    updateTable(){
        this.tableComponent=null;
        this.tableComponent =(
            <GuidTable
                className={this.tableClassName}
                tableTitle={this.tableTitle} 
                bodyInput={this.finalFolder.documentsInFolder}
                lineMatrix={this.lineMatrix}
                callBack={this.callBackTable}
                createBufferLine={this.createBufferLine}
                guidArray={this.finalFolder.guidArray}
                ref={(input)=>this.activeElement['Table']=input}
            />);
    };
    getABDFinalSetList(response){
        //transparanting the result matrix
        this.lists.ABDFinalSet.clear();
        this.lists.ABDFinalSet.add(null, this.LangPack.NotSelected);
        for(var i=0; i<response.length; i++){ 
            this.lists.ABDFinalSet.add(response[i].ABDFinalSet_ID, response[i].ABDFinalSet_Number);
        }
        this.forceUpdate();
    }
    getABDFinalFolderList(response){
        if(response==null || !response.length>0){
            this.finalFolder.ABDFinalFolder_ID=null;
            this.finalFolder.ABDFinalFolder_Name=null;
            this.lists.ABDFinalFolder.add(null, this.LangPack.NoFolderCreatedYet)
        }
        else{
            this.lists.ABDFinalFolder.clear();
            for(var i=0; i<response.length; i++){
                this.lists.ABDFinalFolder.add(response[i].ABDFinalFolder_ID, response[i].ABDFinalFolder_Name);
            }
            /*also after loading the whole list of folders of this set you have to check if 
            the ABDFinalFolder_ID is not null and choose the appropriate ABDFinalFolder_Name from the list*/
            if(this.finalFolder.ABDFinalFolder_ID!=null)
            if(this.lists.ABDFinalFolder.hasKey(this.finalFolder.ABDFinalFolder_ID))
            this.finalFolder.ABDFinalFolder_Name=this.lists.ABDFinalFolder.valueByKey(this.finalFolder.ABDFinalFolder_ID);
            console.log(this.finalFolder.ABDFinalFolder_ID);
            console.log(this.lists.ABDFinalFolder);
            }
        this.forceUpdate();
    }

    getABDFinalSetProperties(response){
        this.finalFolder.TitleObject_Name=response.TitleObject_Name;
        this.finalFolder.TitleDescriptionRus=response.TitleDescriptionRus;
        this.finalFolder.MarkaDescriptionRus=response.MarkaDescriptionRus;
        
        //retrieving all folder available in this set:
        this.ajaxModuleOutputRef.sendRequest('ABDFinalSet_ID='+this.finalFolder.ABDFinalSet_ID,'/getABDFinalFolderListBySet',
        this.ajaxModuleOutputRef,this.getABDFinalFolderList);

        this.forceUpdate();
    }
    //this method is used to retrieve the requested ABDFinalSet_ID and ABDFinalSet_Number by the provided ABDFinalFolder_ID
    getABDFinalSetByFolder(response){
        if(response!=null)
        {
            this.finalFolder.ABDFinalSet_ID = response[0].ABDFinalSet_ID;
            this.finalFolder.ABDFinalSet_Number = response[0].ABDFinalSet_Number;
            console.log(this.finalFolder.ABDFinalSet_ID);
            //retrieving the other required properties of the ABDFinalSet and filling them in the fields
            this.ajaxModuleOutputRef.sendRequest('ABDFinalSet_ID='+this.finalFolder.ABDFinalSet_ID,'/getABDFinalSetProperties',
            this.ajaxModuleOutputRef,this.getABDFinalSetProperties); //beware - there's a chain: getABDFinalSetProperties -> getABDFinalFolderList

            this.oldModel = Object.assign({},this.createTransactionModel());
        }
    }
    getContragentByFolder(response){
        
        if(response!=null)
        {
            this.finalFolder.Contragent_ID = response[0].Contragent_ID;
            this.finalFolder.Contragent_DescriptionRus = response[0].Description_Rus;
            this.oldModel = Object.assign({},this.createTransactionModel()); 
        }
        else
        {
            this.finalFolder.Contragent_ID=null;
            this.finalFolder.Contragent_DescriptionRus='';
        }
    }
    selectABDFinalSet(value){
        this.lists.ABDFinalFolder.clear();

        if(this.finalFolder.ABDFinalSet_Number!=value)
            if(this.lists.ABDFinalSet.hasValue(value))
            {
                this.finalFolder.ABDFinalSet_Number = value;
                this.finalFolder.ABDFinalSet_ID = this.lists.ABDFinalSet.keyByValue(value);
                this.selectABDFinalFolder('');
            } 
            else alert("Front-end software error, please, contact the developer");

        //uploading title
        
        this.ajaxModuleOutputRef.sendRequest('ABDFinalSet_ID='+this.finalFolder.ABDFinalSet_ID,'/getABDFinalSetProperties',
        this.ajaxModuleOutputRef,this.getABDFinalSetProperties); //chain: getABDFinalSetProperties -> getABDFinalFolderList

        this.forceUpdate();
    }

    selectABDFinalFolder(ABDFinalFolder_Name){
        //in case you came here from the ABDFinalFolder_Name INPUT ELEMENT
        if(ABDFinalFolder_Name!=null) {
        this.finalFolder.ABDFinalFolder_ID=this.lists.ABDFinalFolder.keyByValue(ABDFinalFolder_Name);
        }
        this.finalFolder.ABDFinalFolder_Name=ABDFinalFolder_Name;
        this.finalFolder.Contragent_ID=null;
        this.finalFolder.Contragent_Name =null;
        
        //retrieving the table by folder ID
        this.ajaxModuleOutputRef.sendRequest('ABDFinalFolder_ID='+this.finalFolder.ABDFinalFolder_ID,'/getABDFinalFolderDocuments',
        this.ajaxModuleOutputRef,this.createTable);

        //retrieving the contragent by the ABDFinalFolder_ID:
        this.ajaxModuleOutputRef.sendRequest('ABDFinalFolder_ID='+this.finalFolder.ABDFinalFolder_ID,'/getContragentByFolder',
        this.ajaxModuleOutputRef,this.getContragentByFolder);

        this.oldModel=this.createTransactionModel(); //after you've changed the folder the oldModel have to be updated
    }

    saveABDFinalFolder(){
        return; //DELETE THIS OPERATOR AFTER IMPLEMENTING OK TRANSACTION BLOCKS
        this.newModel = this.createTransactionModel();

        var pairOfTransactionModels = [];
        pairOfTransactionModels.push(this.oldModel);
        pairOfTransactionModels.push(this.newModel);
        console.log(pairOfTransactionModels);
        this.ajaxModuleOutputRef.sendJson(pairOfTransactionModels,'/updateEditFinalFolder',
        this.ajaxModuleOutputRef,this.showResult);
    }
    deleteABDFinalFolder(){
        return; //DELETE THIS OPERATOR AFTER IMPLEMENTING OK TRANSACTION BLOCKS
        this.newModel = null;

        var pairOfTransactionModels = [];
        pairOfTransactionModels.push(this.oldModel);
        pairOfTransactionModels.push(this.newModel);
        this.ajaxModuleOutputRef.sendJson(pairOfTransactionModels,'/updateEditFinalFolder',
        this.ajaxModuleOutputRef,this.showResult);
    }
    showResult(response){
        if(response!=null){
            var message=null;
            var heading=null;
            if(response.didSucceed) {
                message = "Операция произведена успешно";
                heading="Успешно";
                this.finalFolder.ABDFinalFolder_ID = response.returnGuid;
                this.ajaxModuleOutputRef.sendRequest('ABDFinalFolder_ID='+this.finalFolder.ABDFinalFolder_ID,'/getABDFinalSetByFolder',
                this.ajaxModuleOutputRef,this.getABDFinalSetByFolder);

                this.selectABDFinalFolder();
            }
            else {
                message = "Операция не произведена. Ошибка: "+response.errorMessage;
                heading = "Ошибка";
            }
            this.setState({popup: (
                <SuperPopupWindow
                    inputFunctions={[this.hidePopup]}
                    messageButtonsList={['Ok']}
                    head={heading}
                    message={message}
                    />
                )});
        }
    }
    createTransactionModel(){
        var TransactionModelABDFinalFolder = {
            ABDFinalFolder_ID: this.finalFolder.ABDFinalFolder_ID, //guid of the transaction block
            //properties of the transaction block:
            ABDFinalFolder_Name: this.finalFolder.ABDFinalFolder_Name,
            ABDFinalSet_ID: this.finalFolder.ABDFinalSet_ID,
            ABDFinalSet_Number: this.finalFolder.ABDFinalSet_Number,
            TitleObject_Name: this.finalFolder.TitleObject_Name,
            TitleDescriptionRus: this.finalFolder.TitleDescriptionRus,
            Contragent_Name: this.finalFolder.Contragent_Name,
            Contragent_DescriptionRus: this.finalFolder.Contragent_DescriptionRus,
            MarkaDescriptionRus: this.finalFolder.MarkaDescriptionRus,
            Contragent_ID:this.finalFolder.Contragent_ID,
            ListCount: 1,
            ABDFinalFolderItems:[] //child transaction block
        }
        //filling the TransactionModelABDFinalFolder with items
        for(var i=0; i<this.finalFolder.documentsInFolder.length; i++){
            var TransactionModelABDFinalFolder_Item = {
                ABDFinalFolderItem_ID: null, //guid of the transaction block
                //properties of the transaction block:
                RowNumber: null,
                ABDDocument_Number: null,
                ABDDocument_Name: null,
                Issue_Date: null,
                Total_Sheets: null,
                Number_in_Folder: null,
                Sheet_Folder_Number: null,
                Remark: null,
                    Structures:[], //child transaction block
                    ABDFinalFolderItemDrawings:[]
            }
            TransactionModelABDFinalFolder_Item.ABDFinalFolderItem_ID=this.finalFolder.guidArray[i];
            TransactionModelABDFinalFolder_Item.RowNumber = this.finalFolder.documentsInFolder[i][0].inValue[0];
            TransactionModelABDFinalFolder_Item.ABDDocument_Number = this.finalFolder.documentsInFolder[i][4].inValue[0];
            TransactionModelABDFinalFolder_Item.ABDDocument_Name = this.finalFolder.documentsInFolder[i][5].inValue[0];
            TransactionModelABDFinalFolder_Item.Issue_Date = this.finalFolder.documentsInFolder[i][6].inValue[0];
            TransactionModelABDFinalFolder_Item.Total_Sheets = this.finalFolder.documentsInFolder[i][8].inValue[0]
            TransactionModelABDFinalFolder_Item.Number_in_Folder = this.finalFolder.documentsInFolder[i][1].inValue[0];
            TransactionModelABDFinalFolder_Item.Sheet_Folder_Number = this.finalFolder.documentsInFolder[i][1].inValue[0];
            TransactionModelABDFinalFolder_Item.Remark = this.finalFolder.documentsInFolder[i][9];
            //putting structures inside item:
            for(var j=0; j<this.finalFolder.documentsInFolder[i][2].inValue.length; j++){
                //creating brand new transaction model 'Structure'
                var TransactionModelStructure = {
                    ABDFinalFolderItem_to_Structure_ID: null, //guid of the transaction block
                                //properties of the transaction block:
                                Structure_ID: null
                }

                TransactionModelStructure.Structure_ID=this.finalFolder.documentsInFolder[i][2].inValue[j];
                TransactionModelABDFinalFolder_Item.Structures.push(TransactionModelStructure);
            }
            //putting Pid & Gost inside item:
            for(var j=0; j<this.finalFolder.documentsInFolder[i][3].inValue.length; j++){
                //creating brand new transaction model 'Pid & Gost'
                var TransactionModelPidGost = {
                    ABDFinalFolderItemDrawing_ID: null, //guid of the transaction block
                                //properties of the transaction block:
                                Gost_Id: null,
                                Pid_Id: null
                }
                TransactionModelPidGost.Pid_Id=this.finalFolder.documentsInFolder[i][3].inValue[j];
                ++j;
                TransactionModelPidGost.Gost_Id=this.finalFolder.documentsInFolder[i][3].inValue[j];
                TransactionModelABDFinalFolder_Item.ABDFinalFolderItemDrawings.push(Object.assign({},TransactionModelPidGost));
            }
            //console.log(TransactionModelABDFinalFolder_Item);
            TransactionModelABDFinalFolder.ABDFinalFolderItems.push(Object.assign({},TransactionModelABDFinalFolder_Item));
        }
        //also counting total amount of all lists in the folder:
        TransactionModelABDFinalFolder.ListCount = 0;
        if(this.finalFolder.documentsInFolder!=null && this.finalFolder.documentsInFolder.length>0)
        for(var i=0; i<this.finalFolder.documentsInFolder.length; i++)
        if(this.finalFolder.documentsInFolder[i][8]!=null)
        TransactionModelABDFinalFolder.ListCount = +TransactionModelABDFinalFolder.ListCount + +this.finalFolder.documentsInFolder[i][8].inValue[0];
        if(TransactionModelABDFinalFolder.ListCount ==0 || isNaN(TransactionModelABDFinalFolder.ListCount)) TransactionModelABDFinalFolder.ListCount=0;
        return TransactionModelABDFinalFolder;
    }
    callBackTable(bodyInput, guidArray, deleteArray){
        this.finalFolder.documentsInFolder = bodyInput;
        this.finalFolder.guidArray = guidArray;
        this.finalFolder.deleteArray = deleteArray;
        this.updateTable();
        this.forceUpdate();
    }
    getContragentsList(response){
        //here we work with Dictionary methods
        this.lists.Contragent.clear();
        this.lists.Contragent.add(null, this.LangPack.NotSelected);
        for(var i=0; i<response.length; i++){
            this.lists.Contragent.add(response[i].Contragent_ID, response[i].Description_Rus); //this is a good example where we don't need strong typing from the Backend model
        }
        this.forceUpdate();
    }
    hidePopup(){
        this.setState({popup:null});
    }
}