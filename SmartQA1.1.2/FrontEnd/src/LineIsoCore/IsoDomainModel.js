import {Dictionary} from '../Models/Dictionary.js';
import {LangPack} from '../Service/LangPack.js';

export class IsoDomainModel{
    constructor(){
        //PRIVATE
        this.dictionary = new Dictionary();
        this.LangPack = new LangPack('eng');

        //PUBLIC
        this.currentRow = 0;
        this.isDeselectable = false;
        this.isCreatable = false;
        this.resultsFound = 0;
        this.title = this.LangPack.Isos;
        this.currentId = null;
        this.currentName = null;
       

        //binding functions
        this.add = this.add.bind(this);
        this.clear = this.clear.bind(this);
        this.trySelectNewIso = this.trySelectNewIso.bind(this);
        this.deselect = this.deselect.bind(this);
        this.resetTitle = this.resetTitle.bind(this);
        this.setTitleByLineName = this.setTitleByLineName.bind(this);
        this.setTitleNotSelected = this.setTitleNotSelected.bind(this);
        this.getIdByNumber = this.getIdByNumber.bind(this);
        this.getNameByNumber = this.getNameByNumber.bind(this);
        this.changeRowSelected = this.changeRowSelected.bind(this);
    }
    add(guid, name){
        this.dictionary.add(guid, name);
    }
    clear(){
        this.dictionary.clear();
    }
    trySelectNewIso(isoNumber){
        if(this.currentRow == isoNumber) 
            return false;
        else{
            this.currentRow = isoNumber;
            this.currentId = this.dictionary.keyByIndex(isoNumber);
            this.currentName = this.dictionary.valueByIndex(isoNumber);
            this.isDeselectable = true;
            this.isCreatable = true;
            return true;
        }
    }
    isSelected(){
        return this.currenId ? true : false;
    }
    changeRowSelected(rowNumber){
        this.currentRow = rowNumber;
    }
    deselect(){
        this.currentRow = 0;
        this.currentId = null;
        this.currentName = null;
        this.isDeselectable = false;
        this.isCreatable = false;
        this.resultsFound = 0;
        this.resetTitle();
    }
    resetTitle(){
        this.title = this.LangPack.Isos;
    }
    setTitleByLineName(lineName){
        this.title = this.LangPack.Isos + this.LangPack.ForLine + lineName;
    }
    setTitleNotSelected(){
        this.title = this.LangPack.Isos + this.LangPack.notSelected;
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