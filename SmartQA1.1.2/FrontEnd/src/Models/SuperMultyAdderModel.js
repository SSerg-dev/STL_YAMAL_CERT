import { Dictionary } from "./Dictionary";
import {ToolKit} from '../Service/ToolKit.js';

/*this model is used for transfering values from page cores to the 
different variants of MultyAdders. It's the main model that MultyAdapters
work with*/

export class SuperMultyAdderModel{
    constructor(cols){//cols specify the amout of dictionaries used
        this.guidArray = []; //use it to store guids of TO-TABLE rows
        this.values=[];
        for(var i=0; i<cols; i++) this.values[i] = new Dictionary();
        this.Count = 0;

        //binding all functions: 
        this.addLine = this.addLine.bind(this);
        this.delete = this.delete.bind(this);
        this.getLineValues = this.getLineValues.bind(this);
        this.isContaining = this.isContaining.bind(this);
    }
    addLine(guid, line){//line is array of pairs key-value like [key, value]
        //can only be pushed if length of line equals number of dictionaries created
        //console.log(this.values[0]);
        if(line!=null && line.length==this.values.length){
            this.guidArray.push(guid);
            for(var i=0; i<line.length; i++)
            this.values[i].add(line[i][0],line[i][1]); 
            this.Count++;
        }
    }
    delete(index){//delete line from all dictionaries and delete guid
        this.guidArray=ToolKit.deleteElement(this.guidArray, index);
        this.values.map(oneDictionary => oneDictionary.delete(index)); //interating over dictionaries
        if(this.guidArray!=null) this.Count--;
    }
    getLineValues(index){//this function is very useful for creating component nodes so you get only values without guid and keys
        var lineValue =[];
        this.values.map(oneDictionary => lineValue.push(oneDictionary.values[index][1])); //iterating over dictionaries 
        return lineValue;
    }
    isContaining(line){//line is guids of all values user wants to add - use this to validate user input
        for(var i=0; i<this.values.length; i++)
        for(var j=0; j<Math.min(line.length, this.Count); j++) 
        {
            if(!this.values[j].value[i] == line[j]) break;
            return true;
        }
        return false;
    }
}