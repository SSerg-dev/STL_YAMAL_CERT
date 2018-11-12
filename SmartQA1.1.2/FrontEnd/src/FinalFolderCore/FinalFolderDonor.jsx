import React from 'react';
import ReactDOM from 'react-dom';
import {SuperList} from '../SharedComponents/SuperList.jsx';
import {SuperInput} from '../SharedComponents/SuperInput.jsx';
import {DateInput} from '../SharedComponents/DateInput.jsx';
import {RightMenu} from '../SharedComponents/RightMenu.jsx';
import {SuperPopupWindow} from '../SharedComponents/SuperPopupWindow.jsx';
import {RegeditHandlerModule} from './RegeditHandlerModule.jsx';
import {RegeditKeyHandler} from './RegeditKeyHandler.jsx';

import {TestHandlerModule} from '../TestObjects/TestHandlerModule.jsx';
import {TestRegeditKeyHandler} from '../TestObjects/TestRegeditKeyHandler.jsx';
import {TestRCMenuEnvironment} from '../TestObjects/TestRCMenuEnvironment.jsx';
import {TestTableEnvironment} from '../TestObjects/TestTableEnvironment.jsx';
import {TestAjaxModule} from '../TestObjects/TestAjaxModule.jsx';
import {TestFilterWindowEnvironment } from '../TestObjects/TestFilterWindowEnvironment';
import {TestFilterLineEnvironment } from '../TestObjects/TestFilterLineEnvironment';

//have to send this component into another file - component will be used several times
class MiniHead extends React.Component{
    render() {
        return (
        <h2>Our minihead</h2>);
    }
}
class RegTitle extends React.Component {
    render() {
        return(
            <div>
                <h2>Out RegTitle</h2>
                <SuperList MyId='ABDFinalSetList' inValue={this.props.Register.Title.ABDFinalSet} ArrayOfStrings={TestABDFinalSet} callBack={this.props.onClick.ChangeABDFinalSet}/>
                <div>{this.props.Register.Title.ABDFinalFolder}</div>
                <div>{this.props.Register.Title.Company}</div>
                <SuperList MyId='ContragentList' inValue={this.props.Register.Title.Contragent} ArrayOfStrings={TestContragents} callBack={this.props.onClick.ChangeContractor}/>
                <div>{this.props.Register.Title.Plant}</div>
                <div>{this.props.Register.Title.Project}</div>
                <div>{this.props.Register.Title.TitleObjectDsc}</div>
                <div>{this.props.Register.Title.MarkaDesc}</div>
            </div>
        );
    }
}
class RegButtons extends React.Component {
    render() {
        return(
            <div>
                <button onClick={this.props.onClick.CreateNew}>Создать новый реестр</button>
                <button onClick={this.props.onClick.SaveThis}>Сохранить реестр</button>
                <button onClick={this.props.onClick.DeleteThis}>Удалить реестр</button>
            </div>
            );
    }
}
class RegTable extends React.Component {
    render() {
        return(
            <h2>Out RegTable</h2>
            );
    }
}
class RegResp extends React.Component {
    render() {
        return(
            <div>
                <h2>Out RegRest</h2>
                <p>Сдал представитель Субподрядчика</p>
                <SuperInput inValue={this.props.Register.Resp.NameSubContractor} callBack={this.props.onClick.ChangeNameSubContractor}/>
                <DateInput inValue={this.props.Register.Resp.DateSubContractor} callBack={this.props.onClick.ChangeDateSubContractor}/>
                <p>Проверил представитель (Ген.) подрядчика </p>
                <SuperInput inValue={this.props.Register.Resp.NameContractor} callBack={this.props.onClick.ChangeNameContractor}/>
                <DateInput inValue={this.props.Register.Resp.DateContractor} callBack={this.props.onClick.ChangeDateContractor}/>
                <p>Сдал представитель Заказчика</p>
                <SuperInput inValue={this.props.Register.Resp.NameCompany} callBack={this.props.onClick.ChangeNameCompany}/>
                <DateInput inValue={this.props.Register.Resp.DateCompany} callBack={this.props.onClick.ChangeDateCompany}/>
            </div>
        );
    }
}

//this Test models will have to be implemented with JSON requests in JSON Module
var TestABDFinalSet = ['3300-3310001-АВК', '3300-331001-AB', '3300-331-002-TX'];
var TestContragents = ["Nova", "Velesstroy", "Rega"];
var TestRegister = {
    Title : {
        ABDFinalSet: '3300-3310001-ABK',
        ABDFinalFolder: '3300-3310001-ABK-4-008',
        Company: "Yamal-SPG",
        Contragent: "NOVA",
        Plant: "LNG plant construction",
        Project: "LNG plant",
        TitleObjectdex: "Buildings and constructions. Stage 1",
        TitleObjectName: "33-OFD-38",
        MarkaDesc: "Foundations construction"
    },
    Resp : {
        NameSubContractor: 'Производитель работ Зуев Д.А.',
        DateSubContractor: '24.08.2017',
        NameContractor: 'Инженер по надзору за строительством Богданов А.В.',
        DateContractor: '20.09.2017',
        NameCompany: 'Инженер технического надзора Смирнов В.А.',
        DateCompany: '30.10.2017'
    }
}
//to switch between classes and their test implementations just change name of the constructor (add prefix 'Test')
let MyHM = new RegeditHandlerModule(TestRegister);
let MyKH = new RegeditKeyHandler(MyHM);



ReactDOM.render(
            <div>
                <RegTitle Register={TestRegister} onClick ={MyHM.RegTitleOnClick}/>
                <RegButtons onClick={MyHM.RegButtonsOnClick}/>
                <RegTable />
                <RegResp Register={TestRegister} onClick={MyHM.RegRespOnClick}/>
            </div>, document.getElementsByTagName("body")[0]);

//testing right-click menu:
//ReactDOM.render(<TestRCMenuEnvironment/>, document.getElementsByTagName("body")[0]);

//testing table:
var messageButtonsList=['Ok','Cancel'];

var InputFunctions = [
    function() {alert('TEST: 1-st function');},
    function() {alert('TEST: 2-nd function');}
];
document.onkeypress = MyKH.handKeyPressed;
document.onkeydown = MyKH.handKeyDown;



//implement your testing environment here
/*
ReactDOM.render(<TestFilterLineEnvironment/>, 
                document.getElementsByTagName('body')[0]);
*/


