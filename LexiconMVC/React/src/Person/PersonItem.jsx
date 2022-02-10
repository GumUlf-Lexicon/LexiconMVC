import React from 'react';

function PersonItem(props) {

	return (
		<div className="row">
			<div className="col-6">{props.personData.name}</div>
			<div className="col-6">{props.personData.cityName}, {props.personData.countryName}</div>
		</div>
	)
}

export default PersonItem;