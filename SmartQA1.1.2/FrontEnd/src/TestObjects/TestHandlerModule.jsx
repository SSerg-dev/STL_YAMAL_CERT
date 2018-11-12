export class TestHandlerModule{

constructor(Register){
    this.Register = Register;
}

//**************** REGBUTTONS HANDLER BLOCK ***************
CreateNew(){alert("TEST: You've pressed CreateNew");}
SaveThis(){alert("TEST: You've pressed SaveThis");}
DeleteThis(){alert("TEST: You've pressed DeleteThis");}
//creating array of functions
RegButtonsOnClick = {
    CreateNew: ()=>{this.CreateNew()},
    SaveThis: ()=>{this.SaveThis()},
    DeleteThis: ()=>{this.DeleteThis()}
    };

//**************** REGTITLE CHANGE BLOCK ******************
ChangeABDFinalSet(newABDFinalSet){alert("TEST: You've changed ABDFinalSet")};
ChangeContractor(newContractor){alert("TEST: You've changed Contractor")};
//creating array of functions
RegTitleOnClick = {
    ChangeABDFinalSet: ()=>{this.ChangeABDFinalSet()},
    ChangeContractor: ()=>{this.ChangeContractor()}
};

//**************** REGRESP CHANGE BLOCK *******************
ChangeNameSubContractor(){alert('TEST: Changed name of SubContractor responsible');}
ChangeDateSubContractor(){alert('TEST: Changed date of signing the document by SubContractor');}
ChangeNameContractor(){alert('TEST: Changed name of Contractor repsonsible');}
ChangeDateContractor(){alert('TEST: Changed date of signing the document by Contractor');}
ChangeNameCompany(){alert('TEST: Changed name of Company responsible');}
ChangeDateCompany(){alert('TEST: Changed date of signing the document by the Company');}
//creating array for testing
RegRespOnClick = {
    ChangeNameSubContractor: ()=>{this.ChangeNameSubContractor()},
    ChangeDateSubContractor: ()=>{this.ChangeDateSubContractor()},
    ChangeNameContractor: ()=>{this.ChangeNameContractor()},
    ChangeDateContractor: ()=>{this.ChangeDateContractor()},
    ChangeNameCompany: ()=>{this.ChangeNameCompany()},
    ChangeDateCompany: ()=>{this.ChangeDateCompany()}
}





}