import React from 'react';
import {TableReadonly} from './TableReadonly.jsx';
import {ActiveHeadCell} from './ActiveHeadCell.jsx';

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
