import React from 'react';
import {FileView} from './FileLoader.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import '../Styles/FileLoader.css';
import {Dictionary} from '../Models/Dictionary.js';
import {LangPack} from '../Service/LangPack.js';

export class FileBar extends React.Component{
    constructor(props){
        super(props);
        this.inValue = this.props.inValue;
        this.LangPack = new LangPack('eng');
        this.files = new Dictionary();
        this.nodes = new Dictionary();

        //binding functions:
        this.createNodes = this.createNodes.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }
    render(){
        this.createNodes();

        if(this.nodes.count()>0) 
        var contains = (
                <table>
                    <thead>
                        <th></th>
                        <th className='fileViewTableHead'>{this.LangPack.FileName}</th>
                        <th className='fileViewTableHead'>{this.LangPack.ModifiedDate}</th>
                        <th></th>
                    </thead>
                    <tbody>{this.nodes.getAllValues()}</tbody>
                </table>
            );
        else var contains = <div className='fileLoaderNoFiles'>{this.LangPack.FilesNotAttached}</div>;

        return (
            <div className='fileBarContainer'>
                <div className='fileLoaderTitle'>{this.LangPack.DocumentFiles}</div>
                {contains}
            </div>
        );
    }
    onDelete(fileStreamId){
        this.nodes.deleteElementByKey(fileStreamId);
        this.files.deleteElementByKey(fileStreamId);
        this.inValue = this.files.getAllValues();
        this.props.callBack(this.inValue);
        this.forceUpdate();
    }
    createNodes(){
        if(this.inValue!=null && this.inValue.length>0){
            for(var i = 0; i<this.inValue.length; i++){
                this.files.add(this.inValue[i].FileTable_Stream_ID, this.inValue[i]);
                this.nodes.add(
                    this.inValue[i].FileTable_Stream_ID,
                    <FileBarView
                        inValue={this.inValue[i]}
                        onDelete={this.onDelete}
                        key={ToolKit.shortId()}
                        isDisabled = {this.props.isDisabled}
                    />
                );
            }
        }
    }
}

class FileBarView extends React.Component{
    constructor(props){
        super(props);

        this.inValue = this.props.inValue;
        this.deleteFile = this.deleteFile.bind(this);
        this.isDisabled = this.props.isDisabled ? true : false;
    }
    render(){
        var styleDisabled = this.isDisabled ? {filter:'grayscale(100%)'} : null;
        var img = FileView.createImage(this.inValue.name);

        var controllElement = <img className='fileViewDelete' style={styleDisabled} onClick={this.deleteFile} src={require('../img/scroll_deselect.png')}/>;
        return(
            <tr className = 'fileViewBarContainer'>
                <td>{img}</td>
                <td> <div className='fileViewName'>{this.inValue.name}</div></td>
                <td className='fileViewSize'>{this.inValue.last_write_time_UINormalized}</td>
                <td>{controllElement}</td>
            </tr>
        );
    }
    deleteFile(){
        if(!this.isDisabled)
        this.props.onDelete(this.inValue.FileTable_Stream_ID);
    }
}
/*
ABDDocument_ID:"81ae8b9c-ae4f-e811-a9db-0050569403d4"
FileTable_Stream_ID:"be542371-1360-e811-a9e9-005056947b15"
file_type:"pdf"
last_write_time:"/Date(1524311691793)/"
last_write_time_UINormalized:"21.04.2018"
name:"3300-33B0100-COW-4-001.pdf"
*/