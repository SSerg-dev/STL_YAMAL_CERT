import React from 'react';
import {SuperDropCheck} from '../SharedComponents/SuperDropCheck.jsx';
import {ToolKit} from '../Service/ToolKit.js';
import '../Styles/ColumnDropCheck.css';

export class ColumnDropCheck extends SuperDropCheck{
    alterStyles(){
        this.styles = {}; 
        if(!this.props.styles)
        {
            this.styles.title = 'cdc_title';
            this.styles.checkbox = 'cdc_checkBox'
            this.styles.container = 'cdc_container';
            this.styles.nodesBlock = 'cdc_nodesBlock'
            this.styles.nodes = '';
            this.styles.buttonIn = 'cdc_button';
            this.styles.nodesShow = 'cdc_droplist';
            this.styles.head = 'cfwHeader';
        }
        else
        {
            this.styles = this.props.styles;
            this.styles.nodes = ''; //initial state of the nodes style
        }
    }
    /*
    createNodes(option){
        var nodes = [];
        nodes.push(
        <div className='cdc_buttomLine'>
            <button onClick={this.selectAll} className={this.styles.buttonIn}>{this.langSelectAll}</button>
            <button onClick={this.clearAll} className={this.styles.buttonIn}>{this.langDeselectAll}</button>
        </div>);
        for(var i=0; i<option.length; i++){
            var j=0;
            if(this.props.hasTitles==true) nodes.push(<div className={this.styles}>{option[i][j++]}</div>);
            var columnContent = [];
            var column = (<div className='cdc_column'>{columnContent}</div>);
            for(j; j<option[i].length; j++){
                
                columnContent.push(
                    <div>
                        <input type="checkbox" 
                            className={this.styles.checkbox}
                            value={option[i][j]}
                            onChange={this.toggleCheckBox}
                            checked={this.selectedCheckBoxes.has(option[i][j])}
                            key={ToolKit.shortId()}
                        />
                        {option[i][j]}
                    </div>);
                if((j+1) % this.props.columnHeight == 0 || j==option[i].length-1) 
                {
                    nodes.push(Object.assign({},column));
                    columnContent=[];
                    column = (<div className='cdc_column'>{columnContent}</div>);
                }
            }
        }
        return nodes;
        
    }*/
}