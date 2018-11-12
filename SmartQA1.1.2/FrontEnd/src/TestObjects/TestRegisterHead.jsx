import React from 'react';
import ReactDOM from 'react-dom';
import { RegisterHeadEdit } from '../RegisterCore/RegisterHeadEdit';
import {Register} from '../RegisterCore/Register.js';

export function startPage(){
    
    var inputRegister = new Register();
    inputRegister.id = "23141234";
    inputRegister.number = "Register number";
    inputRegister.log_id = "2341234";
    inputRegister.phase = "4";
    inputRegister.title = "Title register";
    inputRegister.unit = "Unit register";
    inputRegister.marka = "Marka register";
    inputRegister.workDescription = 'workDesctrip';
    inputRegister.dateToContractor = '23.12.2017';
    inputRegister.subContractorResp = 'dateInput';

    ReactDOM.render(
        <RegisterHeadEdit inValue={"f10269b6-86dc-e711-a99f-0050569403d4"}/>
        , document.getElementsByTagName("body")[0]);
            
}
