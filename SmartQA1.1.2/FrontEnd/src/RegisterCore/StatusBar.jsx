import React from 'react';
import ReactDOM from 'react-dom';
import {TabWindow} from '../SharedComponents/TabWindow.jsx';
import {PopRight} from '../SharedComponents/PopRight.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import {Dictionary} from '../Models/Dictionary.js';
import {ToolKit} from '../Service/ToolKit.js';
import {LangPack} from '../Service/LangPack.js';
import '../Styles/StatusBar.css';

export class StatusBar extends React.Component{

    constructor(props){
        super(props);

        this.tabNames = ['Статус 1', 'Статус 2', 'Статус 3'];
        this.tabStyleClass={container:'tabWindowContainer', buttonLine:'tabWindowButtonLine', tabs:'tabWindowTabs'};
        this.className ={};
        this.ajaxModuleOutputRef = null;

        this.statusBar = [];
        this.statusDictionary = null;
        this.currentStatus = null;
        this.statusLines = new Dictionary();
        this.LangPack = new LangPack('eng');
        this.lastStatus = null;
        this.activeStatus = null;

        this.prevStatus = this.prevStatus.bind(this);
        this.nextStatus = this.nextStatus.bind(this);
        this.showStatus = this.showStatus.bind(this);
        this.getRegisterStatus = this.getRegisterStatus.bind(this);
        this.createStatusBar = this.createStatusBar.bind(this);
        this.hideStatus = this.hideStatus.bind(this);
        this.checkNullStatus = this.checkNullStatus.bind(this);

        this.callBack = this.props.callBack;
        this.registerStatus = {};
        this.Register_ID = this.props.inValue;
        this.response = null;
    }
    componentDidMount(){
        this.ajaxModuleOutputRef.sendRequest(null,'/getRegisterStatusList',
        this.ajaxModuleOutputRef,(response)=>{this.response=response; this.forceUpdate();});

        if(this.Register_ID!=null)
        {
            var param = 'Register_ID='+this.Register_ID;
            this.ajaxModuleOutputRef.sendRequest(param,'/getRegisterStatusByRegisterId',
            this.ajaxModuleOutputRef,this.getRegisterStatus);
        }
    }
    createStatusBar(){
        this.statusBar = [];
        this.statusDictionary = new Dictionary();
        
        var response = this.response;
        if(this.activeStatus==null) 
        {
            this.activeStatus = "27D9385A-4D7D-4218-AC94-D9B6FF1A5F1A".toLowerCase();
            this.lastStatus = this.activeStatus;
            
        }
        if(response && response.length>0)
        for(var i = 0; i<response.length; i++){
            var isActive = this.activeStatus==response[i].ABDStatus_ID;
            this.statusDictionary.add(response[i].ABDStatus_ID, null);
            this.statusBar.push(
            <div 
                key={ToolKit.shortId()}
                style={{backgroundColor: isActive?'rgb(194, 230, 193)':null}}
                className='status_head' 
                id={response[i].ABDStatus_ID} 
                onMouseEnter={this.showStatus}
                onMouseLeave={this.hideStatus}
                >
                    {response[i].Description_Eng}
            </div>
            );
        }
        this.callBack(this.activeStatus);
        return this.statusBar;
    }
    render(){
        return(
            <div className='status_line'>
                <div>{this.createStatusBar()}</div>
                {this.currentStatus}
                <div className='status_changePanel'>
                    <button onClick={this.prevStatus} className='status_prev'><p></p></button>
                    <button onClick={this.nextStatus} className='status_next'><p></p></button>
                    <div className='status_null'>
                        <input type='checkbox' onChange={this.checkNullStatus} key={ToolKit.shortId()} checked={this.activeStatus=='433CCBE4-9790-4C63-B3D3-A1B8F1EFA024'.toLowerCase()}/>
                        <p>{this.LangPack.AnnulledRegister}</p>
                    </div>
                </div>
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div> 
        );
    }
    showStatus(event){
        if(this.statusLines.hasKey(event.target.id)) 
        this.currentStatus = <div className='status_current' Key={ToolKit.shortId()}>{this.statusLines.valueByKey(event.target.id)}</div>;
        this.forceUpdate();
    }
    hideStatus(){
        this.currentStatus = null;
        this.forceUpdate();
    }
    prevStatus(){
        if(this.activeStatus!='433CCBE4-9790-4C63-B3D3-A1B8F1EFA024'.toLowerCase()){
            var index=this.statusDictionary.indexByKey(this.activeStatus);
            if(index>0) this.activeStatus = this.statusDictionary.keyByIndex(index-1);
        }
        this.callBack(this.activeStatus);
        this.forceUpdate();
    }
    nextStatus(){
        if(this.activeStatus!='433CCBE4-9790-4C63-B3D3-A1B8F1EFA024'.toLowerCase()){
            var index=this.statusDictionary.indexByKey(this.activeStatus);
            if(index<this.statusDictionary.count()-1) this.activeStatus = this.statusDictionary.keyByIndex(index+1);
        }
        this.callBack(this.activeStatus);
        this.forceUpdate();
    }
    checkNullStatus(event){
        if(event.target.checked) 
        this.activeStatus = '433CCBE4-9790-4C63-B3D3-A1B8F1EFA024'.toLowerCase();
        else 
            if(this.lastStatus == '433CCBE4-9790-4C63-B3D3-A1B8F1EFA024'.toLowerCase())
            {
                this.activeStatus = this.statusDictionary.keyByIndex(0);
            }
            else
            {
                this.activeStatus = this.lastStatus;
            }
        this.callBack(this.activeStatus);
        this.forceUpdate();
    }
    getRegisterStatus(response){
        //DELETE THIS MOCK AFTER DEBUGGING
        var mock = [ 	[ 		{ 			"Register_ID":"f10269b6-86dc-e711-a99f-0050569403d4", 			"Register_To_Status_ID":"80a1f9ad-dc31-e811-a9c5-0050569403d4", 			"Created_By":"", 			"Modified_By":"Сидоров", 			"ABDStatusDate_UINormalized":"23.05.2017", 			"ABDStatusDate":"2017-05-23T00:00:00", 			"status": 				{ 					"ABDStatus_ID":"68ff1544-eb67-4874-a711-069e24aaeb1c", 					"Code":"N/A", 					"Description_Eng":"Cancelled", 					"Description_Rus":"Аннулирован" 				} 		}, 		{ 			"Register_ID":"f10269b6-86dc-e711-a99f-0050569403d4", 			"Register_To_Status_ID":"80a1f9ad-dc31-e811-a9c5-0050569403d4", 			"Created_By":"", 			"Modified_By":"Петров", 			"ABDStatusDate_UINormalized":"24.05.2017", 			"ABDStatusDate":"2017-05-23T00:00:00", 			"status": 				{ 					"ABDStatus_ID":"68ff1544-eb67-4874-a711-069e24aaeb1c", 					"Code":"N/A", 					"Description_Eng":"Cancelled", 					"Description_Rus":"Аннулирован" 				} 		} 	], 	[ 		{ 			"Register_ID":"d2cfe1a2-6bd6-4065-840d-afcd1af6f7a6", 			"Register_To_Status_ID":"80a1f9ad-dc31-e811-a9c5-0050569403d4", 			"Created_By":"", 			"Modified_By":"Иванов", 			"ABDStatusDate_UINormalized":"25.05.2017", 			"ABDStatusDate":"2017-05-23T00:00:00", 			"status": 				{ 					"ABDStatus_ID":"eff66d0e-9908-4914-ad2e-b91bc429277b", 					"Code":"N/A", 					"Description_Eng":"Cancelled", 					"Description_Rus":"Аннулирован" 				} 		} 	] ];
        //response = mock;

        this.statusLines= new Dictionary();
        for(var i = 0; i<response.length; i++){
            var current = [];
            
            for(var j = 0; j< response[i].length; j++){
                current.push(
                    <div key={ToolKit.shortId()} className='status_sub_line'>
                        <div className='status_sub_date'>{this.LangPack.StatusDate+response[i][j].ABDStatusDate_UINormalized}</div>
                        <div className='status_sub_name'>{this.LangPack.StatusModifiedBy+response[i][j].Modified_By}</div>
                    </div>
                );
            }
            this.statusLines.add(response[i][0].status.ABDStatus_ID, current);
        }
        this.lastStatus = this.statusLines.getLastKey();
        this.activeStatus = this.lastStatus;
        this.forceUpdate();
    }
}
