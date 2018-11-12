import React from 'react';
import ReactDOM from 'react-dom';
import {MileStoneModel} from '../Models/MileStoneModel.js';
import '../Styles/TimeLine.css';

export class TimeLine extends React.Component{
    constructor(props){
        super(props);
        this.model = this.props.inValue;

        this.selectBlock = this.selectBlock.bind(this);
        this.createNodes = this.createNodes.bind(this);
    }
    createNodes(){
        var nodes = [];
        for(var i = 0; i<this.model.countBlocks(); i++)
        {
            nodes.push(
                <div id={this.model.getBlockIdByIndex(i)} onClick={this.selectBlock}>
                    <div class='tml_selector' style={{backgroundColor:this.model.blockByIndex(i).color}}></div>
                    <div class='tml_status_date' style={{color:this.model.blockByIndex(i).color}}>{this.model.blockByIndex(i).date}</div>
                    <div class='tml_status_name' style={{color:this.model.blockByIndex(i).color}}>{this.model.blockByIndex(i).name}</div>
                </div>
            );
            if(i!=this.model.countBlocks()-1)
            if(this.model.blockByIndex(i).isChosen)
            nodes.push(
                <div class='tml_substatus_container'
                    style={{borderColor:this.model.blockByIndex(i).color}}
                >
                    {this.model.blockByIndex(i).subBlock.getAllPairs().map(
                        (subBlockPair)=>{ 
                            return (
                            <div class='tml_substatus_block'
                            style={{borderColor:this.model.blockByIndex(i).color}}
                            >
                                <div class='tml_substatus_date'>{subBlockPair[0]}</div>
                                <div class='tml_substatus_name'>{subBlockPair[1]}</div>
                            </div>
                            );}) }
                </div>
            );
        else  nodes.push(<div class='tml_substatus_container' style={{borderColor:this.model.blockByIndex(i).color}}>&nbsp;&nbsp;</div>);
        }
        return nodes;
    }
    render(){
        return (
            <div class='tml_container'>
                {this.createNodes()}
            </div>
        );
    }
    selectBlock(event){
        this.model.selectBlock(this.model.getBlockIndexById(event.currentTarget.id));
        this.forceUpdate();
    }
}