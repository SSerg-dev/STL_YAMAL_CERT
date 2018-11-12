import React from 'react';
import {LangPack} from '../Service/LangPack.js';
import '../Styles/ButtonPanelStyle.css';

/*this component was created for better visualization of 
buttons that are situated right under the head line.
Also this component was created without any css-styled only
involving js-styling to use this experience for expanding the
futher use of the js-styling*/

export class ButtonPanel extends React.Component{
    constructor(props){
        super(props);
        this.goToMainMenu = this.goToMainMenu.bind(this);
        this.LangPack = new LangPack('eng');
    }
    render(){
        return(
            <div className = 'buttonPanelLineStyling'>
            <div className = 'buttonPanelPanetStyling'>
                <button className = 'buttonPanelHomeStyling' onClick={this.goToMainMenu}><div className='buttonPanelHomeSelector'></div>{this.LangPack.HomeButton}</button>
                {this.props.children}
            </div>
            </div>
        );
    }
    goToMainMenu(){
        var local = '';
        var tpnet = '/SmartPlant';
        var url = tpnet;
        window.location = url+'/mainMenuReact';
    }

}

