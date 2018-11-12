import {SuperList} from '../SuperList.jsx';
import '../../Styles/TableCellStyle.css';

export class TableList extends SuperList{
    
    componentWillMount(){
        this.setState({class: 'tableCell'});
    }
    onChange(event){
        if (event.key==37 || event.key == 39 || event.key ==38) console.log("came from onChange");
        this.setState({value: event.target.value});
        this.props.callBack(this.props.MyId, event.target.value);
    }
    onFocus(){
        this.props.cellOnFocus(this.props.MyId);
    }
    focusCell(){
        //console.log("came from line");
        this.textInput.focus();
    }
    onKeyDown(event){
        if(event.keyCode==37 || event.keyCode==38 || event.keyCode==39 || event.keyCode ==40) {
            event.preventDefault();
            return false;
        }

    }
}