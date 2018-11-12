import React from 'react';
import {ToolKit} from '../Service/ToolKit.js';
import {Dictionary} from '../Models/Dictionary.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {ErrorConsole} from '../Settings/ErrorConsole.jsx';
import {LangPack} from '../Service/LangPack.js';
import '../Styles/FileLoader.css';

export class FileLoader extends React.Component{
    constructor(props){
        super(props);

        this.nodes = new Dictionary();
        this.LangPack = new LangPack('eng');

        this.sendFiles = this.sendFiles.bind(this);
        this.deleteFile = this.deleteFile.bind(this);
    }
    render(){
        var isDisabled = this.props.isDisabled;

        if(this.nodes.count()>0) var contains = (
            <table>
                <thead>
                    <th></th>
                    <th className='fileViewTableHead'>{this.LangPack.FileName}</th>
                    <th className='fileViewTableHead'>{this.LangPack.FileSize}</th>
                    <th></th>
                </thead>
                <tbody>{this.nodes.getAllValues()}</tbody>
            </table>
        );
        else
        var contains = <div className='fileLoaderNoFiles'>{this.LangPack.FilesNotUploaded}</div>

        var styleDisabled = isDisabled ? {filter: 'grayscale(100%)', opacity: 0.2} : null;

        return(
            <div className='fileLoaderContainer' style={styleDisabled}>
            <div className='fileLoaderTitle'>{this.LangPack.UploadFiles}</div>
            <label>
                <img src={require('../img/add.png')}className='fileLoaderAddButton'/>
                <input type="file" name="inputUploadFiles" hidden multiple 
                    disabled = {isDisabled}
                    onChange={this.sendFiles}>
                </input>
            </label>
                {contains}
            </div>
        );
    }
    sendFiles(event){
        var files = event.target.files;
        for(var i=0; i<files.length; i++){
            if(this.nodes.hasKey(files[i].name)){
                document.globalPopupRef.showPopup(this.LangPack.ErrorUpload, this.LangPack.TheFile+" "+files[i].name+" "+this.LangPack.FileAlreadyAttached, [this.LangPack.Ok]);
            }
            else{
                this.nodes.add
                (
                    files[i].name,
                    <FileView 
                        key={ToolKit.shortId()} 
                        file = {files[i]}
                        onDelete={this.deleteFile}
                    />
                );
                this.forceUpdate();
            }
        }
    }
    deleteFile(fileName){
        this.nodes.deleteElementByKey(fileName);
        this.forceUpdate();
    }
}
export class FileView extends React.Component{
    constructor(props){
        super(props);
        this.file = this.props.file;
        this.isLoaded = false;
        this.deleteFile = this.deleteFile.bind(this);
        this.showUploadedFile = this.showUploadedFile.bind(this);
    }
    componentDidMount(){
        //sending the file
        var formData = new FormData()
        formData.append('file', this.file);

        this.ajaxModuleOutputRef.sendFiles(formData, '/ABDDocumentUploadFile',
            false, this.showUploadedFile);
    }
    render(){
        if(!this.isLoaded){
            var controllElement = <img className='fileViewControllElement' src={require('../img/fileLoad.gif')}/>;
            var styleLoading = {filter: 'grayscale(100%)', opacity: 0.2};
        }
        else var controllElement = <img className='fileViewDelete' name={this.file.name} onClick={this.deleteFile} src={require('../img/scroll_deselect.png')}/>;

        return(
            <tr className='fileViewContainer' >
                <td style={styleLoading}>{FileView.createImage(this.file.name)}</td>
                <td style={styleLoading}><div className='fileViewName'>{this.file.name}</div></td>
                <td className='fileViewSize' style={styleLoading}>{ToolKit.convertBytesNumber(this.file.size)}</td>
                <td>{controllElement}</td>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </tr>
        )
    }
    deleteFile(){
        //here the interaction with the controller must be shown
        this.ajaxModuleOutputRef.sendRequest("FileName="+this.file.name,'/ABDDocumentDeleteFile',
        this.ajaxModuleOutputRef,this.showSaveResult);
    }
    showUploadedFile(result){
        if(result!=null && result.isValid){
            this.isLoaded = true;
            this.forceUpdate();
        }
        else{
            //ErrorConsole.writeLine("File "+this.file.name+" hasn't been uploaded");
            //document.globalPopupRef.showPopup("File "+this.file.name+" hasn't been uploaded");
            this.props.onDelete();
        }
    }
    showDeleteResult(result){
        console.log(result);
        if(result!=null && result.isValid){
            this.props.onDelete(this.showDeleteResult);
        }
        else{
            //ErrorConsole.writeLine("File "+this.file.name+" hasn't been deleted");
            //document.globalPopupRef.showPopup("File "+this.file.name+" hasn't deleted");
        }
    }
    static createImage(fileName){
        var extension = ToolKit.getFileExtenstion(fileName);
        var imgPath = null;
        if(extension=='xls' || extension=='xlsx' || extension=='csv') imgPath=require('../img/fileIcons/excel.png');
        if(extension=='doc' || extension=='docx') imgPath=require('../img/fileIcons/word.png');
        if(extension=='pdf') imgPath=require('../img/fileIcons/pdf.png');
        if(extension=='png' || extension=='gif' || extension=='img' || extension=='jpeg' || extension=='jpg') imgPath=require('../img/fileIcons/image.png');
        if(extension=='txt' || extension=='rtf') imgPath=require('../img/fileIcons/text.png')
        if(imgPath==null) imgPath=require('../img/fileIcons/unknown.png');
        return <img className='fileViewIcon' src={imgPath} />
    }

}