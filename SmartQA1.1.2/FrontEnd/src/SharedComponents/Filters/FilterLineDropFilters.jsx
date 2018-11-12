import React from 'react';
import { SuperDropCheck } from '../SuperDropCheck.jsx';

export class FilterLineDropFilters extends SuperDropCheck {
    render() {
        if (this.props.inValue) {
            this.selectedCheckBoxes.clear();
            for (var i = 0; i < this.props.inValue.length; i++)
                this.selectedCheckBoxes.add(this.props.inValue[i]);
        }
        return (
            <div className="fsdc_container">
                <button onClick={this.showNodes} class="fsdc_button">
                    <img className="fsdc_buttonImg" src={require('../../img/filter.png')} />
                </button>
                {this.nodes}
            </div>
        );
    }
}