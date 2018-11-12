import React from 'react';
import ReactDOM from 'react-dom';

import '../Styles/LineIso.css';

export class LineIsoResultsFoundBar extends React.Component{
    render(){
        return(
            <div className='lineIso_resultsFound'>
                {this.props.resultsFound}
            </div>
        );
    }
}