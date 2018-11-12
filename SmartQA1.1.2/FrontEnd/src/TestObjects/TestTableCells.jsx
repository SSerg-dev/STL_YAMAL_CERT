import React from 'react';

/*beware - this class doesn't test TableLines for full functionality
and have to be suplemented with up-to-date functions implemented in TableLine*/

export class TestTableLineEnvironment extends React.Component{
    render(){
        return(
        <div>
            <TableInput callBack={this.callBack} inValue='Editable'/>
            <TableInput callBack={this.callBack}/>
            <TableInput callBack={this.callBack} inValue='Editable'/>
            <TableInput callBack={this.callBack}/>
            <TableInput callBack={this.callBack} inValue='Editable'/>
            <TableInput callBack={this.callBack}/>
            <TableInput callBack={this.callBack} inValue='Editable'/>
            <TableInput callBack={this.callBack}/>
            <TableDateInput callBack={this.callBack} inValue='Editable'/>
            <TableDateInput callBack={this.callBack}/>
        </div>);
    }
    this.callBack = this.callBack.bind(this);
    callBack(){

    }
}