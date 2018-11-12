import React from 'react';
import ReactDOM from 'react-dom';
import '../Styles/BottomStyle.css';

export class Bottom extends React.Component{
    constructor(props){
        super(props);

        this.closeButtom = this.closeButtom.bind(this);

    }
    componentDidMount(){
        document.getElementById("bottom_element").style.display="none";
    }
    render(){
        var infoBar = null;
        if(this.props.infoMessage!=null){
            infoBar = <div className="bottom_searchResult">{this.props.infoMessage}</div>
        }
        return (
            <div className="bottom_line" id="bottom_element">
                <div className="bottom_container">
                    <p>Version 1.1.2. Developed in South Tambey LNG</p>
                    <div className="bottom_closeButton" onClick={this.closeButtom}>{'\u2A09'}</div>
                    {infoBar}
                </div>
            </div>
        );
    }
    closeButtom(){
        document.getElementById("bottom_element").style.display="none";
    }
}