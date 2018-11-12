import {Dictionary} from './Dictionary';
export class Tree{
    constructor(root_Id, root_value){ //usually stands for not - selected values
        this.root = new node(null, root_Id, root_value);

        //binding functions:
        this.addNode = this.addNode.bind(this);
        this.flatten = this.flatten.bind(this);
        this.findNode = this.findNode.bind(this);
        this.findValue = this.findValue.bind(this);
        this.findParent = this.findParent.bind(this);
        this.findChildren = this.findChildren.bind(this);
        this.findAllParents = this.findAllParents.bind(this);
        this.findChildren = this.findChildrenValues.bind(this);
        this.findParentValue = this.findParentValue.bind(this);
        this.nextNode = this.nextNode.bind(this);
        this.prevNode = this.prevNode.bind(this);
        this.clear = this.clear.bind(this);
    }
    addNode(parent_Id, node_Id, value){
        //so there could be a number of nodes without parent id, that are really root node children
        if(parent_Id==null) {
            this.root.child.push(new node(null, node_Id, value));
            return true;
        }
        else{
            var parent = this.root.findNode(parent_Id);
            if(parent) {
                parent.child.push(new node(parent_Id, node_Id, value));
                return true;
            }
            else return false;
        }
    }
    //always start with the root node
    findNode(search_Id){return this.root? this.root.findNode(search_Id):null;}
    findChildren(search_Id){return this.root? this.root.findChildren(search_Id):null;}
    findParent(search_Id){return this.root? this.root.findParent(search_Id):null;}
    findValue(search_Id){return this.root? this.root.findValue(search_Id):null;}

    //these functions are what these class have been implemented for:
    findChildrenValues(search_Id){ //search_Id is the Id of the element which child values are wanted
        var searchNodeChildren = this.root.findChildren(search_Id);
        if(searchNodeChildren) {
            var result = [];
            searchNodeChildren.forEach((child)=>result.push(child.value));
            return result;
        } else return null;
    }
    findParentValue(search_Id){ //search_Id is the Id of the element which parent value is wanted
        var searchNodeParent = this.root.findParent(search_Id);
        if(searchNodeParent) return searchNodeParent.value
        else return null;
    }
    /*This function return all nodes except most low-level nodes - very useful for case when the tree 
    is already formed up and you want to know which nodes could be parents except the lowest nodes.
    */
    findAllParents(){
        if(this.root){
            var depth=this.root.findLongestChain().length;
            var result = new Dictionary();

            var _result = this.root.findSubNodesByDepth(depth-2);
            _result.forEach((node)=>result.add(node.node_Id, node.value));
            return result;
            /*one -1 stands for the chain length beeing always greater by one than the depth
            the other -1 stands for not inclucding the lowest level*/

        }else return null;
    }
    /*this function returns just id of nodes and their value in dictionary so we're able to find node id 
    of the required value*/
    flatten(){
        var result = new Dictionary();
        if(this.root){
            var depth=this.root.findLongestChain().length;
            
            /*-1 stands for the chain length beginning 
            with 1 and node level beginning with 0 - THIS node*/
            var toBePutInside =  this.root.findSubNodesByDepth(depth-1);
            toBePutInside.forEach((node)=>result.add(node.node_Id, node.value));
            return result;
        }
        else return null;
    }
    /*this function returns the next child of the node by previous child id*/
    nextNode(search_Id){
        var thisChild = this.root.findNode(search_Id);
        if(thisChild && thisChild.parent_Id){
            var parent = this.root.findNode(thisChild.parent_Id);
            if(parent){
                for(var i=0; i<this.parent.child.length; i++){
                    if(this.parent.child[i].node_Id == thisChild.node_Id) 
                    if(i==(this.parent.child.length-1)) return null;
                    else return this.parent.child[i+1];
                }
            }
        }else return null;
    }
    /*this function return previous child of the node*/
    prevNode(search_Id){
        var thisChild = this.root.findNode(search_Id);
        if(thisChild){
            var parent = this.root.findNode(thisChild.parent_Id);
            if(parent){
                for(var i=0; i<parent.child.length; i++){
                    if(parent.child[i].node_Id == thisChild.node_Id) 
                    if(i==0) return null;
                    else return parent.child[i-1];
                }
            }
        }else return null;
    }
    //preserves root node:
    clear(){
        this.root.child = [];
    }
}
//CLASS
class node{
    constructor(parent_Id, node_Id, value){
        this.parent_Id = parent_Id;
        this.node_Id = node_Id;
        this.value = value;
        this.child = [];

        this.findChildren = this.findChildren.bind(this);
        this.findParent = this.findParent.bind(this);
        this.findValue = this.findValue.bind(this);
        this.findNode = this.findNode.bind(this);
        this.findLongestChain = this.findLongestChain.bind(this);
        this.findSubNodesByDepth = this.findSubNodesByDepth.bind(this);
    }
    findNode(search_Id){//search_Id - is Id of the element which is wanted
        if(this.node_Id == search_Id) return this;
        for(var i=0; i<this.child.length; i++){
            var searchResult = this.child[i].findNode(search_Id);
            if(searchResult){
                return searchResult;
            }
        }
        return null;
    }
    findChildren(search_Id){ //search_Id - is Id of the element which children are wanted
        if(this.node_Id == search_Id) return this.child;
        for(var i=0; i<this.child.length; i++){
            var searchResult = this.child[i].findChildren(search_Id);
            if(searchResult){
                return searchResult;
            }
        }
        return null;
    }
    findParent(search_Id){//search_Id - is Id of the element which parent is wanted
        if(this.node_Id==search_Id) return this.parent_Id;
        for(var i=0; i<this.child.length; i++){
            var searchResult = this.child[i].findParent(search_Id);
            if(searchResult){
                return searchResult;
            }
        }
        return null;
    } 
    findValue(search_Id){//search_Id - is Id of the element which value is wanted
        if(this.node_Id==search_Id) return this.value;
        for(var i=0; i<this.child.length; i++){
            var searchResult = this.child[i].findValue(search_Id);
            if(searchResult){
                return searchResult;
            }
        }
        return null;
    }
    /*this function returns an array of elements that form up the longest
     chain in the tree one of the longest chains starging with this node*/
    findLongestChain(){
        var resultChain = [];
        if(this.child && this.child.length>0){
            var possibleChains = [];

            this.child.forEach((child)=> possibleChains.push(child.findLongestChain()));
            
            //finding the maximum chain
            resultChain = possibleChains[0];
            possibleChains.forEach((chain)=>
                {
                    if(resultChain.length<chain.length) resultChain=chain;
                }
            );
        }
        resultChain.push(this);
        return resultChain;
    }
    /*this function help to retrieve all child and subchild elements of the node that are
    situated not deeper then the particular level. Level enumeration start with the node
    itself with number 0*/
    findSubNodesByDepth(depth){
        var result = [];
        if(depth!=0) this.child.forEach((child)=>
            {
                var subNodes = child.findSubNodesByDepth(depth-1);
                subNodes.forEach((node)=>result.push(node));
            }
        );
        result.push(this);
        return result;
    }
}