import React from 'react';

/*beware - this class doesn't test TableLines for full functionality
and have to be suplemented with up-to-date functions implemented in SuperTable*/
export class TestTableLineEnvironment extends React.Component{
    constructor(props){
        super(props); 
        this.changeTableLines = this.changeTableLines.bind(this);
        this.state = {}
    }
    lineMatrix = ['tableInput', ['mercedes', 'toyota', 'lexus', 'range rover', 'bugatti'], 'tableDateInput', 'tableInput', 'tableInput'];
    lineInput = ['New document', 'toyota', '23.12.2013', 'Document Type', 'Construction site'];
    render(){
        return(
            <div>
                <TableLine 
                    lineMatrix={this.lineMatrix} 
                    MyId="fake" 
                    lineInput={this.lineInput} 
                    callBack={this.changeTableLines}
                />
                <p>{this.lineInput[0]}</p>
                <p>{this.lineInput[1]}</p>
                <p>{this.lineInput[2]}</p>
                <p>{this.lineInput[3]}</p>
                <p>{this.lineInput[4]}</p>
            </div>
        );
    }

    //i - row, j - position in the row
    changeTableLines(i, j, newValue){
        this.lineInput[j] = newValue;

        //TODO - remove this after successful testing of the component
        this.forceUpdate();
    }
}