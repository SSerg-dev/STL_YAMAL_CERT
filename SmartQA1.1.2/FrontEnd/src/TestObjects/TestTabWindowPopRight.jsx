import React from 'react';
import ReactDOM from 'react-dom';
import {TabWindow} from '../SharedComponents/TabWindow.jsx';
import {PopRight} from '../SharedComponents/PopRight.jsx';
import '../Styles/tabwindow.css';

export function startPage(){

        this.tabNames = ['Статус 1', 'Статус 2', 'Статус 3'];
        this.tabStyleClass={container:'tabWindowContainer', buttonLine:'tabWindowButtonLine', tabs:'tabWindowTabs'}

        ReactDOM.render(
            
            <PopRight className={"popRight"}>
                <TabWindow  tabNames={this.tabNames} className={this.tabStyleClass}>
                    <div>Tab 1 inside<input type="text"/></div>
                    <div>Tab 2 inside<input type="text"/></div>
                    <div>Tab 3 inside<input type="text"/></div>
                </TabWindow>
            </PopRight>
            , document.getElementsByTagName("body")[0]);
}