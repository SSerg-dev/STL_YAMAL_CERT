import React from 'react';
import ReactDOM from 'react-dom';
import {Head} from '../SharedComponents/Head.jsx';
import {Bottom} from '../SharedComponents/Bottom.jsx';
import {LangPack} from '../Service/LangPack.js';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import '../Styles/MainMenuStyle.css';

class MainMenu extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');
        this.closePopup = this.closePopup.bind(this);

        this.notAuthentificatedNode = null;
        this.isAuth = (this.props.isAuth!=null && this.props.isAuth=="False") ? true : false;
    }
    componentDidMount(){ 
        if(this.isAuth)
        document.globalPopupRef.showPopup(this.LangPack.UnAuthorisedUser, this.LangPack.MustEnterTheSystem, [this.LangPack.Ok]);
        else this.notAuthentificatedNode = null;
        document.MainMenuRefUpdate = ()=>{this.forceUpdate()};
        /*
        var el = document.getElementsByClassName("mmenu_dropdown-content");
        console.log(el);
        if(!document.isAuth){
            for(var i =0; i<el.length; i++){
                el[i].style.display='none';
            }
        }
        else{
            for(var i =0; i<el.length; i++){
                el[i].style.display='block';
            }
        }
        */
    }
    componentDidUpdate(){
        /*
        var el = document.getElementsByClassName("mmenu_dropdown-content");
        console.log(el);
        if(!document.isAuth){
            for(var i =0; i<el.length; i++){
                el[i].style.display='none';
            }
        }
        else{
            for(var i =0; i<el.length; i++){
                el[i].style.display='block';
            }
        }
        */
    }
    render(){
        var local = '';
        var tpnet = '/SmartPlant';
        var urlHost = tpnet;
        var height  = window.innerHeight; //100+this.lineEditWindows.length*20

        var isDisabled = !document.isAuth;
        //style={{backgroundColor:'rgb(26,128,240)'}}
        //style={{backgroundColor:'rgb(237,28,36)'}}
        //backgroundColor:'rgb(43, 169, 29)',
        var disabledStyle = isDisabled ? {display:"none"} : null;
        return (
        <div className="mmenu_container" style={{height:height}}>
            <Head/>
            <img className="mmenu_background" src={require('../img/background_blur_16.png')}/>
            <div class="mmenu_button_line">
                <div class="mmenu_dropdown">
                    <button class="mmenu_dropbtn" disabled={isDisabled} >{this.LangPack.ABD}</button>
                    <div class="mmenu_dropdown-content" style={disabledStyle}>
                        <a className="mmenu_dd_content_blue" href={urlHost+'/getFinalFolderList'}>{this.LangPack.FoldersAndSets}</a>
                        <a className="mmenu_dd_content_blue" href={urlHost+'/Registers'}>{this.LangPack.Registers}</a>
                    </div>
                </div>
                <button onClick={function(){window.location=urlHost+'/Permission'}} 
                    class="mmenu_dropbtn" 
                    disabled={isDisabled}
                >
                    {this.LangPack.IPD}
                </button>
                <div class="mmenu_dropdown">
                    <button class="mmenu_dropbtn" disabled={isDisabled} >{this.LangPack.ReferenceDocumentation}</button>
                    <div class="mmenu_dropdown-content" style={disabledStyle}>
                        <a className="mmenu_dd_content_blue" href={urlHost+'/MarkaDictionary'}>{this.LangPack.Markas}</a>
                        <a className="mmenu_dd_content_blue" href={urlHost+'/TitleObjectDictionary'}>{this.LangPack.TitleObjects}</a>
                        <a className="mmenu_dd_content_blue" href={urlHost+'/LineIsoDictionary'}>{this.LangPack.LineIsoDictionary}</a>
                    </div>
                </div>
                <button onClick={function(){window.location=urlHost+'/Documents'}} 
                    class="mmenu_dropbtn"
                    disabled={isDisabled}
                >
                    {this.LangPack.Documents}
                </button>
            </div>
            <Bottom/>
        </div>
        );
    }
    closePopup(){
        this.notAuthentificatedNode = null;
        this.forceUpdate();
    }
}
export function startPage(isAuth){
    ReactDOM.render(
        <MainMenu isAuth={isAuth}/>
        , document.getElementsByTagName("body")[0]);
        window.onwheel = (event)=> {event.preventDefault()};
}
