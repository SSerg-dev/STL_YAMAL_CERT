export class Filter{

    constructor(varName, name, type, options){
        this.varName = varName;
        this.name = name;
        this.type=type;
        this.options=options;
        this.guidList=[];
        this.filterParams=[];
    }

}