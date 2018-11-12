/*
This component has to be supplied with several props to be created:

-> idCol - Name of the ID property of the object
-> nameCol - Name of the Label property of the object
-> callBack - callBack function that'll receive [id, name] parameters (id and name are concatenated with "/" multivalues)
-> inValue - current value [id, name] - also, concatenated with "/" multivalues
-> url - URL of the source
-> style object (optional)
-> disabled (optional)

*/
import React from 'react';
import {Dictionary} from '../Models/Dictionary.js';
import {ToolKit} from '../Service/ToolKit.js';
import '../Styles/AsyncSelect.css';
import {AjaxModule} from './AjaxModule.jsx';
import {Filter} from '../Models/Filter.js';
import {LangPack} from '../Service/LangPack.js';

export class AsyncSelect extends React.Component{
    constructor(props){
        super(props);
        
        this.nodex = new Dictionary();
        this.searchResult = new Dictionary();
        this.searchResultNodes = null;
        this.LangPack = new LangPack('eng');
        this.style = this.props.style;
        this.tooBigResultId = '00000000-0000-0000-0000-000000000000';

        this.createNodes = this.createNodes.bind(this);
        this.delete = this.delete.bind(this);
        this.select = this.select.bind(this);
        this.showSearch = this.showSearch.bind(this);
        this.hideSearch = this.hideSearch.bind(this);
        this.search = this.search.bind(this);
        this.updateSearchDictionary = this.updateSearchDictionary.bind(this);

        this.inValue = new Dictionary();
        if (this.props.inValue != null && this.props.inValue[0] != null && this.props.inValue[1] != null){
            var ids = this.props.inValue[0].split("/");
            var names = this.props.inValue[1].split("/");
            for(var i=0; i<ids.length; i++) this.inValue.add(ids[i], names[i]);
        }
        this.isDisabled = this.props.disabled ? true : false;
        this.createNodes();
    }
    componentDidMount(){

    }
    createNodes(){
        this.nodex.clear();
        for(var i=0; i<this.inValue.count(); i++){
            this.nodex.add(
                this.inValue.keyByIndex(i), 
                <ChosenOption 
                    key={ToolKit.shortId()} 
                    idParam = {this.inValue.keyByIndex(i)} 
                    nameParam = {this.inValue.valueByIndex(i)}
                    delete={this.delete}
                    disabled = {this.isDisabled}
                />
            );
        }
    }
    createSearchResultNodes(){
        var ids = this.searchResult.getAllKeys();
        var names = this.searchResult.getAllValues();
        var nodes = [];
        for(var i=0; i<names.length; i++){
            nodes.push(
                <SearchOption 
                    select={this.select}
                    idParam = {ids[i]}
                    nameParam = {names[i]}
                    key={ToolKit.shortId()}
                />
            );
        }
        if(nodes!=null && nodes.length>0)
            this.searchResultNodes = (
                <div className='asyncSelect_searchResultContainer' id={this.searchNodesId}>
                    {nodes}
                </div>
            );
        else this.searchResultNodes = null;
    }
    render(){
        if(this.isDisabled) this.style = {...this.style, ... {backgroundColor:'rgb(235,235,228)'}};
        var input = this.isDisabled ? null : <input type='text' disabled = {this.isDisabled} placeholder='...' onClick={this.showSearch} onChange={this.search}/>;
        return (
            <div className='asyncSelect_container' style={this.style}>
                <div className='asyncSelect_chosen'></div>
                {this.nodex.getAllValues()}
                {input}
                {this.searchResultNodes}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
    }
    search(event){
        var value = event.target.value;
        if(value ==null || value==''){
            this.hideSearch();
        }
        else{
            var textFilter = new Filter(null, null, 'text');
            textFilter.filterParams[0]=0;
            textFilter.filterParams[1]=value;
            this.ajaxModuleOutputRef.sendJson(textFilter,this.props.url,
            this.ajaxModuleOutputRef,this.updateSearchDictionary);
        }
    }
    updateSearchDictionary(response){
        this.searchResult.clear();
        if(response==null || response.length==0){
            this.searchResult.add(null, this.LangPack.NoResults);
        }
        else{
            for(var i = 0; i< response.length; i++){
                var id = Reflect.get(response[i], this.props.idCol);
                var label = Reflect.get(response[i], this.props.nameCol);
                if(id==this.tooBigResultId)
                label = '. . .';
                this.searchResult.add(id,label);
            }
        }
        this.createSearchResultNodes();
        this.forceUpdate();
    }
    showSearch(event){
        if(this.inValue!=null && this.inValue!=''){
            if(document.onclick) {
                document.onclick();
                document.onclick = null;
            }
            this.createSearchResultNodes();
            this.forceUpdate();
            document.onclick = (this.hideSearch);
        }
    }
    hideSearch(){
        this.searchResultNodes = null;
        this.forceUpdate();
    }
    delete(idParam){
        this.nodex.deleteElementByKey(idParam);
        this.inValue.deleteElementByKey(idParam);
        this.props.callBack(this.inValue.getAllKeys().join("/"));
        this.forceUpdate();
    }
    select(idParam){
        if(!this.inValue.hasKey(idParam) && idParam!=null && idParam!=this.tooBigResultId){
            this.inValue.add(idParam, this.searchResult.valueByKey(idParam));
            this.props.callBack(this.inValue.getAllKeys().join("/"));
            this.createNodes();
            this.forceUpdate();
        }
    }

}
class ChosenOption extends React.Component{
    constructor(props){
        super(props);
        this.idParam = this.props.idParam;
        this.nameParam = this.props.nameParam;
        this.delete = this.delete.bind(this);
        this.isDisabled = this.props.disabled ? true : false;
    }
    render(){
        var disabledStyle = this.isDisabled ? {filter:'grayscale(100%)'} : null;
        return(
            <div className='asyncSelect_optionContainer' style={disabledStyle}>
                <div className='asyncSelect_optionName'>{this.nameParam}</div>
                <div className='asyncSelect_deselect' onClick={this.delete}>
                    <img className='asyncSelect_deselectImg' src={require('../img/close.png')}/>
                </div>
            </div>
        );
    }
    delete(){
        if(!this.isDisabled)
        this.props.delete(this.idParam);
    }
}
class SearchOption extends React.Component{
    constructor(props){
        super(props);
        this.idParam = this.props.idParam;
        this.nameParam = this.props.nameParam;
        this.select = this.select.bind(this);
        this.key = ToolKit.shortId();
    }
    render(){
        return (
            <div key={this.key} className='asyncSelect_choseOption' onClick={this.select}>
                {this.nameParam}
            </div>
        );
    }
    select(event){
        this.props.select(this.idParam);
    }

}