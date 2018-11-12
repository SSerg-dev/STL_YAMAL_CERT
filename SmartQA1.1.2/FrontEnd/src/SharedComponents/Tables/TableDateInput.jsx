import {DateInput} from '../DateInput.jsx';
import '../../Styles/TableCellStyle.css';

export class TableDateInput extends DateInput{

    componentWillMount(){
        this.setState({contenteditable: false, class: 'tableCell'});
    }
    onChange(event){
        //first - check the input value with mask and then write it into input state and the register
        this.isOnFocus=3;
        var inValue = DateInput.DateMask(event.target.value);
        this.setState({value: inValue});
        this.props.callBack(this.props.MyId, inValue);
    }
    onFocus(){
        this.isOnFocus++;
        this.setState({reference: 'selectedInput'});

        //Telling the Line: "I'm focused!": 
        this.props.cellOnFocus(this.props.MyId);
    }
    onClick(){
        if(this.isOnFocus>1) {
            this.setState({readOnly: false});
            this.isOnFocus=3;}
        else {this.isOnFocus=2;}
    }
    onBlur(){
        this.isOnFocus = 0;
        this.setState({readOnly: true, reference: null});
    }
    onKeyPress(){
        if(this.isOnFocus<3){
            this.isOnFocus++;
        this.setState({readOnly: false});
        this.textInput.select();
        }
    }
    focusCell(){
        this.textInput.focus();
    }

}
