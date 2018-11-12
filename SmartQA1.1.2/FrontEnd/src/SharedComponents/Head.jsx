import React from 'react';
import ReactDOM from 'react-dom';
import Switch from "react-switch";

import {LangPack} from '../Service/LangPack.js';
import {LoginCore} from '../Login/LoginCore.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {SettingsPanel} from '../Settings/SettingsPanel.jsx';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';

import '../Styles/HeadStyle.css';

export class Head extends React.Component{
    constructor(props){
        super(props);
    }
    render(){
        return (
            <div className="head_line">
                <img className="head_logo" src={require('../img/logo3.png')}/>
                <SettingsPanel/>
                <LoginCore/>
                <div className='window_block' id='windowBlock'></div>
                <SuperPopupWindow ref={(input)=>document.globalPopupRef=input}/>
            </div>
        );
    }
    static hideBlock(){
        document.getElementById('windowBlock').style.display = 'none';
        document.getElementById('windowBlock').onclick = null;
    }
    //you have to provide showBlock function with the function that has to be called as delegate
    static showBlock(inputFunction){
        console.log("showing block");
        document.getElementById('windowBlock').style.display = 'block';
        document.getElementById('windowBlock').onclick = inputFunction;
    }
}
