import React from 'react';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';

export class TestAjaxModule extends React.Component{
    constructor(props){
        super(props);
        this.state={
            valueOut:null
        };
        this.ajaxModuleOutputRef=null;

        //binding neccessary functions:
        this.sendWait = this.sendWait.bind(this);
        this.showFakeError = this.showFakeError.bind(this);
        this.sendNoParamsOkUrl = this.sendNoParamsOkUrl.bind(this);
        this.sendOkParamsNoUrl = this.sendOkParamsNoUrl.bind(this);
        this.sendOkParamsOkUrl = this.sendOkParamsOkUrl.bind(this);
        this.sendOkParamsOkUrlDelay = this.sendOkParamsOkUrlDelay.bind(this);
    }
    render(){
        return (<div>
                    <p>Testing AjaxModule</p>
                    <button onClick={this.sendWait}>Throw ajax module waiting</button>
                    <button onClick={this.showFakeError}>Show fake 400 error window</button>
                    <button onClick={this.sendNoParamsOkUrl}>Send ajax request with no parameters to ok url</button>
                    <button onClick={this.sendOkParamsNoUrl}>Send ajax request to bad url</button>
                    <button onClick={this.sendOkParamsOkUrl}>Send ajax ok params and ok result without delay</button>
                    <button onClick={this.sendOkParamsOkUrlDelay}>Send ajax request knocking to controller with Thread.sleep</button>
                    <div>OutPut: {this.state.valueOut}</div>
                    <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
                </div>
                    );
    }
    //test function that throws ajax module into waiting state
    sendWait(){
        this.ajaxModuleOutputRef.showWaiting();
        setTimeout(this.ajaxModuleOutputRef.clearAjaxComponent, 2000);
    }
    //test function that shows fake test window
    showFakeError(){
        this.ajaxModuleOutputRef.showError400();
    }
    //test function sending no post-parameters to ok url
    sendNoParamsOkUrl(){
        this.ajaxModuleOutputRef.sendRequest(
            "",
            'http://localhost:61108/ajaxtestRequest',
            function(){}
        );
    }
    //test function trying to send parameters to bad url
    sendOkParamsNoUrl(){
        this.ajaxModuleOutputRef.sendRequest(
            "",
            'http://localhost:61108/invalidUrl',
            function(){}
        );
    } 
    //test function sending ok parameters and receiving ok result
    sendOkParamsOkUrl(){
        this.ajaxModuleOutputRef.sendRequest(
            "testParams=Knocking from Node.js and React",
            'http://localhost:61108/ajaxtestRequest',
            function(){}
        );
    }
    //test function that knocks to the controller with Thread.sleep
    sendOkParamsOkUrlDelay(){
        this.ajaxModuleOutputRef.sendRequest(
            "testParams=Knocking from Node.js and React",
            'http://localhost:61108/ajaxtestRequestDelay',
            function(){}
        );
    }
}
