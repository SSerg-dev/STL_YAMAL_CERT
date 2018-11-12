import React from 'react';
import ReactDOM from 'react-dom';
import {PhotoshopPicker} from 'react-color';
import { Github } from 'react-color/lib/components/github/Github';
import '../Styles/ColorPicker.css';

export class DictionaryColorPicker extends React.Component{
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
            <div className='colorPickerStruct'>
                <div className='colorPickerBlock' onClick={this.props.onExit}></div>
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