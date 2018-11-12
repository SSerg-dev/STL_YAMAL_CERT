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
import Iframe from 'react-iframe';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import '../Styles/FileStorage.css';

export class FileStorageCore extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.ajaxModuleOutputRef = null;

        this.bodyInput = [[this.LangPack.Loading]];

        this.tableTitle = [this.LangPack.FileName, this.LangPack.LastWriteTime]//, this.LangPack.FileStatus]
        this.colNames = ['FileName', 'LastWriteTime'];

        this.lists = {
            Stream_Id: new Dictionary()
        }

        this.popUpWindow = null;
        this.isLoading = true; //this value is used in the handleScroll method so the Ajax call and table update won't launch twice while updating
        this.previewNode = null;

        //binding functions
        this.handleScroll = this.handleScroll.bind(this);
        this.openFile = this.openFile.bind(this);
        this.sendFilters = this.sendFilters.bind(this);
        this.tableUpdate = this.tableUpdate.bind(this);
        this.tableClear = this.tableClear.bind(this);
        this.sendFiles = this.sendFiles.bind(this);
        this.clearPopupAfterFilesUpload = this.clearPopupAfterFilesUpload.bind(this);
        this.clearPopup = this.clearPopup.bind(this);
        this.showUploadResult = this.showUploadResult.bind(this);
        this.showDownloadResult = this.showDownloadResult.bind(this);
        this.addSearchInFilesFilter = this.addSearchInFilesFilter.bind(this);
        this.openPreview = this.openPreview.bind(this);
        this.hidePreview = this.hidePreview.bind(this);

        //FILTERS
        //PLACE NECCESSARY FUNCTIONS HERE TO BE CALLBACK FUNCTIONS:
        this.filterDomain = new FilterDomain(this.sendFilters, 40, this.tableClear); //40 - how many rows will be downloaded each time

        this.filterDomain.add(new Filter('FileName', this.LangPack.FileName, 'text'));
        this.filterDomain.add(new Filter('LastWriteTime', this.LangPack.LastWriteTime, 'date'));
        this.filterDomain.add(new Filter(null, null, 'fileContent'));

        //this.filterDomain.add(new Filter('FileStatus', this.LangPack.FileStatus, 'text'));

        //CREATING FUNCTIONS FOR Rc MENU AND NAMES OF BUTTONS
        this.RcFunctions = [];
        this.RcFunctions.push(this.openFile);
        this.RcFunctions.push(this.openPreview);

        this.RcNames = [];
        this.RcNames.push(this.LangPack.Open);
        this.RcNames.push(this.LangPack.OpenFileForPreview);
    }
    addSearchInFilesFilter() {
        var searchInFilesFilter = new Filter(null, null, 'fileContent');
        searchInFilesFilter.filterParams[0] = document.getElementById("searchInFilesField").value;
        this.filterDomain.appendSearchInFilesFilter(searchInFilesFilter);
    }
    componentDidMount(){
        window.addEventListener("scroll", this.handleScroll);
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
                <Head />
                <ButtonPanel>
                    <label className='ff_createnew'><input type="file" name="inputUploadFiles" hidden multiple onChange={this.sendFiles}></input>{this.LangPack.UploadFiles}</label>
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
                {this.previewNode}
                <Bottom infoMessage = {this.ResultsFound}/>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                {this.popUpWindow}
            </div>
        );
    }
    openPreview(lineId){
        var width = 1048;
        var height = 700;
        var offsetRight = (window.innerWidth - width)/2;
        var offsetTop  = (window.innerHeight - height)/2;

        //get URI from Ajax module:
        var domain = this.ajaxModuleOutputRef.urlHost;
        var src = domain+'/GetPreview?Stream_Id='+this.lists.Stream_Id.keyByIndex(lineId);

        Head.showBlock(this.hidePreview);
        this.previewNode = 
        (
            <PopMovable
                onExit={this.hidePreview} 
                head={this.lists.Stream_Id.valueByIndex(lineId)}
                MyId={ToolKit.shortId}
                offsetStyle={{right:offsetRight, top:offsetTop, width:width, height:height, zIndex:100}}
            >
                <iframe src={src}
                    className="fileStorage_iframe"
                    id="myId"
                    display="initial"
                    position="relative"
                />
            </PopMovable>
        );
        this.forceUpdate();
    }
    hidePreview(){
        Head.hideBlock();
        this.previewNode = null;
        this.forceUpdate();
    }

    tableUpdate(response){
        if (response != null) {
            if (response.Error) {
                document.globalPopupRef.showPopup(this.LangPack.Error, response.Error, [this.LangPack.Ok]);
            }
            else {
                //showing the amount of the result on the page:
                document.getElementById("bottom_element").style.display = "block";
                this.ResultsFound = this.LangPack.TotalFound + response.ResultsFound + " " + this.LangPack.OfFiles;

                if (this.bodyInput == [] || this.bodyInput[0] == this.LangPack.Loading) {
                    this.tableClear();
                }
                if (response.fileList != null && response.fileList.length > 0) {
                    for (var i = 0; i < response.fileList.length; i++) {
                        this.bodyInput.push([]); //adding new line
                        var indexLastLine = this.bodyInput.length - 1; //getting the index of the last current line in the bodyInput
                        this.lists.Stream_Id.add(response.fileList[i].Stream_Id, response.fileList[i].FileName);
                        this.bodyInput[indexLastLine].push(response.fileList[i].FileName);
                        this.bodyInput[indexLastLine].push(response.fileList[i].LastWriteTime_UINormalized);
                    }
                }
            }
            this.forceUpdate();
        }
    }
    tableClear() {
        this.lists.Stream_Id.clear();
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
    openFile(lineId) {
        this.ajaxModuleOutputRef.getFile('Stream_Id=' + this.lists.Stream_Id.keyByIndex(lineId), '/DownloadFile',
            this.ajaxModuleOutputRef, this.showDownloadResult);
        //this.forceUpdate();
    }
    sendFilters(filters) {
        this.ajaxModuleOutputRef.sendJson(filters,'/GetFileList',
        this.ajaxModuleOutputRef, this.tableUpdate);
    }
    sendFiles() {
        var input = document.getElementsByName("inputUploadFiles")[0];
        if (input.files.length > 0 && window.FormData !== undefined)
        {
            var form = document.createElement("form");
            form.appendChild(input);
            this.ajaxModuleOutputRef.sendFiles(new FormData(form), '/UploadFiles',
                true, this.showUploadResult);
        }
    }
    clearPopup() {
        this.popUpWindow = null;
        this.forceUpdate();
    }
    clearPopupAfterFilesUpload() {
        this.popUpWindow = null;
        this.forceUpdate();
        document.location.reload(true);
    }
    showUploadResult(response) {
        if (response) {            
            document.globalPopupRef.showPopup(
                response.ErrorCode == 0 ? this.LangPack.UploadFilesSuccess : this.LangPack.UploadFilesError, 
                response.FilesUploadResult, 
                [this.LangPack.Ok]
            );

        this.ajaxModuleOutputRef.sendJson(null, '/GetFileList',
        this.ajaxModuleOutputRef, this.tableUpdate);
        }        
    }
    showDownloadResult(response, isFile, HTTPheader) {
        if (response) {
            if (isFile && HTTPheader!=null) {
                var a = document.createElement('a');
                a.href = URL.createObjectURL(response);
                a.download = decodeURIComponent(HTTPheader.match(/filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/)[1]);
                a.click();
                URL.revokeObjectURL(a.href);
            }
            else
            {
                document.location.assign(URL.createObjectURL(response));
            }
        }
    }
}