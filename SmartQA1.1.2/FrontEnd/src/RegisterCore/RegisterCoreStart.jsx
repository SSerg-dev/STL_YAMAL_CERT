import React from 'react';
import ReactDOM from 'react-dom';
import {RegisterCore} from './RegisterCore.jsx';

export function startPage(){
    ReactDOM.render(
        <div>
            <RegisterCore/>
        </div>, document.getElementsByTagName("body")[0]);
}