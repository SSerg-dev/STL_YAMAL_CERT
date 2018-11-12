import React from 'react';
import ReactDOM from 'react-dom';
import {CirclePicker} from 'react-color';
import {BlockPicker} from 'react-color';
import {ChromePicker} from 'react-color';
import {PhotoshopPicker} from 'react-color';
import {SketchPicker} from 'react-color';
import {SliderPicker} from 'react-color';
import {SwatchesPicker} from 'react-color';
import {TwitterPicker} from 'react-color';
import { Github } from 'react-color/lib/components/github/Github';
import {ToolKit} from '../Service/ToolKit.js';
import '../Styles/ColorPicker.css';

export function startPage(){
    this.callBack = function(value){
        //console.log(value);
    }
    this.onAccept = (value)=>{console.log(this.color);}
    this.onChangeComplete = (value)=>{this.color = value.hex};
    this.onCancel = this.onAccept;
    var colorUsed = ['#B80000', '#DB3E00', '#FCCB00', '#008B02', '#006B76', '#1273DE', '#004DCF', '#5300EB', '#EB9694', '#FAD0C3', '#FEF3BD', '#C1E1C5', '#BEDADC', '#C4DEF6', '#BED3F3', '#D4C4FB'];
    colorUsed = ['#B80000', '#DB3E00'];

    console.log(ToolKit.checkHexColor('#B80000'));
    console.log(ToolKit.checkHexColor('#B8000'));
    console.log(ToolKit.checkHexColor('B80000'));
    console.log(ToolKit.checkHexColor());
    console.log(ToolKit.checkHexColor('#240000'));

    ReactDOM.render(
        <DictionaryColorPicker 
            inValue={'#577F4D'}
            callBack={(value)=>{console.log(value)}} 
            onExit={()=>{console.log("onExit")}}
            colorArray = {colorUsed}
        />
        , document.getElementsByTagName("body")[0]);
}
class DictionaryColorPicker extends React.Component{
    constructor(props){
        super(props);
        this.color=(this.props.inValue)?this.props.inValue:null;
        this.onChangeColor = this.onChangeColor.bind(this);
        this.onAccept = this.onAccept.bind(this);
    }
    render(){
        if(!this.props.colorArray || !this.props.colorArray.length>0) 
            var gitHubSelect = <p className='colorPickerNoColorsUsed'>Для данного словаря еще не использовано ни одного цвета</p>
        else var gitHubSelect = <Github onChange = {this.onChangeColor} colors={this.props.colorArray}/>
        return (
            <div>
            <div className='colorPickerBlock'></div>
            <div className='colorPickerContainer'>
                <p className='colorPickertitle'>Выбрать новый цвет:</p>
                <PhotoshopPicker 
                    color={(!this.color)?'#ffffff':this.color}
                    onAccept={this.onAccept}
                    onCancel={this.props.onExit}
                    onChangeComplete={this.onChangeColor}
                />
                <p className='colorPickertitle'>Уже использующиеся для данного словаря цвета:</p>
                {gitHubSelect}
            </div>
            </div>
        );
    }
    onChangeColor(value){
        this.color=value.hex;
        this.forceUpdate();
    }
    onAccept(){
        this.props.callBack(this.color);
    }
}