import React from 'react';
import ReactDOM from 'react-dom';
import Iframe from 'react-iframe';
import {Head} from '../SharedComponents/Head.jsx';
import {AjaxModule} from '../SharedComponents/AjaxModule.jsx';
import '../Styles/FileStorage.css';
import { ToolKit } from '../Service/ToolKit';
import {PopMovable} from '../SharedComponents/PopMovable.jsx';

class TestIFrame extends React.Component{
    constructor(props){
        super(props);
        this.rendered = false;
        this.requestForPreview = this.requestForPreview.bind(this);
        this.openPreview = this.openPreview.bind(this);
        this.hidePreview = this.hidePreview.bind(this);
    }
    componentDidMount(){
        if(!this.rendered){
            console.log("opening");
            this.rendered = true;
        }
        this.requestForPreview();

    }
    requestForPreview(lineId){
        this.ajaxModuleOutputRef.getHtml('Stream_Id=D844E8AA-4977-E811-A9F7-005056947B15', '/GetPreview',
            this.ajaxModuleOutputRef, this.openPreview);
    }
    openPreview(response){
        var width = 1048;
        var height = 700;
        var offsetRight = (window.innerWidth - width)/2;
        var offsetTop  = (window.innerHeight - height)/2;

        Head.showBlock(this.hidePreview);
        this.previewNode = 
        (
            <PopMovable
                onExit={this.hidePreview} 
                head={"Head"}
                MyId={ToolKit.shortId}
                offsetStyle={{right:offsetRight, top:offsetTop, width:width, height:height, zIndex:100}}
            >
                <iframe src="http://localhost:61108/GetPreview?Stream_Id=D844E8AA-4977-E811-A9F7-005056947B15"
                    className="fileStorage_iframe"
                    id="myId"
                    display="initial"
                    position="relative"
                />
            </PopMovable>
        );
        this.forceUpdate();
    }
    hidePreview(){
        Head.hideBlock();
        this.previewNode = null;
        this.forceUpdate();
    }
    shouldComponentUpdate(){
        return false;
    }
    render(){
        var location = "http://localhost:61108/GetPreview?Stream_Id=D844E8AA-4977-E811-A9F7-005056947B15";
        return(
            <div>
                <Head/>
                {this.previewNode}
                <AjaxModule ref={(input)=>this.ajaxModuleOutputRef=input}/>
            </div>
        );
        /*
            <Iframe url={"data:text/html;charset=utf-8,"+escape(response)}
                    width="450px"
                    height="450px"
                    id="myId"
                    className="myClassname"
                    display="initial"
                    position="relative"
                    allowFullScreen
                />
        */
    }
}
export function startPage(){
    ReactDOM.render(
        <TestIFrame/>
        , document.getElementsByTagName('body')[0]
    );
}