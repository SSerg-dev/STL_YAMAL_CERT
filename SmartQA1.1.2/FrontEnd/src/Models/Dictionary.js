import {ToolKit} from '../Service/ToolKit.js';

/*This component is used to create a JavaScript implementation of
the C#-like dictionary the way that it'll provide us with
some useful functionality*/

//Dictionary.value[i] - retrieve pair key-value
//Dictionary.value[i][0] - retrieve key
//Dictionary.value[i][1] - retrieve value

export class Dictionary{
    constructor(){
        this.values=[]; //TODO - make this item 

        this.add=this.add.bind(this);
        this.count = this.count.bind(this);
        this.delete= this.delete.bind(this);
        this.hasKey = this.hasKey.bind(this);
        this.hasValue = this.hasValue.bind(this);
        this.keyByValue = this.keyByValue.bind(this);
        this.keyByIndex = this.keyByIndex.bind(this);
        this.valueByKey = this.valueByKey.bind(this);
        this.pairByIndex = this.pairByIndex.bind(this);
        this.getAllValues = this.getAllValues.bind(this); //we need to use dictionary values in input elements like list or dropcheck
        this.getAllKeys = this.getAllKeys.bind(this);
        this.getAllPairs = this.getAllPairs.bind(this);
        this.prevKeyByKey = this.prevKeyByKey.bind(this);
        this.nextKeyByKey = this.nextKeyByKey.bind(this);
        this.getLastKey = this.getLastKey.bind(this);
        this.indexByKey = this.indexByKey.bind(this);
        this.indexByValue = this.indexByValue.bind(this);
        this.deleteElementByKey = this.deleteElementByKey.bind(this);
        this.removeElementByKey = this.removeElementByKey.bind(this);
        this.clone = this.clone.bind(this);
    }
    add(key, value){
        this.values.push([key, value]);
    }
    delete(index){
        this.values=ToolKit.deleteElement(this.values, index);
    }
    //TODO - create function for deleting an item from the dictionary
    hasKey(key){ //no need to check for null
        for(var i=0; i<this.values.length; i++)
        if(this.values[i][0]==key) return true;
        return false;
    }
    hasValue(value){
        for(var i=0; i<this.values.length; i++)
        if(this.values[i][1]==value) return true;
        return false;
    }
    keyByValue(value){
        for(var i=0; i<this.values.length; i++)
        if(this.values[i][1]==value) return this.values[i][0];
        return null;
    }
    keyByIndex(index){
        if(index!=null)
        {
            if(this.values.length<=index) 
            {
                console.log('Index is out of boundaries');
                return null;
            }
            return this.values[index]? this.values[index][0] : null;
        }
        return null;
    }
    valueByKey(key){
        for(var i=0; i<this.values.length; i++)
        if(this.values[i][0]==key) return this.values[i][1];
        return null;
    }
    valueByIndex(index){
        if(index!=null)
        {
            if(this.values.length<=index) 
            {
                console.log('Index is out of boundaries');
                return null;
            }
            return this.values[index]? this.values[index][1] : null;
        }
        return null;
    }
    pairByIndex(index){
        if(index!=null)
        {
            if(this.values.length<=index)
            {
                console.log('Index is out of boundaries');
                return null;
            }
            return this.values[index];
        }
        return null;
    }
    getAllPairs(){
        return this.values;
    }
    getAllValues(){ //BEWARE - NOT TESTED FUNCTION - GO TO UNIT TESTS AND IMPLEMENT
        var outPut=[];
        for(var i=0; i<this.values.length; i++) outPut.push(this.values[i][1]);
        return outPut;
    }
    getAllKeys(){ //BEWARE - NOT TESTED FUNCTION - GO TO UNIT TESTS AND IMPLEMENT
        var outPut=[];
        for(var i=0; i<this.values.length; i++)
        outPut.push(this.values[i][0]);
        return outPut;
    }
    clear(){ //BEWARE - NOT TESTED FUNCTION - GO TO UNIT TESTS AND IMPLEMENT
        this.values=[];
    }
    deleteElementByKey(key){
        var result = new Dictionary();
        for(var i=0; i<this.values.length; i++){
            if(this.values[i][0]!=key) result.add(this.values[i][0], this.values[i][1]);
        }
        this.values = result.values;
    }
    count(){
        return this.values.length;
    }
    clone(){
        var outputDic = new Dictionary();
        for(var i=0; i<this.count(); i++)
            outputDic.add(this.values[i][0], this.values[i][1]);
        return outputDic;
    }
    indexByKey(key){
        if(!this.hasKey(key)) return null;
        for(var i=0; i<this.count(); i++) if(this.values[i][0]==key) return i;
        return null;
    }
    indexByValue(value){
        if(!this.hasValue(value)) return null;
        for(var i=0; i<this.count(); i++) if(this.values[i][1]==value) return i;
        return null;
    }
    getLastKey(){
        if(this.values.length>0) return this.values[this.values.length-1][0];
        else return null;
    }
    removeElementByKey(key){ //removes ALL elements with the specified key
        var resultDict = new Dictionary();
        for(var i =0 ; i<this.values.length; i++) 
        {
            if(!(this.values[i][0]==key)) resultDict.add(this.values[i][0], this.values[i][1]);
        }
        return resultDict;
    }
    prevKeyByKey(key){
        for(var i = 1; i<this.values.length; i++){
            if(this.values[i][0]==key) return this.values[i-1][0];
        }
        return null;
    }
    nextKeyByKey(key){
        for(var i = 0 ; i<this.values.length-1; i++){
            if(this.values[i][0]==key) return this.values[i+1][0];
        }
        return null;
    }
    static concatenateDictionaries(dict_1, dict_2){
        if(dict_1)
        {
            for(var i=0; i<dict_2.values.length; i++){
                dict_1.add(dict_2.values[i][0], dict_2.values[i][1]);
            }
            return dict_1;
        }
        else
        {
            if(dict_2){
                return dict_2;
            }
            else return null;
        }
    }

}