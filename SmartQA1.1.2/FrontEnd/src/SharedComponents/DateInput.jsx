import {SuperInput} from './SuperInput.jsx';

export class DateInput extends SuperInput{
/*
These component requires these things to be supplied with:

->inValue
->callBack

that's it!
*/
    onChange(event){
        //first - check the input value with mask and then write it into input state and the register
        this.isOnFocus=3;
        var inValue = DateInput.DateMask(event.target.value);
        this.setState({value: inValue});
        this.props.callBack(inValue);
    }

    //here the input is checked by the mask
    static DateMask(inputDate){
        //break the string into chars
        inputDate = inputDate.split('');

        for(var i=0; i<inputDate.length; i++) if(!/[0-9]/.test(inputDate[i])) inputDate.splice(i, 1); 
        var outputDate = [];
        for(i=0; i<8; i++) {
            if(!inputDate[i]) break;
            if(i==2 || i==4) outputDate.push(".");
            outputDate.push(inputDate[i]);
        }

        //concatenate the array back into string value
        return outputDate.join('');
    }
}