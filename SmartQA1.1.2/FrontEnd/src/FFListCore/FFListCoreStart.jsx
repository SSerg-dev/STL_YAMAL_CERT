import React from 'react';
import ReactDOM from 'react-dom';
import {FFListCore} from './FFListCore.jsx';

export function startPage(){
    ReactDOM.render(
        <div>
            <FFListCore/>
        </div>, document.getElementsByTagName("body")[0]);
}