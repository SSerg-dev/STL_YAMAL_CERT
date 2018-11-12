import React from 'react';
import {LangPack} from '../../Service/LangPack.js';

export class FilterSearch extends React.Component{
    constructor(props){
        super(props);
        this.LangPack = new LangPack('eng');
        this.state = {value:""}
        this.sendFilters = this.sendFilters.bind(this);
        this.onChange = this.onChange.bind(this);
        this.isSearchActive = false;
    }
    render(){
        var cross = <img 
            src={require('../../img/if_cross-24_103181.png')}
            className="filterSearchCrossIcon"
        />;
        var search = <img 
            src={require('../../img/search.png')}
            className="filterSearchSearchIcon"
        />;

        var img = this.isSearchActive ? cross : search;
        
        return(
            <div className = "filterSearch" onChange={this.onChange}>
                <input type="text" value={this.state.value} placeHoder={this.LangPack.Search}/>
                <div className="filterSearchButtonContainer" onClick={this.sendFilters}>
                    {img}
                </div>  
            </div>
        );
    }
    sendFilters(){
        if(this.isSearchActive){
            this.setState({value:""});
            this.props.callBack(null);
        }
        else{
            this.props.callBack(this.state.value);
        }
        this.isSearchActive = !this.isSearchActive;
    }
    onChange(event){
        this.isSearchActive = false;
        this.setState({value:event.target.value});
    }
}