import {RegeditHandlerModule} from './RegeditHandlerModule.jsx';

export class RegeditKeyHandler{

    constructor(inputHandlerModule){
        this.myHandlerModule = inputHandlerModule;
    }
    handKeyPressed(event){

    }

    //here you specify functions to handle different combinations of keys
    //beware! events on such key as ctrl, alt are fired only on keyDown
    handKeyDown(event){
        this.keyCtrl_S(event);
    }
    handKeyDown = this.handKeyDown.bind(this);

    // CTRL+S combination:
    keyCtrl_S(event){
        if(event.ctrlKey && (event.which == 83)){
            event.preventDefault();
            this.myHandlerModule.SaveThis();
            return false;
        }
    }
}