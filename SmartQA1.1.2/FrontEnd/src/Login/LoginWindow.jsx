import React from 'react';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {LangPack} from '../Service/LangPack.js';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import '../Styles/LoginStyle.css';

export class LoginWindow extends React.Component{
    constructor(props){
        super(props);
        this.state={userName:null, userPasswordHidden:''};
        this.ajaxModuleOutputRef=null;
        this.LangPack = new LangPack('rus');
        this.userPassword='';
        this.isPublicKeyAquired = false;

        //rsa variables:
        var RSA = require('react-native-rsa');
        this.rsa = new RSA();

        //binding functions:
        this.changeUserName= this.changeUserName.bind(this);
        this.changeUserPassword = this.changeUserPassword.bind(this);
        this.setPublicKey = this.setPublicKey.bind(this);
        this.validate = this.validate.bind(this);
        this.sendPassword = this.sendPassword.bind(this);
        this.checkLoginResponse = this.checkLoginResponse.bind(this);
        this.onKeyPress = this.onKeyPress.bind(this);
    }
    componentDidMount(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getRSAPublicKeyPassword',
        this.ajaxModuleOutputRef,this.setPublicKey);
    }
    changeUserName(value){
        this.setState({userName:value});
    }
    render(){
        //try to get the popMovable window to the center of the window:
        var offsetRight = (window.innerWidth - 334)/2;
        var offsetTop  = (window.innerHeight - 400)/2;
        
        var isDisabled= this.validate() ? false : true;

        return (
            <PopMovable
                onExit={this.props.onExit}
                head={this.LangPack.LoginUserProfile}
                MyId={"loginWindow"}
                offsetStyle = {{right:offsetRight, top:offsetTop, width:240}}
            >
                <div className='loginContainer' onKeyPress={this.onKeyPress}>
                    <p className='loginName'>{this.LangPack.Login}</p><SuperInput callBack={this.changeUserName} inValue={this.state.userName} />
                    <br/>
                    <p className='loginPassword'>{this.LangPack.Password}</p><SuperInput callBack={this.changeUserPassword} inValue={this.state.userPasswordHidden}/>
                    <button className='loginButton' disabled={isDisabled} onClick={this.sendPassword}>{this.LangPack.EnterTheSystem}</button>
                    <p className='loginMessageWarning'>{this.LangPack.CheckYourUrl}</p>
                    <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                    {this.encryptionResult}
                </div>
            </PopMovable>
        );
        //<button className='loginRegisterButton' disabled={isDisabled} onClick={this.createUser}>{this.LangPack.Register}</button>
    }    
    onKeyPress(event){
        if(event.key=='Enter'){
            this.sendPassword();
        }
    }
    setPublicKey(response){
        this.rsa.setPublicString(response);
        this.isPublicKeyAquired = true;
    }
    changeUserPassword(value){
        var passHidden = '';
        //check if the user pasted the input:
        if(value!=null && (value.length - this.state.userPasswordHidden.length>1)){
            var passHidden = '';
            this.userPassword = value;
            for(var i =0; i<value.length; i++) passHidden +='*';
            this.setState({userPasswordHidden:passHidden});
        }
        else{
            //check if the value from the input became shorter:
            if(value!=null && this.state.userPasswordHidden.length>value.length){
                var passHidden = this.state.userPasswordHidden.substring(0, this.state.userPasswordHidden.length-1);
                this.userPassword = this.userPassword.substring(0, this.userPassword.length-1);
                this.setState({userPasswordHidden:passHidden});
            }
            //check if it has become longer:
            if(value!=null && this.state.userPasswordHidden.length<value.length){
                var passHidden = this.state.userPasswordHidden + '*';
                this.userPassword = this.userPassword+value[value.length-1];
                this.setState({userPasswordHidden:passHidden});
            }
        }
        if(value=='' || value==null){
            this.userPassword = '';
            passHidden = '';
        }
        this.setState({userPasswordHidden:passHidden});
    }
    validate(){
        if
        (
            this.userPassword==null 
            || this.userPassword=='' 
            || this.state.userName==null 
            || this.state.userName ==''
        ) return false;
        
        return true;
    }
    sendPassword(){
        if(this.validate()){
            //encrypting the user password:
            var enc = this.rsa.encrypt(this.userPassword);

            //finally sending user object
            this.ajaxModuleOutputRef.sendJson({Name: this.state.userName, PasswordEncryptedFE: enc},'/login',
            this.ajaxModuleOutputRef,this.checkLoginResponse);
        }
    }
    sendRegistration(){
        if(this.validate()){
            var enc = this.rsa.encrypt(this.userPassword);

            //sending the user object
            this.ajaxModuleOutputRef.sendJson({Name: this.state.userName, PasswordEncryptedFE: enc},'/registerNewUser',
            this.ajaxModuleOutputRef,this.checkLoginResponse);
        }
    }
    checkLoginResponse(LoginResult){
        if(LoginResult!=null){          
            if(!LoginResult.isAuth){
                //show error window in case of inValid authentification:
                if(LoginResult.errorType == 1)
                document.globalPopupRef.showPopup(this.LangPack.Error, this.LangPack.NotValidUserCredentials, [this.LangPack.Ok]);
                if(LoginResult.errorType == 2) 
                document.globalPopupRef.showPopup(this.LangPack.Error, LoginResult.message, [this.LangPack.Ok]);
            }
            else{
                //in case login was succesfull - pass the LoginResult further to parent component
                this.props.callBack(LoginResult);
            }
        }
    }
}