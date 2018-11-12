import {SuperMultyAdderModel} from '../Models/SuperMultyAdderModel.js'

export function TestSuperMultyAdderModel(){
    var newModel = new SuperMultyAdderModel(2);
    var line1 = [["guid1","value1"],["guid2","value2"]];
    var line2 = [["guid3","value3"],["guid4","value4"]];
    var line3 = [["guid5","value5"],["guid6","value6"]];

    newModel.addLine("line1guid", line1);
    newModel.addLine("line2guid", line2);
    newModel.delete(0);
    newModel.addLine("line3guid",line3);
    newModel.delete(1);
    
    /*
    */
    console.log(newModel);
    console.log(newModel.getLineValues(0));
}