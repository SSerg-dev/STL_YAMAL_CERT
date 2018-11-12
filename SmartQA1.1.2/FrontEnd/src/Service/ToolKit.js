export class ToolKit{

/*This class contains static functions for working with different types
of objects, but mainly - with arrays.
please, keep this file structured - functions are ordered by their names*/

/*TODO - test this function in different contexts
this function deletes an element from the array
*/
static deleteElement(array, index){
    var newArray = [];
    if(index<0) {
        console.log("INDEX is less 0");
        return null;
    }
    if(index>=array.length) {
        console.log("INDEX out of boundaries (delete)");
        return null;
    }
    for(var i=0; i<array.length; i++) 
    if(i!=index) newArray.push(array[i]);
    return newArray;
}
/*this function fills a one-dimensional array with non-null string values "" */
static empty(array){
    var emptyArray=[];
    for(var i=0; i<array.length; i++) emptyArray[i]="";
    return emptyArray;
}
/*this function runs searches for the element in the array and return null if nothing was found;*/
static findElementByIndex(array, key){
    for(var i=0; i<array.length; i++){
        if(key == array[i]) return array[i];
    }
    return null;
}
/*this functions returns the index of the element of the array if it's found and null
if nothing was fount*/
static getKeyByValue(array, value){
    for(var i=0; i<array.length; i++){
        if(array[i]==value) return i;
    }
    return null;
}
/*this functions checks if the array contains an element*/
static isContaining(array, element){
    for(var i=0; i<array.length; i++) if(array[i]==element) return true;
    return false;
}
/*this function finds out if the array is entirely empty*/
static isEmpty(array){
    if(array) for(var i=0; i<array.length; i++) if(array[i]!=''){
        return false;
    }
    return true;
}
/*this function is used to push an element inside the array, if the index of the element
is greater than the length of the array it places the element last*/
static pushInside(array, element, index){
    if(index>=array.length) {
        array.push(element);
        return array;
    }
    if(index>=0) {
        for(var i=array.length; i>index; i--) array[i]=array[i-1]; //Object.assign({}, array[i-1])
        array[index]=element;
        return array;
    }
    array=null;
}
//this function pushes the value in the array if the array doesn't containg this value
static pushInsideOriginal(array, value){
    if(!array.includes(value)) array.push(value)
    return array;
}
/*this function compares two date and returns false if the first date is bigger
than the second */
static compareTwoDates(date1, date2){
    var inputDate1 = date1.split('');
    var inputDate2 = date2.split('');
    var i = 6;
    for(i; i<10; i++) if(inputDate1[i]<inputDate2[i]) return false; else return true;
    i = 3;
    for(i; i<5; i++) if(inputDate1[i]<inputDate2[i]) return false; else return true;
    i = 0;
    for(i; i<2; i++) if(inputDate1[i]<inputDate2[i]) return false; else return true;
    return true;
}
/*this function generates short Id, that can be used when working with simple DOM
elements by their ID*/
static shortId(){
    var firstPart = (Math.random() * 46656) | 0;
    var secondPart = (Math.random() * 46656) | 0;
    firstPart = ("000" + firstPart.toString(36)).slice(-3);
    secondPart = ("000" + secondPart.toString(36)).slice(-3);
    return firstPart + secondPart;
}
static slashSeparate(inputTitleGuidLine, dictionarySep){
    var guids = inputTitleGuidLine.split("/");
    var names = guids.map((guid)=>{return dictionarySep.valueByKey(guid)});
    return names.join('/');
}
static max(array){
    var m = null;
    for(var i=0; i<array.length; i++){
        if(!m) 
        {
            m = array[i];
            continue;
        }
        if(array[i]) if(m<array[i]) m = array[i];
    }
    return m;
}
static min(array){
    var m = null;
    for(var i=0; i<array.length; i++){
        if(!m) 
        {
            m = array[i];
            continue;
        }
        if(array[i]) if(m>array[i]) m = array[i];
    }
    return m;
}
static moveElement(array, elementIndex, destinationIndex){
    if(!array || array.length<1){
        console.log("Not valid input array");
        return null;
    }
    if(elementIndex>array.length-1 || destinationIndex>array.length-1) {
        console.log("Index is greater then the length of the array (moveElement)");
        return null;
    }
    if(elementIndex<0 || destinationIndex<0){
        console.log("Index is smaller then zero (moveElement)");
        return null;
    }
    if(elementIndex==destinationIndex) return array;
    var resultArray  =[];
    for(var i=0; i<array.length; i++){
        if(i!=elementIndex || i==destinationIndex){
            if(i!=destinationIndex) resultArray.push(array[i]);
            else 
            {
                resultArray.push(array[destinationIndex]);
                resultArray.push(array[elementIndex]);
            }
        }
    }
    return resultArray;
}
static checkHexColor(color){
    if(!color) return false;
    if(color.length!=7) return false;
    if(color[0]!='#') return false;
    return true;
}
static copyArray(inputArray){
    if(inputArray.length){
        var resultArray = [];
        inputArray.forEach((element)=>resultArray.push(element));
        return resultArray;
    }
    else return null;
}
//only applicable for string arrays
static maxStringLength(stringArray){
    if(stringArray && stringArray.length>0){
        var max = 0;
        for(var i=0; i<stringArray.length; i++){
            var currentString = String(stringArray[i]);
            if(currentString && currentString.length)
                if(currentString.length>max) max = currentString.length;
        }
        return max;
    }
    else return 0;
}
static convertBytesNumber(bytesNumber){
    if(bytesNumber<1024) return bytesNumber + " bytes";
    var kbNumber = Math.round(bytesNumber / 1024);
    if(kbNumber<1024) return kbNumber + " kb";
    var mbNumber = Math.round(kbNumber / 1024);
    return mbNumber + " mb";
}
    static getFileExtenstion(fileName) {
        var fileExtension = "";
        //Если файл удалить из сетевой шары "руками", то сюда приходит null
        if (fileName != null) {
        var _temp = [];
        for (var i = fileName.length - 1; i > -1; i--) {
            if (fileName[i] != '.') {
                _temp.push(fileName[i]);
            }
            else {
                for (var j = _temp.length - 1; j > -1; j--)
                    fileExtension += _temp[j];
                break;
            }
        }
    }
    return fileExtension;
}
}
