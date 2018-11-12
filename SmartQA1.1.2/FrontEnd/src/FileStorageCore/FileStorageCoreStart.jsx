import React from 'react';
import ReactDOM from 'react-dom';
import { FileStorageCore } from './FileStorageCore.jsx';

export function startPage(){
    ReactDOM.render(
        <div>
            <FileStorageCore/>
        </div>, document.getElementsByTagName("body")[0]);
}