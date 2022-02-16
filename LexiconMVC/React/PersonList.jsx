import React, { useState, useEffect } from 'react';
import axios from 'axios';
import PersonItem from './PersonItem';
import BottomButton from './BottomButton';

function PersonList(props) {

	let mounted = true;

	useEffect(() => {
		mounted = true;

		return (() => mounted = false)

	}, [])


	// Loading stats used for display the right information
	const [isLoading, setIsLoading] = useState(true);
	const [hasLoadingFailed, setHasLoadingFailed] = useState(false);

	// Enable reload from server
	const [loadingTryNumber, setLoadingTryNumber] = useState(0);

	// List of persons (loaded from server)
	const [personList, setPersonList] = useState([]);

	// Track sortingorder of list
	const [sortNameOrder, setSortNameOrder] = useState('ascending');

	// Load data from server
	useEffect(() => {
		setIsLoading(true);
		const getPersons = async () => {
			try {
				const response = await axios.get("/Person/GetPersons");
				if (mounted) {
					if (response.data == null) {
						setPersonList([])
					} else {
						const persons = response.data;
						sortNameOrder == 'ascending' ? persons.sort(comparePersons) : persons.sort(comparePersons).reverse();
						setPersonList(persons);
					}
					setHasLoadingFailed(false);
					setIsLoading(false);
				}
			} catch (err) {
				setHasLoadingFailed(true);
				setIsLoading(false);
			}
		}

		getPersons();
	}, [loadingTryNumber])

	// Trigger reload from server
	const handleRetryClick = () => {
		setLoadingTryNumber(loadingTryNumber + 1);
	}

	// Used for sorting list
	const comparePersons = (person1, person2) => {
		const name1 = person1.name.toLowerCase();
		const name2 = person2.name.toLowerCase();

		if (name1 < name2) return -1;
		if (name1 > name2) return 1;
		return 0;
	}


	const handleDeleteClick = async (event, personId) => {
		event.preventDefault();
		event.stopPropagation();
		props.handleDeleteClick(event, personId);
		handleRetryClick();
	}

	const handleInfoClick = (event, personId) => {
		event.preventDefault();
		event.stopPropagation();
		props.showPersonInfo(personId);
	}

	const handleSortClick = (event) => {
		let list = [];
		switch (event.target.attributes.name.nodeValue) {
			case 'nameAscending':
				list = personList;
				setPersonList(list.sort(comparePersons));
				setSortNameOrder('ascending');
				break;
			case 'nameDecending':
				list = personList;
				setPersonList(list.sort(comparePersons).reverse());
				setSortNameOrder('decending');
				break;
			default:
		}
	}


	/*    RENDERINGS BELOW    */

	if (isLoading) {

		return (
			<div className="text-center">
				<div className="spinner-border"></div>
			</div>
		);

	} else if (hasLoadingFailed) {

		return (
			<div className="text-center">
				Loading has failed!
				<BottomButton handleOnClick={handleRetryClick} textValue="Retry!" />
			</div>
		);

		// There are no persons to show
	} else if (personList.length == 0) {
		return (
			<div className="text-center">
				Could not find any persons
				<BottomButton handleOnClick={handleRetryClick} textValue="Retry getting list of persons" />
			</div>
		);
	}

	return (
		<React.Fragment>
			<div id="personList" className="row border-bottom ">
				<div className="row mx-3 mb-1">
					<span className="col-md-5 col-4 fw-bold">
						Name
						<i name="nameAscending"
							className={`bi bi-caret-up-square${sortNameOrder == 'ascending' ? "-fill" : ""} ms-2`}
							onClick={(event) => handleSortClick(event)}></i>
						<i name="nameDecending"
							className={`bi bi-caret-down-square${sortNameOrder == 'decending' ? "-fill" : ""} ms-1`}
							onClick={(event) => handleSortClick(event)}></i>
					</span>
					<span className="col-md-5 col-5 fw-bold">Location</span>
					<span className="col-md-2 col-3"></span>
				</div>
			</div>

			{
				personList.map(person => (
					<div key={person.personId} className="row py-2 border-bottom row-striped"
						onClick={(event) => handleInfoClick(event, person.personId)}>
						<PersonItem personData={person} handleInfoClick={handleInfoClick} handleDeleteClick={handleDeleteClick} />
					</div>

				))
			}

			<BottomButton handleOnClick={props.addPerson} textValue="Add person" />

		</React.Fragment>
	);

}

export default PersonList;