export class Cell{
    constructor(type, AoS){
        this.type=type;
        this.inValue=[]; //should be ARRAY for constincensy
        this.AoS = AoS; //AoS - array of strings - used for lists and dropcheck components (possible options)
    }
}

/*available types of input:
tableInput
tableDateInput
tableList
tableDropCheck
guidSingleCheck
guidDoubleCheck





*/