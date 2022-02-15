import React from 'react';

function BottomButton(props) {
	return (
		<div className="d-grid px-5">
			<input
				type="button"
				className="btn btn-info fw-bold"
				onClick={(event) => { event.preventDefault(); props.handleOnClick(); }}
				value={props.textValue} />
		</div>
		
	);
}

export default BottomButton;