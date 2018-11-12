export class RegeditHandlerModule{
    constructor(Register){
        this.Register = Register;
    }


    //**************** REGBUTTONS HANDLER BLOCK ******************

    CreateNew(){
        alert("Redirecting to new page");
    };

    SaveThis(){        
        alert(JSON.stringify(this.Register));
    };

    DeleteThis(){alert("DeleteThis")};
    //creating array of functions
    RegButtonsOnClick = {
        CreateNew: ()=>{this.CreateNew()},
        SaveThis: ()=>{this.SaveThis()},
        DeleteThis: ()=>{this.DeleteThis()}
    }

    //**************** REGTITLE CHANGE BLOCK ******************

    ChangeABDFinalSet(newABDFinalSet){this.Register.Title.ABDFinalSet = newABDFinalSet;};
    ChangeContractor(newContractor){this.Register.Title.Company = newContractor;};
    //creating array of functions
    RegTitleOnClick = {
        ChangeABDFinalSet: (newABDFinalSet)=>{this.ChangeABDFinalSet(newABDFinalSet)},
        ChangeContractor: (newContractor)=>{this.ChangeContractor(newContractor)}
    };

    //**************** REGRESP CHANGE BLOCK ******************

    ChangeNameSubContractor(newNameSubContractor){this.Register.Resp.NameSubContractor = newNameSubContractor;}
    ChangeDateSubContractor(newDateSubContractor){this.Register.Resp.DateSubContractor = newDateSubContractor;}
    ChangeNameContractor(newNameContractor){this.Register.Resp.NameContractor = newNameContractor;}
    ChangeDateContractor(newDateContractor){this.Register.Resp.DateContractor = newDateContractor;}
    ChangeNameCompany(newNameCompany){this.Register.Resp.NameCompany = newNameCompany;}
    ChangeDateCompany(newDateCompany){this.Register.Resp.DateCompany = newDateCompany;}

    RegRespOnClick = {
        ChangeNameSubContractor: (newNameSubContractor)=>{this.ChangeNameSubContractor(newNameSubContractor)},
        ChangeDateSubContractor: (newDateSubContractor)=>{this.ChangeDateSubContractor(newDateSubContractor)},
        ChangeNameContractor: (newNameContractor)=>{this.ChangeNameContractor(newNameContractor)},
        ChangeDateContractor: (newDateContractor)=>{this.ChangeDateContractor(newDateContractor)},
        ChangeNameCompany: (newNameCompany)=>{this.ChangeNameCompany(newNameCompany)},
        ChangeDateCompany: (newDateCompany)=>{this.ChangeDateCompany(newDateCompany)}
    }


}
