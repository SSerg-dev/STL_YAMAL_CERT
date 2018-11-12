export class TestRegeditKeyHandler{
    /*this class is created for implementation of integration testing
    it just fires proper alerts when you press a key or key combination
    please, use this class for creating new function for handling key events
    and only after testing the new feature add it to the main RegeditKeyHandler class*/

    constructor(inputHandlerModule){
        this.myHandlerModule = inputHandlerModule;
    }
    handKeyPressed(event){
        alert("TEST: keyPressed");
        event.preventDefault();
        return false;
    }

    //here you specify functions to handle different combinations of keys
    //beware! events on such key as ctrl, alt are fired only on keyDown
    handKeyDown(event){
        this.keyCtrl_S(event);
        return false;
    }
    handKeyDown = this.handKeyDown.bind(this);

    // CTRL+S combination:
    keyCtrl_S(event){
        if(event.ctrlKey && (event.which == 83)){
            event.preventDefault();
            alert("TEST: Ctrl+S");
        }
    }
}