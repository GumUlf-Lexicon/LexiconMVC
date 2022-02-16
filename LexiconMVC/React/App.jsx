import React, { useState, useEffect } from 'react';
import PersonList from './PersonList';
import PersonInfo from './PersonInfo';
import PersonAdd from './PersonAdd';

function App(props) {

	// To keep track of what should we show to the user at the moment
	const [personSubPage, setPersonSubPage] = useState();

	// Detailed information about a person
	const showPersonInfo = (personId) =>
		setPersonSubPage(<PersonInfo personId={personId} showPersonList={showPersonList} />);

	// Add a new person to the list
	const addPerson = () =>
		setPersonSubPage(<PersonAdd showPersonList={showPersonList} />);

	// Show a simple list of the persons
	const showPersonList = () =>
		setPersonSubPage(<PersonList showPersonInfo={showPersonInfo} addPerson={addPerson} />);

	// To select the startup view with the person list
	useEffect(() => { showPersonList() }, []);

	return (
		<div className="row">
			<div className="col-xl-2 col-lg-1"></div>
			<div className="col-xl-8 col-lg-10">
				<h1 className="text-center">Person Index</h1>
				{personSubPage}
			</div>
			<div className="col-xl-2 col-lg-1"></div>
		</div>
	);
}

export default App;