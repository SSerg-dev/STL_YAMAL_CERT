import React from 'react';
import '../../Styles/SuperFilteringWindow.css';

//this component creates basic check list

export class SuperFilterWindow extends React.Component{
    constructor(props){
        super(props);
        this.state={};
        this.selectedCheckBoxes=new Set();
        
    //binding all functions:
    this.toggleCheckBox = this.toggleCheckBox.bind(this);
    this.clearAll=  this.clearAll.bind(this);
    }
    render(){
        return(
    
        <div style={{textAlign:'center'}}>
            <div class="sfwBlock">
            </div>
            <div class='sfwContainer'>
                <button onClick={this.clearAll}>Clear all</button>
                {this.createNodes(this.props.filterOptions)}
                <button onClick={()=>(this.props.onOk(this.selectedCheckBoxes))}>Ok</button>
                <button >Cancel</button>
            </div>
        </div>
        );
    }
    createNodes(option){
        var nodes = [];
        for(var i=0; i<option.length; i++){
            var j=0;
            if(this.props.hasTitles==true) nodes.push(<div class='sfwHeader'>{option[i][j++]}</div>);
            for(j; j<option[i].length; j++)
            nodes.push(
                <div>
                    <input type="checkbox"
                    value={option[i][j]}
                    onChange={this.toggleCheckBox}
                    checked={this.selectedCheckBoxes.has(option[i][j])}
                    />
                    {option[i][j]}
                </div>
            );
            }
        return nodes;
    }
    toggleCheckBox(event){
        var Xi = event.target.value;
        if(this.selectedCheckBoxes.has(Xi)) this.selectedCheckBoxes.delete(Xi);
        else this.selectedCheckBoxes.add(Xi);
        console.log(this.selectedCheckBoxes);
        this.forceUpdate();
    }
    clearAll(){
        this.selectedCheckBoxes.clear();
        this.forceUpdate();
        console.log(this.selectedCheckBoxes);
    }

}