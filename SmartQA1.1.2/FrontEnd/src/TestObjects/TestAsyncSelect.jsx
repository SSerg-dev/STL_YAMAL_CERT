import React from 'react';
import ReactDOM from 'react-dom';
import {AsyncSelect} from '../SharedComponents/AsyncSelect.jsx';

class TestAsyncSelect extends React.Component{
    constructor(props){
        super(props);
        this.showResult = this.showResult.bind(this);
        this.inValue = null;
    }//inValue = {['id1/id2/id3', 'Name1/Name2/Name3']}
    render(){
        return(
            <div>
                <AsyncSelect
                    inValue = {this.inValue}
                    idCol={'PID_ID'}
                    nameCol={'PID_Code'}
                    url = {'/SearchPid'}
                    callBack = {this.showResult}
                    disabled = {true}
                    style={{width:200}}
                />
                <AsyncSelect
                    idCol={'GOST_ID'}
                    nameCol={'GOST_Code'}
                    url = {'/SearchGost'}
                    callBack = {this.showResult}
                    style={{width:200}}
                />
            </div>
        );
    }
    showResult(value){
        console.log(value);
    }
}
export function startPage(){
    ReactDOM.render(
        <TestAsyncSelect/>
        , document.getElementsByTagName('body')[0]
    );
}