import {Tree} from '../Models/Tree.js';

export function startPage(){
    console.log("Start debug");

    var tree = new Tree();
    tree.addNode(null, '1', 34);
    tree.addNode('1', '3', 347);
    console.log(tree);
}