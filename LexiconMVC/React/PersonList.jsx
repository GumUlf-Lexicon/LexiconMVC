import React, { useState, useEffect } from 'react';
import axios from 'axios';
import PersonItem from './PersonItem';

function PersonList(props) {

	const [isLoading, setIsLoading] = useState(true);
	const [hasLoadingFailed, setHasLoadingFailed] = useState(false);
	const [personList, setPersonList] = useState([]);

	function showPersonInfo(e, personId) {
		e.preventDefault();
		props.showInfo(personId);
	};

	useEffect(() => {
		let mounted = true;
		const getPersons = async () => {
			try {
				const persons = await axios.get("/Person/GetPersons");
				if (mounted) {
					setPersonList(persons.data);
					setIsLoading(false);
				}
			} catch (err) {
				console.error(err);
			}
		}

		getPersons();

		return () => { mounted = false; };

	}, [])

	if (isLoading) {
		return (
			<div className="text-center">
				<div className="spinner-border"></div>
			</div>
		)
	}

	return (
		<div>
			<div id="personList" className="row pt-2 border-bottom ">
				<div className="col-6 fw-bold">Name</div>
				<div className="col-6 fw-bold">Location</div>
			</div>
			{
				personList.map(person => (
					<div key={person.personId} className="row py-2 border-bottom row-striped" onClick={(e) => showPersonInfo(e, person.personId)}>
						<PersonItem personData={person} />
					</div>

				))
			}
		</div >

	)

}

export default PersonList;