import React from 'react';

function PersonItem(props) {

	const person = props.personData;

	function handleInfoClick(event, personId) {
		event.preventDefault();
		event.stopPropagation();
		props.handleInfoClick(event, person.personId);
	}

	function handleDeleteClick(event, personId) {
		event.preventDefault();
		event.stopPropagation();
		props.handleDeleteClick(event, person.personId);
	}

	return (
		<div className="row mx-3 py-0 my-0">
			<span className="col-md-5 col-4 py-0 my-0">{person.name}</span>
			<span className="col-md-5 col-5 py-0 my-0">{person.cityName}, {person.countryName}</span>
			<span className="col-md-2 col-3 py-0 my-0">
				<span className="btn btn-info btn-sm fw-bold py-0 my-0 me-1"
					onClick={(event) => handleInfoClick(event, person.personId)}>
					Info
				</span>
				<span className="btn btn-danger btn-sm fw-bold py-0 my-0 ms-1"
					onClick={(event) => handleDeleteClick(event, person.personId)}>
					X
				</span>
			</span>
		</div>
	)
}

export default PersonItem;