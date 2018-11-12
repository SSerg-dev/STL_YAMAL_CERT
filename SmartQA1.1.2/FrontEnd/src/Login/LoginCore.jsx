import React from 'react';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {LangPack} from '../Service/LangPack.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {LoginWindow} from './LoginWindow.jsx';
import {MainMenuCore} from '../MainMenuCore/MainMenuCore.jsx';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import '../Styles/LoginStyle.css';

export class LoginCore extends React.Component{
    constructor(props){
        super(props);
        this.ajaxModuleOutputRef=null;
        this.LangPack = new LangPack('rus');

        this.user = {
            isAuth:false, 
            userName:null
        };
        
        //binding functions:
        this.showLoginWindow = this.showLoginWindow.bind(this);
        this.hideLoginWindow = this.hideLoginWindow.bind(this);
        this.sendLoginRequest = this.sendLoginRequest.bind(this);
        this.checkLogin = this.checkLogin.bind(this);
        this.sendLogOutRequest = this.sendLogOutRequest.bind(this);
        this.checkLogOutResult = this.checkLogOutResult.bind(this);
    }
    componentDidMount(){
        //check if the user was redirected here from the other pages

        //check if the user is authentificated
        this.sendLoginRequest();
    }
    render(){
        var loginNodes = null;
        var isAuth = this.user.isAuth;
        document.isAuth = isAuth;
        return loginNodes = 
        (
            <div className = 'head_loginBar'>
                <p className = 'head_loginBarUser'>{this.LangPack.User}</p>
                <p className = 'head_loginBarUserAuth'>{isAuth ? this.user.userName : this.LangPack.UnAuthorisedUser}</p>
                <button 
                    onClick = {isAuth ? this.sendLogOutRequest: this.showLoginWindow}
                >
                    {isAuth ? this.LangPack.ExitTheSystem : this.LangPack.EnterTheSystem}
                </button>
                {this.loginWindow}
                {this.popUpWindow}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
        
    }
    showLoginWindow(){
        //just pass the checkLogin function as callback so that LoginWindow can tell this component when to ask for new Login information
        this.loginWindow = (
            <LoginWindow onExit={this.hideLoginWindow} callBack={this.checkLogin}/>
        );
        this.forceUpdate();
    }
    hideLoginWindow(){
        this.loginWindow = null;
        this.forceUpdate();
    }
    //this function asks the server whether the current session is authentificated:
    sendLoginRequest(){
        this.ajaxModuleOutputRef.sendRequest(null,'/checkLogin',
        this.ajaxModuleOutputRef,this.checkLogin);
    }
    checkLogin(loginResult){
        if(loginResult!=null){
            this.user.isAuth = loginResult.isAuth;
            if(this.user.isAuth){
                document.isAuth = true;
                this.user.userName = loginResult.user.Name;
                this.hideLoginWindow();
                console.log('checkLogin successful');
                document.MainMenuRefUpdate();
            }
            this.forceUpdate();
        }
    }
    sendLogOutRequest(){
        this.ajaxModuleOutputRef.sendRequest(null,'/logout',
        this.ajaxModuleOutputRef,this.checkLogOutResult);
    }
    checkLogOutResult(result){
        if(result!=null){
            this.user.isAuth = false;
            this.user.userName = null;
            if(result.errorType==3){
                console.log("CRITICAL ERROR: The user has already logged out");
            }   
            window.location = '.';
        }
    }

}