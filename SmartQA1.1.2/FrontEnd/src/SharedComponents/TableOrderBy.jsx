import React from 'react';
import {TableReadonly} from './TableReadonly.jsx';
import {LangPack} from '../Service/LangPack.js';
import {Filter} from '../Models/Filter.js';
import {ToolKit} from '../Service/ToolKit.js';

/*this component was made to implement simple TableReadonly with
possibility to sort the table by it's contents

apart from its base TableReadOnly props this table requires 
-> orderByColumns (array of strings that will be placed inside output filter)
-> orderCallBack (function that will be called when user press orderby buttons)
*/
export class TableOrderBy extends TableReadonly{
    createTitleLine(){
        if(this.props.titleLine){
            for(var i=0; i<this.props.titleLine.length; i++)
            this.titleLine.push(
                <ActiveHeadCell colName={this.props.colNames[i]} orderCallBack = {this.props.orderCallBack}>
                    <p>{this.props.titleLine[i]}</p>
                    <i class="arrow_down"></i>
                    {this.childList}
                </ActiveHeadCell>
            );
        }
        else this.titleLine=[];
    }
}
class ActiveHeadCell extends React.Component{
    constructor(props){
        super(props);
        this.showOrderByMenu = this.showOrderByMenu.bind(this);
        this.hideOrderByMenu = this.hideOrderByMenu.bind(this);
        this.orderDesc = this.orderDesc.bind(this);
        this.orderAsc = this.orderAsc.bind(this);
        this.LangPack = new LangPack('rus');
    }
    render(){
        return(
            <th onClick = {this.showOrderByMenu} name='orderbyMenuProducer'>
                {this.props.children}
                {this.orderMenu}
            </th>
        );
    }
    showOrderByMenu(event){
        if(document.onclick) {
            document.onclick();
            document.onclick = null;
        }
        this.orderMenu = (
            <div className = "orderMenuContainer" key = {ToolKit.shortId()}>
                <button className = 'orderMenuButton' onClick={this.orderAsc}>{this.LangPack.OrderByAsc}<i class="arrow_up_in"></i></button>
                <button className = 'orderMenuButton' onClick={this.orderDesc}>{this.LangPack.OrderByDesc}<i class="arrow_down_in"></i></button>
            </div>
        );
        document.onclick = this.hideOrderByMenu;
        this.forceUpdate();
    }
    hideOrderByMenu(){
        this.orderMenu = null;
        this.forceUpdate();
    }
    orderAsc(event){
        var newFilter = new Filter(this.props.colName, null, 'orderBy',null);
        newFilter.filterParams[0] = true;
        event.stopPropagation();
        this.hideOrderByMenu();
        this.props.orderCallBack(newFilter);
    }
    orderDesc(event){
        var newFilter = new Filter(this.props.colName, null, 'orderBy',null);
        newFilter.filterParams[0] = false;
        event.stopPropagation();
        this.hideOrderByMenu();
        this.props.orderCallBack(newFilter);
    }
}