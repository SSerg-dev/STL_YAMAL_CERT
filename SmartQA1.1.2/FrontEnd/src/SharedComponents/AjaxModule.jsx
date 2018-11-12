import React from 'react';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import '../Styles/AjaxModule.css';

export class AjaxModule extends React.Component{
    /* TODO - specify functions for all possible http errors*/

    /*This class requires when implementing:
    -> it's own component where the component will show errors, systemInProcess and other output
    -> params, of course

    -> requested url
    -> function to do when result is finally achieve (update, render, change value etc);
    */
    constructor(props){
        super(props);
        this.state={
            nodes:null
        };
        //binding neccessary functions:
        this.sendRequest = this.sendRequest.bind(this);
        this.showWaiting = this.showWaiting.bind(this);
        this.showError = this.showError.bind(this);
        this.clearAjaxComponent = this.clearAjaxComponent.bind(this);

        var local = '';
        var tpnet = '/SmartPlant';
        this.urlHost = tpnet;
    }
    componentDidMount(){
    }
    render(){
        return(<div>{this.state.nodes}</div>);
    }
    sendRequest(postParam, requestUrl, ajaxComponent, onResult){
        //console.log("Sending request here "+requestUrl);
        var result;
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.onreadystatechange = ()=>{
            this.clearAjaxComponent();
            if(xmlHttp.status==0) this.showError("Error: no response came from server. Request timed out");
            if(xmlHttp.status==400) this.showError("Error 400: bad request");
            if(xmlHttp.status==404) this.showError("Error 404: invalid Url");
            if (xmlHttp.status == 200 && xmlHttp.readyState == XMLHttpRequest.DONE) 
            {
                if(xmlHttp.response=='') {
                    console.log("Empty response: "+xmlHttp.response);
                    onResult(null)}
                else onResult(JSON.parse(xmlHttp.response));
                this.clearAjaxComponent();
            }
            //if(xmlHttp.status==200) onResult(JSON.parse('[["778c4fb9-2cf6-4db5-86bb-0001e1b02619","3300-33T1700-АВК-4"]]'));
            //input.innerHTML = JSON.parse(xmlHttp.responseText);
            //input.innerHTML = xmlHttp.responseText;
        }
        xmlHttp.open("POST", this.urlHost+requestUrl, true);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlHttp.send(postParam);
        this.showWaiting();
    }
    //method in development
    sendRequestSync(postParam, requestUrl, ajaxComponent, onResult){
        console.log("Sending request here "+requestUrl);
        var result;
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.open("POST", this.urlHost+requestUrl, false);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlHttp.send(postParam);
        this.showWaiting();
        if(xmlHttp.status==0) this.showError("Error: no response came from server. Request timed out");
        if(xmlHttp.status==400) this.showError("Error 400: bad request");
        if(xmlHttp.status==404) this.showError("Error 404: invalid Url");
        if (xmlHttp.status == 200 && xmlHttp.readyState == XMLHttpRequest.DONE) 
        {
            if(xmlHttp.response=='') {
                console.log("Empty response: "+xmlHttp.response);
                onResult(null)}
            else onResult(JSON.parse(xmlHttp.response));
            
        }
        //if(xmlHttp.status==200) onResult(JSON.parse('[["778c4fb9-2cf6-4db5-86bb-0001e1b02619","3300-33T1700-АВК-4"]]'));
        //input.innerHTML = JSON.parse(xmlHttp.responseText);
        //input.innerHTML = xmlHttp.responseText;
        this.clearAjaxComponent();
    }
    sendJson(objectToSend, requestUrl, ajaxComponent, onResult){
        var result;
        //console.log("Sending object to server: "+JSON.stringify(objectToSend));
        this.showWaiting();
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("POST", this.urlHost+requestUrl, true);
        xmlHttp.setRequestHeader("Content-type", "application/json");
        xmlHttp.onreadystatechange = ()=>{
            if(xmlHttp.status==0) this.showError("Error: no response came from server. Request timed out");
            if(xmlHttp.status==400) this.showError("Error 400: bad request");
            if(xmlHttp.status==404) this.showError("Error 404: invalid Url");
            if (xmlHttp.status == 200 && xmlHttp.readyState == XMLHttpRequest.DONE) 
            {
                if(xmlHttp.response=='') {
                    console.log("Empty response: "+xmlHttp.response);
                    onResult(xmlHttp.response);
                }
                else {
                    onResult(JSON.parse(xmlHttp.response));
                }
                this.clearAjaxComponent();
            }
            //if(xmlHttp.status==200) onResult(JSON.parse('[["778c4fb9-2cf6-4db5-86bb-0001e1b02619","3300-33T1700-АВК-4"]]'));
            //input.innerHTML = JSON.parse(xmlHttp.responseText);
            //input.innerHTML = xmlHttp.responseText;
        }
        xmlHttp.send(JSON.stringify(objectToSend));
    }
    sendFiles(postParam, requestUrl, showWaiting, onResult) {
        var result;
        if(showWaiting) this.showWaiting();
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("POST", this.urlHost + requestUrl, true);

        // обработчик для закачки
        /*xmlHttp.upload.onprogress = function (event) {
            onResult(event.loaded + ' / ' + event.total);
        }*/

        xmlHttp.onload = xmlHttp.onerror = () => {
            switch (xmlHttp.status) {
                case 0:
                    this.showError("Error: no response came from server. Request timed out");
                    break;
                case 200:
                    if (xmlHttp.readyState == XMLHttpRequest.DONE) {
                        if (xmlHttp.response == '') {
                            console.log("Empty response: " + xmlHttp.response);
                            onResult(null)
                        }
                        else onResult(JSON.parse(xmlHttp.response));
                        this.clearAjaxComponent();
                    }
                    break;
                case 400:
                    this.showError("Error 400: bad request");
                    break;
                case 404:
                    this.showError("Error 404: invalid Url");
                    break;
                default:
                    this.showError("Error " + xmlHttp.status);
                    break;
            }
        };      
        xmlHttp.send(postParam);
    }
    getFile(postParam, requestUrl, ajaxComponent, onResult) {
        var result;
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = () => {
            switch (xmlHttp.status) {
                case 0:
                    this.showError("Error: no response came from server. Request timed out");
                    break;
                case 200:
                    if (xmlHttp.readyState == XMLHttpRequest.DONE) {
                        if (xmlHttp.response == '') {
                            console.log("Empty response: " + xmlHttp.response);
                            onResult(null, false, null)
                        }
                        else if (xmlHttp.getResponseHeader('Content-Type').indexOf('text/html') == -1)
                            onResult(xmlHttp.response, true, xmlHttp.getResponseHeader('Content-Disposition'));
                        else
                            onResult(xmlHttp.response, false, null);
                        this.clearAjaxComponent();
                    }
                    break;
                case 400:
                    this.showError("Error 400: bad request");
                    break;
                case 404:
                    this.showError("Error 404: invalid Url");
                    break;
                case 500:
                    this.showError("Error 500: Internal Server Error");
                    break;
                default:
                    this.showError("Error " + xmlHttp.status);
                    break;
            }
        };

        xmlHttp.open("POST", this.urlHost + requestUrl, true);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlHttp.responseType = "blob";
        xmlHttp.send(postParam);
        this.showWaiting();
    }
    getHtml(postParam, requestUrl, ajaxComponent, onResult){
        var result;
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = () => 
        {
            onResult(xmlHttp.response);
        }
        
        xmlHttp.open("POST", this.urlHost + requestUrl, true);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlHttp.responseType = "text";
        xmlHttp.send(postParam);
        this.showWaiting();
    }
    showWaiting(){
        var width = 300;
        var height = 200;
        var offsetRight = (window.innerWidth - width)/2; //100+this.markaEdit.length*20
        var offsetTop  = (window.innerHeight - height)/2;
        this.setState({nodes: (
        <div class='AjaxModuleWaiting'>
            <img 
                className ='AjaxModuleLoadingIcon' 
                style={{top:offsetTop, right:offsetRight, width:width, height:height}}
                src={require("../img/loading.gif")}/>
        </div>)});    
    }
    clearAjaxComponent(){
        
        this.setState({nodes: (<div></div>)});
    }
    showError(messageParam){
        this.setState({nodes: (<SuperPopupWindow
                inputFunctions={[this.clearAjaxComponent]}
                messageButtonsList={['Ok']}
                head={"Server error occured"}
                message={messageParam}
                />)});
    }
}