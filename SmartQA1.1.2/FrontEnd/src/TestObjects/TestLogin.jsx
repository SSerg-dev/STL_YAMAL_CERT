import React from 'react';
import ReactDOM from 'react-dom';
import {LoginCore} from '../Login/LoginCore.jsx';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';
import {LangPack} from '../Service/LangPack.js';

class TestLogin extends React.Component{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('rus');
    }
    render(){
        //try to get the popMovable window to the center of the window:
        var offsetRight = (window.innerWidth - 334)/2;
        var offsetTop  = (window.innerHeight - 400)/2;

        //TODO - other offset style,
        // other MyId parameter
        return(
            <PopMovable
                onExit={()=>{console.log("exiting")}}
                head={this.LangPack.LoginUserProfile}
                MyId={"loginComponent"}
                offsetStyle = {{right:offsetRight, top:offsetTop, width:332}}
            >
                <LoginCore/>
            </PopMovable>
            
        );
    }
}
export function startPage(){
    ReactDOM.render(
        <TestLogin/>
        , document.getElementsByTagName('body')[0]
    );
}