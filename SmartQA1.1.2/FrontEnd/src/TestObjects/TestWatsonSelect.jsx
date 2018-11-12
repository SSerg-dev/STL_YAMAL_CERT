import React from 'react';
import ReactDOM from 'react-dom';
import createClass from 'create-react-class';
import PropTypes from 'prop-types';
import Select from 'react-select';
import 'react-select/dist/react-select.css';

const FLAVOURS = [
	{ label: 'Chocolate', value: 'chocolate' },
	{ label: 'Vanilla', value: 'vanilla' },
	{ label: 'Strawberry', value: 'strawberry' },
	{ label: 'Caramel', value: 'caramel' },
	{ label: 'Cookies and Cream', value: 'cookiescream' },
	{ label: 'Peppermint', value: 'peppermint' },
];

var MultiSelectField = createClass({
	getInitialState () {
		return {
			removeSelected: true,
			disabled: false,
			crazy: false,
			stayOpen: false,
			value: [],
			rtl: false,
		};
	},
	handleSelectChange (value) {
        console.log(value);
		this.setState({ value });
	},
	render () {
		const { crazy, disabled, stayOpen, value } = this.state;
		const options = FLAVOURS;
		return (
			<div className="section">
				<Select
					closeOnSelect={true}
					disabled={false}
					onChange={this.handleSelectChange}
					options={options}
					placeholder="Выбрать Титул"
                    removeSelected={true}
					rtl={false}
                    value={value}
                    multi={true}
				/>
			</div>
		);
	}
});
export function startPage(){
    ReactDOM.render(
        <MultiSelectField/>
        , document.getElementsByTagName("body")[0]);
}
