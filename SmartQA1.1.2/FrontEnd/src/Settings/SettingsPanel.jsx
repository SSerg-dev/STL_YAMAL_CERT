import React from 'react';
import ReactDOM from 'react-dom';
import Switch from "react-switch";

import {LangPack} from '../Service/LangPack.js';
import {ErrorConsole} from './ErrorConsole.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';

import '../Styles/SettingsPanel.css';

export class SettingsPanel extends React.Component{
    constructor(props){
        super(props);
        this.showErrorConsole = this.showErrorConsole.bind(this);
        this.hideErrorConsole = this.hideErrorConsole.bind(this);
        this.createSettings = this.createSettings.bind(this);
        this.showHideSettings = this.showHideSettings.bind(this);
        this.changeErrorConsoleState = this.changeErrorConsoleState.bind(this);
        this.isErrorConsoleOn = false;
        this.isWindowShown = false;
        this.errorConsole = null;
    }
    render(){
        var isDisabled = !document.isAuth;

        this.createSettings();
        return (
            <div className = "settingsContainer">
                <button className="settings_button">RUS</button>
                <button className="settings_button">ENG</button>
                <button disabled = {isDisabled} className="settings_button" onClick={this.showHideSettings}>Settings</button>
                {this.errorConsole}
                {this.settings}
            </div>
        );
        //<img className="head_settings" src={require('../img/settings.png')}/>;
    }
    createSettings(){
        if(this.isWindowShown)
            this.settings = 
                <PopMovable 
                    onExit={this.showHideSettings}
                    head={"Settings"}
                    MyId={"setting"}
                    offsetStyle={{right:100, top:100, width:280}}
                >
                    <div className='settingsMenu_container'>
                        <div className="settings_text">Show error logout</div>
                        <div className="settings_selector">
                            <Switch
                                onChange={this.changeErrorConsoleState}
                                checked={this.isErrorConsoleOn}
                                className="react-switch"
                                id="normal-switch"
                                height={20}
                                width={40}
                            />
                        </div>
                    </div>
            </PopMovable>;
        else this.settings = false;
    }
    showHideSettings(){
        this.isWindowShown = !this.isWindowShown;
        this.forceUpdate();
    }
    showErrorConsole(){
        this.isErrorConsoleOn = true;
        this.errorConsole= <ErrorConsole onExit={this.hideErrorConsole}/>
        this.forceUpdate();
    }
    changeErrorConsoleState(isChecked){
        if(isChecked) this.showErrorConsole(); else this.hideErrorConsole();
    }
    hideErrorConsole(){
        this.isErrorConsoleOn = false;
        this.errorConsole= null;
        this.forceUpdate();
    }
} 