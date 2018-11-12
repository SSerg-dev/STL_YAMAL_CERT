import React from 'react';
import {LangPack} from '../Service/LangPack.js';
import '../Styles/SuperDropCheck.css';
import {Head} from './Head.jsx';

/*This class is used to create a simple drop-down list with checkboxes
to create a component of this class you have to supply it with these things:

-> name of the list (name) 
-> filtering options (see example in TestFilterWindowEnvironment) (filterOptions)
-> function with one input parameter where the component will send checked options as parameter (onOk)
-> specify if the first string of the string array of filtering options has to interpreted as titles (hasTitles)

*/

export class SuperDropCheck extends React.Component{
    constructor(props){
        super(props);

        this.LangPack = new LangPack('eng');

        this.selectedCheckBoxes=new Set();
        this.nodes = null;

        this.toggleCheckBox = this.toggleCheckBox.bind(this);
        this.selectAll = this.selectAll.bind(this);
        this.clearAll =  this.clearAll.bind(this);
        this.createNodes = this.createNodes.bind(this);
        this.alterStyles = this.alterStyles.bind(this);
        this.showNodes = this.showNodes.bind(this);
        this.hideNodes = this.hideNodes.bind(this);
        
        this.alterStyles();
    }
    /*here we have to create array of style
        variables because practical application of this 
        component strongly depends on the styles involved*/
    alterStyles(){
        if(true){
            this.styles = {}; 
            this.styles.title = 'sdc_title';
            this.styles.checkbox = 'sdc_checkBox'
            this.styles.container = 'sdc_container';
            this.styles.nodesBlock = 'sdc_nodesBlock'
            this.styles.nodes = '';
            this.styles.buttonIn = 'sdc_button';
            this.styles.head = 'sfwHeader';
            this.styles.nodesContanter = 'sdc_nodes_container';
            this.styles.listButtonStyle = 'sdc_list_buttonStyle';
            this.styles.checkOption = 'sdc_checkOption';
        }
        else{
            this.styles = this.props.styles;
        }
        
        
            /*
            this.styles = this.props.styles;
            this.styles.nodes = ''; //initial state of the nodes style
            */

    }
    render(){
        if(this.props.inValue) {
            this.selectedCheckBoxes.clear();
            for(var i=0; i<this.props.inValue.length; i++) 
            this.selectedCheckBoxes.add(this.props.inValue[i]);
        }
        return(
            <div className={this.styles.container}>
                <div className={this.styles.title}>{this.props.name}</div>
                <button onClick={this.showNodes} class={this.styles.buttonIn}> </button>
                {this.nodes}
            </div>
        );
    }
    createNodes(options){
        var nodes = [];
        nodes.push(<button onClick={this.selectAll} className={this.styles.listButtonStyle}>{this.LangPack.Select_All}</button>);
        nodes.push(<button onClick={this.clearAll} className={this.styles.listButtonStyle}>{this.LangPack.Deselect_All}</button>)
        for(var i=0; i<options.length; i++){
            nodes.push(
                <div>
                    <input type="checkbox" 
                    className={this.styles.checkbox}
                    value={options[i]}
                    onChange={this.toggleCheckBox}
                    checked={this.selectedCheckBoxes.has(options[i])}
                    />
                    <div className={this.styles.checkOption}>{options[i]}</div>
                </div>
            );
        }
        return nodes;
    }
    toggleCheckBox(event){
        var Xi = event.target.value;
        if(this.selectedCheckBoxes.has(Xi)) this.selectedCheckBoxes.delete(Xi);
        else this.selectedCheckBoxes.add(Xi);
        //console.log(this.selectedCheckBoxes);
        this.showNodes();
    }
    clearAll(){
        this.selectedCheckBoxes.clear();
        this.showNodes();
        //console.log(this.selectedCheckBoxes);
    }
    selectAll(){
        var options = this.props.filterOptions;
        for(var i=0; i<options.length; i++){
            if(!this.selectedCheckBoxes.has(options[i])) this.selectedCheckBoxes.add(options[i]);
        }
        this.showNodes();
    }
    showNodes(event){
        Head.showBlock(this.hideNodes);
        //else{
            this.styles.nodes=this.styles.nodesShow;
            this.nodes = (
                <div>
                    <div className = {this.styles.nodesContanter}>
                        {this.createNodes(this.props.filterOptions)}
                    </div>
                </div>
            );
        //}
        this.forceUpdate();
    }
    hideNodes(){
        Head.hideBlock();
        this.nodes = null;
        this.props.callBack(this.selectedCheckBoxes);
        this.forceUpdate();
    }
}
