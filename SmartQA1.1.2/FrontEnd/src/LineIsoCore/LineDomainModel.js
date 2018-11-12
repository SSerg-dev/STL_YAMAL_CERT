import { Dictionary } from "../Models/Dictionary";
import {LangPack} from '../Service/LangPack.js';

export class LineDomainModel{
    constructor(){
         //PRIVATE
         this.dictionary = new Dictionary();
         this.LangPack = new LangPack('eng');

        //PUBLIC 
        this.currentRow = 0;
        this.isDeselectable = false;
        this.isCreatable = true; // this parameter is never changing for LineDomainModel
        this.resultsFound = 0;
        this.title = this.LangPack.Lines;
        this.currentId = null;
        this.currentName = null;

        this.isos  = new Dictionary();

        //binding functions
        this.add = this.add.bind(this);
        this.clear = this.clear.bind(this);
        this.trySelectNewLine = this.trySelectNewLine.bind(this);
        this.deselect = this.deselect.bind(this);
        this.resetTitle = this.resetTitle.bind(this);
        this.setTitleByLineName = this.setTitleByLineName.bind(this);
        this.setTitleNotSelected = this.setTitleNotSelected.bind(this);
        this.getIdByNumber = this.getIdByNumber.bind(this);
        this.getNameByNumber = this.getNameByNumber.bind(this);
        this.checkIfLineHasIso = this.checkIfLineHasIso.bind(this);
        this.consumeSingleLine = this.consumeSingleLine.bind(this);
        this.clearIsoList = this.clearIsoList.bind(this);
        this.changeRowSelected = this.changeRowSelected.bind(this);
    }
    add(guid, name){
        this.dictionary.add(guid, name);
    }
    clear(){
        this.dictionary.clear();
        this.isos.clear();
    }
    clearIsoList(){
        this.isos.clear();
    }
    changeRowSelected(rowNumber){
        this.currentRow = rowNumber;
    }
    trySelectNewLine(lineNumber){
        if(this.currentrow == lineNumber)
            return false;
        else{
            this.currentRow = lineNumber;
            this.currentId = this.dictionary.keyByIndex(lineNumber);
            this.currentName = this.dictionary.valueByIndex(lineNumber);
            this.isDeselectable = true;
            return true;
        }
    }
    consumeSingleLine(singleLine){
        this.clearIsoList();
        this.title = this.LangPack.Line + ": " + singleLine.lineList[0].Line_Number;
        this.currentId = singleLine.Line_ID;
        this.currentName = singleLine.Line_Number;
        this.currentRow = 0;
        this.isDeselectable = true;
    }
    isSelected(){
        return this.currentId!=null ? true : false;
    }
    checkIfLineHasIso(isoId){
        return this.isos.hasKey(isoId);
    }
    deselect(){
        this.currentRow = 0;
        this.currentId = null;
        this.currentName = null;
        this.isDeselectable = false;
        this.resultsFound = 0;
        this.clear();
        this.resetTitle();
    }
    resetTitle(){
        this.title = this.LangPack.Lines;
    }
    setTitleByLineName(){
        this.title = this.LangPack.Lines 
    }
    setTitleNotSelected(){
        this.title = this.LangPack.Line+": "+this.LangPack.notSelected;
    }
    getIdByNumber(number){
        if(this.dictionary.count() == 0) return null;
        return this.dictionary.keyByIndex(number);
    }
    getNameByNumber(number){
        if(this.dictionary.count() == 0) return null;
        return this.dictionary.valueByIndex(number);
    }
}