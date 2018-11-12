import {Dictionary} from '../Models/Dictionary'

export function TestDictionary(){
    var newDict = new Dictionary();

    newDict.add('key1', 'value1');
    newDict.add('key2', 'value2');
    newDict.add('key3', null);
    newDict.add(null, 'value4');

    console.log(newDict);
    console.log(newDict.hasKey(null));
    console.log(newDict.hasKey('value1'));
    console.log(newDict.hasKey('key2'));
    console.log(newDict.hasValue(null));
    console.log(newDict.hasValue('value1'));
    console.log(newDict.hasValue('key1'));
    console.log(newDict.keyByValue('value1'));
    console.log(newDict.keyByValue(null));
    console.log(newDict.valueByKey('key1'));
    console.log(newDict.valueByKey(null));
}