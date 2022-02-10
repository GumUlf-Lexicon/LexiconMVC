import React, { useState } from 'react';
import PersonItem from './PersonItem';

function PersonList(props) {

	const [count, setCount] = useState(1);

	function showPersonInfo(e, person) {
		e.preventDefault();
		console.log(`Showing info for person with id: ${person.id}. Count: ${count}.`);
		setCount(count + 1);
	}



	return (
		<div className="row">
			<div className="col-6 offset-3">
				<div id="personList" className="row pt-2 border-bottom ">
					<div className="col-6 fw-bold">Name</div>
					<div className="col-6 fw-bold">Location</div>
				</div>

				{
					props.personData.personList.map(person => (
						<div key={person.id} className="row py-2 border-bottom row-striped" onClick={(e) => showPersonInfo(e, person )}>
							<PersonItem personData={person} />
						</div>

					))
				}

			</div >
		</div >

	)

}

export default PersonList;