import React from 'react';
import ReactDOM from 'react-dom';
import {FinalFolderCore} from './FinalFolderCore.jsx';

export function startPage(ABDFinalFolder_ID){
    ReactDOM.render(
        <div>
            <FinalFolderCore ABDFinalFolder_ID={ABDFinalFolder_ID}/>
        </div>, document.getElementsByTagName("body")[0]);
}